using System;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class BarsSaver : MonoBehaviour
{
    [Inject] private SaveQuit _saveQuit;
    [Inject] private DataStorage _dataStorage;
    private List<BarData> _barsData = new();
    public List<BarData> BarsData { get { return _barsData; } }
    public event Action OnDataSave;
    private void OnEnable()
    {
        _saveQuit.OnGameQuit += Save;
    }
    private void OnDisable()
    {
        _saveQuit.OnGameQuit -= Save;
    }
    public void AddData(BarData data)
    {
        _barsData.Add(data);
    }
    private void Save()
    {
        _barsData.Clear();
        OnDataSave?.Invoke();
        BarsListData item = new();
        _barsData.ForEach(data => item.Data.Add(data));
        _dataStorage.SaveInfo(item, "BarsData");
    }
}
