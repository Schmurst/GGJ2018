using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinGameState : GameState<WinGameState>, IGameState
{
	public override EGameState Type { get { return EGameState.win; } }
}
