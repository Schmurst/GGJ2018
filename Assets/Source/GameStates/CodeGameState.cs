using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CodeGameState : GameState<CodeGameState>, IGameState
{
	public override EGameState Type { get { return EGameState.code; } }

	[SerializeField] float m_initialDelay = 2f;

	float m_tStart, m_tEnd;

	public override string ToString ()
	{
		return string.Format ("{0}|timeLeft:{1}", Type, m_tEnd - m_tStart);
	}

	public override void EnterState ()
	{
		base.EnterState ();
		StartCoroutine (Co_StartCountDown ());
	}

	IEnumerator Co_StartCountDown()
	{
		// play nice wait maybe kick off some animations
		yield return new WaitForSeconds (m_initialDelay);

		// enable code input controls

		// Start CountDown
		m_tStart = Time.time;
		m_tEnd = m_tStart + ((!GameManager.IS_DEBUG) ? RadioManager.Me.Day.TimeLimit : 2f);
		yield return new WaitUntil (() =>{return Time.time > m_tEnd;});
		bool isCorrect = CodeCalculator.Me.DidPlayerDecodeTransmissionSuccessfully ();
		GameManager.Me.SetState(isCorrect ? (IGameState)SuccessGameState.Me : (IGameState)FailGameState.Me);
	}
}