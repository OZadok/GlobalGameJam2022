using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class WanderState : FamilyMemberState
{

    Vector3 destination;
    float EPSILON = 0.01f;
    public bool isDebug = true;
    float walkTooLong = 12f;
    float sightRadius = 6f;
    float startWalking;

    public WanderState(FamilyMemberScript familyMember) : base(familyMember)
    {
    }
    public override void Enter()
    {
        this.startWalking = Time.time;
        this.destination = this.familyMember.familyMgr.RequestDestination(this.familyMember);
        this.familyMember.agent.SetDestination(destination);
        GameManager.Instance.OnPosterPost += OnPlayerPosted;
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

        else if (IsArrivedAtDestination() || IsWalkingTooLong())
        {
            ChangeToIdle();
        }

    }

    public void OnPlayerPosted(Poster poster) {
        if (IsPosterSpotted(poster) && poster.Type == familyMember.family)
        {
            ChangeToGiveMoney();
        }
    }

    public override void Exit()
    {
        GameManager.Instance.OnPosterPost -= OnPlayerPosted;
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

    bool IsPosterSpotted(Poster poster) {
        bool canSee = familyMember.gameObject.CanSee(poster.gameObject);
        bool isNear = Vector3.Distance(familyMember.transform.position, poster.transform.position) < sightRadius;
        return canSee && isNear;
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
