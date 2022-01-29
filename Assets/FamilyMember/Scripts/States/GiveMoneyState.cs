using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GiveMoneyState : FamilyMemberState
{

    public int coins = 4; 

    public GiveMoneyState(FamilyMemberScript familyMember) : base(familyMember)
    {
        

    }

    public override void Enter()
    {

        familyMember.StartCoroutine(GiveMoney());
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

    private IEnumerator GiveMoney() {
        GameManager.Instance.OnGiveMoney?.Invoke();
        familyMember.animator.SetTrigger("GiveMoney");
        familyMember.particles.Play();
        yield return WaitAnimationTime();
        GameManager.Instance.FamilyBossDictionary[familyMember.family].IncreaseSalary(coins);
        ChangeToIdle();
    }
}
