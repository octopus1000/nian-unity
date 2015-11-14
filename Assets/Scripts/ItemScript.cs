using UnityEngine;
using System.Collections;

public class ItemScript : MonoBehaviour {
	
	public int type =  0; //0 - normal item, 1 - increase crack, 2 - increase health

	Runner runner;

	//collect garbage
	void OnBecameInvisible() {
		Destroy (gameObject);
	}

	void OnTriggerEnter2D(Collider2D col) {
		if (col.gameObject.tag == "PlayerParts") {
			if (perceiveRunner()) {
				switch (type) {
				case 1: 
					runner.addCoin();
					break;
				case 2:
					runner.increaseLife (1);
					break;
				}
				Destroy(gameObject);
			}
		}
	}

	//return false if cannot find runner component in player
	bool perceiveRunner() {
		if (!runner) {
			GameObject player = GameObject.FindGameObjectWithTag("Player");
			if (player) {
				runner = player.GetComponent<Runner>();
			}
		}
		return runner ? true : false;
	}
}
