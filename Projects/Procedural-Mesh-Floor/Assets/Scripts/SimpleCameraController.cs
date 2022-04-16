using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleCameraController : MonoBehaviour
{

    [SerializeField] private int speed = 5;
    private Camera _camera;
    private Vector3 _direction;


    private void Awake()
    {
        _camera = GetComponent<Camera>();
    }


    void Update()
    {
        _direction.x = Input.GetAxis("Horizontal");
        _direction.z = Input.GetAxis("Vertical");
        _direction.Normalize();

        transform.Translate(_direction * speed * Time.deltaTime);
    }
}
