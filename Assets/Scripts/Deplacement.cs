using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deplacement : MonoBehaviour
{

    public float speed = 1;

    // Start is called before the first frame update
    void Start()
    {
        Rigidbody2D cube = GetComponent<Rigidbody2D>();
        Debug.Log(cube);
        cube.gravityScale = speed;
    }

    // Update is called once per frame
    void Update()
    {
       
    }
}
