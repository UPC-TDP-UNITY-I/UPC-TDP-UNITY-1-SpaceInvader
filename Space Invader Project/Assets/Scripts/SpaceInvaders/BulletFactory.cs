using System;
using UnityEngine;

namespace AssemblyCSharp
{
	public class BulletFactory
	{
		public BulletFactory ()
		{
		}

		public void CreateBullet(Vector3 pos, float speed, float power, 
			Vector2 direction, EnumBullet bulletType) {

			GameObject goBullet = null;

			switch (bulletType) {
			case EnumBullet.Enemy:
                goBullet = Utils.LoadPFab("prefabs/pfab_bullet_player");
                break;
			case EnumBullet.Player:
				goBullet = Utils.LoadPFab ("prefabs/pfab_bullet_player");
				break;
			}

			if (goBullet != null) {
				BaseBullet bb = goBullet.GetComponent<BaseBullet> ();
				bb.SetConfiguration (speed, power, direction, bulletType);
				bb.transform.localPosition = pos;
			}
		}
	}
}

