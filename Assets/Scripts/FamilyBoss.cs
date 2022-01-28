using UnityEngine.Events;

public class FamilyBoss
{
    // public FamilyType FamilyType;

    private int Salary
    {
        get => salary;
        set
        {
            salary = value;
            OnSalaryChange?.Invoke(salary);
        }
    }

    public UnityAction<int> OnSalaryChange;
    private int salary;

    public int GetAndZeroSalary()
    {
        var tempSalary = Salary;
        Salary = 0;
        return tempSalary;
    }

    public void IncreaseSalary(int amount)
    {
        Salary += amount;
    }
}
