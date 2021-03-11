using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlatformTrigger : MonoBehaviour
{
    public UnityAction DestroyPlatformSegment;

    private void OnTriggerEnter(Collider other)
    {        
        if (other.gameObject.TryGetComponent<Ball>(out Ball ball))
        {
            DestroyPlatformSegment?.Invoke();
            GetComponentInParent<BeamPart>().CheckPlatformSegmentsCount();
            GetComponentInParent<BeamBuilder>().OnPlatformDestroy();
        }
    }
}
