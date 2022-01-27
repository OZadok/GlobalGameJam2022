using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

// [CreateAssetMenu(fileName = "PlayerMovementState", menuName = "Player States/Movement")]
public class PostState : PlayerState
{
	private float maxDistanceToPost = 1.5f;
	public PostState(PlayerScript player) : base(player)
	{
	}

	public override void Enter()
	{
		// find the closest postable point to post
		var closest = GetClosestPostable();
		var sqrDistance = (closest.GetPostPosition() - player.transform.position).sqrMagnitude;
		//todo - need to check also for colliders!
		if ( /*the closest point is not in range to post*/true)
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

	private Postable GetClosestPostable()
	{
		var closest = GameManager.Instance.Postables
			.OrderBy(p => (p.GetPostPosition() - player.transform.position).sqrMagnitude)
			.First();
		return closest;
	}
}
