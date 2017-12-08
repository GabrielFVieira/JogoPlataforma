using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class Music : MonoBehaviour {
    public bool controle;
    public AudioSource song;
    // Use this for initialization
    void Start () {
        song = GetComponent<AudioSource>();
        controle = true;
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Player" && controle == true)
        {
            song.Play();
            controle = false;
        }
    }

}
