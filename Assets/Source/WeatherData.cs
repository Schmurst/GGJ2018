using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeatherData : MonoBehaviour
{
	public enum weatherType
	{
		sunny,
		rain,
		fog,
		cloud
	}

	public weatherType type;
}
