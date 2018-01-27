using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuccessGameState : GameState<SuccessGameState>, IGameState
{
	public EGameState Type { get { return EGameState.success; } }
}