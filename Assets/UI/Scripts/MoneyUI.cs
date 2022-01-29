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
    }

    private void OnDebtChanged(float value)
    {
        debtText.text = "Debt: " + value.ToString("C0");
    }

    private void OnTotalMoneyChanged(float value)
    {
        totalMoneyText.text = "Bank: " + value.ToString("C0");
    }
}
