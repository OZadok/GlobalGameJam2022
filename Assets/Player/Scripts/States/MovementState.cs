using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// [CreateAssetMenu(fileName = "PlayerMovementState", menuName = "Player States/Movement")]
public class MovementState : PlayerState
{
	[SerializeField] private float speed = 50f;

	private bool isWalking;
	private static readonly int Walk = Animator.StringToHash("Walk");
	private static readonly int Idle = Animator.StringToHash("Idle");

	public MovementState(PlayerScript player) : base(player)
	{
	}

	public override void Enter()
	{
		player.InputBehaviour.OnPostAction += ChangeToPost;
		player.InputBehaviour.OnSwapAction += ChangeToSwap;
	}

	public override void ExecuteUpdate()
	{
		
	}

	public override void ExecuteFixedUpdate()
	{
		Move(player.InputBehaviour.Movement);
	}

	public override void Exit()
	{
		player.InputBehaviour.OnPostAction -= ChangeToPost;
		player.InputBehaviour.OnSwapAction -= ChangeToSwap;
	}
	
	private void Move(Vector2 movement)
	{
		var lastIsWalking = isWalking;
		isWalking = movement.sqrMagnitude > 0;

		if (lastIsWalking != isWalking)
		{
			player.Animator.SetTrigger(isWalking ? Walk : Idle);
		}
		
		// // todo - change the movement to be with target speed. i.e. when the vector is zero it should calculate the force to add to get to zero velocity.
		// if (movement.sqrMagnitude > 1)
		// {
		// 	movement.Normalize();
		// }
		//
		// var movement3D = new Vector3(movement.x, 0, movement.y);
		// var cameraYAngle = player.PlayerCamera.transform.rotation.eulerAngles.y;
		// movement3D = Quaternion.Euler(0, cameraYAngle, 0) * movement3D;
		//
		// player.Rigidbody.AddForce(movement3D * speed);
	}
}
