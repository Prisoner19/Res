using UnityEngine;
using System.Collections;

public class SoldierSound : MonoBehaviour 
{
	private Soldier.Info obj_soldier;

	public AudioClip snd_shot_1;
	public AudioClip snd_shot_2;
	public AudioClip snd_knife;
	public AudioClip snd_reload;

	private AudioSource[] comp_audio_sources;

	void Awake()
	{
		obj_soldier = gameObject.GetComponent<Soldier.Info>();
	}

	// Use this for initialization
	void Start () 
	{
		comp_audio_sources = gameObject.GetComponents<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}

	public void Play_Shot_Sound()
	{
		if(Random.Range(0f, 1f) < 0.5)
		{
			comp_audio_sources[0].PlayOneShot(snd_shot_1);
		}
		else
		{
			comp_audio_sources[0].PlayOneShot(snd_shot_1);
		}
	}

	public void Play_Knife_Sound()
	{
		comp_audio_sources[0].PlayOneShot(snd_knife);
	}

	public void Play_Reload_Sound()
	{
		comp_audio_sources[0].PlayOneShot(snd_reload);
	}
}
