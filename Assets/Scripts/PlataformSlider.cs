using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlataformSlider : MonoBehaviour {
    public GameObject min;
    public GameObject max;
    public GameObject player;
    public float velocity;
    public bool esq;
    // Use this for initialization
    void Start()
    {
        esq = true;
        velocity = 1.5f;

        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < max.transform.position.x && esq == true)
        {
            transform.Translate(velocity * Time.deltaTime, 0, 0);
        }

        if (transform.position.x > min.transform.position.x && esq == false)
        {
            transform.Translate(velocity * Time.deltaTime, 0, 0);
        }


        if (transform.position.x >= max.transform.position.x)
        {
            esq = false;
            velocity = -1.5f;
        }

        if (transform.position.x <= min.transform.position.x)
        {
            esq = true;
            velocity = 1.5f;
        }
    }

    public void OnCollisionStay2D(Collision2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            player.transform.Translate(velocity * Time.deltaTime, 0, 0);
        }
    }
}
