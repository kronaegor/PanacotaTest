using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class BarsLoader : MonoBehaviour
{
    [Inject] private DataStorage _dataStorage;
    [SerializeField] private BarsSpawner _spawner;
    private List<BarData> _dataToGet = new();
    private void OnEnable()
    {
        _dataStorage.OnGameLoading += LoadBarsData;
    }
    private void OnDisable()
    {
        _dataStorage.OnGameLoading -= LoadBarsData;
    }
    private void LoadBarsData()
    {
        _dataToGet.Clear();
        _dataStorage.LoadInormathion<BarsListData>("BarsData").Data.ForEach(item => _dataToGet.Add(item));
        _spawner.SpawnBars(_dataToGet);
    }
}
