using UnityEngine;
using System.Collections;

public class CrackScript : MonoBehaviour {

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D col) {
		if (col.name == "Player") {
			Runner runner = col.gameObject.GetComponent<Runner>();
			Debug.Log("Coin:" + runner.addCoin());
			Destroy(gameObject);
		}
	}
}
