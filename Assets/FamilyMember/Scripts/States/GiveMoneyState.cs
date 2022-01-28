using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GiveMoneyState : FamilyMemberState
{

    public int coins = 4; 

    public GiveMoneyState(FamilyMemberScript familyMember) : base(familyMember)
    {

    }

    public override void Enter()
    {
        GameManager.Instance.FamilyBossDictionary[familyMember.family].IncreaseSalary(coins);
        //ChangeToWander();
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
}
