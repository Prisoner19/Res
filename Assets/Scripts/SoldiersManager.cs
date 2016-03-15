using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SoldiersManager : MonoBehaviour 
{
	private static SoldiersManager instance;

	public List<Soldier> list_obj_soldiers;

	private Soldier obj_selected_soldier;

	// Use this for references
	void Awake()
	{
		instance = this;
	}

	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}

	public void Select_Soldier(int id)
	{
		Soldier obj_soldier = Get_Soldier_By_ID(id);

		if(obj_soldier != null)
		{
			if(obj_selected_soldier != null)
			{
				obj_selected_soldier.Set_As_Unselected();
			}

			obj_soldier.Set_As_Selected();
			obj_selected_soldier = obj_soldier;
		}
	}

	private Soldier Get_Soldier_By_ID(int id)
	{
		foreach(Soldier s in list_obj_soldiers)
		{
			if(s.ID == id)
			{
				return s;
			}
		}

		return null;
	}

	public Soldier Get_Seletected_Soldier()
	{
		return obj_selected_soldier;
	}

	public static SoldiersManager Instance 
	{
		get { return instance; }
	}
}
