using UnityEngine;
using System.Collections;

public class FlyCreepScript : MonoBehaviour {

	enum States{Idle, Fly, Die};
	public float v = 10;
	public float amplitudeY = 5.0f;
	public float omegaY = 4.0f;
	public bool flyInWave = true;

	private States state = States.Idle;
	private float flyTime;
	private Vector3 initPos;
	private CollideToDie coreScript;

	void Start() {
		coreScript = GetComponent<CollideToDie> ();
		coreScript.die += die;
	}

	void  OnBecameVisible() {
		//start to perceive player
		state = States.Fly;
		flyTime = 0;
		initPos = transform.position;
	}

	void OnBecameInvisible() {
		Destroy (gameObject);
	}

	// Update is called once per frame
	void Update () {
		Debug.Log (state);
		switch (state) {
		case States.Fly:
			//transform.position = transform.position + new Vector3(-v * Time.deltaTime / 2, 0,0);
			if (flyInWave) {
				flyTime += Time.deltaTime;
				float x = -v * flyTime;
				float y = Mathf.Abs (amplitudeY*Mathf.Sin (omegaY*flyTime));
				transform.position = new Vector3(x,y,0) + initPos;
			} else {
				transform.position += new Vector3(-v, 0, 0) * Time.deltaTime;
			}
			break;
		case States.Die:
			transform.position = new Vector3(0,-2 * v * Time.deltaTime,0) + transform.position;
			break;
		}
	}

	void die() {
		//remove corescript so that the creature can no longer cause damage
		Destroy (coreScript);
		if (state == States.Fly) {
			state = States.Die;
		}
	}
}
