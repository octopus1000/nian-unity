using UnityEngine;
using System.Collections;

public class CreepScript : MonoBehaviour {

	private Animator ani;
	private bool attackState = false;
	private Rigidbody2D bd;
	public float speedX = 10;

	void Start() {
		ani = GetComponent<Animator> ();
		bd = GetComponent<Rigidbody2D> ();
	}

	void OnBecameVisible () {
		//bd.isKinematic = false;
		bd.velocity = new Vector2 (-speedX, 0);

		if (ani) {
			//enemy walk...
			ani.SetFloat("speed", speedX);
		}
	}


	void FixedUpdate() {
		if ((transform.position.x - Utility.playerPosX) < 10 && ani != null && !attackState) {
			bd.velocity = new Vector2(0,0);
			ani.SetBool("attack", true);
			attackState = true;
		}
	}

	void OnBecameInvisible () {
		Destroy (gameObject);
	}

	void OnCollisionEnter2D(Collision2D coll) {
		if (coll.gameObject.tag == "Player") {
			Runner runner = coll.gameObject.GetComponent<Runner>();
			if (runner) {
				if (runner.takeDamage(1)) {
					bd.velocity = new Vector2(-speedX, 0);
				} else {
					die();
				}
			} else {
				Debug.Log("Can not find runner script");
			}
		}
	}

	//set orc to trigger
	void OnTriggerEnter2D(Collider2D coll) {
		if (coll.tag == "PlayerParts" || coll.tag == "weapon") {
			Runner runner = coll.gameObject.transform.parent.GetComponent<Runner>();
			if (runner) {
				if ( !runner.takeDamage(1)) {
					die();
				}
			} else {
				Debug.Log("Can not find runner script");
			}
		}
	}


	void die() {
		//animation....
		Debug.Log ("Creep die");
		ani.Play ("die");
		//Destroy (gameObject);
	}
}
