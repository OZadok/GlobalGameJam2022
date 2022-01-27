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
	public UnityAction<bool> OnPostAction;
	public UnityAction<bool> OnSwapAction;

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
		OnPostAction?.Invoke(IsPost);
	}
	
	public void OnPost(InputAction.CallbackContext context)
	{
		IsPost = context.ReadValueAsButton();
		OnPostAction?.Invoke(IsPost);
	}
	
	public void OnSwap(InputValue value)
	{
		IsSwap = value.isPressed;
		OnSwapAction?.Invoke(IsSwap);
	}
	
	public void OnSwap(InputAction.CallbackContext context)
	{
		IsSwap = context.ReadValueAsButton();
		OnSwapAction?.Invoke(IsSwap);
	}
}
