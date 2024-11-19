using System;
using UnityEngine;
using Zenject;

public class BarCalculathions : MonoBehaviour
{
    [Inject] private DataStorage _dataStorage;
    private double _timeOutOfGame;
    private double _currentTime;
    private double _leaveTimeSeconds;
    private int _moneyToGet;
    public int CalculateMoney(int money, int maxAmountOfMoney, float timeToEarn)
    {
        _currentTime = TimeSpan.FromTicks(DateTime.Now.Ticks).TotalSeconds;
        _leaveTimeSeconds = _dataStorage.LoadInormathion<TimeData>("Time").Time;
        _timeOutOfGame = _currentTime - _leaveTimeSeconds;
        _moneyToGet = money + ((int)_timeOutOfGame / (int)timeToEarn);
        if (_moneyToGet > maxAmountOfMoney)
            _moneyToGet = maxAmountOfMoney;
        return _moneyToGet;
    }
}
