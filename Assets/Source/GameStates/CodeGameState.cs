using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CodeGameState : GameState<CodeGameState>, IGameState
{
	public override EGameState Type { get { return EGameState.code; } }

	[SerializeField] float m_initialDelay = 2f;

	public override void EnterState ()
	{
		base.EnterState ();
	}

	public override void ExitState ()
	{
		base.ExitState ();
	}

	IEnumerator Co_StartCountDown()
	{
		// play nice wait maybe kick off some animations
		yield return new WaitForSeconds (m_initialDelay);

		// enable code input controls

		// Start CountDown
		yield return new WaitForSeconds (RadioManager.Me.Day.TimeLimit);
		bool isCorrect = CodedTransmissionCalculator.Me.DidPlayerDecodeTransmissionSuccessfully ();
		GameManager.Me.SetState(isCorrect ? (IGameState)SuccessGameState.Me : (IGameState)FailGameState.Me);
	}
}