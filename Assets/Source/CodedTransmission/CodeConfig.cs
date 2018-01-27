using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CodeConfig : MonoSingleton<CodeConfig>
{
	public enum OperationType
	{
		plus,
		minus,
		mult,
		reverse,
		david
	}

	[Header("News")]	
	[SerializeField] OperationType NewsWarOp;
	[SerializeField] OperationType NewsZarotOp;
	[SerializeField] int NewsZarotVal;
	[SerializeField] OperationType NewsTeamOp;
	[SerializeField] int NewsTeamVal;
	[SerializeField] OperationType NewsDavidOp;
	[SerializeField] int NewsDavidVal;

	[Header("Weather")]	
	[SerializeField] OperationType WeatherRain;
	[SerializeField] OperationType WeatherSnow;
	[SerializeField] OperationType WeatherSun;
	[SerializeField] OperationType WeatherApoc;

	[Header("Rules")]	
	[SerializeField] int SegmentCount2;
}