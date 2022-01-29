using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwapState : PlayerState
{
	private static readonly int Swap1 = Animator.StringToHash("Swap");

	public SwapState(PlayerScript player) : base(player)
	{
	}

	public override void Enter()
	{
        FamilyType newFamilyType = GetNewFamilyType();
        if (CanSwap())
        {
            player.StartCoroutine(SwapMasks(1f, newFamilyType));
            player.StartCoroutine(SwapFamilyTypeAndExit(newFamilyType));
        }
        else {
            ChangeToMovement();
        }

	}

    bool CanSwap() {
        return true;
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
	
	private IEnumerator SwapFamilyTypeAndExit(FamilyType newFamilyType)
	{
        player.Animator.SetTrigger(Swap1);
        yield return WaitAnimationTime();
        player.FamilyType = newFamilyType;
        ChangeToMovement();
	}
	
	private IEnumerator CantSwap()
	{
		//play animation can't do Swap
		player.Animator.SetTrigger(CantDo);
		// wait for the animation to end
		yield return WaitAnimationTime();
	}

    FamilyType GetNewFamilyType() {
        switch (player.FamilyType)
        {
            case FamilyType.Lucas:
                return FamilyType.Marco;
            case FamilyType.Marco:
                return FamilyType.Lucas;
            default:
                return FamilyType.Marco;
        }
    }

    IEnumerator SwapMasks(float seconds, FamilyType familyType) {
        yield return new WaitForSeconds(seconds);
        player.SwapToMask(familyType);
    }


}
