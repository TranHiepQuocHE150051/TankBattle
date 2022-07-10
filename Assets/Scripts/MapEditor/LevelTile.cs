using System;
using UnityEngine;
using UnityEngine.Tilemaps;

[CreateAssetMenu(fileName = "New Level Tile", menuName = "2D/Tiles/Level Tile")]
public class LevelTile : Tile
{
    public TileType Type;

}

[Serializable]
public enum TileType
{
    // Ground
    tileGrass1 = 1,
    tileSand1 = 2,
    tileGrass_transitionCorner_1_0 = 3,
    tileGrass_transitionCorner_1_1 = 4,
    tileGrass_transitionCorner_1_2 = 5,
    tileGrass_transitionCorner_1_3 = 6,
    tileGrass_transitionCorner_2_0 = 7,
    tileGrass_transitionCorner_2_1 = 8,
    tileGrass_transitionCorner_2_2 = 9,
    tileGrass_transitionCorner_2_3 = 10,
    tileGrass_transitionE = 11,
    tileGrass_transitionN = 12,
    tileGrass_transitionS = 13,
    tileGrass_transitionW = 14,


    // Obstacles 
    barricadeMetal = 1000,
    barricadeWood = 1001,
    crateMetal = 1002,
    crateWood = 1003,
    fenceRed = 1004,

    //Detail
    treeGreen_small = 2000,
    treeGreen_large = 2001,
    treeBrown_small = 2002,
    treeBrown_large = 2003,
}
