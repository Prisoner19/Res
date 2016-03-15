using UnityEngine;
using System.Collections;

public class Soldier : MonoBehaviour 
{
	public int ID;

	private Rendering obj_rendering;
	private Shooting obj_shooting;

	// Use this for references
	void Awake()
	{
		obj_rendering = gameObject.GetComponent<Rendering>();
		obj_shooting = gameObject.GetComponent<Shooting>();
	}

	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}

	public Rendering Get_Rendering()
	{
		return obj_rendering;
	}

	public Shooting Get_Shooting()
	{
		return obj_shooting;
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
