using UnityEngine;
using System.Collections;

public class GameManagerScript : MonoBehaviour {
	enum Status {Running, Paused};

	private Status gameStatus = Status.Running;
	private UIManagerScript UI;

	void Start() {
		//delegate gamewin method
		GameEventScript.GameWin += gameWin;
		GameEventScript.GameStart += gameStart;
		GameEventScript.GameOver += gameOver;

		UI = GetComponent<UIManagerScript> ();
		if (UI == null) {
			Debug.LogWarning("Zhang: No UI manager is Found");
		}
	}
	
	public void gameStart() {
		gameResume ();
		Application.LoadLevel (1);
	}

	public void gameOver() {
		Application.LoadLevel (2);
	}
	
	public void gamePause() {
		Time.timeScale = 0;
		gameStatus = Status.Paused;
		if (UI != null) {
			UI.enableButton (false);
			UI.enablePause (false);
		}
	}
	public void gameResume() {
		Time.timeScale = 1;
		gameStatus = Status.Running;
		if (UI != null) {
			UI.enableButton (true);
			UI.enablePause (true);
		}
	}

	//enable pause button
	public void gameStatusToggle() {
		switch (gameStatus) {
		case Status.Running: 
			gamePause();
			break;
		case Status.Paused:
			gameResume();
			break;
		}
	}

	//show restart button
	public void gameWin() {
		gamePause ();
		if (UI != null) {
			UI.enableRestart (true);
		}
	}

}
