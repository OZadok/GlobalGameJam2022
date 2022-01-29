using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerState : States.IState {

    [SerializeField] protected PlayerScript player;
    
    protected static readonly int CantDo = Animator.StringToHash("CantDo");

    public PlayerState(PlayerScript player)
    {
        this.player = player;
    }

    public abstract void Enter();
    public abstract void ExecuteUpdate();
    public abstract void ExecuteFixedUpdate();
    public abstract void Exit();

    public void ChangeToPost()
    {
        player.StateMachine.ChangeState(player.PostState);
    }
    
    public void ChangeToSwap()
    {
        player.StateMachine.ChangeState(player.SwapState);
    }
    
    public void ChangeToMovement()
    {
        player.StateMachine.ChangeState(player.MovementState);
    }

    protected float GetAnimationClipLength()
    {
        //float speed = player.Animator.GetNextAnimatorStateInfo(0).speedMultiplier;
        //float length = player.Animator.GetCurrentAnimatorClipInfo(0)[0].clip.length;
        //return length / speed;
        return player.Animator.GetNextAnimatorStateInfo(0).length;
    }

    protected IEnumerator WaitAnimationTime()
    {
        yield return null;
        float timeToWait = GetAnimationClipLength();
        yield return new WaitForSeconds(timeToWait);
    }
}
