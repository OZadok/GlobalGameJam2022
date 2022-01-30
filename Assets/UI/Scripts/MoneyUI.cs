using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using TMPro;
using UnityEngine;

public class MoneyUI : MonoBehaviour
{
    [SerializeField] private TMP_Text totalMoneyText;
    [SerializeField] private TMP_Text debtText;

    private void Start()
    {
        GameManager.Instance.OnTotalMoneyChanged += OnTotalMoneyChanged;
        GameManager.Instance.OnDebtChanged += OnDebtChanged;

        OnDebtChanged(GameManager.Instance.MoneyManager.PeriodDebt);
        OnTotalMoneyChanged(GameManager.Instance.MoneyManager.TotalMoneyGained);
    }

    private void OnDebtChanged(float value)
    {
        debtText.text = "Debt: " + GetCurrencyString(value);
    }

    private void OnTotalMoneyChanged(float value)
    {
        totalMoneyText.text = "Bank: " + GetCurrencyString(value);
    }

    public static string GetCurrencyString(float number)
    {
        return string.Format(new System.Globalization.CultureInfo("it-IT"), "{0:C0}", number);
    }
}
