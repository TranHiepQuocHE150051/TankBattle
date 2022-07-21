using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject player;
    public SaveSystem saveSystem;
    public GameObject Instructions;
    private void Awake()
    {
        SceneManager.sceneLoaded += Initialize;
        DontDestroyOnLoad(gameObject);
    }

    private void Initialize(Scene scene, LoadSceneMode sceneMode)
    {
        Debug.Log("Loaded GM");
        var playerInput = FindObjectOfType<PlayerInput>();
        if (playerInput != null)
            player = playerInput.gameObject;
        saveSystem = FindObjectOfType<SaveSystem>();
        if (player != null && saveSystem.LoadedData != null)
        {
            var damagable = player.GetComponentInChildren<Damagable>();
            damagable.Health = saveSystem.LoadedData.playerHealth;
        }
    }

    public void LoadLeve()
    {
        if (saveSystem.LoadedData != null)
        {
            SceneManager.LoadScene(saveSystem.LoadedData.sceneIndex);
            return;
        }
        LoadNextLevel();
    }    
    public void LoadNextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void LoadLevel1()
    {
        SceneManager.LoadScene(1);
        Time.timeScale = 0;
    }
    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }
    public void SelectLevel()
    {
        SceneManager.LoadScene(1);
    }
    public void LoadInstruction()
    {
        Instructions.SetActive(true);
    }
    public void BackToMenu()
    {
        Instructions.SetActive(false);
    }
    public void ExitGame()
    {
        Application.Quit();
    }
    public void SaveData()
    {
        if (player != null)
            saveSystem.SaveData(SceneManager.GetActiveScene().buildIndex + 1, player.GetComponentInChildren<Damagable>().Health);
    }
}
