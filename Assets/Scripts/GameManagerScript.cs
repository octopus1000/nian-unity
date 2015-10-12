using UnityEngine;
using System.Collections;

public class GameManagerScript : MonoBehaviour {
	private int gameStatus = 1; //1 - running, 2 - paused
	private static GameManagerScript instance;

	void Start() {
		instance = this;
	}
	public void gameStart() {
		Application.LoadLevel (1);
	}

	public void gameRestart() {
		gameResume ();
		Application.LoadLevel (1);
	}
	public void gameOver() {
		Application.LoadLevel (2);
	}
	
	public void gamePause() {
		Time.timeScale = 0;
		gameStatus = 2;
		UIManagerScript.enableButton (false);
		UIManagerScript.enablePause (false);
	}
	public void gameResume() {
		Time.timeScale = 1;
		gameStatus = 1;
		UIManagerScript.enableButton (true);
		UIManagerScript.enablePause (true);
	}

	public void gameStatusToggle() {
		switch (gameStatus) {
		case 1: 
			gamePause();
			break;
		case 2:
			gameResume();
			break;
		}
	}

	public static void gameWin() {
		instance.gamePause ();
		UIManagerScript.enableRestart (true);
	}

}
