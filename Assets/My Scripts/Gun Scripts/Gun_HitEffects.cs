using UnityEngine;
using System.Collections;

namespace S3
{
	public class Gun_HitEffects : MonoBehaviour {

        private Gun_Master gunMaster;
        public GameObject defaultHitEffect;
        public GameObject enemyHitEffect;

		void OnEnable()
		{
            SetInitialReferences();
            gunMaster.EventShotDefault += SpawnDefaultHitEffect;
            gunMaster.EventShotEnemy += SpawnEnemyHitEffect;
        }

		void OnDisable()
		{
            gunMaster.EventShotDefault -= SpawnDefaultHitEffect;
            gunMaster.EventShotEnemy -= SpawnEnemyHitEffect;
        }

		void SetInitialReferences()
		{
            gunMaster = GetComponent<Gun_Master>();
		}

        void SpawnDefaultHitEffect(RaycastHit hitPosition, Transform hitTransform)
        {
            if (defaultHitEffect != null)
            {
                Quaternion quatAngle = Quaternion.LookRotation(hitPosition.normal);
                Instantiate(defaultHitEffect, hitPosition.point, quatAngle);
            }
        }

        void SpawnEnemyHitEffect(RaycastHit hitPosition, Transform hitTransform)
        {
            if (enemyHitEffect != null)
            {
                Quaternion quatAngle = Quaternion.LookRotation(hitPosition.normal);
                Instantiate(enemyHitEffect, hitPosition.point, quatAngle);
            }
        }
    }
}


