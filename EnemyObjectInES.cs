using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Basnih
{

    public class EnemyObjectInES : MonoBehaviour // all code is not SG Code
    {
        EnemyObjectInRightHand enemyObjectInRightHand;
        PlayerStats playerStats;

        public float angleEnemyObject;

        public void Awake()
        {
            playerStats = FindObjectOfType<PlayerStats>();
        }

        private void Update()
        {
            enemyObjectInRightHand = GetComponentInParent<EnemyObjectInRightHand>();
            angleEnemyObject = Vector3.Angle(enemyObjectInRightHand.enemyObjectForAngle.transform.forward, playerStats.playerObjectForAngle.transform.forward);
        }

    }
}
