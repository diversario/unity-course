using UnityEngine;
using System.Collections;

public class NumberWizard : MonoBehaviour {
	int max;
	int min;
	int guess;
	
	// Use this for initialization
	void Start () {
		StartGame();
	}
	
	void StartGame () {
		max = 1000;
		min = 1;
		guess = max / 2;
		
		print("====================================");
		
		print("Welcome");
		print("Pick a number.");
		
		print("Number is between " + min + " and " + max);
		
		print("Is the number higher or lower than " + guess + "?");
		print("Press up or down or Enter");
		
		max++;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.UpArrow)) {
			min = guess;
			NextGuess();
		} else if (Input.GetKeyDown(KeyCode.DownArrow)) {
			max = guess;
			NextGuess();
		} else if (Input.GetKeyDown(KeyCode.Return)) {
			print("Win!");
			StartGame();
		}
	}
	
	void NextGuess() {
		guess = (min + max) / 2;
		print ("Higher or lower than " + guess);
	}
}
