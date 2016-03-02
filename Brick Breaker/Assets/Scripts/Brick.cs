using UnityEngine;
using System.Collections;

public class Brick : MonoBehaviour {
	public Sprite[] hitSprites;

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
			levelManager.BrickDestroyed ();
		} else {
			UpdateSprite ();
		}
	}

	void UpdateSprite() {
		int index = timesHit - 1;
		Sprite sprite = hitSprites [index];

		if (sprite) {
			this.GetComponent<SpriteRenderer> ().sprite = sprite;
		}
	}

	void SimulateWin () {
		levelManager.LoadNextLevel();
	}
}
