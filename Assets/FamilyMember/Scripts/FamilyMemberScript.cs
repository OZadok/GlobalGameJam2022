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
    public AICharacterControl AICharacterControl { get; private set; }
    

    public FamilyType family;
    internal StateMachine StateMachine;
    public WanderState wanderState;
    public IdleState idleState;
    public GiveMoneyState giveMoneyState;

    private GameObject targetGameObject;

    void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        AICharacterControl = GetComponent<AICharacterControl>();
        
        targetGameObject = new GameObject($"target of {name}");
        targetGameObject.transform.SetParent(null);
    }

    private void Start()
    {
        familyMgr = FindObjectOfType<FamilyMovementManager>();
        
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

    public  void SetDestination(Vector3 target)
    {
        targetGameObject.transform.position = target;
        AICharacterControl.SetTarget(targetGameObject.transform);
        // return agent.SetDestination(target);
    }
}



