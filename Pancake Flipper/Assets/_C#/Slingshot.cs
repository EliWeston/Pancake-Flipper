﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slingshot : MonoBehaviour {
	static private Slingshot S;
	[Header("Set in Inspector")]
	public GameObject 	prefabPancake;
	public float		velocityMult = 8f;
    public GameObject prefabPan;

	[Header("Set Dynamically")]
	public GameObject	launchPoint;
	public Vector3		launchPos;
	public GameObject	pancake;
	public bool aimingMode;
    public Vector3 panStartPosition;

	private Rigidbody	pancakeRigidbody;
	private Pancake 	pancakeScript;
    private Rigidbody   panRB;

	//public float    torque;
	//int X;
	//int Y;

	//public float  rotationsPerMinute = 10.00f;

	static public Vector3 LAUNCH_POS {
		get {
			if (S == null) return Vector3.zero;
			return S.launchPos;
		}
	}
	void Awake() {
		S = this;
		Transform launchPointTrans = transform.Find("LaunchPoint");
		launchPoint = launchPointTrans.gameObject;
		launchPoint.SetActive (false);
		launchPos = launchPointTrans.position;
        panStartPosition = prefabPan.transform.position;
	}

	void OnMouseEnter() {
		//print ("Slingshot:OnMouseEnter()");
		launchPoint.SetActive( true );
	}

	void OnMouseExit(){
		//print ("Slingshot:OnMouseExit()");
		launchPoint.SetActive( false );
	}

	void OnMouseDown(){
		aimingMode = true;
		pancake = Instantiate (prefabPancake) as GameObject;
		pancake.transform.position = launchPos;
		//projectile.GetComponent<Rigidbody> ().isKinematic = true;

		pancakeRigidbody = pancake.GetComponentInChildren<Rigidbody> ();
		pancakeRigidbody.isKinematic = true;

        panRB = prefabPan.GetComponent<Rigidbody>();

		pancakeScript = pancake.GetComponent<Pancake> ();
        prefabPan.transform.position = launchPos;
	}

	void Update(){

		if (!aimingMode)
			return;

		Vector3 mousePos2D = Input.mousePosition;
		mousePos2D.z = -Camera.main.transform.position.z;
		Vector3 mousePos3D = Camera.main.ScreenToWorldPoint (mousePos2D);

		Vector3 mouseDelta = mousePos3D - launchPos;
		float maxMagnitude = this.GetComponent<SphereCollider> ().radius;
		if (mouseDelta.magnitude > maxMagnitude) {
			mouseDelta.Normalize ();
			mouseDelta *= maxMagnitude;
		}
		Vector3 projPos = launchPos + mouseDelta;
		pancake.transform.position = projPos;
        prefabPan.transform.position = projPos;

		if (Input.GetMouseButtonUp (0)) {
			aimingMode = false;
			pancakeRigidbody.isKinematic = false;
			pancakeRigidbody.velocity = -mouseDelta * velocityMult;

            prefabPan.transform.position = panStartPosition;

			pancakeScript.isFlying = true;
			pancake = null;
		}
	}
}