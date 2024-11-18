using System;
using UnityEngine;
using UnityEngine.UI;
using Zenject;
public class BarUpgrader : MonoBehaviour
{
    [Inject] private Wallet _money;
    [SerializeField] Button _upgradeButton;
    private BarTimer _timer;
    private BarLevel _level;
    private BarMoneyFolder _moneyFolder;
    private int _moneyToUpgrade = 50;
    private float _earnUpgradePercent = 0.95f;
    private float _amountUpgradePercent = 1.05f;
    private float _priceToUpgradePercent = 1.1f;
    public int MoneyToUpgrade { get => _moneyToUpgrade; set => _moneyToUpgrade = value; }
    public event Action OnBarUpgraded;
    private void OnEnable()
    {
        _upgradeButton.onClick.AddListener(UpgradeBar);
    }
    private void OnDisable()
    {
        _upgradeButton.onClick.RemoveListener(UpgradeBar);
    }
    private void Awake()
    {
        _timer = transform.parent.GetComponent<Bar>().Timer;
        _level = transform.parent.GetComponent<Bar>().Level;
        _moneyFolder = transform.parent.GetComponent<Bar>().MoneyFolder;
    }
    private void UpgradeBar()
    {
        if (_moneyToUpgrade > _money.Money)
            return;
        _money.Money -= _moneyToUpgrade;
        UpgradeMoneyAmount();
        UpgradeLevel();
        UpgradeEarnTime();
        UpdateUpgradePrice();
        OnBarUpgraded?.Invoke();
    }
    private void UpdateUpgradePrice()
    {
        _moneyToUpgrade = (int)Math.Round(_moneyToUpgrade * _priceToUpgradePercent, 0);
    }
    private void UpgradeEarnTime()
    {
        _timer.TimeTeEarnCoin *= _earnUpgradePercent;
    }
    private void UpgradeLevel() 
    {
        _level.Level++;
    }
    private void UpgradeMoneyAmount()
    {
        _moneyFolder.MaxAmountOfMoney = (int)Math.Round(_moneyFolder.MaxAmountOfMoney * _amountUpgradePercent, 0);
    }
}
