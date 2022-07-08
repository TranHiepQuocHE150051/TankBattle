using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnTank : MonoBehaviour
{
    public GameObject myPrefab;
    public GameObject StaticEnemy;
    // This script will simply instantiate the Prefab when the game starts.
    void Start()
    {
        // Instantiate at position (0, 0, 0) and zero rotation.
        Instantiate(myPrefab, new Vector3(7.51f, 4.14f, 0), Quaternion.identity);
        Instantiate(StaticEnemy, new Vector3(4.75f, -0.22f, 0), Quaternion.identity);

    }
    private void Update()
    {
        if (!GameObject.FindWithTag("PatrollingEnemy"))
        {
            Instantiate(myPrefab, new Vector3(7.51f, 4.14f, 0), Quaternion.identity);
        }
    }
    public static bool IsDestroyed(GameObject gameObject)
    {
        
        return gameObject == null && !ReferenceEquals(gameObject, null);
    }
}
