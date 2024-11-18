using UnityEngine;
using Zenject;

public class BarDataSaver : MonoBehaviour
{
    [Inject] private BarsSaver _saver;
    [SerializeField] private BarLevel _level;
    [SerializeField] private BarTimer _timer;
    [SerializeField] private BarUpgrader _upgrader;
    [SerializeField] private BarMoneyFolder _moneyFolder;
    private void OnEnable()
    {
        _saver.OnDataSave += Save;
    }   
    private void OnDisable()
    {
        _saver.OnDataSave -= Save;
    }
    private void Save()
    {
        BarData data = new()
        {
            Level = _level.Level,
            Money = _moneyFolder.Money,
            MaxAmount = _moneyFolder.MaxAmountOfMoney,
            Timer = _timer.TimeTeEarnCoin,
            UpgradePrice = _upgrader.MoneyToUpgrade,
        };
        _saver.AddData(data);
    }
}
