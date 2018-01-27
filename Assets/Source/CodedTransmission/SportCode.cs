using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SportCode : MonoBehaviour, ITranmission
{
	public TransmissionType Type { get { return TransmissionType.sport; } }
	public enum SportType
	{
		multbyDiff,
		teamSport,
	}

	public SportType sportType;
	public int CalculateCode (int _val)
	{
		return 0;
	}
}