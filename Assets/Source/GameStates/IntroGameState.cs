using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroGameState : GameState<IntroGameState>, IGameState
{
	public EGameState Type { get { return EGameState.intro; } }

	[SerializeField] float m_introLengthSeconds ;

	public override void Init ()
	{
		base.Init ();
	}

	public override void EnterState ()
	{
		base.EnterState ();
		StartCoroutine (Co_PlayIntro());
	}

	public override void ExitState ()
	{
		base.ExitState ();
	}

	IEnumerator Co_PlayIntro()
	{
		yield return new WaitForSeconds (m_introLengthSeconds);
		GameManager.Me.SetState (RadioGameState.Me);
	}
}