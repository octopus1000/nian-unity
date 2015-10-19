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
}
