using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class MoneyManager : MonoBehaviour
{
    [SerializeField] private int totalMoneyGained;
    [SerializeField] private int periodDebt = 10;

    public int TotalMoneyGained
    {
        get => totalMoneyGained;
        set
        {
            totalMoneyGained = value;
            GameManager.Instance.OnTotalMoneyChanged?.Invoke(totalMoneyGained);
        }
    }

    
    public int PeriodDebt
    {
        get => periodDebt;
        set
        {
            periodDebt = value;
            GameManager.Instance.OnDebtChanged?.Invoke(periodDebt);
        }
    }

    private void Start()
    {
        GameManager.Instance.OnEndOfPeriod += OnEndOfPeriod;
        
        GameManager.Instance.OnTotalMoneyChanged?.Invoke(totalMoneyGained);
        GameManager.Instance.OnDebtChanged?.Invoke(periodDebt);
    }

    private void OnEndOfPeriod()
    {
        var salary = GameManager.Instance.FamilyBossDictionary.Values.Sum(familyBoss => familyBoss.GetAndZeroSalary());
        TotalMoneyGained += salary;
        TotalMoneyGained -= PeriodDebt;
        if (TotalMoneyGained < 0)
        {
            // game over;
            GameManager.Instance.OnGameOver?.Invoke();
        }
    }
}
