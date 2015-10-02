using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BgManagerScript : MonoBehaviour {

	public int numOfGround;
	public GameObject groundPrefab;

	private Queue<GameObject> groundQ;
	private Vector3 nextPos;
	private Vector3 shift; 

	void Start () {
		Renderer renderer = groundPrefab.GetComponent<Renderer>();
		shift = new Vector3(renderer.bounds.size.x,0,0);
		nextPos = groundPrefab.transform.position;

		groundQ = new Queue<GameObject> (numOfGround);

		for (int i = 0; i < numOfGround; i++) {
			GameObject ground = (GameObject)Instantiate (groundPrefab, nextPos, Quaternion.identity);
			groundQ.Enqueue(ground);
			nextPos += shift;
		}
	}
	
	// Update is called once per frame
	void Update () {
		GameObject ground = groundQ.Peek ();
		
		Vector3 screenPosition = Camera.main.WorldToScreenPoint (ground.transform.position + shift * 0.5f);
		if (screenPosition.x < 0) {
			ground = groundQ.Dequeue ();
			ground.transform.position = nextPos;
			groundQ.Enqueue (ground);
			nextPos += shift;
		}
		}

}
