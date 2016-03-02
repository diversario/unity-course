using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour {
	public void LoadLevel (string name) {
		ResetGameState ();
		Application.LoadLevel(name);
	}
	
	public void QuitRequest() {
		Application.Quit();
	}

	public void LoadNextLevel() {
		ResetGameState ();
		Application.LoadLevel (Application.loadedLevel + 1);
	}

	public void BrickDestroyed() {
		if (Brick.breakableCount <= 0) {
			LoadNextLevel ();
		}
	}

	void ResetGameState () {
		Brick.breakableCount = 0;
	}
}
