using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    [Header("Targeting")]
    [SerializeField] Transform objectToPan;
    [SerializeField] Transform targetEnemy;

    [Header("Equipment")]
    [SerializeField] ParticleSystem[] guns;
    [SerializeField] float attackRange = 50;

    // Start is called before the first frame update
    void Start()
    {
        FireGun(false);
    }

    // Update is called once per frame
    void Update()
    {
        TargetEnemy();
    }

    void TargetEnemy()
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
