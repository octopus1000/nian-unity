using UnityEngine;
using System.Collections;

public class GameManagerScript : MonoBehaviour {
	public void gameStart() {
		Application.LoadLevel (1);
	}
	public void gameOver() {
		Application.LoadLevel (2);
	}
}
