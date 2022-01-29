using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class FamilyBossUI : MonoBehaviour
{
	[Header("References")] 
	[SerializeField] private TMP_Text salaryText;

	[SerializeField] private Image bossImage;
	[SerializeField] private Sprite bossOK;
	[SerializeField] private Sprite bossAngry;
	
	[Header("Parameters")]
	[SerializeField] private FamilyType type;

	private FamilyBoss familyBoss;
	private void Start()
	{
		familyBoss = GameManager.Instance.FamilyBossDictionary[type];
		familyBoss.OnSalaryChange += OnSalaryChange;

		bossImage.sprite = bossOK;
		
		GameManager.Instance.OnTakeAwayMoney += OnTakeAwayMoney;
		GameManager.Instance.OnEndOfPeriod += OnEndOfPeriod;
	}

	private void OnEndOfPeriod()
	{
		bossImage.sprite = bossOK;
	}

	private void OnTakeAwayMoney()
	{
		bossImage.sprite = bossAngry;
	}

	private void OnSalaryChange(int salary)
	{
		salaryText.text = salary.ToString("C0");
	}
}
