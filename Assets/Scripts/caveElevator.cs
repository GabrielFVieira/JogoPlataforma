using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class caveElevator : MonoBehaviour
{
    public GameObject max;
    public GameObject player;
    public float velocity;
    public bool sobe;
    public bool start;
    // Use this for initialization
    void Start()
    {
        sobe = true;
        velocity = 1.5f;
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (start == true)
        {
            if (transform.position.y < max.transform.position.y && sobe == true)
            {
                transform.Translate(0, velocity * Time.deltaTime, 0);
            }
        }
    }

    public void OnCollisionStay2D(Collision2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            start = true;
        }
    }

}
