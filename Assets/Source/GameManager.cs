using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class GameManager : MonoSingleton<GameManager>
{
	public EGameState State { get { return m_currentState != null ? m_currentState.Type : EGameState.nullOrLength; } }
	IGameState m_currentState;

	// -------------------------------------------------------------------------------------------
	void StartGame()
	{
		SetState (IntroGameState.Me);
	}

	// -------------------------------------------------------------------------------------------
	public void SetState(IGameState _state)
	{
		_state.EnterState ();
		m_currentState = _state;
	}

	// -------------------------------------------------------------------------------------------
	[CustomEditor(typeof(GameManager))]	
	public class GameManagerEditor : Editor
	{
		GameManager me;
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
			{
				me.StartGame ();
			}

			EditorGUILayout.LabelField ("State: ", me.State.ToString());
		}
	}
}