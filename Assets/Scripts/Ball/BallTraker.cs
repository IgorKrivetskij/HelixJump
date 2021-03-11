using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallTraker : MonoBehaviour
{
    [SerializeField] private Vector3 _cameraOffset;
    [SerializeField] private float _length;
    private Ball _ball;
    private Vector3 _cameraPosition;
    private float _minimumBallYPosition;

    private void Start()
    {
        _ball = FindObjectOfType<Ball>();
        _minimumBallYPosition = _ball.transform.position.y;
    }

    private void Update()
    {
        if (_minimumBallYPosition > _ball.transform.position.y)
        {
            TrackBall();
            _minimumBallYPosition = _ball.transform.position.y;
        }
    }

    private void TrackBall()
    {
        _cameraPosition = new Vector3(0, _ball.transform.position.y, 0);
        Vector3 cameraDirection = (_cameraPosition - _ball.transform.position).normalized - _cameraOffset;
        _cameraPosition -= cameraDirection * _length;
        transform.position = _cameraPosition;
        transform.LookAt(_ball.transform.position);
    }
}
