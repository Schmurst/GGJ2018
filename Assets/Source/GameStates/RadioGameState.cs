using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RadioGameState : GameState<RadioGameState>, IGameState
{
	public EGameState Type { get { return EGameState.radio; } }



	public override void Init ()
	{
		base.Init ();
	}


}
