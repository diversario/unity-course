using UnityEngine;
using System.Collections;

public class Paddle : MonoBehaviour {
	public bool autoplay = false;

	private Ball ball;

	float mousePositionInBlocks;
	
	// Use this for initialization
	void Start () {
		ball = GameObject.FindObjectOfType<Ball> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (autoplay) {
			MoveWithBall ();
		} else {
			MoveWithMouse ();
		}
	}

	void MoveWithMouse() {
		Vector3 paddlePos = new Vector3(0.5f, this.transform.position.y, this.transform.position.z);
		mousePositionInBlocks = Input.mousePosition.x / Screen.width * 16;
		
		paddlePos.x = Mathf.Clamp(mousePositionInBlocks, 0.5f, 15.5f);

		this.transform.position = paddlePos;
	}

	void MoveWithBall () {
		this.transform.position = new Vector3 (
			ball.transform.position.x, 
			this.transform.position.y, 
			this.transform.position.z
		);
	}
}
