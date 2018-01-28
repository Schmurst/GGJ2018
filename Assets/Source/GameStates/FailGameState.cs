using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FailGameState : GameState<FailGameState>, IGameState
{
	public override EGameState Type { get { return EGameState.fail; } }

	public override void EnterState ()
	{
		base.EnterState ();
		SceneManager.LoadScene ("fail");
	}
}
