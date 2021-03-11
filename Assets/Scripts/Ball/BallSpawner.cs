using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSpawner : MonoBehaviour
{
    [SerializeField] private Transform _spawnPoint;
    [SerializeField] private Ball _ball;

    private void Awake()
    {
        Instantiate(_ball, _spawnPoint.position, Quaternion.identity);
    }
}
