using UnityEngine;
using System.Collections;

public class Rendering : MonoBehaviour 
{
	private Soldier obj_soldier;

	private SpriteRenderer sprRnd;
	private Sprite spr_free;
	private Sprite spr_busy;
	private Sprite spr_reloading;

	private SpriteRenderer sprRnd_marker;

	// Use this for references
	void Awake()
	{
		obj_soldier = gameObject.GetComponent<Soldier>();
		sprRnd = gameObject.GetComponent<SpriteRenderer>();
		sprRnd_marker = gameObject.transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>();
	}

	// Use this for initialization
	void Start () 
	{
		Load_Sprites();
		Change_To_Free();
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}

	private void Load_Sprites()
	{
		spr_free = Resources.Load<Sprite>("Sprites/spr_sold_" + obj_soldier.ID + "_free");
		spr_busy = Resources.Load<Sprite>("Sprites/spr_sold_" + obj_soldier.ID + "_busy");
		spr_reloading = Resources.Load<Sprite>("Sprites/spr_sold_" + obj_soldier.ID + "_reloading");
	}

	public void Change_To_Busy()
	{
		sprRnd.sprite = spr_busy;
	}

	public void Change_To_Free()
	{
		sprRnd.sprite = spr_free;
	}

	public void Change_To_Reloading()
	{
		sprRnd.sprite = spr_reloading;
	}

	public void Change_To_Selected()
	{
		sprRnd_marker.enabled = true;
	}

	public void Change_To_Unselected()
	{
		sprRnd_marker.enabled = false;
	}
}
