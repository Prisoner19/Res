using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class EnemyManager : MonoBehaviour 
{
	private static EnemyManager instance;

	public GameObject pfb_enemy;

	private List<Enemy.Info> list_obj_enemies;
	private GameObject go_enemy_container;
	private bool can_spawn;

	// Use this for references
	void Awake()
	{
		instance = this;
	}

	// Use this for initialization
	void Start () 
	{
		Debug.Log(System.Environment.Version);
		can_spawn = true;
		list_obj_enemies = new List<Enemy.Info>();
		go_enemy_container = GameObject.Find("Enemies");
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(can_spawn)
		{
			StartCoroutine(Enemy_Spawning());
		}
	}

	private IEnumerator Enemy_Spawning()
	{
		can_spawn = false;
		Spawn_Enemy();
		yield return new WaitForSeconds(UnityEngine.Random.Range(0.4f,0.6f));
		can_spawn = true;
	}

	private void Spawn_Enemy()
	{
		GameObject go_enemy = GameObject.Instantiate(pfb_enemy);

		int rand = UnityEngine.Random.Range(1, 5);
		Vector3 enemy_position = Vector3.zero;

		switch(rand)
		{
			case 1: enemy_position = new Vector3(1100,370); break;
			case 2: enemy_position = new Vector3(1100,150); break;
			case 3: enemy_position = new Vector3(1100,-50); break;
			case 4: enemy_position = new Vector3(1100,-250); break;
		}

		go_enemy.name = "Enemy";
		go_enemy.transform.position = enemy_position;
		go_enemy.transform.parent = go_enemy_container.transform;
		list_obj_enemies.Add(go_enemy.GetComponent<Enemy.Info>());
	}

	public static EnemyManager Instance 
	{
		get { return instance; }
	}
}
