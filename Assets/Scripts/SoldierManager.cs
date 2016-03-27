using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SoldierManager : MonoBehaviour 
{
	private static SoldierManager instance;

	public List<Soldier.Info> list_obj_soldiers;

	private Soldier.Info obj_selected_soldier;

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

	public Soldier.Info Get_Closest_Idle_Soldier(Vector3 enemy_position)
	{
		Soldier.Info obj_closest_soldier = null;
		float min_distance = float.MaxValue;

		foreach(Soldier.Info s in list_obj_soldiers)
		{
			if(s.Get_State() == SoldierState.Idle)
			{
				float d = Vector3.Distance(s.gameObject.transform.position, enemy_position);

				if(d < min_distance)
				{
					min_distance = d;
					obj_closest_soldier = s;
				}
			}
		}

		return obj_closest_soldier;
	}

	public Soldier.Info Get_Random_Idle_Soldier()
	{
		if(Is_Any_Soldier_Idle() == true)
		{
			Soldier.Info obj_random_soldier = null;
			int rand = Random.Range(0,list_obj_soldiers.Count);

			do
			{
				rand = Random.Range(0,list_obj_soldiers.Count);
				obj_random_soldier = list_obj_soldiers[rand];
			}
			while(obj_random_soldier.Get_State() != SoldierState.Idle);

			return obj_random_soldier;
		}

		return null;
	}

	public bool Is_Any_Soldier_Idle()
	{
		for(int i=0; i < list_obj_soldiers.Count; i++)
		{
			if(list_obj_soldiers[i].Get_State() == SoldierState.Idle)
			{
				return true;
			}
		}

		return false;
	}

	public void Select_Soldier(int id)
	{
		Soldier.Info obj_soldier = Get_Soldier_By_ID(id);

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

	private Soldier.Info Get_Soldier_By_ID(int id)
	{
		foreach(Soldier.Info s in list_obj_soldiers)
		{
			if(s.ID == id)
			{
				return s;
			}
		}

		return null;
	}

	public Soldier.Info Get_Seletected_Soldier()
	{
		return obj_selected_soldier;
	}

	public static SoldierManager Instance 
	{
		get { return instance; }
	}
}
