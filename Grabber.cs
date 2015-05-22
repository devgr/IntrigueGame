using UnityEngine;
using System.Collections;

public class Grabber : MonoBehaviour {

	private GameObject inHand = null;
	private GameObject camera;
	public float throwForce = 300f;
	public float reachDistance = 10f;
	private bool throwing = false;

	void Start(){
		camera = GameObject.Find ("CenterEyeAnchor");
	}

	// Update is called once per frame
	void Update () {
		float trigger = Input.GetAxis ("Triggers");
		float thrower = Input.GetAxis ("Throw");
		//print (trigger);
		if(inHand == null ){ // check for input
			if(trigger > 0 && !throwing){ // pickup 
				print ("casting");
				castForward();
			}
		}
		else{ // carrying somthing
			if(trigger < .1f && trigger > -.1f){ // drop it
				dropIt();
			}
			else if(thrower > 0){
				throwIt();
			}
			else{ // carry it with you
				moveWithHand();
			}

		}

		if(trigger < .02f && trigger > -.02f)
			throwing = false;
	}

	private void castForward(){
		RaycastHit hit;
		int layermask = ~(1 << 2); // ignore the player in the raycast
		Vector3 camDirection = camera.transform.TransformDirection (Vector3.forward);
		//Debug.DrawRay (camera.transform.position, camera.transform.forward);
		Debug.DrawRay (camera.transform.position, camDirection);
		if(Physics.Raycast(camera.transform.position, camDirection, out hit, reachDistance, layermask)){
			print ("hit");
			GameObject target = hit.collider.gameObject;
			print (target.ToString());
			if(target.tag == "grab" && target.GetComponent("Rigidbody") != null){
				print ("picking up");
				inHand = target;
				inHand.rigidbody.useGravity = false;
				moveWithHand();
			}
		}
	}
	private void moveWithHand(){
		inHand.transform.position = gameObject.transform.position;
		inHand.transform.rotation = gameObject.transform.rotation;
	}
	private void dropIt(){
		print ("dropping");
		inHand.rigidbody.useGravity = true;
		inHand = null;
	}
	private void throwIt(){
		print ("throwing");
		inHand.rigidbody.useGravity = true;
		inHand.rigidbody.AddForce (camera.transform.forward * throwForce);
		inHand = null;
		throwing = true;
	}
}
