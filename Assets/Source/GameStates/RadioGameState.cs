using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RadioGameState : GameState<RadioGameState>, IGameState
{
	public EGameState Type { get { return EGameState.radio; } }

	// -------------------------------------------------------------------------------------------
	public override void Init ()
	{
		base.Init ();
	}

	// -------------------------------------------------------------------------------------------
	public override void EnterState ()
	{
		base.EnterState ();

		RadioManager.Me.PlayDay ();
	}

	// -------------------------------------------------------------------------------------------
	public override void ExitState ()
	{
		base.ExitState ();
	}

	// -------------------------------------------------------------------------------------------
	public void OnRadioDayBroadcastComplete()
	{
		GameManager.Me.SetState (CodeGameState.Me);
	}
}