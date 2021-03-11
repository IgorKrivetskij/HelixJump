using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlatformSegment : MonoBehaviour
{    
    private Rigidbody _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    public void Bounce(float Force, Vector3 center, float radius)
    {
        _rigidbody.isKinematic = false;
        _rigidbody.AddExplosionForce(Force, center, radius);
    }
}
