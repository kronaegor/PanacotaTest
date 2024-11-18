using UnityEngine;
using Zenject;

public class BarsListSaverInstaler : MonoInstaller
{
    [SerializeField] private BarsSaver _saver;
    public override void InstallBindings()
    {
        Container.Bind<BarsSaver>().FromInstance(_saver).AsSingle();
    }
}
