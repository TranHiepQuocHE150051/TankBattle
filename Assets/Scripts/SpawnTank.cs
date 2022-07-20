using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnTank : MonoBehaviour
{
    public GameObject StaticEnemy;
    public GameObject PatrollingEnemy;
    public GameObject AlliedBase;
    public GameObject EnemyBase;
    public GameObject FastEnemy;
    public GameObject TankyEnemy;
    public GameObject BigTurret;
    public GameObject SpeedEnemy;
    public GameObject Boss;
    public int level;
    public float timer = 10;
    
    private int count = 0;
    // This script will simply instantiate the Prefab when the game starts.
    void Start()
    {

        

    }
    public void SpawnTurret(int level)
    {
        switch (level)
        {
            case 1:
                Instantiate(PatrollingEnemy, new Vector3(-3.91f, 10.53f, 0), Quaternion.identity);
                Instantiate(StaticEnemy, new Vector3(4.75f, -0.22f, 0), Quaternion.identity);
                Instantiate(StaticEnemy, new Vector3(9.3f, -1.42f, 0), Quaternion.identity);
                Instantiate(StaticEnemy, new Vector3(-0.26f, 12.25f, 0), Quaternion.identity);
                Instantiate(StaticEnemy, new Vector3(4.73f, 6.53f, 0), Quaternion.identity);
                break;
            case 2:
                Instantiate(StaticEnemy, new Vector3(-1.8f, 9.96f, 0), Quaternion.identity);
                Instantiate(StaticEnemy, new Vector3(2.87f, 9.96f, 0), Quaternion.identity);
                Instantiate(StaticEnemy, new Vector3(-6.06f, 6.69f, 0), Quaternion.identity);
                Instantiate(StaticEnemy, new Vector3(6.2f, 5.83f, 0), Quaternion.identity);
                Instantiate(StaticEnemy, new Vector3(6.09f, 0.9f, 0), Quaternion.identity);
                Instantiate(StaticEnemy, new Vector3(-6.41f, 1.36f, 0), Quaternion.identity);               
                break;
            case 3:
                Instantiate(StaticEnemy, new Vector3(10.19f, -0.59f, 0), Quaternion.identity);
                Instantiate(StaticEnemy, new Vector3(-7.17f, 5.99f, 0), Quaternion.identity);
                Instantiate(StaticEnemy, new Vector3(-0.19f, 9.28f, 0), Quaternion.identity);
                Instantiate(StaticEnemy, new Vector3(6.46f, 5.93f, 0), Quaternion.identity);
                Instantiate(StaticEnemy, new Vector3(5.75f, 0.15f, 0), Quaternion.identity);
                Instantiate(StaticEnemy, new Vector3(7.49f, -4.24f, 0), Quaternion.identity);
                Instantiate(BigTurret, new Vector3(3.29f, 9.38f, 0), Quaternion.identity);
                Instantiate(BigTurret, new Vector3(9.94f, 11.27f, 0), Quaternion.identity);
                break;
        }
    }
    public void SpawnBase(int level)
    {
        
        switch (level)
        {
            case 1:               
                AlliedBase.transform.position = new Vector3(-4.45f, -2.5f, 0);
                EnemyBase.transform.position = new Vector3(-6.6f, 12.66f, 0);
                break;
            case 2:
               
                    AlliedBase.transform.position = new Vector3(0.5f, -2.97f, 0);
                    EnemyBase.transform.position = new Vector3(0.57f, 12.36f, 0);
                             
                break;
            case 3:
                
                AlliedBase.transform.position = new Vector3(-4.84f, -2.03f, 0);
                EnemyBase.transform.position = new Vector3(-4.79f, 12.12f, 0);
                break;
        }
    }
    private void Update()
    {
        switch (level) {
            case 1:
                if (timer > 0)
                {
                    timer -= Time.deltaTime;
                }
                else if (timer < 0 && GameObject.FindGameObjectsWithTag("PatrollingEnemy").Length <= 10)
                {
                    Instantiate(PatrollingEnemy, new Vector3(-3.91f, 10.53f, 0), Quaternion.identity);
                    timer += 10;
                }
                break;
            case 2:
                if (timer > 0)
                {
                    timer -= Time.deltaTime;
                }
                else if (timer < 0 && GameObject.FindGameObjectsWithTag("PatrollingEnemy").Length <= 10)
                {
                    Instantiate(FastEnemy, new Vector3(-3.74f, 12.62f, 0), Quaternion.identity);
                    Instantiate(TankyEnemy, new Vector3(4.74f, 12.71f, 0), Quaternion.identity);
                    timer += 10;
                }

                break;
            case 3:
                
                if (timer > 0)
                {
                    timer -= Time.deltaTime;
                }
                else if (timer < 0 && count<5)
                {
                    Instantiate(SpeedEnemy, new Vector3(-2.3f, 12.02f, 0), Quaternion.identity);                  
                    timer += 10;
                    count++;
                }else if(timer<0 && count >= 5)
                {
                    Instantiate(Boss, new Vector3(-2.14f, 11.97f, 0), Quaternion.identity);
                    timer =0;                    
                }
                break;
        }
        
    }
    public static bool IsDestroyed(GameObject gameObject)
    {
        
        return gameObject == null && !ReferenceEquals(gameObject, null);
    }
}
