using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class FinalGate : MonoBehaviour {
    public GameManager manager;
    public GameObject winImage;

    public AudioSource songWin;
    public AudioSource songOpen;

    public Animator anim;
    public float timer;
    public bool start;
    // Use this for initialization
    void Start () {
        anim = GetComponent<Animator>();
        manager = GameObject.Find("GameManager").GetComponent<GameManager>();
        //winImage = GameObject.Find("Win");
        winImage.SetActive(false);

    }
	
	// Update is called once per frame
	void Update () {
        if (start == true)
            timer += Time.deltaTime;

		if(timer >= 0.6f)
        {
            anim.SetBool("Opened", true);
        }
	}

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && timer < 0.6f)
        {
            anim.SetBool("Open", true);
            start = true;
            songOpen.Play();
        }

        if (collision.gameObject.tag == "Player" && timer >= 0.8f)
        {
            songWin.Play();
            Destroy(collision.gameObject);
            winImage.SetActive(true);
            manager.cavePass = 0;
            manager.Save();
        }
    }

    public void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && timer >= 0.8f)
        {
            songWin.Play();
            Destroy(collision.gameObject);
            winImage.SetActive(true);
            manager.cavePass = 0;
            manager.Save();
        }
    }
}
