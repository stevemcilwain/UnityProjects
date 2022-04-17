using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    [SerializeField] private float _speed = 5f;
    [SerializeField] private SpriteRenderer _renderer;

    private Animator _animator;
    private Rigidbody _body;

    private Vector3 _direction = Vector3.zero;
    private Vector3 _velocity = Vector3.zero;

    private void Awake()
    {
        _body = GetComponent<Rigidbody>();
        _animator = GetComponent<Animator>();
        _renderer.shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.On;
        _renderer.receiveShadows = true;
    }

    private void Update()
    {
        _direction.x = Input.GetAxis("Horizontal");
        _direction.z = Input.GetAxis("Vertical");
        _direction.Normalize();
        _velocity = _direction * _speed;

        switch (_direction)
        {
            case Vector3 v when v.Equals(Vector3.zero):     //idle
                _animator.SetBool("idle", true);
                break;
            case Vector3 v when v.Equals(Vector3.back):     //moving south
                _animator.SetBool("idle", false);
                break;
            case Vector3 v when v.Equals(Vector3.right):    //moving east
                _animator.SetBool("idle", false);
                break;
            case Vector3 v when v.Equals(Vector3.left):     //moving west
                _animator.SetBool("idle", false);
                break;
            case Vector3 v when v.Equals(Vector3.forward):  //moving north
                _animator.SetBool("idle", false);
                break;

        }

    }

    private void FixedUpdate()
    {
        _body.AddForce(_velocity, ForceMode.Force);
    }


}
