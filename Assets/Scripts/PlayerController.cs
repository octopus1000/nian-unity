using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	//States
	private const int NORMAL = 0;
	private const int IN_AIR = 1;
	private const int CROUCH = 2;
	private const int DIE = 3;

	private int state;
	private int player_speed = 10;
	private int accelerate_speed = 20;
	private int player_height = 22;
	private int activate_num = 10;
	private bool unstoppable_state = false;
	private Rigidbody2D rb;
	private Runner runner;
	private Animator anim;
	public GameObject weapon;
	public GameObject halo;
	public GodPlayerScript godPlayer;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D> ();
		anim = GetComponent<Animator> ();
		runner = GetComponent<Runner> ();
		run ();
	}
	
	// Update is called once per frame
	void Update () {
		//debug
		if (runner.getCoin () >= activate_num) {
			Debug.Log(runner.getCoin());
			runner.decreaseCoin (activate_num);
			unstoppable();
		}
	}

	void OnCollisionEnter2D (Collision2D col) {
		if (state == IN_AIR) {
			anim.SetTrigger("onGround");
			Debug.Log ("collision");
			state = NORMAL;
		}
	}

	void FixedUpdate(){	
		float speedX = godPlayer.getSpeedX();
		//lag behind god player
		if (transform.position.x < godPlayer.transform.position.x) {
			speedX *= 1.2f;
		}
		rb.velocity = new Vector2 (speedX, rb.velocity.y);
	}

	public void run (){
		Debug.Log ("run");
		state = NORMAL;
	}

	public void jump (){
		if (state == NORMAL) {
			Debug.Log ("jump");
			rb.velocity = new Vector2 (player_speed, player_height);
			anim.Play ("Knight2JumpUp", -1, 0f);
			state = IN_AIR;
		}
	}

	public void attack (){
		anim.Play ("Knight2Attack", -1, 0f);
//		Vector2 weapon_p = new Vector2(rb.position.x+1,rb.position.y);
//		Instantiate (weapon, weapon_p, Quaternion.identity); 
	}

	public void magic(){
		StartCoroutine(MyCoroutine());
	}


	public void accelerate (){
		rb.velocity = new Vector2 (accelerate_speed,0);
	}

	IEnumerator MyCoroutine(){
		accelerate ();
		anim.Play ("boost",-1,0f);
		Debug.Log (rb.velocity);
		yield return new WaitForSeconds (0.7f);
		run ();
		Debug.Log (rb.velocity);
	}

	public void unstoppable(){
		StartCoroutine (StateCoroutine ());
	}

	IEnumerator StateCoroutine(){
		Vector2 halo_p = new Vector2 (rb.position.x, rb.position.y + 3);
		GameObject halo_ins = (GameObject)Instantiate (halo, halo_p, Quaternion.identity);
		unstoppable_state = true;
		yield return new WaitForSeconds (5.0f);
		unstoppable_state = false;
		Destroy (halo_ins);
	}

	public bool getUnstoppableState(){
		return this.unstoppable_state;
	}
}
