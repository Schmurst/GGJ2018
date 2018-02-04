using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class DraggableGUI : MonoBehaviour
{
	enum InputState
	{
		nothing,
		hover,
		grabbed
	}

	static float s_grabScale = 1.05f;
	static Color s_hoverTint = new Color(0.9f, 0.9f, 0.9f);

	[SerializeField] Image m_img;

	public Vector2 SpawnPoint;

	InputState m_state;
	Vector2 m_grabPosOffset;

	void Start()
	{
		DraggableGUIManager.Me.RegisterDraggable (this);
	}

	public void OnPointerEnter()	{m_state = InputState.hover;}
	public void DeSelect()			{m_state = InputState.nothing;}
	public void OnPointerExit()		{m_state = InputState.nothing;}
	public void OnPointerUp()		{m_state = InputState.nothing;}
	public void OnPointerDown()	
	{
		m_state = InputState.grabbed;
		Debug.LogFormat ("MousePos: {0}", Input.mousePosition);
		m_grabPosOffset = this.transform.position - Input.mousePosition;
		transform.SetAsLastSibling ();
	}

	void Update()
	{
		switch (m_state)
		{
		default:
		case InputState.nothing:
			m_img.color = Color.white;
			transform.localScale = Vector3.one;
			return;
		case InputState.hover:
			m_img.color = s_hoverTint;
			transform.localScale = Vector3.one;
			break;
		case InputState.grabbed:
			m_img.color = s_hoverTint;
			transform.position = m_grabPosOffset + (Vector2)Input.mousePosition;
			transform.localScale = Vector3.one * s_grabScale;
			break;
		}
	}
}