using UnityEngine;
using System.Collections;

public class CollideToDie : MonoBehaviour {

	public bool isDestructable = false;
	public bool isTrigger = true;
	public bool isTrample = false;
	public int lifeBound = 1;

	private Runner runner; //must exist
	private Animator ani;
	private int life;
 
	public delegate void CreatureBehave();
	public CreatureBehave die = null;

	void Start() {
		//set animator
		ani = GetComponent<Animator> ();
		//set life
		life = lifeBound;
	}

	void  OnBecameVisible() {
		//set player script which control life
		GameObject player = GameObject.FindGameObjectWithTag("Player");
		if (player) {
			runner = player.GetComponent<Runner> ();
		} else {
			Debug.LogError("can't find tag with player");
		}
	}

	void OnTriggerEnter2D(Collider2D col) {
		if (isTrigger && col.tag == "PlayerParts") {
			damage();
		}
	}

	void OnCollisionEnter2D(Collision2D col) {
		if (col.gameObject.tag == "Player") {
			//collision from bottom
			if (isTrample &&  Vector3.Dot(col.contacts[0].normal, -Vector3.up) > 0.7f) {
				explode(transform.position, 10);
				takeDamage(1);
			} else {
				damage();
			}
		}
	}

	void OnBecameInvisible() {
		Destroy (gameObject);
	}

	//attempt to damage player and receive feedback from player
	void damage() {
		//player is attacking
		if (life > 0 && runner && runner.takeDamage (isDestructable)) {
			takeDamage(1);
		}
	}

	//reduce creature itself's damage by @damage
	void takeDamage(int damage) {
		//no damage produced
		if (!isDestructable || life <= 0)
			return;

		life -= damage;
		if (life <= 0) {
			if (die != null) {
				die();
			} else {
				DieDefault();
			}
		}
	}

	//cause damage on gameobjectWith tag enemy with radius range
	//@param{vector3} center explode center
	//@param{float} radius explode radius
	void explode(Vector3 center, float radius) {
		Collider2D[] colls = Physics2D.OverlapCircleAll ((Vector2)center, radius);

		for (int i = 0; i < colls.Length; i++) {
			Debug.Log(colls[i].name);
			if (colls[i].tag == "enemy") {
				colls[i].SendMessageUpwards("takeDamage", 1);
			}
		}
	}

	void DieDefault() {
		//disable collider
//		foreach(Collider2D c in GetComponents<Collider2D> ()) {
//			c.enabled = false;
//		}

		//play animation
		if (ani) {
			ani.SetTrigger("die");
		} else {
			Destroy(gameObject);
		}
	}
}
