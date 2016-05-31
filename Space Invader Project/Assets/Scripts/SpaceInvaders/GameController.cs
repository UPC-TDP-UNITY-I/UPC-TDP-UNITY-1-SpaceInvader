using UnityEngine;
using System.Collections;
using AssemblyCSharp;

public class GameController : MonoBehaviour {

	private PlayerControl mPlayerControl;
	private BulletFactory mBulletFactory;

	public BulletFactory BulletFactory { get { return mBulletFactory; } }

	// Use this for initialization
	void Start () {
		mBulletFactory = new BulletFactory ();

		mPlayerControl = GameObject.Find ("GO_Player").GetComponent<PlayerControl> ();
		mPlayerControl.SetGameController(this);

		Vector3 leftBottom = Vector3.zero;
		Vector3 rightTop = Vector3.zero;

		Utils.ComputeResponsiveScreenPoints (Camera.allCameras [0], 
			out leftBottom, out rightTop);

		GameObject goEnemyLayer = GameObject.Find ("Layer_Enemy");

		for (int i = 1; i < 16; i++) {
			GameObject go = Utils.LoadPFab ("Prefabs/pfab_dummy_enemy");
			Vector3 pos = go.transform.localPosition;
			pos.x = Mathf.Lerp(leftBottom.x, rightTop.x, i / 16f);
			go.transform.localPosition = pos;

			go.transform.SetParent (goEnemyLayer.transform);
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
