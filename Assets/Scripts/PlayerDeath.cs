using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(AudioSource))]
public class PlayerDeath : MonoBehaviour {
    public bool start;
    public float timer;

    public float deathTime;

    public int random;
    public bool controle = true;

    public AudioSource song;
    public AudioSource song2;
    public AudioSource song3;

    public GameManager manager;
    // Use this for initialization
    void Start () {
        manager = GameObject.Find("GameManager").GetComponent<GameManager>();
        deathTime = 1;
    }
	
	// Update is called once per frame
	void Update () {
        if (GetComponent<Animator>().GetBool("Dead") == true)
        {
            GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
            transform.localScale = new Vector3(1.771533f, 1.771533f, 1);
            start = true;
            random = Random.Range(1, 4);
            manager.cavePass = 0;
            manager.Save();
        }

        if (random == 1 && controle == true)
        {
            song.Play();
            controle = false;
        }

        if (random == 2 && controle == true)
        {
            song2.Play();
            controle = false;
        }

        if (random == 3 && controle == true)
        {
            song3.Play();
            controle = false;
        }

        if (start == true)
            timer += Time.deltaTime;

        if (timer > deathTime)
        {
            manager.BluePowerUpActivated = manager.GreenPowerUpActivated = manager.RedPowerUpActivated = manager.YellowPowerUpActivated = false;
            manager.timerBlue = manager.timerGreen = manager.timerRed = manager.timerYellow = 0;
            SceneManager.LoadScene("Game");
        }
    }
}
