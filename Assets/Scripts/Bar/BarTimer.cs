using System;
using System.Collections;
using UnityEngine;

public class BarTimer : MonoBehaviour
{
    private float _timeToEarnCoin = 5;
    public float TimeTeEarnCoin { get => _timeToEarnCoin; set { _timeToEarnCoin = value; } }
    public event Action OnTimerEnd;
    private void Start()
    {
        StartCoroutine(TimerEnd());
    }
    private IEnumerator TimerEnd()
    {
        yield return new WaitForSeconds(_timeToEarnCoin);
        OnTimerEnd?.Invoke();
        StartCoroutine(TimerEnd());
    }
}
