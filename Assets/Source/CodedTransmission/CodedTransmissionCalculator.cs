using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CodedTransmissionCalculator : MonoSingleton<CodedTransmissionCalculator>
{
	public bool DidPlayerDecodeTransmissionSuccessfully()
	{
		var code = DecodeTransmission (RadioManager.Me.Day.Transmissions);
		Debug.LogFormat ("Correct Code: {0}", code);

		return true;
	}
		
	int DecodeTransmission (ICodedTranmission[] _trans)
	{
		return 0;
	}
}
