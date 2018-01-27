using UnityEngine;

public interface IGameState
{
	void EnterState ();
	void ExitState ();
	void ChangeState (IGameState _new);
}

public abstract class GameState<T> : MonoSingleton<T> where T:GameState<T>, IGameState
{
	public virtual void EnterState()
	{
		Debug.LogFormat ("Entering State: {0}", Me.name);
	}

	public virtual void ExitState()
	{
		Debug.LogFormat ("Leaving State: {0}", Me.name);
	}

	public virtual void ChangeState(IGameState _newState)
	{
		Me.ExitState ();
		_newState.EnterState ();
	}
}