using System;
using UnityEngine;
[CreateAssetMenu(fileName = "Wallet")]
public class Wallet : ScriptableObject
{
    [SerializeField] private int _money;
    public int Money { get { return _money; } set { _money = value; OnMoneyChanged?.Invoke(); } }
    public event Action OnMoneyChanged;
}
