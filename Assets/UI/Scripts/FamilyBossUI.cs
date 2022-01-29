using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FamilyBossUI : MonoBehaviour
{
	[Header("References")] 
	[SerializeField] private TMP_Text salaryText; 
	[SerializeField] private FamilyType type;

	private FamilyBoss familyBoss;
	private void Start()
	{
		familyBoss = GameManager.Instance.FamilyBossDictionary[type];
		familyBoss.OnSalaryChange += OnSalaryChange;
	}

	private void OnSalaryChange(int salary)
	{
		salaryText.text = salary.ToString("C0");
	}
}
