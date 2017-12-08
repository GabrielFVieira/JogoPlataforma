using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {
    public AudioSource song;

    public float velocity;
    public GameManager menu;
	// Use this for initialization
	void Start () {
		velocity = 15.5f;

        song = GameObject.Find("LevelManager").GetComponent<AudioSource>();	
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate (velocity * Time.deltaTime, 0, 0);

		if (transform.position.x > 150 || transform.position.x < -50f)
			Destroy (gameObject);
	}

	public void OnCollisionEnter2D(Collision2D col)
	{
		if (col.gameObject.tag == "Player" && col.gameObject.GetComponent<Animator>().GetBool("Dead") == false) 
		{
            song.Play();
            col.gameObject.GetComponent<Animator>().SetBool("Dead", true);
            col.gameObject.GetComponent<PlayerDeath>().controle = false;
            col.gameObject.GetComponent<PlayerDeath>().deathTime = 2;
            Destroy(gameObject);
        }

		if (col.gameObject.tag == "Untagged") 
		{
			Destroy (gameObject);
		}
	}
}
