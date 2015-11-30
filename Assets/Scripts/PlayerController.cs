using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	//States
	private const int NORMAL = 0;
	private const int IN_AIR = 1;
	private const int DIE = 2;
	private int jump_count = 0;

	private int state;
	private int player_speed = 10;
	private int player_height = 22;
	private int activate_num = 10;
	private Rigidbody2D rb;
	private Animator anim;
	public GodPlayerScript godPlayer;
	public bool attackState = false;
	public LayerMask touchInputMask;
	public AudioSource attck_clip;
	public AudioSource jumpup_clip;

	bool grounded = false;
	public Transform groundCheck;
	float groundRadius = 0.2f;
	public LayerMask whatIsGround;

	private int attack_num = 0;
	public bool DistanceAttack = false;
	public GameObject fireball;
	private bool isCd = false;

	// Use this for initialization
	void Start () {
		//Time.timeScale = 1;
		rb = GetComponent<Rigidbody2D> ();
		anim = GetComponent<Animator> ();
		run ();
	}

	void OnCollisionEnter2D (Collision2D col) {
		if (state == IN_AIR) {
			anim.SetBool ("Ground",true);
			Debug.Log ("collision");
			state = NORMAL;	
			if(jump_count==2) 
			{
				jump_count=0;
			}
		}
	}

	void Update(){
		grounded = Physics2D.OverlapCircle (groundCheck.position, groundRadius, whatIsGround);

		anim.SetBool ("Ground",grounded);
		anim.SetFloat ("vSpeed",rb.velocity.y);

		float speedX = godPlayer.getSpeedX();
		//lag behind god player
		if (transform.position.x < godPlayer.transform.position.x) {
			speedX *= 1.2f;
		}
		Vector2 targetV = new Vector2 (speedX, rb.velocity.y);

		//use add force instead of change speed directly to simulate physics
		rb.AddForce ( (targetV - rb.velocity) * rb.mass / Time.fixedDeltaTime, ForceMode2D.Force);
		//rb.velocity = targetV;


		//add keyboard control for debugging using unity ide
		if (Input.GetKey ("up")) {
			jump();
		}
		if (Input.GetKey ("space")) {
			attack ();
		}
	}

	public void run (){
		Debug.Log ("run");
		anim.SetBool ("Ground",true);
		state = NORMAL;
	}

	public void jump (){
		if (state == NORMAL || (state == IN_AIR && jump_count<2)) {
			Debug.Log ("jump");
			rb.transform.position += new Vector3(0,1f,0);
			rb.velocity = new Vector2 (player_speed, player_height);
			jumpup_clip.Play ();
			state = IN_AIR;
			anim.SetBool("Ground",false);
			jump_count++;
		}
	}
	
	public void attack (){
		attackState = true;
		if (!DistanceAttack) {
			attck_clip.Play ();
			attack_num++;
			if (attack_num % 4 == 0) {
				anim.SetTrigger ("attack_3");
			} else if (attack_num % 3 == 0) {
				anim.SetTrigger ("attack_2");
			} else {
				anim.SetTrigger ("attack");
			}
		} else {
			//sound
			if(!isCd){
				isCd = true;
				Invoke ("changeCd", 1f);
				GameObject fb = Instantiate(fireball);
				fb.transform.position = new Vector3(transform.position.x + 2,transform.position.y + 0.7f,transform.position.z);
				fb.GetComponent<Rigidbody2D>().velocity = new Vector2(40,0);
				anim.SetTrigger("DistanceAttack");

			}
		}
	}

	public void changeCd(){
		isCd = false;
	}

	public void finishAttack(){
		attackState = false;
		anim.Play ("Knight2Walk", -1, 0f);
	}

	public void DistanceAttackTigger(){
		DistanceAttack = true;
		Invoke ("resetAttack",10.0f);
	}

	public void resetAttack(){
		DistanceAttack = false;
	}
//	public void magic(){
//		//rush
//		if (runner.getCoin () >= activate_num) {
//			Debug.Log("enough coin");
//			runner.decreaseCoin(activate_num);
//			StartCoroutine(MyCoroutine());
//		}
//
//	}
//	
//	public void accelerate (){
//		godPlayer.setSpeedX (accelerate_speed);
//	}
//
//	IEnumerator MyCoroutine(){
//		accelerate ();
//		anim.Play ("Knight2Rush",-1,0f);
//		rushState = true;
//		Debug.Log (rb.velocity);
//		yield return new WaitForSeconds (2.0f);
//		godPlayer.setSpeedX (player_speed);
//		rushState = false;
//		Debug.Log (rb.velocity);
//	}

}
