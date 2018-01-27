using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroGameState : GameState<IntroGameState>, IGameState
{
	public override void Init ()
	{
		base.Init ();
	}

	public override void EnterState ()
	{
		base.EnterState ();
	}

	public override void ExitState ()
	{
		base.ExitState ();
	}

	public override void ChangeState (IGameState _newState)
	{
		base.ChangeState (_newState);
	}
}