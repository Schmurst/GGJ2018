using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class GameManager : MonoSingleton<GameManager>
{
	public static bool IS_DEBUG = true;

	public EGameState PrevState { get ; protected set; }
	public EGameState State { get { return m_currentState != null ? m_currentState.Type : EGameState.nullOrLength; } }

	public float InitialWait = 5f;

	IGameState m_currentState;

	// -------------------------------------------------------------------------------------------
	void Start()
	{
		TransitionGameState.Me.ForceDown ();
		TransitionGameState.Me.OnComplete = () => {SetState (RadioGameState.Me);};
		SetState(TransitionGameState.Me);
	}

	// -------------------------------------------------------------------------------------------
	IEnumerator Co_WaitThenDo(float _secs, System.Action _do)
	{
		yield return new WaitForSeconds (_secs);
		_do ();
	}

	// -------------------------------------------------------------------------------------------
	void StartGame()
	{
		SetState (IntroGameState.Me);
	}

	// -------------------------------------------------------------------------------------------
	public void SetState(IGameState _state)
	{
		PrevState = State;
		_state.EnterState ();
		m_currentState = _state;
	}

	// -------------------------------------------------------------------------------------------
	[CustomEditor(typeof(GameManager))]	
	public class GameManagerEditor : Editor
	{
		GameManager me;
		public override bool RequiresConstantRepaint (){return true;}
		public override void OnInspectorGUI ()
		{
			if (!Application.isPlaying)
			{
				DrawDefaultInspector ();
				return;
			}
			
			if (me == null)
				me = GameManager.Me;
			if (me == null)
				return;

			if (GUILayout.Button("Start Intro"))
				me.StartGame ();
			if (GUILayout.Button ("Skip Track"))
				AudioManager.Me.Debug_SkipAudio ();

			string msg = string.Format ("State: {0}", me.m_currentState != null ? 
				me.m_currentState.ToString() : "None");
			EditorGUILayout.LabelField (msg);
		}
	}
}