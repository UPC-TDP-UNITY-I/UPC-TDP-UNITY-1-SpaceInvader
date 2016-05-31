using AssemblyCSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts.behaviours
{
    public class FSMC_Shoot : FSMC_Base
    {

        private GameController mGameController;

        public FSMC_Shoot(GameObject go) : base(go)
        {

        }

        public void Shoot(float bulletSpeed, float frecuency)
        {
            Vector3 pos = mGO.transform.localPosition;
            pos.y -= 1f;

            mGameController = GameObject.Find("GOP_Game").GetComponent<GameController>();
            mGameController.BulletFactory.CreateBullet(pos, bulletSpeed, 1f, Vector2.down, EnumBullet.Enemy);

            mIsActive = false;
        }
    }
}
