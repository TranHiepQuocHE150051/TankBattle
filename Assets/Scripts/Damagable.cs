using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class Damagable : MonoBehaviour
{
    public int MaxHealth = 100;
    
    [SerializeField]
    private int health = 0;
    public GameObject GameOverMenu;
    public GameObject LevelCompleteMenu;
    public int Health
    {
        get { return health; }
        set
        {
            health = value;
            OnHealthChange?.Invoke((float)Health / MaxHealth);
        }
    }


    public UnityEvent OnDead;
    public UnityEvent<float> OnHealthChange;
    public UnityEvent OnHit, OnHeal;


    private void Start()
    {
        if(health == 0)
            Health = MaxHealth;
    }

    internal void Hit(int damagePoints)
    {
        Health -= damagePoints;
        if (Health <= 0)
        {
            OnDead?.Invoke();           
        }
        else
        {
            OnHit?.Invoke();
        }
    }
    public void GameOver()
    {       
        GameOverMenu.SetActive(true);
        Time.timeScale = 0;       
    }   
    public void LevelComplete()
    {
        LevelCompleteMenu.SetActive(true);
        Time.timeScale = 0;
    }
    public void Heal(int healthBoost)
    {
        Health += healthBoost;
        Health = Mathf.Clamp(Health, 0, MaxHealth);
        OnHeal?.Invoke();
    }
}
