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

	static int DateStart = 25; //25th Feb

	//[Header("Misc")]	

	[Header("News")]	
	[SerializeField] OperationType NewsWarOp;
	[SerializeField] OperationType NewsZarotOp;
	[SerializeField] int NewsZarotVal;
	[SerializeField] OperationType NewsTeamOp;
	[SerializeField] int NewsTeamVal;
	[SerializeField] OperationType NewsDavidOp;
	[SerializeField] int NewsDavidVal;

	[Header("Weather")]	
	[SerializeField] OperationType WeatherRainOp;
	[SerializeField] OperationType WeatherSnowOp;
	[SerializeField] OperationType WeatherSunOp;
	[SerializeField] OperationType WeatherApocOp;

	[Header("Lotto")]
	[SerializeField] OperationType LottoAdd3rdOp;
	[SerializeField] OperationType LottoLastIsEvenOp;
	[SerializeField] int LottoLastIsEvenVal;
	[SerializeField] OperationType LottoIfRepeated;

	[Header("Sport")]
	[SerializeField] OperationType SportScoreDiffOp;
	[SerializeField] OperationType SportTeamOp;
	[SerializeField] OperationType SportSoloOp;

	public int GetDate()
	{
		return (DateStart + RadioManager.Me.WeekIdx * 7 + RadioManager.Me.DayIdx) % 30;
	}



}