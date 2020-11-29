using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    AudioSource audioSource;
  //  Collider boxCollider;
   // ScoreBoard scoreBoard;

    [Header("Effects")]
    [Tooltip("Death explose sound effect")] [SerializeField] AudioClip deathExplosionAC;
    [SerializeField] GameObject deathExplosion;
    [SerializeField] Transform parent;

    [Header("Scoring")]
    [Tooltip("Points to add to the player's score")] [SerializeField] int weaponStrength = 1;
    [Tooltip("Enemy resiliance to damage")] [SerializeField] int healthPoints = 10;
    // Start is called before the first frame update
    void Start()
    {

        audioSource = GetComponent<AudioSource>();
        AddCollider();
       // scoreBoard = FindObjectOfType<ScoreBoard>();
    }

    private void AddCollider()
    {
        AddNonTriggerBoxCollider();
    }

    void AddNonTriggerBoxCollider()
    {
    //    boxCollider = gameObject.AddComponent<BoxCollider>();
    //    boxCollider.isTrigger = false;
    }

    void OnParticleCollision(GameObject other)
    {
       // print("im hit");
        healthPoints--;
        if (healthPoints <= 0)
        {
          //  scoreBoard.ScoreHit(weaponStrength);
            GameObject fx = Instantiate(deathExplosion, transform.position, Quaternion.identity);
            fx.transform.parent = parent;
                    print("Particles collided with enemy " + gameObject.name);
            Destroy(gameObject);
           
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
