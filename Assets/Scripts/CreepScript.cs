using UnityEngine;
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
}
