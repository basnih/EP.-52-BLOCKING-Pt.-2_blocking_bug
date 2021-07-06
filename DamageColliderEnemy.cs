using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Basnih
{
    public class DamageColliderEnemy : MonoBehaviour
    {
        public CharacterManager characterManager;
        Collider damageColliderenemy;

        public int currentWeaponEnemyDamage = 25;

        EnemyObjectInWP enemyObjectInWP;//not SG code
        [Header("Angles for Blocking")] //NotSGCode
        public float angleEnemyObjectDamageCollider;//not SG code
        public float maxAngleBlock = 30; //not SG code

        private void Awake()
        {
            damageColliderenemy = GetComponent<Collider>();
            damageColliderenemy.gameObject.SetActive(true);
            damageColliderenemy.isTrigger = true;
            damageColliderenemy.enabled = false;

            //characterManager = GetComponentInParent<CharacterManager>(); //not SG code
            enemyObjectInWP = GetComponentInParent<EnemyObjectInWP>();//not SG code
        }

        private void Update() //not SG code
        {
            angleEnemyObjectDamageCollider = enemyObjectInWP.angleEnemyObjectWP;//not SG code
        }

        public void EnableDamageCollider()
        {
            damageColliderenemy.enabled = true;
        }

        public void DisableDamageCollider()
        {
            damageColliderenemy.enabled = false;
        }

        private void OnTriggerEnter(Collider collision)
        {

            if (collision.tag == "Player")
            {
                PlayerStats playerStats = collision.GetComponent<PlayerStats>();
                CharacterManager enemyCharacterManager = collision.GetComponent<CharacterManager>();
                BlockingCollider shield = collision.transform.GetComponentInChildren<BlockingCollider>();

                float angleForBlocking = 180f - angleEnemyObjectDamageCollider; //not SG code

                if (enemyCharacterManager != null)
                {
                    if (enemyCharacterManager.isParrying)
                    {
                        Debug.Log("Parried");
                        characterManager.GetComponentInChildren<AnimatorManager>().PlayTargetAnimation("Parried", true);
                        return;
                    }
                    else if (shield != null && enemyCharacterManager.isBlocking && angleForBlocking <= maxAngleBlock) //not SG code
                    {
                        float physicalDamageAfterBlock =
                            currentWeaponEnemyDamage - (currentWeaponEnemyDamage * shield.blockingPhysicalDamageAbsorption) / 100;

                        if (playerStats != null)
                        {
                            playerStats.TakeDamage(Mathf.RoundToInt(physicalDamageAfterBlock), "Block Guard");
                            return;
                        }
                    }
                }

                if (playerStats != null)
                {
                    playerStats.TakeDamage(currentWeaponEnemyDamage);
                }
            }
        }
    }
}