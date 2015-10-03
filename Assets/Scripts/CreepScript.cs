﻿using UnityEngine;
using System.Collections;

public class CreepScript : MonoBehaviour {

	void OnBecameVisible () {
		Rigidbody2D body = GetComponent<Rigidbody2D> ();
		body.isKinematic = false;
		body.velocity = new Vector2 (-10, 6);
	}

	void OnBecameInvisible () {
		Destroy (gameObject);
	}

	void OnCollisionEnter2D (Collision2D col) {
		if (col.gameObject.tag == "weapon") {
			//destroy weapon
			Destroy (col.gameObject);
			die ();
		} else if (col.gameObject.tag == "Player") {
			//hit top of a creep, creep dies
			if (collideTop(col.contacts[0].point, (Vector2)transform.position)) {
				die();
			} else {
				Runner runner = col.gameObject.GetComponent<Runner>();
				runner.decreaseLife();
			}
		}
	}

	bool collideTop(Vector2 cPoint, Vector2 pos) {
		Vector2 v = cPoint - pos;
		return  Mathf.Abs (Vector2.Angle (v, Vector3.up)) < 45.0;
	}

	void die() {
		//animation....
		Debug.Log ("Creep die");
		Destroy (gameObject);
	}
}
