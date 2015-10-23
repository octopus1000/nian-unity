﻿using UnityEngine;
using System.Collections;

public class MilestoneScript : MonoBehaviour {

	void Start () {
		//change particle sys to yellow
		GetComponent<ParticleSystem> ().startColor = new Color (255, 255, 0, .5f);
	}

	void OnTriggerEnter2D(Collider2D col) {
		if (col.gameObject.tag == "PlayerParts") {
			/*Runner runner = col.gameObject.transform.parent.GetComponent<Runner>();
			if (runner) {
				runner.playerWin();
			} else {
				Debug.LogError("zhang: no Runner script in Player");
			}*/
			GameEventScript.TriggerGameWin();
		}
	}
}
