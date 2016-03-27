using UnityEngine;
using System.Collections;

public enum SoldierState
{
	Idle,
	Shooting,
	Reloading
}

public class Soldier : MonoBehaviour 
{
	public int ID;

	private Rendering obj_rendering;
	private Attacking obj_attacking;
	private SoldierSound obj_sound_player;

	private SoldierState current_state;

	// Use this for references
	void Awake()
	{
		obj_rendering = gameObject.GetComponent<Rendering>();
		obj_attacking = gameObject.GetComponent<Attacking>();
		obj_sound_player = gameObject.GetComponent<SoldierSound>();
	}

	// Use this for initialization
	void Start () 
	{
		current_state = SoldierState.Idle;
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}

	public Rendering Get_Rendering()
	{
		return obj_rendering;
	}

	public Attacking Get_Attacking()
	{
		return obj_attacking;
	}

	public SoldierSound Get_Sound_Player()
	{
		return obj_sound_player;
	}

	public SoldierState Get_State()
	{
		return current_state;
	}

	public void Set_State(SoldierState state)
	{
		current_state = state;
	}

	public void Set_As_Selected()
	{
		obj_rendering.Change_To_Selected();
	}

	public void Set_As_Unselected()
	{
		obj_rendering.Change_To_Unselected();
	}
}
