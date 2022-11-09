using TMPro;
using UnityEngine;

public class MoneyView : UIView
{
    [SerializeField] TextMeshProUGUI _moneyText;
    [SerializeField] PlayerMoneyHandler _playerMoneyHandler;
    public override void Initialize()
    {
        _moneyText.text = DataHandler.Money.ToString();
        _playerMoneyHandler.OnMoneyChange += UpdateView;
    }

    public override void SetActive(bool isActive)
    {
        gameObject.SetActive(isActive);
    }

    public override void UpdateView()
    {
        _moneyText.text = DataHandler.Money.ToString();       
    }
}
