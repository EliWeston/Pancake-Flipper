using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Plate2 : MonoBehaviour {
	
	[Header ("Set in Inspector")]
	public GameObject panTrig;

	public float speed = 1f;
	public float leftAndRightEdge = 30f;
	public float chanceToChangeDirections = 0.05f;
	public float collMover = 1f;

	Collider pancakeColl;
	Collider myCollider;
	private GameObject	cylinder;
	private GameObject pancake;
	private Pancake pancakeScript;
	private GameObject lastPancake;
	private GameObject plate;
    //private bool firstTime = true;
    //Collider capColl;
    //FixedJoint joint;

    [Header("Set Dynamically")]
    public Text scoreGT;
    static public int lowScore = 0;

	void Start () {

	    plate = this.gameObject;
        GameObject scoreGO = GameObject.Find("ScoreCounter");
        scoreGT = scoreGO.GetComponent<Text>();
        scoreGT.text = "0";
        
    }

	void Update ()
	{
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
		if ((cylinder != null) && (lastPancake != null)) {
			if (cylinder.transform.position.y >= lastPancake.transform.position.y) { 
				panTrig.transform.position = new Vector3 (cylinder.transform.position.x, cylinder.transform.position.y + collMover, cylinder.transform.position.z);
			}
		} else {
				panTrig.transform.position = new Vector3 (plate.transform.position.x, plate.transform.position.y + collMover, plate.transform.position.z);
		}
	}

	void OnTriggerEnter (Collider other)
	{ 
		if ((other.gameObject.tag == "Cylinder") && (other.gameObject.transform.parent != this.gameObject)) {
			print ("real dicks");
			cylinder = other.gameObject;
			pancake = cylinder.transform.parent.gameObject;
			pancakeScript = pancake.GetComponent<Pancake> ();
			pancakeScript.isFlying = false;
			cylinder.transform.rotation = Quaternion.Euler (0, 0, 0);
			pancake.transform.parent = this.transform;
			//joint = this.gameObject.AddComponent<FixedJoint>();
			//joint.connectedBody = cylinder.GetComponent<Rigidbody>();
			//cylinder.transform.GetComponent<Rigidbody>().isKinematic = true;
			//pancakeColl = pancake.GetComponentInChildren<Collider> ();
			//pancakeColl.isTrigger = true;
			pancake = null;
			//cylinder = null;
			lastPancake = cylinder;
            //panTrig = this.gameObject.transform.GetChild();

            lowScore += 1;
            scoreGT.text = lowScore.ToString();
            if (lowScore > HighScore.score)
            {
                HighScore.score = lowScore;
            }
        }
        

		//MeshFilter[] meshFilters = GetComponentsInChildren<MeshFilter>();
       // CombineInstance[] combine = new CombineInstance[meshFilters.Length];
      //  int i = 0;
      //  while (i < meshFilters.Length) {
           // combine[i].mesh = meshFilters[i].sharedMesh;
           // combine[i].transform = meshFilters[i].transform.localToWorldMatrix;
            //meshFilters[i].gameObject.active = false;
           // i++;
       // }
        //transform.GetComponent<MeshFilter>().mesh = new Mesh();
        //transform.GetComponent<MeshFilter>().mesh.CombineMeshes(combine);
       // transform.gameObject.active = true;
	}
	void FixedUpdate () {
		if (Random.value < chanceToChangeDirections) {
			speed *= -1;
            
        }
        scoreGT.text = lowScore.ToString();
    }
}
