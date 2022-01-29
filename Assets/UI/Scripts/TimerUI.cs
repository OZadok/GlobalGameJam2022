using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TimerUI : MonoBehaviour
{
   [SerializeField] private TMP_Text timerText;
   [SerializeField] private Animator animator;

   private void Awake()
   {
      if (animator == null)
      {
         animator = GetComponent<Animator>();
      }
   }

   private void Start()
   {
      GameManager.Instance.OnEndOfPeriod += OnEndOfPeriod;
      animator.SetFloat("Speed", 1f / GameManager.Instance.SalaryTimer.PeriodTime);
   }

   private void OnEndOfPeriod()
   {
      animator.Play("TimerNewPeriod");
   }

   private void Update()
   {
      if (GameManager.Instance)
      {
         timerText.text = GameManager.Instance.SalaryTimer.GetTimeRemain().ToString("00");
      }
   }

   private void Test()
   {
      // GameManager.Instance.SalaryTimer.
      // var a = 
   }
}
