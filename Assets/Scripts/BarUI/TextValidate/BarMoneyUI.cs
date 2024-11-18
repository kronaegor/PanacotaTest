using TMPro;
using UnityEngine;

public class BarMoneyUI : MonoBehaviour, IValidateText
{
    [SerializeField] private TextMeshProUGUI _text;
    private BarMoneyFolder _moneyFolder;
    private void OnEnable()
    {
        _moneyFolder.OnBarMoneyChanged += ValidateText;
    }
    private void Awake()
    {
        _moneyFolder = transform.parent.GetComponent<Bar>().MoneyFolder;
    }
    private void Start()
    {
        ValidateText();
    }
    private void OnDisable()
    {
        _moneyFolder.OnBarMoneyChanged -= ValidateText;
    }
    public void ValidateText()
    {
        _text.text = _moneyFolder.Money.ToString();
    }
}
