using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Minimap : MonoBehaviour {

	public GameObject player;
	public float distance = 1000;

	// Use this for initialization
	void Start () {

	}
	// Update is called once per frame
	void FixedUpdate () {
		GetComponent<Slider> ().value = (float)(player.transform.position.x + 8.16)/distance;
	}
}
