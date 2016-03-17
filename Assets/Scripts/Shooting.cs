using UnityEngine;
using System.Collections;

public class Shooting : MonoBehaviour 
{
	private Soldier obj_soldier;

	private int current_ammo;
	private bool can_shoot;

	void Awake()
	{
		obj_soldier = gameObject.GetComponent<Soldier>();
	}

	void Start () 
	{
		can_shoot = true;
		current_ammo = 6;
	}
	
	void Update () 
	{
	
	}

	public bool Try_To_Shoot()
	{
		bool success = can_shoot;

		if(can_shoot)
		{
			Start_To_Fire_Weapon();
		}

		return success;
	}
		
	private void Start_To_Fire_Weapon()
	{
		can_shoot = false;
		obj_soldier.Get_Rendering().Change_To_Shooting();
	}

	private void Fire_Weapon()
	{
		Decrease_Ammo();
	}

	private void Finish_Firing_Weapon()
	{
		if(Is_Out_Of_Ammo())
		{
			Reload_Weapon();
		}
		else
		{
			obj_soldier.Get_Rendering().Change_To_Idle();
			can_shoot = true;
		}
	}

	private void Reload_Weapon()
	{
		obj_soldier.Get_Rendering().Change_To_Reloading();
	}

	private void Finish_Reloading_Weapon()
	{
		current_ammo = 6;
		obj_soldier.Get_Rendering().Change_To_Idle();
		can_shoot = true;
	}

	private void Decrease_Ammo()
	{
		current_ammo = (current_ammo > 0) ? current_ammo - 1 : 0;
	}

	private bool Is_Out_Of_Ammo()
	{
		return (current_ammo == 0);
	}
}
