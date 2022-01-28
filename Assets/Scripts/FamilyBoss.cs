using UnityEngine.Events;

public class FamilyBoss
{
    // public FamilyType FamilyType;

    public int MoneyGainedThisPeriod;

    public int Salary
    {
        get => salary;
        set => salary = value;
    }

    public UnityAction<int> OnSalaryChange;
    private int salary;

    public int GetSalary()
    {
        var salary = MoneyGainedThisPeriod;
        MoneyGainedThisPeriod = 0;
        return salary;
    }

    public void IncreaseSalary(int amount)
    {
        
    }
}
