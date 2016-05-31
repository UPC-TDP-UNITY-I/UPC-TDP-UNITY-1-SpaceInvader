using System;
using UnityEngine;

namespace AssemblyCSharp
{
	public class BaseBullet : MonoBehaviour
	{

		protected float mSpeed;
		protected float mPower;
		protected Vector2 mDirection;
		protected EnumBullet mBulletType;
		protected SpriteRenderer mSR;

		protected Vector3 mLeftBottom;
		protected Vector3 mRightTop;

		public bool IsAlive;

		public EnumBullet BulletType { get { return mBulletType; } }

		void Start() {
			this.IsAlive = true;

			mSR = this.GetComponent<SpriteRenderer> ();

			Utils.ComputeResponsiveScreenPoints (Camera.allCameras [0], 
				out mLeftBottom, out mRightTop);
		}

		public void SetConfiguration(float speed, float power, 
			Vector2 direction, EnumBullet bulletType) {

			mSpeed = speed;
			mPower = power;
			mDirection = direction;
			mBulletType = bulletType;
		}

		void OnTriggerEnter2D(Collider2D collider) {
			if (collider.gameObject.CompareTag ("DummyEnemy")) {
				GameObject.Destroy(collider.gameObject);
				GameObject.Destroy(this.gameObject);
			}
		}

		void Update () {
			if (this.IsAlive) {
				Vector2 pos = this.gameObject.transform.localPosition;
				pos.x += (mDirection.x * mSpeed) * Time.deltaTime;
				pos.y += (mDirection.y * mSpeed) * Time.deltaTime;
				this.gameObject.transform.localPosition = pos;

				if ((pos.y - mSR.bounds.size.y * 0.5f) > mRightTop.y) {
					this.IsAlive = false;
					GameObject.Destroy (this.gameObject);
				}
			}
		}
	}
}

