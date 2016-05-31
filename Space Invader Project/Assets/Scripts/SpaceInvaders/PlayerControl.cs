using UnityEngine;
using System.Collections;
using AssemblyCSharp;

public class PlayerControl : MonoBehaviour {

	private ResponsiveComponent mResponsiveComponent;
	private SpriteRenderer mSpriteRenderer;
	private GameController mGameController;

	// Use this for initialization
	void Start () {
		mResponsiveComponent = this.GetComponent<ResponsiveComponent>();
		mSpriteRenderer = this.GetComponent<SpriteRenderer> ();
	}

	public void SetGameController(GameController controller) {
		mGameController = controller;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Space)) {
			mGameController.BulletFactory.CreateBullet (
				this.gameObject.transform.localPosition, 
				6f, 1f, Vector2.up, EnumBullet.Player);
		}

		float x = Input.GetAxis ("Horizontal");

		Vector3 pos = this.gameObject.transform.localPosition;
		pos.x += x / 10f;

		float hsize = mSpriteRenderer.bounds.size.x * 0.5f;

		if ((pos.x - hsize) <= mResponsiveComponent.LeftBottom.x) {
			pos.x = mResponsiveComponent.LeftBottom.x + hsize;
		}

		if ((pos.x + hsize) >= mResponsiveComponent.RightTop.x) {
			pos.x = mResponsiveComponent.RightTop.x - hsize;
		}

		this.gameObject.transform.localPosition = pos;
	}
}
