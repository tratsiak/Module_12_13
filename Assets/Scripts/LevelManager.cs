using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    private const string GameWinLabel = "All the coins have been collected, you win!";
    private const string GameOverLabel = "Time is up, you lose!";
    private const string RemainingTimeLabel = "Remaining time: ";

    [SerializeField] private List<Coin> _coinsList;
    [SerializeField] private float _levelTime = 60f;

    [SerializeField] private Ball _ball;

    private float _remainingTime;

    private bool _isGameRunning = true;

    private void Start()
    {
        _remainingTime = _levelTime;
    }

    private void Update()
    {
        if (_isGameRunning)
        {
            if (_remainingTime > 0)
            {
                _remainingTime -= Time.deltaTime;
                Debug.Log(RemainingTimeLabel + Math.Truncate(_remainingTime));

                if (HasActiveCoins() == false)
                    GameWin();
            }
            else
            {
                GameOver();
            }
        }
    }

    private bool HasActiveCoins()
    {
        foreach (Coin coin in _coinsList)
        {
            if (coin.isActiveAndEnabled)
                return true;
        }

        return false;
    }

    private void GameWin()
    {
        _isGameRunning = false;
        _ball.Celebrate();

        Debug.Log(GameWinLabel);
    }
    private void GameOver()
    {
        _isGameRunning = false;
        _ball.Die();

        Debug.Log(GameOverLabel);
    }
}
