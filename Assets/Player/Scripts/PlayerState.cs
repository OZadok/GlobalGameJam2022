using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerState : States.IState {

    [SerializeField] protected PlayerScript player;

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
}
