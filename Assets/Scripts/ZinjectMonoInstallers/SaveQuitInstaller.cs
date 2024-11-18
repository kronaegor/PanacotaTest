using UnityEngine;
using Zenject;

public class SaveQuitInstaller : MonoInstaller
{
    [SerializeField] private SaveQuit _quit;
    public override void InstallBindings()
    {
        Container.Bind<SaveQuit>().FromInstance(_quit).AsSingle();
    }
}
