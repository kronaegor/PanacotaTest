using System;
using UnityEngine;

public class SaveQuit : MonoBehaviour
{
    public event Action OnGameQuit;
    private void OnApplicationPause(bool pause)
    {
        OnGameQuit?.Invoke();
    }
    private void OnApplicationQuit()
    {
        OnGameQuit?.Invoke();
    }
}
