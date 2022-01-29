using System.Collections;
using UnityEngine;
using System.Collections;
using UnityEngine;

public class IdleState : FamilyMemberState
{
    float minWaitTime = 3f;
    float maxWaitTime = 12f;
    float enterTime;
    float timeToIdle;

    public IdleState(FamilyMemberScript familyMember) : base(familyMember)
    {
    }

    public override void Enter()
    {
        this.familyMember.animator.SetTrigger("Idle");
        timeToIdle = Random.Range(minWaitTime, maxWaitTime);
        enterTime = Time.time;
    }

    public override void ExecuteFixedUpdate()
    {
    }

    public override void ExecuteUpdate()
    {
        if ((Time.time - enterTime) >= timeToIdle) {
            ChangeToWander();
        }
    }

    public override void Exit()
    {
    }

}
