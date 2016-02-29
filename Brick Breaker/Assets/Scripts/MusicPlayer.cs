using UnityEngine;
using System.Collections;

public class MusicPlayer : MonoBehaviour {
	static MusicPlayer instance;
	
	void Awake(){
		if (instance) {
			Destroy(gameObject);
			return;
		}
		
		instance = this;
		GameObject.DontDestroyOnLoad(gameObject);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
