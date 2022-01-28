using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SalaryTimer : MonoBehaviour
{
    [SerializeField] private float periodTime;

    private float lastTimePeriodStart;

    private void Start()
    {
        StartCoroutine(Period());
    }

    private IEnumerator Period()
    {
        while (true)
        {
            lastTimePeriodStart = Time.time;
            yield return new WaitForSeconds(periodTime);
            GameManager.Instance.OnEndOfPeriod?.Invoke();
        }
    }

    public float GetTimeRemain()
    {
        var timePast = Time.time - lastTimePeriodStart;
        return periodTime - timePast;
    }
}
