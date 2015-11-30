using UnityEngine;
using System.Collections;

public class haloController : MonoBehaviour {

	public GameObject player;
	private Animator halo_ani;

	// Use this for initialization
	void Start () {
		halo_ani = GetComponent<Animator> ();
		halo_ani.Play ("halo",-1,0f);
		player = GameObject.FindGameObjectWithTag ("Player");
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = new Vector2 (player.transform.position.x, player.transform.position.y + 3);
	}
}
