using UnityEngine;
using System.Collections;

public class FlyCreepScript : MonoBehaviour {

	enum States{Idle, Fly};
	public float v = 10;

	private States state = States.Idle;

	void  OnBecameVisible() {
		//start to perceive player
		state = States.Fly;
	}

	// Update is called once per frame
	void Update () {
		switch (state) {
		case States.Fly:
			transform.position = transform.position + new Vector3(-v * Time.deltaTime / 2, 0,0);
			break;
		}
	}
}
