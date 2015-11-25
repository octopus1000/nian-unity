using UnityEngine;
using System.Collections;

public class GameManagerScript : MonoBehaviour {
	enum Status {Running, Paused};
	
	private Status gameStatus = Status.Running;
	private UIManagerScript UI;

	void Start() {

		AudioListener.pause = false;
		//delegate gamewin method
		GameEventScript.GameWin += gameWin;
		GameEventScript.GameStart += gameStart;
		GameEventScript.GameOver += gameOver;

		UI = GetComponent<UIManagerScript> ();
		if (UI == null) {
			Debug.LogWarning("Zhang: No UI manager is Found");
		}
	}

	public void gameRestart(){
		gameResume ();
		Application.LoadLevel (Application.loadedLevel);
	}

	public void gameMenu() {
		gameResume ();
		Application.LoadLevel (0);
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
			UI.toggleInGameMenu(true);
		}
	}
	public void gameResume() {
		Time.timeScale = 1;
		gameStatus = Status.Running;
		if (UI != null) {
			UI.toggleInGameMenu(false);
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
	}

	public void mute(){
		AudioListener.volume = Mathf.Abs(AudioListener.volume-1);
		Debug.Log (AudioListener.volume);
	}
}
