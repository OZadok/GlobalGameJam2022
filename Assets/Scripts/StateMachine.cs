using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace States
{
    public interface IState
    {
        void Enter();
        void ExecuteUpdate();
        void ExecuteFixedUpdate();
        void Exit();
    }

    public class StateMachine : ScriptableObject
    {
        public IState currentState { get; private set; }
        public IState previousState { get; private set; }

        public void ChangeState(IState newState)
        {
            if (currentState != null)
                currentState.Exit();

            previousState = currentState;
            currentState = newState;
            currentState.Enter();
        }

        public void Update() // not monobehaviour
        {
            if (currentState != null)
                currentState.ExecuteUpdate();
        }

        public void FixedUpdate() // not monobehaviour
        {
            if (currentState != null)
                currentState.ExecuteFixedUpdate();
        }
    }
}
