using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SalaryTimer : MonoBehaviour
{
    
    public float PeriodTime => periodTime;

    private float lastTimePeriodStart;
    [SerializeField] private float periodTime;

    private void Start()
    {
        StartCoroutine(Period());
    }

    private IEnumerator Period()
    {
        while (true)
        {
            lastTimePeriodStart = Time.time;
            yield return new WaitForSeconds(PeriodTime);
            GameManager.Instance.OnEndOfPeriod?.Invoke();
        }
    }

    public float GetTimeRemain()
    {
        var timePast = Time.time - lastTimePeriodStart;
        return PeriodTime - timePast;
    }
}
