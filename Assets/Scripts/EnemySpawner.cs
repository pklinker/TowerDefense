using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [Range(0.1f,120f)] [SerializeField] float secondsBetweenSpawns = 1f;
    [SerializeField] GameObject enemyObject;
    [SerializeField] Transform parent;

    bool gameOver = false;

    // Start is called before the first frame update
    void Start()
    {

        StartCoroutine(SpawnEnemy());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator SpawnEnemy()
    {
        while (!gameOver)
        {
            GameObject enemy = Instantiate(enemyObject, transform.position, Quaternion.identity);
            enemy.transform.parent = parent;
            yield return new WaitForSeconds(secondsBetweenSpawns);
        }
    }
}
