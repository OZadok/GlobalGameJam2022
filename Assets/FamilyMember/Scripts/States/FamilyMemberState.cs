using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class FamilyMemberState : States.IState
{
    [SerializeField] protected FamilyMemberScript familyMember;

    public FamilyMemberState(FamilyMemberScript familyMember)
    {
        this.familyMember = familyMember;
    }

    public abstract void Enter();
    public abstract void ExecuteFixedUpdate();
    public abstract void ExecuteUpdate();
    public abstract void Exit();

    public void ChangeToWander() {
        familyMember.StateMachine.ChangeState(familyMember.WanderState);
    }

    public void ChangeToIdle() {
        familyMember.StateMachine.ChangeState(familyMember.idleState);
    }

}
