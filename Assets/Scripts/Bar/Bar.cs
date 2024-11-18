using UnityEngine;

public class Bar : MonoBehaviour
{
    [SerializeField] private BarCollector _collector;
    [SerializeField] private BarLevel _level;
    [SerializeField] private BarMoneyFactory _moneyFactory;
    [SerializeField] private BarMoneyFolder _moneyFolder;
    [SerializeField] private BarTimer _timer;
    [SerializeField] private BarUpgrader _upgrader;
    public BarCollector Collector { get { return _collector; } }
    public BarLevel Level { get { return _level; } }
    public BarMoneyFactory MoneyFactory { get { return _moneyFactory; } }
    public BarMoneyFolder MoneyFolder { get { return _moneyFolder; } }
    public BarTimer Timer { get { return _timer; } }
    public BarUpgrader Upgrader { get { return _upgrader; } }
}
