using UnityEngine;
using System.Collections;

public class WeaponController : MonoBehaviour {

	private int weapon_speed = 15;
	private Rigidbody2D weapon_rb;
	private Animator weapon_ani;

	// Use this for initialization
	void Start () {
		Debug.Log ("weapon fired");
		if (GetComponent<Rigidbody2D> ()) {
			weapon_rb = GetComponent<Rigidbody2D> ();
			weapon_rb.velocity = new Vector2 (weapon_speed, 0);
			weapon_ani = GetComponent<Animator> ();
		}
	}
	
	// Update is called once per frame
	void Update () {
	}

	void OnBecameInvisible () {
		Destroy (gameObject);
	}
}
