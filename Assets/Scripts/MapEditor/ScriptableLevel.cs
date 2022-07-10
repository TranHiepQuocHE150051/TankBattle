using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ScriptableLevel : ScriptableObject {
    public int LevelIndex;
    public List<SavedTile> GroundTiles;
    public List<SavedTile> Detail_TopTiles;
    public List<SavedTile> ObstaclesTiles;
    public List<SavedTile> Crate_WoodsTiles;
    public List<SavedTile> Details_top_smallTiles;
}

[Serializable]
public class SavedTile {
    public Vector3Int Position;
    public LevelTile Tile;
}