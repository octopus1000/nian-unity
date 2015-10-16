using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BgManagerScript : MonoBehaviour {

	public int numOfGround;
	public GameObject groundPrefab;
	public GameObject hill;

	private Queue<GameObject> groundQ;
	private Queue<GameObject> hillQ;
	private Vector3 nextPos;
	private Vector3 shift; 
	private Vector3 nextPosh;
	private Vector3 shifth; 

	void Start () {
		Renderer renderer = groundPrefab.GetComponent<Renderer>();
		Renderer rendererh = hill.GetComponent<Renderer> ();
		shift = new Vector3(renderer.bounds.size.x,0,0);
		shifth = new Vector3(rendererh.bounds.size.x, 0,0);
		nextPos = groundPrefab.transform.position;
		nextPosh = hill.transform.position;
		groundQ = new Queue<GameObject> (numOfGround);
		hillQ = new Queue<GameObject> (numOfGround);

		//groundPrefab must be an instance which has valid transform position
		for (int i = 0; i < numOfGround; i++) {
			GameObject ground = (GameObject)Instantiate (groundPrefab);
			GameObject newhill = (GameObject)Instantiate (hill);
			groundQ.Enqueue(ground);
			hillQ.Enqueue(newhill);
		}

		for (int i = 0; i < numOfGround; i++) {
			recycle(ref groundQ, ref nextPos, shift);
			recycle(ref hillQ, ref nextPosh, shifth);
		}
	}
	
	// Update is called once per frame
	void Update () {
		GameObject ground = groundQ.Peek ();
		GameObject newhill = hillQ.Peek ();

		if (outOfScreen(ground.transform.position, shift)) {
			recycle(ref groundQ, ref nextPos, shift);
		}
		if (outOfScreen(newhill.transform.position, shifth)) {
			recycle(ref hillQ, ref nextPosh, shifth);
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