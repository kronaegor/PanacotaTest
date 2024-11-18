using System;
using UnityEngine;

public class BarLevel : MonoBehaviour
{
    private int _level = 1;
    public int Level { get => _level; set { _level = value; OnLevelChanged?.Invoke(); } }
    public event Action OnLevelChanged;
}
