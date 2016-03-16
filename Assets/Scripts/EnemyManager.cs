using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemyManager : MonoBehaviour 
{
	private static EnemyManager instance;

	public GameObject pfb_enemy;

	private List<Enemy> list_obj_enemies;
	private bool can_spawn;

	// Use this for references
	void Awake()
	{
		instance = this;
	}

	// Use this for initialization
	void Start () 
	{
		can_spawn = true;
		list_obj_enemies = new List<Enemy>();
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
		yield return new WaitForSeconds(Random.Range(0.5f,0.7f));
		can_spawn = true;
	}

	private void Spawn_Enemy()
	{
		GameObject go_enemy = GameObject.Instantiate(pfb_enemy);

		int rand = Random.Range(1, 5);
		Vector3 enemy_position = Vector3.zero;

		switch(rand)
		{
			case 1: enemy_position = new Vector3(1100,350); break;
			case 2: enemy_position = new Vector3(1100,150); break;
			case 3: enemy_position = new Vector3(1100,-50); break;
			case 4: enemy_position = new Vector3(1100,-250); break;
		}

		go_enemy.transform.position = enemy_position;
		list_obj_enemies.Add(go_enemy.GetComponent<Enemy>());
	}

	public static EnemyManager Instance 
	{
		get { return instance; }
	}
}
