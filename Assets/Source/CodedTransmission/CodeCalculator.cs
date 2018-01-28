using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class CodeCalculator : MonoSingleton<CodeCalculator>
{
	// -------------------------------------------------------------------------------------------
	public bool DidPlayerDecodeTransmissionSuccessfully()
	{
		var code = DecodeTransmission (RadioManager.Me.Day.GetTransmissions());
		var playerInput = CodeInputController.Me.GetPlayerCode ();
		Debug.LogFormat ("Correct Code: {0}|Player Code: {1}", code, playerInput);

		return code == playerInput;
	}
		
	// -------------------------------------------------------------------------------------------
	int DecodeTransmission (ITranmission[] _trans)
	{
		_trans = _trans.OrderBy (x=>(int)x.Type).ToArray();

		var value = RadioManager.Me.WeekIdx * 7 + RadioManager.Me.DayIdx + 1;
		if (RadioManager.Me.WeekIdx > 0)
			value += 5;

		for (int i = 0; i < _trans.Length; i++)
		{
			var trans = _trans [i];
			Debug.LogFormat ("Code:{0}|{1}", i, trans.Type);

			switch (trans.Type)
			{
			case TransmissionType.news:
				DecodeNews (ref value, trans as NewsCode);
				break;
			case TransmissionType.weather:
				DecodeWeather (ref value, trans as WeatherCode);
				break;
			case TransmissionType.lotto:
				DecodeLotto (ref value, trans as LottoCode);
				break;
			case TransmissionType.sport:
				DecodeSport (ref value, trans as SportCode);
				break;
			}
		}

		//rules

		Debug.LogFormat ("<color=green>Code is {0}</color>", value);
		return value;
	}

	// -------------------------------------------------------------------------------------------
	void DecodeNews(ref int _value, NewsCode _code)
	{
		CodeConfig.Me.Calculate (_code.newsType, ref _value);
	}

	// -------------------------------------------------------------------------------------------
	void DecodeWeather(ref int _value, WeatherCode _code)
	{
		CodeConfig.Me.Calculate (_code.weatherType, ref _value, _code.Temperature);
	}

	// -------------------------------------------------------------------------------------------
	void DecodeSport(ref int _value, SportCode _code)
	{
		CodeConfig.Me.Calculate (_code.sportType, ref _value, _code.Value);
	}

	// -------------------------------------------------------------------------------------------
	void DecodeLotto(ref int _value, LottoCode _code)
	{
		CodeConfig.Me.Calculate (_code.lottoType, ref _value, _code.LottoNumbers);
	}
}
