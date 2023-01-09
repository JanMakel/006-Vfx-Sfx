using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move_Left : MonoBehaviour
{
    public float speed = 30f;

    private void Update()
    {
        transform.Translate(Vector3.left * Time.deltaTime * speed);
    }
}