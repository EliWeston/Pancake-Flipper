using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plate2 : MonoBehaviour {
	
	[Header ("Set in Inspector")]


	public float speed = 1f;
	public float leftAndRightEdge = 30f;
	public float chanceToChangeDirections = 0.05f;

	public GameObject	pancake;
	private Pancake pancakeScript;

	void Start () {
	}

	void Update () {
		//Basic Movement
		Vector3 pos = transform.position;
		pos.x += speed * Time.deltaTime;
		transform.position = pos;

		//changing direction
		if (pos.x < -leftAndRightEdge) {
			speed = Mathf.Abs (speed);
		} else if (pos.x > leftAndRightEdge) {
			speed = -Mathf.Abs (speed);
		}
	}

	void OnTriggerStay (Collider other)
	{ 
		if (other.gameObject.tag == "Pancake") {
			pancake = other.gameObject;
			pancakeScript = pancake.GetComponent<Pancake> ();
			pancakeScript.isFlying = false;
			pancake.transform.rotation = Quaternion.Euler(0,0,0);
			pancake.transform.parent = this.transform;
			pancake = null;
		}
	}


	void FixedUpdate () {
		if (Random.value < chanceToChangeDirections) {
			speed *= -1;
		}
		}
}
