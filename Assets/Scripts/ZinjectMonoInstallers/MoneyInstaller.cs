using UnityEngine;
using Zenject;

public class MoneyInstaller : MonoInstaller
{
    [SerializeField] private Wallet _money;
    public override void InstallBindings()
    {
        Container.Bind<Wallet>().FromInstance(_money).AsSingle();
    }
}
