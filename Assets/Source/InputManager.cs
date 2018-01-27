using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoSingleton<InputManager>
{
	void Update ()
	{

		//Debug Start
		if (Input.GetKey(KeyCode.RightAlt))
		{
			if (Input.GetKeyUp (KeyCode.P))
				GameManager.Me.SetState (IntroGameState.Me);
		}
	}
}
