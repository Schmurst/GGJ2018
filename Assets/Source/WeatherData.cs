using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeatherData : MonoBehaviour, ICodedTranmission
{
	public enum WeatherType
	{
		sun,
		rain,
		snow,
		apocalyse,
	}

	public WeatherType Type;
	public int Temperature = 0;

	public int CalculateCode (int _val)
	{
		return 0;
	}
}