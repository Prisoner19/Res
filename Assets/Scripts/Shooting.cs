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
			StartCoroutine(Fire_Weapon());
		}

		return success;
	}

	private void Reload_Weapon()
	{
		current_ammo = 6;
	}

	private IEnumerator Fire_Weapon()
	{
		can_shoot = false;
		Decrease_Ammo();
		obj_soldier.Get_Rendering().Change_To_Busy();

		yield return new WaitForSeconds(1);

		if(Is_Out_Of_Ammo())
		{
			obj_soldier.Get_Rendering().Change_To_Reloading();
			yield return new WaitForSeconds(2);
			Reload_Weapon();
		}

		obj_soldier.Get_Rendering().Change_To_Free();
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
