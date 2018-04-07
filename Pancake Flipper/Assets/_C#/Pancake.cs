using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pancake : MonoBehaviour {

	public float rotationsPerMinute = 10.0f;
	public bool isFlying = false;
 
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
	{  
		if (isFlying == true) {

			transform.Rotate (0, 0, -24 * rotationsPerMinute * Time.deltaTime, 0);
		}
	
}
}
