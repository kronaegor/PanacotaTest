using UnityEngine;
using Zenject;

public class StarterPackGiver : MonoBehaviour
{
    [Inject] private DataStorage _dataStorage;
    [SerializeField] private GameObject _bar;
    [SerializeField] private RectTransform _parent;
    private void OnEnable()
    {
        _dataStorage.OnSavesEmpty += GiveStarterPack;
    }
    private void OnDisable()
    {
        _dataStorage.OnSavesEmpty -= GiveStarterPack;
    }
    private void GiveStarterPack()
    {
        GameObject currentItem =  Instantiate(_bar);
        currentItem.transform.SetParent(_parent, false);
        currentItem.transform.SetAsFirstSibling();
    }
}
