using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class CodeCalculator : MonoSingleton<CodeCalculator>
{
	public bool DidPlayerDecodeTransmissionSuccessfully()
	{
		var code = DecodeTransmission (RadioManager.Me.Day.Transmissions);
		Debug.LogFormat ("Correct Code: {0}", code);

		return true;
	}
		
	int DecodeTransmission (ITranmission[] _trans)
	{
//		_trans = _trans.OrderBy ();


		//date
		var date = CodeConfig.Me.GetDate();

		//news

		//weather

		//lotto

		//sport

		//rules

		return 0;
	}
}
