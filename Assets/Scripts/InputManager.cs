using UnityEngine;
using System.Collections;

public class InputManager : MonoBehaviour 
{
	// Use this for references
	void Awake()
	{

	}

	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		Check_Mouse_Input();
		Check_Key_Input();
	}

	private void Check_Mouse_Input()
	{
		if(InputTracker.Has_Clicked(Mouse_Button.Left))
		{
			if(InputTracker.Get_Object_Under_Mouse("Soldier"))
			{
				GameObject go_soldier = InputTracker.Get_Object_Under_Mouse("Soldier");
				SoldierManager.Instance.Select_Soldier(go_soldier.GetComponent<Soldier>().ID);
			}

			GameObject go_enemy_clicked = InputTracker.Get_Object_Under_Mouse("Enemy");

			if(go_enemy_clicked != null)
			{
				Soldier obj_random_idle_soldier = SoldierManager.Instance.Get_Random_Idle_Soldier();

				if(obj_random_idle_soldier != null)
				{
					SoldierManager.Instance.Select_Soldier(obj_random_idle_soldier.ID);
					bool success = obj_random_idle_soldier.Get_Attacking().Attack(go_enemy_clicked.transform.position);

					if(success)
					{
						go_enemy_clicked.GetComponent<Enemy>().Get_Killed();
					}
				}

			}
		}
	}

	private void Check_Key_Input()
	{
		if(InputTracker.Has_Pressed_Key(KeyCode.Alpha1))
		{
			SoldierManager.Instance.Select_Soldier(1);
		}
		else if(InputTracker.Has_Pressed_Key(KeyCode.Alpha2))
		{
			SoldierManager.Instance.Select_Soldier(2);
		}
		else if(InputTracker.Has_Pressed_Key(KeyCode.Alpha3))
		{
			SoldierManager.Instance.Select_Soldier(3);
		}
		else if(InputTracker.Has_Pressed_Key(KeyCode.Alpha4))
		{
			SoldierManager.Instance.Select_Soldier(4);
		}
	}
}
