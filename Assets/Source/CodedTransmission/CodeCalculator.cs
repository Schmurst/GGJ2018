using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CodeCalculator : MonoSingleton<CodeCalculator>
{
	public bool DidPlayerDecodeTransmissionSuccessfully()
	{
		var code = DecodeTransmission (RadioManager.Me.Day.Transmissions);
		Debug.LogFormat ("Correct Code: {0}", code);

		return true;
	}
		
	int DecodeTransmission (ICodedTranmission[] _trans)
	{
		// Get Date


		return 0;
	}
}
