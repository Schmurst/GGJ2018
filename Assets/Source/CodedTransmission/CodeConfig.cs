using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
#if UNITY_EDITOR
using UnityEditor;
#endif

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

	public int DateStart = 25; //25th Feb

	//[Header("Misc")]	

	[Header("News")]	
	[SerializeField] OperationType NewsWarOp;
	[SerializeField] OperationType NewsZarotOp;
	[SerializeField] int NewsZarotVal;
	[SerializeField] OperationType NewsTeamOp;
	[SerializeField] int NewsTeamVal;
	[SerializeField] OperationType NewsDavidOp;

	[Header("Weather")]	
	[SerializeField] OperationType WeatherRainOp;
	[SerializeField] OperationType WeatherSnowOp;
	[SerializeField] OperationType WeatherSunOp;

	[Header("Lotto")]
	[SerializeField] OperationType LottoAdd3rdOp;
	[SerializeField] OperationType LottoLastIsEvenOp;
	[SerializeField] OperationType LottoIfRepeated;

	[Header("Sport")]
	[SerializeField] OperationType SportScoreDiffOp;
	[SerializeField] OperationType SportTeamOp;
	[SerializeField] int SportTeamVal;
	[SerializeField] OperationType SportSoloOp;
	[SerializeField] int SportSoloVal;

	// -------------------------------------------------------------------------------------------
	public int GetDate()
	{
		int val = DateStart + RadioManager.Me.DayIdx + RadioManager.Me.WeekIdx * 7;
		if (val >= 30)
			val -= 29;

		return val;
	}

	// -------------------------------------------------------------------------------------------
	void Calculate (OperationType _type, ref int _result, int _value)
	{
		switch (_type)
		{
		case OperationType.plus:
			_result += _value;
			break;
		case OperationType.minus:
			_result -= _value;
			break;
		case OperationType.mult:
			_result *= _value;
			break;
		case OperationType.reverse:
			_result = int.Parse(new string(_result.ToString().Reverse().ToArray()));
			break;
		case OperationType.david:
			char[] digets = _result.ToString ().ToCharArray ();
			_result = 0;
			for (int i = 0; i < digets.Length; i++)
				_result += int.Parse (new string (new char[] {digets [i]}));
			break;
		}
	}

	// -------------------------------------------------------------------------------------------
	public void Calculate(NewsCode.NewsType _type, ref int _result)
	{
		switch (_type)
		{
		case NewsCode.NewsType.WarEffort:
			Calculate (NewsWarOp, ref _result, CodeConfig.Me.GetDate());
			break;
		case NewsCode.NewsType.Zarot:
			Calculate (NewsZarotOp, ref _result, NewsZarotVal);
			break;
		case NewsCode.NewsType.Teamwork:
			Calculate (this.NewsTeamOp, ref _result, NewsTeamVal);
			break;
		case NewsCode.NewsType.David:
			Calculate (this.NewsDavidOp, ref _result, 0);
			break;
		}
	}

	// -------------------------------------------------------------------------------------------
	public void Calculate(WeatherCode.WeatherType _type, ref int _result, int _temp)
	{
		switch (_type)
		{
		case WeatherCode.WeatherType.sun:
			Calculate (WeatherSunOp, ref _result, _temp);
			break;
		case WeatherCode.WeatherType.rain:
			Calculate (WeatherRainOp, ref _result, _temp);
			break;
		case WeatherCode.WeatherType.snow:
			Calculate (WeatherSnowOp, ref _result, _temp);
			break;
		case WeatherCode.WeatherType.apocalyse:
			_result = 15;
			break;
		}
	}

	// -------------------------------------------------------------------------------------------
	public void Calculate(SportCode.SportType _type, ref int _result, int _value)
	{
		switch (_type)
		{
		case SportCode.SportType.multbyDiff:
			Calculate (SportScoreDiffOp, ref _result, _value);
			break;
		case SportCode.SportType.teamSport:
			Calculate (_value >= 0 ? SportTeamOp : SportSoloOp, ref _result, 
				_value >= 0 ? SportTeamVal : SportSoloVal);
			break;
		case SportCode.SportType.zarot:
			Calculate (NewsZarotOp, ref _result, NewsZarotVal);
			break;
		}
	}

	// -------------------------------------------------------------------------------------------
	public void Calculate(LottoCode.LottoType _type, ref int _result, int[] _values)
	{
		switch (_type)
		{
		case LottoCode.LottoType.add3rd:
			Calculate (LottoAdd3rdOp, ref _result, _values [2]);
			break;
		case LottoCode.LottoType.lastIsEven:
			if ((_values [5] & 1) == 0)
				Calculate (LottoLastIsEvenOp, ref _result, _values [5]);
			break;
		case LottoCode.LottoType.repeated:
			var sortedValues = _values.OrderBy(x=>{return x;}).ToArray();
			for (int i = 0; i < sortedValues.Length-1; i++)
			{
				if (sortedValues [i] == sortedValues [i + 1])
				{
					Calculate (OperationType.reverse, ref _result, 0);
					break;
				}
			}
			break;
		}
	}

	#if UNITY_EDITOR
	// -------------------------------------------------------------------------------------------
	[CustomEditor(typeof(CodeConfig))]	
	public class CodeConfigEditor : Editor
	{
		CodeConfig me;
		public override bool RequiresConstantRepaint (){return true;}
		public override void OnInspectorGUI ()
		{
			if (me == null)
				me = CodeConfig.Me;
			if (me == null)
				return;

			if (GUILayout.Button("Test Date"))
			{
				Debug.LogErrorFormat("date:{0}", me.GetDate ());
			}
			DrawDefaultInspector ();
		}
	}
	#endif
}