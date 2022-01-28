using States;
using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class FamilyMemberScript : MonoBehaviour
{
    FamilyMovementManager familyMgr;
    NavMeshAgent agent;
    public float minWaitTime = 3f;
    public float maxWaitTime = 12f;
    float EPSILON = 0.001f;
    public float dist;
    public NavMeshPathStatus status;

    internal StateMachine StateMachine;
    public WanderState WanderState;
    public IdleState idleState;

    Camera cam;

    void Start()
    {
        //TODO: obtain via GM
        familyMgr = FindObjectOfType<FamilyMovementManager>();
        agent = GetComponent<NavMeshAgent>();
        cam = Camera.main;
    }


    // Update is called once per frame
    void Update()
    {

        dist = agent.remainingDistance;
        status = agent.pathStatus;
        //Debug.DrawLine(transform.position, agent.destination);
        Vector3 curr = transform.position;
        foreach (Vector3 p in agent.path.corners) {
            Debug.DrawLine(curr, p);
            curr = p;
        }


        if (Input.GetMouseButtonDown(0)) {
            Debug.Log("gonna move");
            float waitTime = Random.Range(minWaitTime, maxWaitTime);
            StartCoroutine(WaitAndWalk(waitTime));
        }
    }

    IEnumerator WaitAndWalk(float secs)
    {
        yield return new WaitForSeconds(secs);
        WalkToNewDestination();
    }

    void WalkToNewDestination() {
        agent.SetDestination(familyMgr.RequestDestination(this));
    }

    bool IsArrivedAtDestination()
    {
        return (agent.remainingDistance <= EPSILON) && (agent.pathStatus == NavMeshPathStatus.PathComplete);
    }


}



