using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(AudioSource))]
public class EnemyAi : MonoBehaviour {
	public GameObject player;
	public float moveSpeed;
	public float maxDistance;

    public AudioSource song;

    public float timer;
    public bool start;
    public Animator anim;

    public Collider2D col;
	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
		moveSpeed = 4f;
		maxDistance = 8f;
		player = GameObject.FindGameObjectWithTag("Player");

        song = GetComponent<AudioSource>();
    }

	// Update is called once per frame
	void Update ()
	{
        if (anim.GetBool("Dead") == false)
        {
            //Look at target
            if (player.transform.position.x < transform.position.x)
            {
                transform.localEulerAngles = new Vector3(0, 180, 0);
            }

            if (player.transform.position.x > transform.position.x)
            {
                transform.localEulerAngles = new Vector3(0, 0, 0);
            }

            if (player.transform.position.y >= transform.position.y - 1 && player.transform.position.y < transform.position.y + 4)
            {
                if (player.transform.position.x + maxDistance > transform.position.x)
                {

                    if (player.transform.position.x < transform.position.x)
                    {
                        //Move towards target X
                        transform.Translate(moveSpeed * Time.deltaTime, 0, 0);
                        anim.SetBool("NearPlayer", true);
                    }
                }

                if (player.transform.position.x - maxDistance < transform.position.x)
                {
                    if (player.transform.position.x > transform.position.x)
                    {
                        //Move towards target X
                        transform.Translate(moveSpeed * Time.deltaTime, 0, 0);
                        anim.SetBool("NearPlayer", true);
                    }
                }
            }

            else
            {
                anim.SetBool("NearPlayer", false);
            }
        }
        if(start == true)
        {
            timer += Time.deltaTime;
        }

        if(timer > 1)
        {
            Destroy(gameObject);
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player" && start == false && player.GetComponent<Animator>().GetBool("Dead") == false)
        {
            anim.SetBool("Dead", true);
            col.isTrigger = true;
            transform.position = new Vector3(transform.position.x, transform.position.y - 0.3f, transform.position.z);
            GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
            start = true;
            song.Play();
        }
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player" && start == false)
        {
            player.GetComponent<Animator>().SetBool("Dead", true);
        }
    }
}
