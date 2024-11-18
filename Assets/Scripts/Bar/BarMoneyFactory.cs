using UnityEngine;

public class BarMoneyFactory : MonoBehaviour
{
    [SerializeField] private int _moneyToEarn = 1;
    private BarTimer _timer;
    private BarMoneyFolder _moneyFolder;
    private void OnEnable()
    {
        _timer.OnTimerEnd += EarnMoney;
    }
    private void Awake()
    {
        _timer = transform.parent.GetComponent<Bar>().Timer;
        _moneyFolder = transform.parent.GetComponent<Bar>().MoneyFolder;
    }
    private void OnDisable()
    {
        _timer.OnTimerEnd -= EarnMoney;
    }
    private void EarnMoney()
    {
        if (_moneyFolder.Money >= _moneyFolder.MaxAmountOfMoney)
            return;
        _moneyFolder.Money += _moneyToEarn;
    }
}
