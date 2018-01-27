using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class GameManager : MonoSingleton<GameManager>
{
	public enum EGameState
	{
		intro,
		radio,
		code,
		transition,
		outro
	}

	public EGameState State { get; protected set; }

	// -------------------------------------------------------------------------------------------
	[CustomEditor(typeof(GameManager))]	
	public class GameManagerEditor : Editor
	{
		GameManager me;
		public override void OnInspectorGUI ()
		{
			if (me == null)
				me = GameManager.Me;
			if (me == null)
				return;

			EditorGUILayout.LabelField ("State: ", me.State.ToString());
		}
	}
}