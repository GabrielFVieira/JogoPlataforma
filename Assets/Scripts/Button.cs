using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour {
    public Animator anim;
    public bool Pressed;
	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        anim.SetBool("Pressed", Pressed);
	}

    public void pressed(bool press)
    {
        Pressed = press;
    }
}
