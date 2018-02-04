using UnityEngine;

public interface IGameState
{
	EGameState Type { get;}
	void EnterState ();
	void ExitState ();
}

public enum EGameState
{
	intro,
	radio,
	code,
	success,
	fail,
	win,
	transition,

	nullOrLength
}

public abstract class GameState<T> : MonoSingleton<T> where T:GameState<T>, IGameState
{
	public abstract EGameState Type{ get; }

	public override string ToString ()
	{
		return Type.ToString ();
	}

	public virtual void EnterState()
	{
		Debug.LogFormat ("Entering State: {0}", Me.name);
	}

	public virtual void ExitState()
	{
		Debug.LogFormat ("Leaving State: {0}", Me.name);
	}
}