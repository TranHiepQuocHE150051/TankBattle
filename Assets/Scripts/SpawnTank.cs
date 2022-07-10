using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnTank : MonoBehaviour
{
    public GameObject StaticEnemy;
    public GameObject PatrollingEnemy;
    public float timer = 10;
    // This script will simply instantiate the Prefab when the game starts.
    void Start()
    {
        // Instantiate at position (0, 0, 0) and zero rotation.
        Instantiate(PatrollingEnemy, new Vector3(-3.91f, 10.53f, 0), Quaternion.identity);
        Instantiate(StaticEnemy, new Vector3(4.75f, -0.22f, 0), Quaternion.identity);
        Instantiate(StaticEnemy, new Vector3(9.3f, -1.42f, 0), Quaternion.identity);
        Instantiate(StaticEnemy, new Vector3(-0.26f, 12.25f, 0), Quaternion.identity);
        Instantiate(StaticEnemy, new Vector3(4.73f, 6.53f, 0), Quaternion.identity);
    }
    private void Update()
    {
        if (timer > 0)
        {
            timer -= Time.deltaTime;
        }else if(timer<0 && GameObject.FindGameObjectsWithTag("PatrollingEnemy").Length <= 10)
        {
            Instantiate(PatrollingEnemy, new Vector3(-3.91f, 10.53f, 0), Quaternion.identity);
            timer += 10;
        }
    }
    public static bool IsDestroyed(GameObject gameObject)
    {
        
        return gameObject == null && !ReferenceEquals(gameObject, null);
    }
}
