using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class PlayerMoviment : MonoBehaviour
{
    public float speed = 5f;

    private Rigidbody rb;

    private Vector3 moveiment;
    // Start is called before the first frame update
    void Start()
    {

        rb = GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void Update()
    {
        GetInput();

    }

    private void GetInput()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float Vertical = Input.GetAxis("Vertical");

        moveiment = new Vector3(horizontal, 0f, Vertical);

    }


    private void FixedUpdate()
    {
        Move();

    }

    private void Move()

    {
        rb.MovePosition(rb.position + moveiment * speed * Time.deltaTime);
    }
}