using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeCounter : MonoBehaviour
{
    [SerializeField] private Text _timeText;
    [SerializeField] private Text _timeCount;
    [SerializeField] private GameObject _gameOverPanel;
    [SerializeField] private BeamBuilder _beamBuilder;
    private float _startTime;
    private float _currentTime;
    private float _bonusTime;
    private int _currenFinishPlatformCount;
    private int _allFinishPlatformCount;

    public int AllFinishedPlatformsCount => _allFinishPlatformCount;

    private void Awake()
    {
        _startTime = 15;
        _currentTime = _startTime;
        _timeCount.text = _startTime.ToString();
        _bonusTime = 10f;
        _currenFinishPlatformCount = 0;
        _allFinishPlatformCount = 0;
    }

    private void OnEnable()
    {
        _beamBuilder.GetBonusTime += GetBonusTime;
    }

    private void OnDisable()
    {
        _beamBuilder.GetBonusTime -= GetBonusTime;
    }

    private void Update()
    {
        ChangeTime();
        if (_currentTime <= 0)
        {
            _gameOverPanel.SetActive(true);
        }
    }

    private void ChangeTime()
    {
        _currentTime -= Time.deltaTime;
        _timeCount.text = ((int)_currentTime).ToString();
    }

    public void GetBonusTime()
    {
        _currentTime += _bonusTime;
        _allFinishPlatformCount += 1;
        ReduseBonusTime();
    }

    private void ReduseBonusTime()
    {
        if (++_currenFinishPlatformCount == 10)
        {
            _bonusTime /= 2;
            _currenFinishPlatformCount = 0;
        }
    }
}
