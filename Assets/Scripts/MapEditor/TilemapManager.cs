using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEditor;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TilemapManager : MonoBehaviour {
    [SerializeField] private Tilemap _groundMap, _detail_top, _obstacles, _crate_Woods, _details_top_small;
    [SerializeField] private int _levelIndex;

    public static TilemapManager tilemapManager { get; set; }
    private void Awake()
    {
        tilemapManager = this;
    }
    public void setLevel(int level)
    {
        _levelIndex = level;
    }
    public void SaveMap() {
        var newLevel = ScriptableObject.CreateInstance<ScriptableLevel>();

        newLevel.LevelIndex = _levelIndex;
        newLevel.name = $"Level {_levelIndex}";

        newLevel.GroundTiles = GetTilesFromMap(_groundMap).ToList();
        newLevel.Detail_TopTiles = GetTilesFromMap(_detail_top).ToList();
        newLevel.ObstaclesTiles = GetTilesFromMap(_obstacles).ToList();
        newLevel.Crate_WoodsTiles = GetTilesFromMap(_crate_Woods).ToList();
        newLevel.Details_top_smallTiles = GetTilesFromMap(_details_top_small).ToList();



        ScriptableObjectUtility.SaveLevelFile(newLevel);

        IEnumerable<SavedTile> GetTilesFromMap(Tilemap map) {
            foreach (var pos in map.cellBounds.allPositionsWithin) {
                if (map.HasTile(pos)) {
                    var levelTile = map.GetTile<LevelTile>(pos);
                    yield return new SavedTile() {
                        Position = pos,
                        Tile = levelTile
                    };
                }
            }
        }
    }

    public void ClearMap() {
       
        var maps = FindObjectsOfType<Tilemap>();

        foreach (var tilemap in maps) {
            tilemap.ClearAllTiles();
        }
    }

    public void LoadMap() {
        Debug.Log("Load Map" + _levelIndex);
        var level = Resources.Load<ScriptableLevel>($"Levels/Level {_levelIndex}");
        if (level == null) {
            Debug.LogError($"Level {_levelIndex} does not exist.");
            return;
        }

        ClearMap();

        foreach (var savedTile in level.GroundTiles) {
            switch (savedTile.Tile.Type) {
                case TileType.tileGrass1:
                case TileType.tileSand1:
                case TileType.tileGrass_transitionCorner_1_0:
                case TileType.tileGrass_transitionCorner_1_1:
                case TileType.tileGrass_transitionCorner_1_2:
                case TileType.tileGrass_transitionCorner_1_3:
                case TileType.tileGrass_transitionCorner_2_0:
                case TileType.tileGrass_transitionCorner_2_1:
                case TileType.tileGrass_transitionCorner_2_2:
                case TileType.tileGrass_transitionCorner_2_3:
                case TileType.tileGrass_transitionE:
                case TileType.tileGrass_transitionN:
                case TileType.tileGrass_transitionS:
                case TileType.tileGrass_transitionW:
                    SetTile(_groundMap, savedTile);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        foreach (var savedTile in level.Detail_TopTiles)
        {
            switch (savedTile.Tile.Type)
            {
                case TileType.treeBrown_large:
                case TileType.treeBrown_small:
                case TileType.treeGreen_large:
                case TileType.treeGreen_small:
                    SetTile(_detail_top, savedTile);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        foreach (var savedTile in level.ObstaclesTiles)
        {
            switch (savedTile.Tile.Type)
            {
                case TileType.barricadeMetal:
                case TileType.barricadeWood:
                case TileType.crateMetal:
                    SetTile(_obstacles, savedTile);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        foreach (var savedTile in level.Crate_WoodsTiles)
        {
            switch (savedTile.Tile.Type)
            {
                case TileType.crateWood:
                    SetTile(_crate_Woods, savedTile);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        foreach (var savedTile in level.Details_top_smallTiles)
        {
            switch (savedTile.Tile.Type)
            {
                case TileType.treeBrown_large:
                case TileType.treeBrown_small:
                case TileType.treeGreen_large:
                case TileType.treeGreen_small:
                    SetTile(_details_top_small, savedTile);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        void SetTile(Tilemap map, SavedTile tile) {
            map.SetTile(tile.Position, tile.Tile);
        }
    }

    
}

#if UNITY_EDITOR

public static class ScriptableObjectUtility {
    public static void SaveLevelFile(ScriptableLevel level) {
        AssetDatabase.CreateAsset(level, $"Assets/Resources/Levels/{level.name}.asset");

        AssetDatabase.SaveAssets();
        AssetDatabase.Refresh();
    }
}

#endif



public struct Level {
    public int LevelIndex;
    public List<SavedTile> GroundTiles;
    public List<SavedTile> UnitTiles;

    public string Serialize() {
        var builder = new StringBuilder();

        builder.Append("g[");
        foreach (var groundTile in GroundTiles) {
            builder.Append($"{(int) groundTile.Tile.Type}({groundTile.Position.x},{groundTile.Position.y})");
        }
        builder.Append("]");

        return builder.ToString();
    }
}