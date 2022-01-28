using States;
using System.Collections;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;

public class FamilyMemberScript : MonoBehaviour
{
    public FamilyMovementManager familyMgr { get; private set; }
    public NavMeshAgent agent { get; private set; }
    public Animator animator { get; private set; }

    public FamilyType family;
    internal StateMachine StateMachine;
    public WanderState wanderState;
    public IdleState idleState;
    public GiveMoneyState giveMoneyState;

    void Awake()
    {

    }

    private void Start()
    {
        familyMgr = FindObjectOfType<FamilyMovementManager>();
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        wanderState = new WanderState(this);
        idleState = new IdleState(this);
        giveMoneyState = new GiveMoneyState(this);
        StateMachine = ScriptableObject.CreateInstance<States.StateMachine>();
        StateMachine.ChangeState(wanderState);
    }


    // Update is called once per frame
    void Update()
    {
        StateMachine.Update();
    }

    private void FixedUpdate()
    {
        StateMachine.FixedUpdate();
    }


}



