using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject[] enemies; 

    private float[] arrPosX = {-2.2f, -1.1f, 0f, 1.1f, 2.2f};
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void SpawnEnemy(float posX, int index) {
        Vector3 spawnPos = new Vector3(posX, transform.position.y, transform.position.z); 
    }

}
