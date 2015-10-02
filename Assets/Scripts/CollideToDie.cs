using UnityEngine;
using System.Collections;

public class CollideToDie : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D col) {
		if (col.name == "Player") {
			//decrease runner life
			decreaseLife (col.gameObject.GetComponent<Runner>());
		}
	}

	void OnCollisionEnter2D (Collision2D col) {
		if (col.gameObject.name == "Player") {
			//decrease runner life
			decreaseLife (col.gameObject.GetComponent<Runner>());
		}
	}
	void decreaseLife(Runner runner) {
		if (runner.decreaseLife() == 0) {
			runner.die();
		}
	}
}
