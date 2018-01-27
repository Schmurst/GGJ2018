using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RadioGameState : GameState<RadioGameState>, IGameState
{
	public EGameState Type { get { return EGameState.radio; } }

	// -------------------------------------------------------------------------------------------
	public override string ToString ()
	{
		var radio = RadioManager.Me;
		return string.Format ("{0}|Week:{1}|Day:{2}|Clip:{3}",
			Type, radio.WeekIdx, radio.DayIdx, AudioManager.Me.ClipIdx-1);
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