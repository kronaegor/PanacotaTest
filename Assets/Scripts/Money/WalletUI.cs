using TMPro;
using UnityEngine;
using Zenject;

public class WalletUI : MonoBehaviour, IValidateText
{
    [Inject] private Wallet _money;
    [SerializeField] private TextMeshProUGUI _text;
    private void OnEnable()
    {
        _money.OnMoneyChanged += ValidateText;
        ValidateText();
    }
    private void OnDisable()
    {
        _money.OnMoneyChanged -= ValidateText;
    }
    public void ValidateText()
    {
        _text.text = _money.Money.ToString();
    }

}
