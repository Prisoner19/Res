using UnityEngine;
using System.Collections;

public class Shooting : MonoBehaviour 
{
	private Soldier obj_soldier;

	private bool can_shoot;

	void Awake()
	{
		obj_soldier = gameObject.GetComponent<Soldier>();
	}

	void Start () 
	{
		can_shoot = true;
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

	private IEnumerator Fire_Weapon()
	{
		can_shoot = false;
		obj_soldier.Get_Rendering().Change_To_Busy();
		yield return new WaitForSeconds(2);
		obj_soldier.Get_Rendering().Change_To_Free();
		can_shoot = true;
	}
}
