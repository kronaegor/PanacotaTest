using TMPro;
using UnityEngine;

public class UpgradePriceUI : MonoBehaviour, IValidateText
{
    [SerializeField] private TextMeshProUGUI _text;
    private BarUpgrader _barUpgrade;
    private void OnEnable()
    {
        _barUpgrade.OnBarUpgraded += ValidateText;
    }
    private void Awake()
    {
        _barUpgrade = transform.parent.GetComponent<Bar>().Upgrader;
    }
    private void Start()
    {
        ValidateText();
    }
    private void OnDisable()
    {
        _barUpgrade.OnBarUpgraded -= ValidateText;
    }
    public void ValidateText()
    {
        _text.text = _barUpgrade.MoneyToUpgrade.ToString();
    }
}
