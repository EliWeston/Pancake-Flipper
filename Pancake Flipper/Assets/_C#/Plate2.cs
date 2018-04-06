using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plate2 : MonoBehaviour {
	
	[Header ("Set in Inspector")]


	public float speed = 1f;

	public float leftAndRightEdge = 30f;

	public float chanceToChangeDirections = 0.05f;


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

	void FixedUpdate () {
		if (Random.value < chanceToChangeDirections) {
			speed *= -1;
		}
		}
}
