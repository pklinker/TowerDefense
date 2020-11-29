using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    [Header("Targeting")]
    [SerializeField] Transform objectToPan;

    [Header("Equipment")]
    [SerializeField] ParticleSystem[] guns;
    [SerializeField] float attackRange = 50;

    Transform targetEnemy;

    // Start is called before the first frame update
    void Start()
    {
        FireGun(false);
    }

    // Update is called once per frame
    void Update()
    {
        targetEnemy = SetTargetEnemy();
        FireAtEnemy();
    }

    Transform SetTargetEnemy()
    {
        Enemy[] enemies = FindObjectsOfType<Enemy>();
        if (enemies.Length == 0) { return null; }

        Transform closestEnemy = enemies[0].transform;

        foreach (Enemy enemy in enemies)
        {
            float enemyDistance = Vector3.Distance(closestEnemy.position, gameObject.transform.position);
            float testDistance = Vector3.Distance(enemy.transform.position, gameObject.transform.position);
            if (testDistance < enemyDistance)
            {
                closestEnemy = enemy.transform;
            }
        }
        return closestEnemy;
    }

    void FireAtEnemy()
    {
        if (targetEnemy)
        {
            objectToPan.LookAt(targetEnemy);
            float enemyDistance = Vector3.Distance(targetEnemy.transform.position, gameObject.transform.position);
           // print(" enemy distance is " + enemyDistance);
            if (enemyDistance <= attackRange) 
            {
                FireGun(true);
            }
        }
        else
        {
            FireGun(false);
        }
    }

    private void FireGun(bool active)
    {
        foreach (ParticleSystem gun in guns)
        {
            var emissionModule = gun.emission;
            emissionModule.enabled = active;
        }
    }
}
