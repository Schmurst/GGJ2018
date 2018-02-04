using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuccessGameState : GameState<SuccessGameState>, IGameState
{
	public override EGameState Type { get { return EGameState.success; } }

	[SerializeField] float m_dayToDayDelay =2f;

	// -------------------------------------------------------------------------------------------
	public override void EnterState ()
	{
		base.EnterState ();
		AudioManager.Me.ForceFadeAudio ();

		TransitionGameState.Me.OnFaded = () => {
			int oldWeek = RadioManager.Me.WeekIdx;
			RadioManager.Me.IncrementToNextDay ();
			if (oldWeek != RadioManager.Me.WeekIdx)
				DraggableGUIManager.Me.SpawnStartDraggables(RadioManager.Me.WeekIdx);
		};

		TransitionGameState.Me.OnComplete = () => {GameManager.Me.SetState (RadioGameState.Me);};
		GameManager.Me.SetState (TransitionGameState.Me);
	}
}