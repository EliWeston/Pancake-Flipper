using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Floor : MonoBehaviour {

	private GameObject cylinder;
	private GameObject pancake;

	// Use this for initialization
	void Start () {
		
	}

	void OnTriggerEnter (Collider other)
	{ 
		if (other.gameObject.tag == "Cylinder"){
			cylinder = other.gameObject;
			pancake = cylinder.transform.parent.gameObject;
			destroyGameObject();
			}
	}

	void destroyGameObject ()
	{
		Destroy (pancake);
	}	

	void Update () {
		
	}
}
