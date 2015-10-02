using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	private int player_speed = 5;
	private int accelerate_speed = 30;
	private int player_hight = 5;
	private Rigidbody2D rb;
	private Animator anim;
	public GameObject weapon;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D> ();
		anim = GetComponent<Animator> ();
		run ();
	}
	
	// Update is called once per frame
	void Update () {
		//debug
	}

	public void run (){
		Debug.Log ("run");
		rb.velocity = new Vector2 (player_speed,0);
	}

	public void jump (){
		Debug.Log ("jump");
		rb.velocity = new Vector2 (player_hight,5);
		anim.Play ("jump",-1,0f);
	}

	public void down (){
		Debug.Log ("down");
		rb.velocity = new Vector2 (player_speed,-player_hight);
		anim.Play ("crouch",-1,0f);
	}

	public void attack (){
		Vector2 weapon_p = new Vector2(rb.position.x+1,rb.position.y);
		Instantiate (weapon, weapon_p, Quaternion.identity); 
	}

	public void accelerate (){
		rb.velocity = new Vector2 (accelerate_speed,0);
	}

}
