using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class BarCollector : MonoBehaviour
{
    [Inject] private Wallet _money;
    [SerializeField] private Button _colectButton;
    private BarMoneyFolder _barMoney;
    private void Awake()
    {
        _barMoney = transform.parent.GetComponent<Bar>().MoneyFolder;
    }
    private void OnEnable()
    {
        _colectButton.onClick.AddListener(CollectMoney);
    }
    private void OnDisable()
    {
        _colectButton.onClick.AddListener(CollectMoney);
    }
    private void CollectMoney()
    {
        _money.Money += _barMoney.Money;
        _barMoney.Money = 0;
    } 
}
