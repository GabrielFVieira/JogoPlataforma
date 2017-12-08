using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class DoorButton : MonoBehaviour {
	public GameObject door;
	public bool active;
	public float timer;
	public bool startTimer;

    public AudioSource song;

    public Sprite green;
    public Sprite red;
	// Use this for initialization
	void Start () {
        song = GetComponent<AudioSource>();
    }
	
	// Update is called once per frame
	void Update () {
		if (startTimer == true) {
			timer += Time.deltaTime;
		}

		if(door.transform.rotation.z <= -90f)
			door.GetComponent<Rigidbody2D> ().constraints = RigidbodyConstraints2D.FreezeRotation;

		if (timer > 8) {
			door.GetComponent<HingeJoint2D> ().useMotor = false;
			timer = 0;
			startTimer = false;
            GetComponent<SpriteRenderer>().sprite = green;
		}

		if (Input.GetKeyDown (KeyCode.E) && active == true || Input.GetKeyDown(KeyCode.RightControl) && active == true) 
		{
			door.GetComponent<Rigidbody2D> ().constraints = RigidbodyConstraints2D.None;
			door.GetComponent<HingeJoint2D> ().useMotor = true;
			startTimer = true;
            song.Play();
            GetComponent<SpriteRenderer>().sprite = red;
            active = false;
        }
	}

	public void OnTriggerEnter2D(Collider2D col)
	{
		if (col.gameObject.tag == "Player") 
		{
			active = true;
		}
	}

	public void OnTriggerExit2D(Collider2D col)
	{
		if (col.gameObject.tag == "Player") 
		{
			active = false;
		}
	}
}
