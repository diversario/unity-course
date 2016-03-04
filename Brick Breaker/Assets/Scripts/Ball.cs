using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour {

	private Paddle paddle;
	
	private Vector3 _paddleToBallVector;
	private bool _gameStarted = false;
	
	// Use this for initialization
	void Start () {
		this.audio.volume = 0.5f;

		paddle = GameObject.FindObjectOfType<Paddle> ();

		_paddleToBallVector = this.transform.position - paddle.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		if (!_gameStarted) {
			this.transform.position = paddle.transform.position + _paddleToBallVector;
			
			if (Input.GetMouseButtonDown (0)) {
				print ("click");
			
				_gameStarted = true;
			
				this.rigidbody2D.velocity = new Vector2 (10f, 10f);
			}
		}
	}

	void OnCollisionEnter2D(Collision2D collision) {
		if (_gameStarted) {
			if (collision.gameObject.CompareTag("Untagged")) {
				audio.Play ();
			}

			Vector2 tweak = new Vector2 (Random.Range (0f, 0.2f), Random.Range (0f, 0.2f));
			this.rigidbody2D.velocity += tweak;
		}
	}
}
