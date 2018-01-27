using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FailGameState : GameState<FailGameState>, IGameState
{
	public override EGameState Type { get { return EGameState.fail; } }
}
