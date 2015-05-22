using UnityEngine;
using System.Collections;

public class LevelBase : MonoBehaviour {
	public int progression = 0;
	public int maxProgression = 100;
	public string nextLevel = "home";

	public void UnProgress(){
		progression -= 10;
	}

	public void Progress(){
		progression += 10;

		forwardLevel ();

		if(progression >= maxProgression){
			loadNextLevel();
		}
	}

	public void loadNextLevel(){
		Application.LoadLevel (nextLevel);
	}

	public virtual void forwardLevel(){} // implemented by HomeLevel, EgoLevel, etc.
}
