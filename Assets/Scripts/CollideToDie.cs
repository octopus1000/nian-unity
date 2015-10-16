using UnityEngine;
using System.Collections;

public class CollideToDie : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D col) {
		if (col.tag == "PlayerParts") {
			//decrease runner life
			Runner runner = col.gameObject.transform.parent.GetComponent<Runner>();
			runner.decreaseLife();
		}
	}


	void OnCollisionEnter2D(Collision2D col) {
		if (col.gameObject.tag == "Player") {
			//decrease runner life
			Runner runner = col.gameObject.GetComponent<Runner>();
			runner.decreaseLife();
		}
	}
}
