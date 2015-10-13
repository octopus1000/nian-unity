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

		//groundPrefab must be an instance which has valid transform position
		for (int i = 0; i < numOfGround; i++) {
			GameObject ground = (GameObject)Instantiate (groundPrefab);
			groundQ.Enqueue(ground);
		}

		for (int i = 0; i < numOfGround; i++) {
			recycle(ref groundQ, ref nextPos, shift);
		}
	}
	
	// Update is called once per frame
	void Update () {
		GameObject ground = groundQ.Peek ();

		if (outOfScreen(ground.transform.position, shift)) {
			recycle(ref groundQ, ref nextPos, shift);
		}
	}

	// Move the prefab to next position
	void recycle(ref Queue<GameObject> queue, ref Vector3 nextPos, Vector3 shift) {
		GameObject obj = queue.Dequeue ();
		obj.transform.position = nextPos;
		queue.Enqueue (obj);
		nextPos += shift;
	}
	
	bool outOfScreen (Vector3 pos, Vector3 scale) {
		Vector3 screenPosition = Camera.main.WorldToScreenPoint (pos + scale * 0.5f);

		if (!Camera.main) {
			Debug.LogError("Please set main camera in tag");
			return false;
		}
		return screenPosition.x < 0;
	}
}