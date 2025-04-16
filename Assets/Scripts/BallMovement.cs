using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour
{
    private const string HorizontalInput = "Horizontal";
    private const string VerticalInput = "Vertical";

    [SerializeField] private float _speed;

    private float _xInput;
    private float _yInput;

    private float _deadZone = 0.05f;

    private Rigidbody _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        _xInput = Input.GetAxisRaw(HorizontalInput);
        _yInput = Input.GetAxisRaw(VerticalInput);
    }

    private void FixedUpdate()
    {
        if (Mathf.Abs(_xInput) > _deadZone)
            _rigidbody.AddTorque(Vector3.back * _speed * _xInput);

        if (Mathf.Abs(_yInput) > _deadZone)
            _rigidbody.AddTorque(Vector3.right * _speed * _yInput);
    }
}
