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
	public float fadeSecs = 1f;
	public float holdSecs = 1f;
	public float FulUpPos;
	public float FulDownPos;
	bool isForceDown = false;

	// -------------------------------------------------------------------------------------------
	void Awake()
	{
		m_mask.color = Color.black;
	}

	// -------------------------------------------------------------------------------------------
	public void ForceDown()
	{
		isForceDown = true;
	}

	// -------------------------------------------------------------------------------------------
	bool exit = false;
	public void ForceExit()
	{
		exit = true;
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
		float pcnt = 0f;
		m_mask.enabled = true;
		m_mask.raycastTarget = true;

		if (!isForceDown)
		{
			while (pcnt < 1f)
			{
				m_mask.color = new Color (0f, 0f, 0f, pcnt);
				pcnt += Time.deltaTime / fadeSecs;
				yield return null;
				m_mask.color = Color.black;
				if (exit)
					goto END;
			}
		}
		else
		{
			m_mask.color = Color.black;
		}
			
		pcnt = 1f;

		if (OnFaded != null)
			OnFaded ();
		OnFaded = null;

		isForceDown = false;
		while (pcnt > 0f)
		{
			m_mask.color = new Color(0f, 0f, 0f, pcnt);
			pcnt -= Time.deltaTime / fadeSecs;
			yield return null;
			m_mask.color = Color.black;
			if (exit)
				goto END;
		}

		END:
		exit = false;
		m_mask.enabled = false;
		m_mask.raycastTarget = false;

		if (OnComplete != null)
			OnComplete ();
		OnComplete = null;
	}

	// -------------------------------------------------------------------------------------------
	public override void ExitState ()
	{
		base.ExitState ();

	}
}
