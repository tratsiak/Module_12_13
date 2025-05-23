using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    private const string HorizontalInput = "Horizontal";
    private const string VerticalInput = "Vertical";
    private const KeyCode JumpButton = KeyCode.Space;

    [SerializeField] private float _speed;
    [SerializeField] private float _speedLimit;
    [SerializeField] private float _jumpForce;

    [SerializeField] private ParticleSystem _ballDieEffect;
    [SerializeField] private ParticleSystem _celebrateEffect;

    private int _coinsCount;

    private float _xInput;
    private float _yInput;

    private float _deadZone = 0.05f;

    private Rigidbody _rigidbody;

    public int CoinsCount => _coinsCount;

    public bool IsCanJump { get; set; }

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        _xInput = Input.GetAxisRaw(HorizontalInput);
        _yInput = Input.GetAxisRaw(VerticalInput);

        if (Input.GetKeyDown(JumpButton) && IsCanJump)
            _rigidbody.AddForce(Vector3.up * _jumpForce, ForceMode.Impulse);
    }

    private void FixedUpdate()
    {
        if (Mathf.Abs(_xInput) > _deadZone && IsSpeedLimit())
            _rigidbody.AddTorque(Vector3.back * _speed * _xInput);

        if (Mathf.Abs(_yInput) > _deadZone && IsSpeedLimit())
            _rigidbody.AddTorque(Vector3.right * _speed * _yInput);
    }

    private bool IsSpeedLimit()
    {
        return _rigidbody.velocity.magnitude <= _speedLimit;
    }

    public void AddCoin()
    {
        _coinsCount++;
    }

    public void Die()
    {
        _ballDieEffect.transform.position = transform.position;
        _ballDieEffect.Play();

        gameObject.SetActive(false);
    }

    public void Celebrate()
    {
        _celebrateEffect.transform.position = transform.position;
        _celebrateEffect.Play();

        gameObject.SetActive(false);
    }
}
