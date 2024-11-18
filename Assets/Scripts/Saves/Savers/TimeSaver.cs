using System;
using UnityEngine;
using Zenject;

public class TimeSaver : MonoBehaviour
{
    [Inject] private DataStorage _dataStorage;
    [Inject] private SaveQuit _saveQuit;
    private void OnEnable()
    {
        _saveQuit.OnGameQuit += Save;
    }
    private void OnDisable()
    {
        _saveQuit.OnGameQuit -= Save;
    }
    private void Save()
    {
        TimeData data = new()
        {
            Time = TimeSpan.FromTicks(DateTime.Now.Ticks).TotalSeconds,
        };
        _dataStorage.SaveInfo(data, "Time");
    }
}
