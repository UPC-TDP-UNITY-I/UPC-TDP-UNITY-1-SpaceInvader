using UnityEngine;
using System.Collections;

public class ResponsiveComponent : MonoBehaviour {

	public float PosPercWidht;
	public float PosPercHeight;

	public Vector3 LeftBottom;
	public Vector3 RightTop;

	// Use this for initialization
	void Start () {
		Utils.ComputeResponsiveScreenPoints (Camera.allCameras [0], 
			out LeftBottom, out RightTop);

		Vector3 pos = this.gameObject.transform.localPosition;
		pos.x = Mathf.Lerp(LeftBottom.x, RightTop.x, (this.PosPercWidht + 1f) / 2f);
		pos.y = Mathf.Lerp(RightTop.y, LeftBottom.y, (this.PosPercHeight + 1f) / 2f);
		this.gameObject.transform.localPosition = pos;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
