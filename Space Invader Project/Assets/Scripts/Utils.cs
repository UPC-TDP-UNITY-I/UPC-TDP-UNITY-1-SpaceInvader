using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public static class Utils {

	public static void ComputeResponsiveScreenPoints(Camera camera, out Vector3 leftBottom, out Vector3 rightTop) {
		Vector3 lb_position = Vector3.zero;

		Vector3 rt_position = Vector3.zero;
		rt_position.x = camera.pixelWidth;
		rt_position.y = camera.pixelHeight;
		rt_position.z = 0;

		leftBottom = camera.ScreenToWorldPoint (lb_position);
		rightTop = camera.ScreenToWorldPoint (rt_position);
	}

	public static GameObject LoadPFab(string path) {
		GameObject uninstanced_go = Resources.Load<GameObject> (path);
		return GameObject.Instantiate (uninstanced_go);
	}

	public static Dictionary<string, object> ParseScript(string script) {
		Dictionary<string, object> result = new Dictionary<string, object> ();

		string[] prop = script.Split (';');

		for (int i = 0; i < prop.Length; i++) {
			string[] objValue = prop [i].Split(':');

			string key = objValue [0];
			float resFloat = 0;
			bool resBool = false;

			if (float.TryParse (objValue [1], out resFloat)) {
				result[key] = resFloat;
			}
			else if (bool.TryParse (objValue [1], out resBool)) {
				result[key] = resBool;
			}
			else {
				result[key] = objValue [1];
			}
		}

		return result;
	}
}
