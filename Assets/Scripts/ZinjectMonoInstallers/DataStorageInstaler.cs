using UnityEngine;
using Zenject;

public class DataStorageInstaler : MonoInstaller
{
    [SerializeField] private DataStorage _data;
    public override void InstallBindings()
    {
        Container.Bind<DataStorage>().FromInstance(_data).AsSingle();
    }
}
