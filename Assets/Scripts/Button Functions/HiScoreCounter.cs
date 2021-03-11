﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HiScoreCounter : MonoBehaviour
{
    [SerializeField] private TimeCounter _timeCounter;
    [SerializeField] private Text _playerScore;
    [SerializeField] private Text _recordScore;

    private void OnEnable()
    {
        ShowScore();
    }

    private void OnDisable()
    {
        Time.timeScale = 1;
    }

    private void ShowScore()
    {
        Time.timeScale = 0;
        _playerScore.text = _timeCounter.AllFinishedPlatformsCount.ToString();
        if (_timeCounter.AllFinishedPlatformsCount >= PlayerPrefs.GetInt("Score"))
        {
            _recordScore.text = _timeCounter.AllFinishedPlatformsCount.ToString();
        }
        else
        {
            _recordScore.text = PlayerPrefs.GetInt("Score").ToString();
        }
    }
}
