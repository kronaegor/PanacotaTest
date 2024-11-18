using System.Collections.Generic;
using UnityEngine;

public class BarsSpawner : MonoBehaviour
{
    [SerializeField] private GameObject _bar;
    [SerializeField] private RectTransform _parent;
    [SerializeField] private BarCalculathions _calculathions;
    public void SpawnBars(List<BarData> dataList)
    {
        foreach (BarData data in dataList)
        {
            GameObject currentBar = Instantiate(_bar);
            currentBar.transform.SetParent(_parent, false);
            currentBar.transform.SetAsFirstSibling();
            InjectDependencies(currentBar.GetComponent<Bar>(), data);
        }
    }
    private void InjectDependencies(Bar bar, BarData data)
    {
        bar.MoneyFolder.MaxAmountOfMoney = data.MaxAmount;
        bar.Timer.TimeTeEarnCoin = data.Timer;
        bar.Upgrader.MoneyToUpgrade = data.UpgradePrice;
        bar.Level.Level = data.Level;
        bar.MoneyFolder.Money =_calculathions.CalculateMoney(bar.MoneyFolder.Money, bar.MoneyFolder.MaxAmountOfMoney, bar.Timer.TimeTeEarnCoin);
    }
}
