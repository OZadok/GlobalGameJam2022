using States;
using System.Collections;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;
using UnityStandardAssets.Characters.ThirdPerson;

public class FamilyMemberScript : MonoBehaviour
{
    public FamilyMovementManager familyMgr { get; private set; }
    public NavMeshAgent agent { get; private set; }
    public Animator animator { get; private set; }

    public ParticleSystem particles { get; private set; }

    public FamilyType family;
    internal StateMachine StateMachine;
    public WanderState wanderState;
    public IdleState idleState;
    public GiveMoneyState giveMoneyState;
    public TakeMoneyState takeMoneyState;
 

    private GameObject targetGameObject;

    void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        particles = GetComponent<ParticleSystem>();
    }

    private void Start()
    {
        familyMgr = FindObjectOfType<FamilyMovementManager>();
        wanderState = new WanderState(this);
        idleState = new IdleState(this);
        giveMoneyState = new GiveMoneyState(this);
        takeMoneyState = new TakeMoneyState(this);
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

    public bool SetDestination(Vector3 target)
    {
        return agent.SetDestination(target);
    }

}



