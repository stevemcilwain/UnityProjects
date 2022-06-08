using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float Speed = 10f;

    private Rigidbody _body;
    private Vector3 _direction;


    private void Awake()
    {
        _body = GetComponent<Rigidbody>();
    }


    private void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        _direction = new Vector3(x, transform.position.y, z).normalized;
    }

    private void FixedUpdate()
    {
        _body.velocity = _direction * Speed;
    }
}
