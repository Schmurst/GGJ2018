using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeatherCode : MonoBehaviour, ITranmission
{
	public TransmissionType Type { get { return TransmissionType.weather; } }
	public enum WeatherType
	{
		sun,
		rain,
		snow,
		apocalyse,
	}

	public WeatherType weatherType;
	public int Temperature = 0;

	public int CalculateCode (int _val)
	{
		return 0;
	}
}
