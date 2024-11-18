using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;

public class MaxAmountUI : MonoBehaviour, IValidateText
{
    [SerializeField] private TextMeshProUGUI _text;
    private BarMoneyFolder _barMoneyFolder;
    private void OnEnable()
    {
        _barMoneyFolder.OnBarMaxAmountChanged += ValidateText;
    }
    private void Awake()
    {
        _barMoneyFolder = transform.parent.GetComponent<Bar>().MoneyFolder;
    }
    private void Start()
    {
        ValidateText();
    }
    private void OnDisable()
    {
        _barMoneyFolder.OnBarMaxAmountChanged -= ValidateText;
    }
    public void ValidateText()
    {
        _text.text = _barMoneyFolder.MaxAmountOfMoney.ToString();
    }
}
