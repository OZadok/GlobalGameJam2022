using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// [CreateAssetMenu(fileName = "PlayerMovementState", menuName = "Player States/Movement")]
public class PostState : PlayerState
{
	public PostState(PlayerScript player) : base(player)
	{
	}

	public override void Enter()
	{
		// find the closest postable point to post
		if ( /*the closest point is not in range to post */true)
		{
			//play animation can't do post
		}
		else
		{
			// play post animation.
			//at the end of the animation: post the poster(with type) on the postable object.
		}
		
		//at the end: exit to movement
		
	}

	public override void ExecuteUpdate()
	{
	}

	public override void ExecuteFixedUpdate()
	{
	}

	public override void Exit()
	{
	}
}
