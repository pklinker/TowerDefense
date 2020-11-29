using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{

    
    // Start is called before the first frame update
    void Start()
    {
       // print("Starting patrol...");
        Pathfinder pathfinder = FindObjectOfType<Pathfinder>();
        List<Block> path = pathfinder.GetPath();

        StartCoroutine(Move(path));
        
    }
    private IEnumerator Move(List<Block> path)
    {
        foreach (Block block in path)
        {
            //print("Visiting block: " + block.name);
            transform.position = block.transform.position;
            // wait for a second
            yield return new WaitForSeconds(1f);
        }
        print("Ending patrol.");
    }
    
     // Update is called once per frame
    void Update()
    {
        
    }
}
