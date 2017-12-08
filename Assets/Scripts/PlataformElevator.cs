using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlataformElevator : MonoBehaviour {
    public GameObject min;
    public GameObject max;
    public float velocity;
    public bool sobe;
	// Use this for initialization
	void Start () {
        sobe = true;
        velocity = 1.5f;
	}
	
	// Update is called once per frame
	void Update () {
		if(transform.position.y < max.transform.position.y && sobe == true)
        {
            transform.Translate(0, velocity * Time.deltaTime, 0);
        }

        if (transform. position.y > min.transform.position.y && sobe == false)
        {
            transform.Translate(0, velocity * Time.deltaTime, 0);
        }


        if (transform.position.y >= max.transform.position.y)
        {
                sobe = false;
				velocity *= -1;
        }

        if (transform.position.y <= min.transform.position.y)
        {
                sobe = true;
				velocity *= -1;
        }
    }

	public void OnTriggerEnter2D(Collider2D col)
	{
		if (col.gameObject.tag == "Player") {
			col.transform.Translate(0, velocity * Time.deltaTime, 0);
		}
	}
}
