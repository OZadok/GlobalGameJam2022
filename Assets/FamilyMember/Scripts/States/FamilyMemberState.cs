using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class FamilyMemberState : States.IState
{
    [SerializeField] protected FamilyMemberScript familyMember;
    float sightRadius = 6f;

    public FamilyMemberState(FamilyMemberScript familyMember)
    {
        this.familyMember = familyMember;
    }

    public abstract void Enter();
    public abstract void ExecuteFixedUpdate();
    public abstract void ExecuteUpdate();
    public abstract void Exit();

    public void ChangeToWander() {
        familyMember.StateMachine.ChangeState(familyMember.wanderState);
    }

    public void ChangeToIdle() {
        familyMember.StateMachine.ChangeState(familyMember.idleState);
    }

    public void ChangeToGiveMoney() {
        familyMember.StateMachine.ChangeState(familyMember.giveMoneyState);
    }

    public void ChangeToTakeMoney()
    {
        familyMember.StateMachine.ChangeState(familyMember.takeMoneyState);
    }

    protected float GetAnimationClipLength()
    {
        return familyMember.animator.GetCurrentAnimatorClipInfo(0)[0].clip.length;
    }

    protected IEnumerator WaitAnimationTime()
    {
        yield return null;
        float timeToWait = GetAnimationClipLength();
        yield return new WaitForSeconds(timeToWait);
    }

    public void OnPlayerPosted(Poster poster)
    {
        if (!IsPosterSpotted(poster))
        {
            return;
        }
        if (poster.Type == familyMember.family)
        {
            ChangeToGiveMoney();
        }
        else
        {
            ChangeToTakeMoney();
        }
    }

    bool IsPosterSpotted(Poster poster)
    {
        bool canSee = familyMember.gameObject.CanSee(poster.gameObject);
        bool isNear = Vector3.Distance(familyMember.transform.position, poster.transform.position) < sightRadius;
        return canSee && isNear;
    }

}
