using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TransitionGameState : GameState<TransitionGameState>, IGameState
{
	public override EGameState Type { get { return EGameState.transition; } }

	public System.Action OnComplete;
	public System.Action OnFaded;

	public Image m_mask;
	public float fadeSecs = 2f;
	public float holdSecs = 2f;
	public float FulUpPos;
	public float FulDownPos;
	bool isForceDown = false;

	// -------------------------------------------------------------------------------------------
	public void ForceDown()
	{
		isForceDown = true;
	}

	// -------------------------------------------------------------------------------------------
	public override void EnterState ()
	{
		base.EnterState ();
		StartCoroutine (Co_Transition ());
	}

	// -------------------------------------------------------------------------------------------
	IEnumerator Co_Transition()
	{
		float pcnt = 1;
		m_mask.enabled = true;
		m_mask.raycastTarget = true;

		if (!isForceDown)
		{
			while (pcnt > 0f)
			{
				m_mask.color = new Color (pcnt, pcnt, pcnt);
				pcnt -= Time.deltaTime / fadeSecs;
				yield return null;
			}
		}

		m_mask.color = Color.white;
		pcnt = 0f;

		isForceDown = false;
		while (pcnt < 1f)
		{
			m_mask.color = new Color (pcnt, pcnt, pcnt);
			pcnt += Time.deltaTime / fadeSecs;
			yield return null;
		}

		m_mask.color = Color.clear;
		m_mask.enabled = false;
		m_mask.raycastTarget = false;
	}

	// -------------------------------------------------------------------------------------------
	public override void ExitState ()
	{
		base.ExitState ();

	}
}
