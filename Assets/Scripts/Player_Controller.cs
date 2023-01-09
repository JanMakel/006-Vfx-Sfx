using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Controller : MonoBehaviour
{
    public float JumpForce = 10f;
    private Rigidbody _rigidbody;
    private bool isOnTheGround = true;

    private void OnCollisionEnter(Collision othercollision)
    {
        isOnTheGround = true;
    }
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        
    }

    
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isOnTheGround)
        {
            isOnTheGround = false;
            _rigidbody.AddForce(Vector3.up * JumpForce, ForceMode.Impulse);
        }
    }
}
