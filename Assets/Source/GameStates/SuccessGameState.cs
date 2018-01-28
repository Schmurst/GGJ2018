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
		StartCoroutine (Co_SuccessToNextDay());
	}

	// -------------------------------------------------------------------------------------------
	IEnumerator Co_SuccessToNextDay()
	{
		yield return new WaitForSeconds (m_dayToDayDelay);
		RadioManager.Me.IncrementToNextDay ();
		TransitionGameState.Me.OnFaded = () => {
			DraggableGUIManager.Me.SpawnStartDraggables(RadioManager.Me.DayIdx);
		};

		TransitionGameState.Me.OnComplete = () => {GameManager.Me.SetState (RadioGameState.Me);};
		GameManager.Me.SetState (TransitionGameState.Me);
	}
}