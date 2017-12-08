using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShockGate : MonoBehaviour {
    public Animator anim;
    public float timer;

    public Collider2D col;
    public GameObject player;

    public AudioSource song;
	// Use this for initialization
	void Start () {
        song = GetComponent<AudioSource>();
        player = GameObject.FindGameObjectWithTag("Player");
        anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (player.transform.position.y >= transform.position.y - 6 && player.transform.position.y < transform.position.y + 6)
            {
                anim.SetFloat("Time", timer);

                timer += Time.deltaTime;

                if (timer > 4)
                    timer = 0;

                if (timer < 1)
                {
                    col.enabled = false;
                    song.Play();
                }
                if (timer >= 1)
                    {
                        col.enabled = true;
                    }
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<Animator>().SetBool("Dead", true);
        }
    }
}
