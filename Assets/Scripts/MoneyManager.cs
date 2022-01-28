using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class MoneyManager : MonoBehaviour
{
    public int TotalMoneyGained { get; set; }
    public int Debt { get; set; }

    [SerializeField] private int periodDebt = 10;

    private void Start()
    {
        GameManager.Instance.OnEndOfPeriod += OnEndOfPeriod;
    }

    private void OnEndOfPeriod()
    {
        var salary = GameManager.Instance.FamilyBossDictionary.Values.Sum(familyBoss => familyBoss.GetAndZeroSalary());
        TotalMoneyGained += salary;
        TotalMoneyGained -= Debt;
        if (TotalMoneyGained < 0)
        {
            // game over;
        }
    }
}
