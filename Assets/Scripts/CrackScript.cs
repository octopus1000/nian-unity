using UnityEngine;
using System.Collections;

public class CrackScript : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D col) {
		if (col.gameObject.tag == "PlayerParts") {
			//player parent has runner script which controls life and 
			Runner runner = col.gameObject.transform.parent.GetComponent<Runner>();
			if (runner) {
				runner.addCoin();
			}
			Destroy(gameObject);
		}
	}

	void OnBecameInvisible() {
		Destroy (gameObject);
	}
}
