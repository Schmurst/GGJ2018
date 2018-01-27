using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoSingleton<InputManager>
{
	void Update ()
	{
		UpdateDebug ();
	}

	void UpdateDebug()
	{
		if (Input.GetKey(KeyCode.RightAlt) && GameManager.IS_DEBUG)
		{
			if (Input.GetKeyUp (KeyCode.P))
				GameManager.Me.SetState (IntroGameState.Me);
			
			if (Input.GetKeyUp (KeyCode.L))
				AudioManager.Me.Debug_SkipAudio ();
		}
	}
}

