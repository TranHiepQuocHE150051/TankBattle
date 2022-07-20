using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SelectLevel : MonoBehaviour
{
    public GameObject mapEditor;
    public GameObject levelPanel;
    public GameObject Maincamera;
    public void Level1()
    {       
        SpawnTank spawnTank = Maincamera.GetComponent<SpawnTank>();
        spawnTank.SpawnTurret(1);
        spawnTank.SpawnBase(1);
        spawnTank.level = 1;
        Time.timeScale = 1;
        levelPanel.SetActive(false);
        TilemapManager tilemapManager = mapEditor.GetComponent<TilemapManager>();
        tilemapManager.setLevel(1);
        tilemapManager.LoadMap();
    }
    public void Level2()
    {
        SpawnTank spawnTank = Maincamera.GetComponent<SpawnTank>();
        spawnTank.SpawnTurret(2);
        spawnTank.SpawnBase(2);
        spawnTank.level = 2;
        Time.timeScale = 1;
        levelPanel.SetActive(false);
        TilemapManager tilemapManager = mapEditor.GetComponent<TilemapManager>();
        tilemapManager.setLevel(3);
        tilemapManager.LoadMap();
    }
    public void Level3()
    {
        SpawnTank spawnTank = Maincamera.GetComponent<SpawnTank>();
        spawnTank.SpawnTurret(3);
        spawnTank.SpawnBase(3);
        spawnTank.level = 3;
        Time.timeScale = 1;
        levelPanel.SetActive(false);
        TilemapManager tilemapManager = mapEditor.GetComponent<TilemapManager>();
        tilemapManager.setLevel(4);
        tilemapManager.LoadMap();
    }
    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }
}
