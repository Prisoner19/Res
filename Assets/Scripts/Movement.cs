using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour 
{
	private Rigidbody2D comp_rigidbody;

	// Use this for references
	void Awake()
	{
		comp_rigidbody = gameObject.GetComponent<Rigidbody2D>();
	}

	// Use this for initialization
	void Start () 
	{
		comp_rigidbody.velocity = new Vector2(-400, 0);
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}
}
