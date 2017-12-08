using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour {
	public bool grounded;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	}

	public void OnCollisionEnter2D(Collision2D col)
	{
		grounded = true;
	}

	public void OnCollisionExit2D(Collision2D col)
	{
		grounded = false;
	}
}
