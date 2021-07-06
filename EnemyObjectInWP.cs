using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Basnih {

    public class EnemyObjectInWP : MonoBehaviour // all code is not SG Code
    {
        EnemyObjectInES enemyObjectInES;
        public float angleEnemyObjectWP;

        public void Awake()
        {
            enemyObjectInES = GetComponentInParent<EnemyObjectInES>();
        }

        private void Update()
        {
            angleEnemyObjectWP = enemyObjectInES.angleEnemyObject;
        }

    }
}
