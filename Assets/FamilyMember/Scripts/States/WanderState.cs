using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class WanderState : FamilyMemberState
{

    Vector3 destination;
    float EPSILON = 0.01f;
    public bool isDebug = true;
    float walkTooLong = 12f;
    float startWalking; 

    public WanderState(FamilyMemberScript familyMember) : base(familyMember)
    {
    }
    public override void Enter()
    {
        this.startWalking = Time.time;
        this.destination = this.familyMember.familyMgr.RequestDestination(this.familyMember);
        this.familyMember.agent.SetDestination(destination);
    }

    public override void ExecuteFixedUpdate()
    {
    }

    public override void ExecuteUpdate()
    {
        if (isDebug)
        {
            DebugDrawPath();
        }
        if (IsArrivedAtDestination() || IsWalkingTooLong())
        {
            ChangeToIdle();
        }

    }

    public override void Exit()
    {
    }

    bool IsArrivedAtDestination()
    {
        Vector3 familyMemberPos = this.familyMember.transform.position;
        return Vector2.Distance(
            new Vector2(familyMemberPos.x, familyMemberPos.z), 
            new Vector2(destination.x, destination.z)) < EPSILON;
    }

    bool IsWalkingTooLong() {
        return (Time.time - this.startWalking) >= walkTooLong;
    }

    void DebugDrawPath()
    {
        Vector3 curr = this.familyMember.transform.position;
        foreach (Vector3 p in this.familyMember.agent.path.corners)
        {
            Debug.DrawLine(curr, p);
            curr = p;
        }
    }

}
