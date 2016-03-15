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
				SoldiersManager.Instance.Select_Soldier(go_soldier.GetComponent<Soldier>().ID);
			}

			if(InputTracker.Get_Object_Under_Mouse("Enemy"))
			{
				if(SoldiersManager.Instance.Get_Seletected_Soldier() != null)
				{
					bool success = SoldiersManager.Instance.Get_Seletected_Soldier().Get_Shooting().Try_To_Shoot();

					if(success)
					{
						InputTracker.Get_Object_Under_Mouse("Enemy").GetComponent<Enemy>().Get_Killed();
					}
				}
			}
		}
	}

	private void Check_Key_Input()
	{
		if(InputTracker.Has_Pressed_Key(KeyCode.Alpha1))
		{
			SoldiersManager.Instance.Select_Soldier(1);
		}
		else if(InputTracker.Has_Pressed_Key(KeyCode.Alpha2))
		{
			SoldiersManager.Instance.Select_Soldier(2);
		}
		else if(InputTracker.Has_Pressed_Key(KeyCode.Alpha3))
		{
			SoldiersManager.Instance.Select_Soldier(3);
		}
		else if(InputTracker.Has_Pressed_Key(KeyCode.Alpha4))
		{
			SoldiersManager.Instance.Select_Soldier(4);
		}
	}
}
