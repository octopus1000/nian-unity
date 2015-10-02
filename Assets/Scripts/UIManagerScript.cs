using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UIManagerScript : MonoBehaviour {
	public Text coinTxt;
	public Button upBtn, downBtn, attackBtn, magicBtn;
	public Text pauseBtnTxt;

	//reference to itself because to provide static variable for static function
	static private UIManagerScript instance; 


	void Start () {
		instance = this;
	}
	public static int updateCoin(int coinNum) {
		//coinTxt.text = coinNum;
		instance.coinTxt.text = coinNum.ToString();
		return 0;
	}

	public static bool enableButton(bool status) {
		instance.upBtn.interactable = status;
		instance.downBtn.interactable = status;
		instance.attackBtn.interactable = status;
		instance.magicBtn.interactable = status;
		return status;
	}

	public static bool enablePause(bool status) {
		instance.pauseBtnTxt.text = status ? "Pause" : "Resume";
		return status;
	}
}
