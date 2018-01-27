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
		zarot
	}

	public SportType sportType;
	public int Value;
}