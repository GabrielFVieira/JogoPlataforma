using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ninja : MonoBehaviour {
    public DoorButton button;
    public Collider2D col;
    public AudioSource song;
    public bool controle;
	// Use this for initialization
	void Start () {
        song = GetComponent<AudioSource>();
        controle = true;
	}
	
	// Update is called once per frame
	void Update () {
        col.enabled = button.startTimer;

    }

    public void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "Player" && button.startTimer == true && controle == true)
        {
            song.Play();
            controle = false;
        }
    }
}
