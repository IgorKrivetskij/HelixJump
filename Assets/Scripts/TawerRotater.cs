using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class TawerRotater : MonoBehaviour
{
    private Rigidbody _rigidbody;
    private float _rotateSpeed;

    private void Start()
    {
        _rotateSpeed = 5f;
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if(Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Moved)
            {
                float torque = touch.deltaPosition.x * _rotateSpeed * Time.deltaTime;
                _rigidbody.AddTorque(Vector3.up * torque);
            }
        }              
    }
}
