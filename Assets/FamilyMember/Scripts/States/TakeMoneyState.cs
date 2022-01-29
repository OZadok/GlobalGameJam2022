using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeMoneyState : FamilyMemberState
{

    public TakeMoneyState(FamilyMemberScript familyMember) : base(familyMember)
    {

    }

    public override void Enter()
    {
        familyMember.StartCoroutine(TakeAwayMoney());
    }

    public override void ExecuteFixedUpdate()
    {

    }

    public override void ExecuteUpdate()
    {

    }

    public override void Exit()
    {

    }

    private IEnumerator TakeAwayMoney()
    {
        //GameManager.Instance.OnTakeAwayMoney?.Invoke();
        familyMember.animator.SetTrigger("Yell");
        yield return WaitAnimationTime();
        GameManager.Instance.FamilyBossDictionary[familyMember.family].GetAndZeroSalary();
        ChangeToIdle();
    }

}
