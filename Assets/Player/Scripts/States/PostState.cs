using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

// [CreateAssetMenu(fileName = "PlayerMovementState", menuName = "Player States/Movement")]
public class PostState : PlayerState
{
	private float maxDistanceToPost = 3.5f;
	private static readonly int Post1 = Animator.StringToHash("Post");
	

	public PostState(PlayerScript player) : base(player)
	{
	}

	public override void Enter()
	{
		player.StartCoroutine(EnterEnumerable());
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

	private Postable GetClosestValidPostable()
	{
		Postable closestValid = null;
		var minSqrDistance = maxDistanceToPost * maxDistanceToPost;
		foreach (var postable in GameManager.Instance.Postables)
		{
			var diff = postable.GetPostPosition() - player.transform.position;
			diff.y = 0;
			var sqrDistance = (diff).sqrMagnitude;
			if (sqrDistance < minSqrDistance && postable.transform.CanSee(player.transform) && postable.FamilyType != player.FamilyType)
			{
				minSqrDistance = sqrDistance;
				closestValid = postable;
			}
			
		}

		return closestValid;
	}

	private IEnumerator EnterEnumerable()
	{
		// find the closest postable point to post
		var closest = GetClosestValidPostable();
		if (closest == null)
		{
			yield return CantPost();
		}
		else
		{
			yield return Post(closest);
		}

		ChangeToMovement();
	}

	private IEnumerator Post(Postable postable)
	{
		// play post animation.
		player.Animator.SetTrigger(Post1);
		yield return WaitAnimationTime();
		//at the end of the animation: post the poster(with type) on the postable object.
		//create poster
		var poster = GameManager.Instance.GetPosterOfType(player.FamilyType);
		postable.Post(poster);
	}
	
	private IEnumerator CantPost()
	{
		//play animation can't do post
		player.Animator.SetTrigger(CantDo);
		// wait for the animation to end
		yield return WaitAnimationTime();
	}
}
