using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Platform : MonoBehaviour
{
    [SerializeField] private float _explowsionForce;
    [SerializeField] private float _radius;
    [SerializeField] private PlatformTrigger _platformTrigger;

    private void OnEnable()
    {
        _platformTrigger.DestroyPlatformSegment += Breake;
    }

    private void OnDisable()
    {
        _platformTrigger.DestroyPlatformSegment -= Breake;
    }

    public void Breake()
    {        
        PlatformSegment[] platformSegments = GetComponentsInChildren<PlatformSegment>();

        foreach(PlatformSegment platformSegment in platformSegments)
        {            
            platformSegment.Bounce(_explowsionForce, transform.position, _radius);
            Destroy(gameObject, 0.5f);
        }       
    }   
}
