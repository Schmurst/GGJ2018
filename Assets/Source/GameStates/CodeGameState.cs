using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CodeGameState : GameState<CodeGameState>, IGameState
{
	public EGameState Type { get { return EGameState.code; } }

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
}