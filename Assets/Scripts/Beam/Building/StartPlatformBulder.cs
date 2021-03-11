using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartPlatformBulder : MonoBehaviour
{
    [SerializeField] private Platform _startPlatform;
    private Vector3 spawnPosition;

    private void Awake()
    {
        spawnPosition = GetComponent<BeamPart>().DownPosition.position;
        Build();
    }

    public  void Build()
    {
        BuildStartPlatform();
    }

    private void BuildStartPlatform()
    {
        Instantiate(_startPlatform, spawnPosition, Quaternion.identity, transform);
    }
}
