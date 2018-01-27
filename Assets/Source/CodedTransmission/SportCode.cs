using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SportCode : MonoBehaviour, ICodedTranmission
{
	public enum SportType
	{
		multbyDiff,
		teamSport,
	}

	public SportType Type;
	public int CalculateCode (int _val)
	{
		return 0;
	}
}