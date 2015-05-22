using UnityEngine;
using System.Collections;

public class BemuseLevel : LevelBase {

	// Use this for initialization
	void Start () {
		Physics.gravity = new Vector3 (.5f, .5f, .5f);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public override void forwardLevel(){
		print ("progressing in bemuse level");
	}
}
