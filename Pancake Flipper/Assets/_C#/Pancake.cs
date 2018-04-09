using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pancake : MonoBehaviour {

	public float rotationsPerMinute = 10.0f;
	public bool isFlying = false;

	Collider pancakeColl;
	Collider myCollider;
	private GameObject cylinder;
	private GameObject	pancake;
	private Pancake pancakeScript;

	[Header("Set in Inspector")]
	public GameObject plate;
	public GameObject cylChild;
 
	void Start () {
	}
	
	// Update is called once per frame
	void Update ()
	{  
		if (isFlying == true) {
			
			cylChild.transform.Rotate (0, 0, -24 * rotationsPerMinute * Time.deltaTime, 0);
		}
	
}
	
}
