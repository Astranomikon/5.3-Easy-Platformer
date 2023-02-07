using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Rigidbody2D))]

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _jumpForce;

    private const string Speed = "Speed";
    private const string Jump = "Speed";

    private Animator _animator;
    private Rigidbody2D _rigidbody2D;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            _rigidbody2D.AddForce(Vector2.left * _speed);
            _animator.SetFloat(Speed, _speed * -1);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            _rigidbody2D.AddForce(Vector2.right * _speed);
            _animator.SetFloat(Speed, _speed);
        }
        else if (Input.GetKeyDown(KeyCode.Space))
        {
            _rigidbody2D.AddForce(Vector2.up * _jumpForce);
            _animator.SetTrigger(Jump);
        }
        else
        {
            _animator.SetFloat(Speed, 0);
        }

        _rigidbody2D.rotation = 0;
    }
}
