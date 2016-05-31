using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using System;

public class ButtonComponent : MonoBehaviour {

	private Action mOnCallback;

	// Use this for initialization
	void Start () {
	
	}

	public void OnClick(Action onCallback) {
		mOnCallback = onCallback;
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetMouseButtonDown (0)) {
			for (int i = 0; i < Camera.allCameras.Length; i++) {
				Camera cc = Camera.allCameras [i];

				if (cc.orthographic) {
					Ray godRay = cc.ScreenPointToRay (Input.mousePosition);
					RaycastHit godRayHit = new RaycastHit ();

					bool detectedPhysic = Physics.Raycast (godRay, out godRayHit);

					if (detectedPhysic) {
						if (godRayHit.transform.gameObject == this.gameObject) {
							if (mOnCallback != null) {
								mOnCallback ();
							}
							break;
						}
					}
				}
			}
		}
	}
}
