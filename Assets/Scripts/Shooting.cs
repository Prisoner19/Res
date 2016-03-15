using UnityEngine;
using System.Collections;

public class Shooting : MonoBehaviour 
{
	public SpriteRenderer sprRnd;
	public Sprite spr_free;
	public Sprite spr_busy;

	private bool can_shoot;

	// Use this for initialization
	void Start () 
	{
		can_shoot = false;
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}

	public void Shoot()
	{
		if(can_shoot)
		{
			StartCoroutine(Fire_Weapon());
		}
	}

	private IEnumerator Fire_Weapon()
	{
		can_shoot = false;
		sprRnd.sprite = spr_busy;
		yield return new WaitForSeconds(2);
		can_shoot = true;
		sprRnd.sprite = spr_free;
	}
}
