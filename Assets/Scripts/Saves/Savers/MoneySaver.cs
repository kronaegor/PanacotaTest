using UnityEngine;
using Zenject;

public class MoneySaver : MonoBehaviour
{
    [Inject] private SaveQuit _saveQuit;
    [Inject] private DataStorage _dataStorage;
    [Inject] private Wallet _wallet;
    private void OnEnable()
    {
        _saveQuit.OnGameQuit += Save;
        _dataStorage.OnGameLoading += Load;
    }
    private void OnDisable()
    {
        _saveQuit.OnGameQuit -= Save;
        _dataStorage.OnGameLoading -= Load;
    }
    private void Save()
    {
        MoneyData item = new()
        {
            Money = _wallet.Money
        };
        _dataStorage.SaveInfo(item, "wallet");
    }
    private void Load()
    {
        _wallet.Money = _dataStorage.LoadInormathion<MoneyData>("wallet").Money;
    }
}
