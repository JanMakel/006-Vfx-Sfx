using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn_Manager : MonoBehaviour
{
    public GameObject[] obstaclePrefab;
    private float startDelay = 2f;
    private float repeatRate = 2f;
    private Player_Controller playerControllerScript;
    public int obstacleNum;
   
    private void SpawnObstacle()
    {
        obstacleNum = Random.Range(0, obstaclePrefab.Length);
        Instantiate(obstaclePrefab[obstacleNum], transform.position, obstaclePrefab[obstacleNum].transform.rotation);
    }

    
    private void Start()
    {
        playerControllerScript = FindObjectOfType<Player_Controller>();
        InvokeRepeating("SpawnObstacle", startDelay, repeatRate);
    }

    private void Update()
    {
        if (playerControllerScript.gameOver)
        {

            CancelInvoke("SpawnObstacle");
            
        }

        
    }
    
}
