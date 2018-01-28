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

	[SerializeField] GameObject post_it1;
	[SerializeField] GameObject post_it2;
	[SerializeField] GameObject post_it3;
	[SerializeField] GameObject post_it4;

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

	public void SpawnStartDraggables(int weekIdx)
	{
		GameObject obj;
		DraggableGUI gui;

		List<GameObject> toSpawn;
		if (weekIdx == 0)
			toSpawn = new List<GameObject> {m_codeBook1, post_it1, post_it2, post_it4};
		else if (weekIdx == 1)
			toSpawn = new List<GameObject> {m_codeBook2, post_it3};
		else
			toSpawn = new List<GameObject> {m_codeBook3};

		foreach (var item in toSpawn)
		{
			obj = Instantiate<GameObject> (item, m_parent);
			gui = obj.GetComponent<DraggableGUI> ();
			((RectTransform)gui.transform).anchoredPosition = gui.SpawnPoint;
		}
	}
}