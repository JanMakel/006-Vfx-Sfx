using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move_Left : MonoBehaviour
{
    public float speed = 30f;
    private Player_Controller playerControllerScript;
    public float leftBound;

    private void Start()
    {
        playerControllerScript = FindObjectOfType<Player_Controller>();
    }
    private void Update()
    {
        if (!playerControllerScript.gameOver)
        {
            transform.Translate(Vector3.left * Time.deltaTime * speed, Space.World);
        }

        if (transform.position.x < leftBound && gameObject.CompareTag("obstacle"))
        {
            Destroy(gameObject);
        }
        
    }
}
