using UnityEngine;
using System;
public class BarMoneyFolder : MonoBehaviour
{
    private int _money = 0;
    private int _maxAmountOfMoney = 1000;
    public int Money { get { return _money; } set { _money = value; OnBarMoneyChanged?.Invoke(); } }
    public int MaxAmountOfMoney { get => _maxAmountOfMoney; set { _maxAmountOfMoney = value; OnBarMaxAmountChanged?.Invoke(); } }
    public event Action OnBarMoneyChanged;
    public event Action OnBarMaxAmountChanged;
}
