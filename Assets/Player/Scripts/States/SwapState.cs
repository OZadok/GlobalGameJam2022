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
		//check if can do Swap.
		if ( /*can't do Swap*/true)
		{
			//play animation can't do Swap
		}
		else
		{
			// play Swap animation.
			// change Mafia Party enum
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
