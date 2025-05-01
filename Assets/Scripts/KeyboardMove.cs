using System;
using UnityEngine;

[RequireComponent(typeof(BoxGroundChecker))]
[RequireComponent(typeof(Rigidbody2D))]
public class KeyboardMove : MonoBehaviour
{
    [SerializeField] private float _speed = 100;
    [SerializeField] private float _jumpForce = 10;
    [SerializeField] private float _cooldownSeconds = .2f;

    private BoxGroundChecker _groundChecker;
    private Rigidbody2D _rigidbody;
    private Cooldown _cooldown;

    private bool _isGround;

    private void Awake()
    {
        _groundChecker = GetComponent<BoxGroundChecker>();
        _rigidbody = GetComponent<Rigidbody2D>();
        _cooldown = new Cooldown(_cooldownSeconds);
    }

    private void Update()
    {
        const string Horizontal = "Horizontal";

        Vector3 velocity = _rigidbody.linearVelocity;
        velocity.x = Input.GetAxisRaw(Horizontal) * _speed;
        _rigidbody.linearVelocity = velocity;

        // Vector3 target = transform.position + Vector3.right * Input.GetAxisRaw(Horizontal);
        // transform.position = Vector3.MoveTowards(transform.position, target, _speed * Time.deltaTime);

        Jump();
    }

    private void Jump()
    {
        const string Jump = "Jump";

        if (Input.GetAxisRaw(Jump) == 0)
            return;

        if (_groundChecker.IsGrounded() == false)
            return;

        if (_cooldown.IsFree == false)
            return;

        StartCoroutine(_cooldown.Accuse());

        _rigidbody.AddForce(Vector3.up * _jumpForce, ForceMode2D.Impulse);
    }
}