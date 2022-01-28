using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TimerUI : MonoBehaviour
{
   [SerializeField] private TMP_Text timerText;

   private void Update()
   {
      timerText.text = GameManager.Instance.SalaryTimer.GetTimeRemain().ToString("00");
   }
}
