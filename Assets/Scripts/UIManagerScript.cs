using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UIManagerScript : MonoBehaviour {
	public Text coinTxt;
	public Button upBtn, downBtn, attackBtn, magicBtn;
	public Text pauseBtnTxt;
	public Canvas canvas;
	public Runner runner;

	void Start () {
		canvas.enabled = false;
	}

	void Update() {
		updateCoin (runner.getCoin ());
	}

	public int updateCoin(int coinNum) {
		//coinTxt.text = coinNum;
		coinTxt.text = coinNum.ToString();
		return 0;
	}

	public bool enableButton(bool status) {
		upBtn.interactable = status;
		downBtn.interactable = status;
		attackBtn.interactable = status;
		magicBtn.interactable = status;
		return status;
	}

	public bool enablePause(bool status) {
		pauseBtnTxt.text = status ? "Pause" : "Resume";
		return status;
	}

	public bool enableRestart(bool status){
		canvas.enabled = status;
		return status;
	}
}
