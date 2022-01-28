using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class PlayerInputBehaviour : MonoBehaviour
{
	public Vector2 Movement { get; set; }
	public bool IsPost { get; set; }
	public bool IsSwap { get; set; }

	public UnityAction<Vector2> OnMovementAction;
	public UnityAction OnPostAction;
	public UnityAction OnSwapAction;

	public void OnMovement(InputValue value)
	{
		Movement = value.Get<Vector2>();
		OnMovementAction?.Invoke(Movement);
	}
	
	public void OnMovement(InputAction.CallbackContext context)
	{
		Movement = context.ReadValue<Vector2>();
		OnMovementAction?.Invoke(Movement);
	}
	
	public void OnPost(InputValue value)
	{
		IsPost = value.isPressed;
		OnPostAction?.Invoke();
	}
	
	public void OnPost(InputAction.CallbackContext context)
	{
		IsPost = context.ReadValueAsButton();
		if (IsPost)
		{
			OnPostAction?.Invoke();
		}
	}
	
	public void OnSwap(InputValue value)
	{
		IsSwap = value.isPressed;
		OnSwapAction?.Invoke();
	}
	
	public void OnSwap(InputAction.CallbackContext context)
	{
		IsSwap = context.ReadValueAsButton();
		if (IsSwap)
		{
			OnSwapAction?.Invoke();
		}
	}
}
