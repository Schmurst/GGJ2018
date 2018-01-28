using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DraggableGUIManager : MonoSingleton<DraggableGUIManager>
{
	List<DraggableGUI> m_draggables;
	DraggableGUI m_current;

	[SerializeField] GameObject m_codeBook1;
	[SerializeField] GameObject m_codeBook2;
	[SerializeField] GameObject m_codeBook3;
	[SerializeField] RectTransform m_parent;

	public override void Init ()
	{
		m_draggables = new List<DraggableGUI> ();
	}

	public void RegisterDraggable(DraggableGUI _instance)
	{
		m_draggables.Add (_instance);
	}

	public void Select(DraggableGUI _selected)
	{
		if (m_current != null)
			m_current.DeSelect ();
		m_current = _selected;
	}

	void Update()
	{
		if (Input.GetMouseButtonUp(0) && m_current != null)
		{
			m_current.DeSelect ();
			m_current = null;
		}
	}

	public void SpawnStartDraggables()
	{
		GameObject obj;
		DraggableGUI gui;

		var toSpawn = new List<GameObject> {m_codeBook1};

		foreach (var item in toSpawn)
		{
			obj = Instantiate<GameObject> (item, m_parent);
			gui = obj.GetComponent<DraggableGUI> ();
			((RectTransform)gui.transform).anchoredPosition = gui.SpawnPoint;
		}
	}
}