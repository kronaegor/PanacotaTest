using UnityEngine;
using UnityEngine.UI;

public class BarProgressFill : MonoBehaviour
{
    [SerializeField] private Image _barImage;
    private BarMoneyFolder _barMoneyFolder;
    private void OnEnable()
    {
        _barMoneyFolder.OnBarMoneyChanged += ChangeImageFill;
        _barMoneyFolder.OnBarMaxAmountChanged += ChangeImageFill;
        ChangeImageFill();
    }
    private void Awake()
    {
        _barMoneyFolder = transform.parent.GetComponent<Bar>().MoneyFolder;
    }
    private void OnDisable()
    {
        _barMoneyFolder.OnBarMoneyChanged -= ChangeImageFill;
        _barMoneyFolder.OnBarMaxAmountChanged += ChangeImageFill;
    }
    private void ChangeImageFill()
    {
        _barImage.fillAmount = (float)_barMoneyFolder.Money / _barMoneyFolder.MaxAmountOfMoney;
    }
}
