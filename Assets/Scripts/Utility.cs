using UnityEngine;
using System.Collections;

public static class Utility {
	public static float playerPosX;

	public static bool outOfScreen (Vector3 pos, Vector3 scale) {
		Vector3 screenPosition = Camera.main.WorldToScreenPoint (pos + scale * 0.5f);
		
		if (!Camera.main) {
			Debug.LogError("Please set main camera in tag");
			return false;
		}
		return screenPosition.x < 0;
	}

	//cause damage on gameobjectWith tag enemy with radius range
	//@param{vector3} center explode center
	//@param{float} radius explode radius
	public static void explode(Vector3 center, float radius) {
		Collider2D[] colls = Physics2D.OverlapCircleAll ((Vector2)center, radius);
		
		for (int i = 0; i < colls.Length; i++) {
			if (colls[i].tag == "enemy") {
				colls[i].SendMessageUpwards("takeDamage", 1);
			}
		}
	}
}
