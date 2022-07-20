using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverScript : MonoBehaviour
{
    public GameObject mapEditor;
    public GameObject levelPanel;
    public GameObject Maincamera;
    public void NextLevel()
    {
        SpawnTank spawnTank = Maincamera.GetComponent<SpawnTank>();
        spawnTank.level += 1;
        spawnTank.SpawnTurret(spawnTank.level);
        spawnTank.SpawnBase(spawnTank.level);
        Time.timeScale = 1;
        TilemapManager tilemapManager = mapEditor.GetComponent<TilemapManager>();
        tilemapManager.setLevel(spawnTank.level+1);
        tilemapManager.LoadMap();
    }
    public void ReloadGame()
    {
        Scene sceneLoaded = SceneManager.GetActiveScene();
        SceneManager.LoadScene(sceneLoaded.buildIndex);
        Time.timeScale = 1;
    }
    public void MainMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }
}
