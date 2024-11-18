using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class BuyBar : MonoBehaviour
{
    [Inject] private Wallet _money;
    [SerializeField] private GameObject _bar;
    [SerializeField] private Button _buyButton;
    [SerializeField] private RectTransform _parent;
    [SerializeField] private int _moneyToBuy = 500;
    private void OnEnable()
    {
        _buyButton.onClick.AddListener(BuyNewBar);
    }
    private void OnDisable()
    {
        _buyButton.onClick.RemoveListener(BuyNewBar);
    }
    private void BuyNewBar()
    {
        if (_moneyToBuy > _money.Money)
            return;
        _money.Money -= _moneyToBuy;
        GameObject item = Instantiate(_bar);
        item.transform.SetParent(_parent, false);
        item.transform.SetAsFirstSibling();
    }
}
