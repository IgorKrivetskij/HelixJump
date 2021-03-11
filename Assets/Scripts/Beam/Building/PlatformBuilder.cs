using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformBuilder : MonoBehaviour
{
    [SerializeField] private Platform[] _platforms;
    private int _stepPlatformBuilding = 1;
    private Vector3 _spawnPosition;
    private int _platformCount = 2;

    private void Start()
    {
        _spawnPosition = transform.position;
        Build();
    }

    public void Build()
    {
        for (int i = 0; i < _platformCount; i++)
        {
            BuildPlatforms();
        }
    }

    protected  void BuildPlatforms()
    {
        Quaternion platformRotation = Quaternion.Euler(0, Random.Range(0, 360), 0);
        Instantiate(_platforms[Random.Range(0, _platforms.Length)], _spawnPosition, platformRotation, transform);
        ChangeSpawnPosition(ref _spawnPosition);
    }

    protected void ChangeSpawnPosition(ref Vector3 spawnPosition)
    {
        spawnPosition.y -= _stepPlatformBuilding;
    }
}
