using UnityEngine;
using System.Collections;

public class Brick : MonoBehaviour {
	public AudioClip crack;
	public Sprite[] hitSprites;

	public GameObject Smoke;

	int timesHit;

	private LevelManager levelManager;

	public static int breakableCount = 0;
	bool isBreakable;

	void Start () {
		levelManager = GameObject.FindObjectOfType<LevelManager> ();
		timesHit = 0;

		isBreakable = this.CompareTag ("Breakable");

		if (isBreakable) {
			breakableCount++;
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnCollisionEnter2D(Collision2D collision) {
		AudioSource.PlayClipAtPoint (crack, this.transform.position, 0.5f);

		if (isBreakable) {
			HandleHit();
		}
	}

	void HandleHit () {
		breakableCount--;
		Debug.Log (Brick.breakableCount);
		int maxHits = hitSprites.Length + 1;
		timesHit++;

		if (timesHit >= maxHits) {
			Destroy (gameObject);
			EmitSmoke ();
			levelManager.BrickDestroyed ();
		} else {
			UpdateSprite ();
		}
	}

	void EmitSmoke () {
		GameObject smoke = Object.Instantiate (Smoke, this.transform.position, Quaternion.identity) as GameObject;
		smoke.particleSystem.startColor = this.GetComponent<SpriteRenderer> ().color;
	}

	void UpdateSprite() {
		int index = timesHit - 1;
		Sprite sprite = hitSprites [index];

		if (sprite) {
			this.GetComponent<SpriteRenderer> ().sprite = sprite;
		} else {
			Debug.LogError("Where's the sprite for hit #" + timesHit + "!");
		}
	}

	void SimulateWin () {
		levelManager.LoadNextLevel();
	}
}
