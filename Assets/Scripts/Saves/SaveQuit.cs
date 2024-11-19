using System;
using UnityEngine;

public class SaveQuit : MonoBehaviour
{
    public event Action OnGameQuit;
    private void OnApplicationQuit()
    {
        OnGameQuit?.Invoke();
    }
}
