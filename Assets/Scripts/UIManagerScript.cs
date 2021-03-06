﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UIManagerScript : MonoBehaviour {
	public Text coinTxt;
	public GameObject[] life_objects;
	public Runner runner;
	public Sprite life_full;
	public Sprite life_half;
	public Sprite life_frame;

	public GameObject inGameMenu;
	public GameObject inGameReport;
	public Text report;
	public Button nextLev;

	void Start () {
		Debug.Log (inGameReport);
		life_objects = new GameObject[5];
		for (int j = 0; j < 5; j++) {
			life_objects[j] = GameObject.FindGameObjectWithTag("Life" + j);	
		}
	}

	void Update() {
		updateCoin (runner.getCoin ());
		updateLife (runner.increaseLife(0));
	}

	public int updateCoin(int coinNum) {
		//coinTxt.text = coinNum;
		coinTxt.text = coinNum.ToString();
		return 0;
	}

	public int updateLife (int life) {
//		life_objects = GameObject.FindGameObjectsWithTag ("Life");
		Image image;
		int i;
		//Debug.Log (life_objects[0].name+" "+life_objects[1].name+" "+life_objects[2].name+" "+life_objects[3].name+" "+life_objects[4].name+" ");
		if (life % 2 == 0) {
			for (i = 0; i < life/2; i++) {
				image = life_objects [i].GetComponent<Image> ();
				image.sprite = life_full;
			}

			for (i = life/2; i < 5; i++) {
				image = life_objects [i].GetComponent<Image> ();
				image.sprite = life_frame;
			}
		} 
		else {
			for (i = 0; i < (life-1)/2; i++) {
				image = life_objects [i].GetComponent<Image> ();
				image.sprite = life_full;
			}

			image = life_objects[(life-1)/2].GetComponent<Image>();
			image.sprite = life_half;

			for (i = (life+1)/2; i < 5; i++) {
				image = life_objects [i].GetComponent<Image> ();
				image.sprite = life_frame;
			}
		}

//		lifeTxt.text = "Life:" + life;
		return 0;
	}

	public void toggleInGameMenu(bool on) {
		if (inGameMenu)
			inGameMenu.SetActive(on);
	}

	public void toggleInGameReport(bool on) {
		if (inGameReport) {
			inGameReport.SetActive (on);
			if (on) {
				report.text = "Crack:" + runner.getCoin() + "\nLife:" + runner.increaseLife(0);
			}
		}
	}

	public void enableNextLev () {
		if (nextLev)
			nextLev.interactable = true;
	}
}
