using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class BallJumper : MonoBehaviour
{
    private Rigidbody _rigidbody;
    private float _jumpForce;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _jumpForce = 2.5f;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent<PlatformSegment>(out PlatformSegment platformSegment))
        {
            _rigidbody.velocity = Vector3.zero;
            _rigidbody.AddForce(_jumpForce * Vector3.up, ForceMode.VelocityChange);
        }
    }
}
