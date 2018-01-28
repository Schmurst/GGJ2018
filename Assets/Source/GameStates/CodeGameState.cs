using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CodeGameState : GameState<CodeGameState>, IGameState
{
	public override EGameState Type { get { return EGameState.code; } }

	float m_initialDelay = 1f;

	float m_tStart, m_tEnd;

	AudioClip clip;

	public override string ToString ()
	{
		return string.Format ("{0}|timeLeft:{1}", Type, m_tEnd - m_tStart);
	}

	public override void EnterState ()
	{
		base.EnterState ();
		StartCoroutine (Co_StartCountDown ());
	}

	bool m_isManualInput = false;
	public void OnManualCodeInput()
	{
		m_isManualInput = true;
	}

	IEnumerator Co_StartCountDown()
	{
		// play nice wait maybe kick off some animations
		AudioManager.Me.PlayRadio(clip, ()=>{});
		yield return new WaitForSeconds (m_initialDelay);

		// Start CountDown
		m_tStart = Time.time;
		m_tEnd = m_tStart + ((!GameManager.IS_DEBUG) ? RadioManager.Me.Day.TimeLimit : 10f);
		yield return new WaitUntil (() =>{return m_isManualInput || Time.time > m_tEnd;});
		m_isManualInput = false;
		bool isCorrect = CodeCalculator.Me.DidPlayerDecodeTransmissionSuccessfully ();
		GameManager.Me.SetState(isCorrect ? (IGameState)SuccessGameState.Me : (IGameState)FailGameState.Me);
		AudioManager.Me.Debug_SkipAudio();
	}
}