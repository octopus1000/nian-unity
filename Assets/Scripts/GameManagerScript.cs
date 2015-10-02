using UnityEngine;
using System.Collections;

public class GameManagerScript : MonoBehaviour {
	public void gameOver() {
		Application.LoadLevel ("gameover");
	}
}
