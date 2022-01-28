using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

// [CreateAssetMenu(fileName = "PlayerMovementState", menuName = "Player States/Movement")]
public class PostState : PlayerState
{
	private float maxDistanceToPost = 3.5f;
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
			yield return player.StartCoroutine(CantPost());
		}
		else
		{
			yield return player.StartCoroutine(Post(closest));
		}

		ChangeToMovement();
	}

	private IEnumerator Post(Postable postable)
	{
		//create poster
		var poster = GameManager.Instance.GetPosterOfType(player.FamilyType);
		// play post animation.
		//at the end of the animation: post the poster(with type) on the postable object.
		postable.Post(poster);
		yield return null;
		yield return new WaitForSeconds(1f);
	}
	
	private IEnumerator CantPost()
	{
		//play animation can't do post
		// wait for the animation to end
		yield return null;
		yield return new WaitForSeconds(1f);
	}
}
