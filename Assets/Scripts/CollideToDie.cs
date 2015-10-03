using UnityEngine;
using System.Collections;

public class CollideToDie : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D col) {
		if (col.name == "Player") {
			//decrease runner life
			Runner runner = col.gameObject.GetComponent<Runner>();
			runner.decreaseLife();
		}
	}
}
