using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwapState : PlayerState
{
	public SwapState(PlayerScript player) : base(player)
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
	
	private IEnumerator EnterEnumerable()
	{
		//check if can do Swap.
		if ( /*can't do Swap*/false)
		{
			yield return player.StartCoroutine(CantSwap());
		}
		else
		{
			yield return player.StartCoroutine(Swap());
		}

		ChangeToMovement();
	}

	private IEnumerator Swap()
	{
		// play Swap animation.
		switch (player.FamilyType)
		{
			case FamilyType.A:
				player.FamilyType = FamilyType.B;
				break;
			case FamilyType.B:
				player.FamilyType = FamilyType.A;
				break;
			default:
				player.FamilyType = FamilyType.A;
				break;
		}
		Debug.Log($"player new family type: {player.FamilyType}");
		yield return null;
		yield return new WaitForSeconds(1f);
	}
	
	private IEnumerator CantSwap()
	{
		//play animation can't do Swap
		// wait for the animation to end
		yield return null;
		yield return new WaitForSeconds(1f);
	}
}
