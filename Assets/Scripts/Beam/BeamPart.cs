using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeamPart : MonoBehaviour
{
    [SerializeField] private Transform _upPosition;
    [SerializeField] private Transform _downPosition;
    [SerializeField] private int _platformCount;
    public Transform UpPosition => _upPosition;
    public Transform DownPosition => _downPosition;

    public void CheckPlatformSegmentsCount()
    {
        if (--_platformCount == 0)
        {
            GetComponentInParent<BeamBuilder>().BuildAndDestroyBeamParts();
        }
    }
}
