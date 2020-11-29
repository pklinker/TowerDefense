using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pathfinder : MonoBehaviour
{
    // key is grid position of block
    Dictionary<Vector2Int, Block> grid = new Dictionary<Vector2Int, Block>();
    Queue<Block> queue = new Queue<Block>();

    List<Block> path = new List<Block>();

    bool isRunning = true;
    
    Vector2Int[] directions = {
        Vector2Int.up,
        Vector2Int.down,
        Vector2Int.left,
        Vector2Int.right
    };

    Block startingBlock = null;
    Block endingBlock = null;

    public List<Block> GetPath()
    {
        if (path.Count == 0)
        {
            CalculatePath();
        }
        return path;
    }

    // Start is called before the first frame update
    void Start()
    {
    }

    private void CalculatePath()
    {
        LoadBlocks();
        BreadthFirstSearch();
        CreatePath();
    }

    private void BreadthFirstSearch()
    {
        isRunning = true;
        queue.Enqueue(startingBlock);
        while ((queue.Count > 0) && isRunning)
        {
            Block searchCenter = queue.Dequeue();
            HaltIfEndBlockFound(searchCenter);
            ExploreNeighbors(searchCenter);
        }
    }

    private void CreatePath()
    {
        path.Add(endingBlock);
        Block previous = endingBlock.exploredFrom;
        while (previous != startingBlock)
        {
            // add intermediate waypoint
            path.Add(previous.exploredFrom);
            previous = previous.exploredFrom;
        }
        // add start waypoint
        path.Add(previous);
        // reverse list
        path.Reverse();
    }

    private void HaltIfEndBlockFound(Block searchCenter)
    {
        if (searchCenter.Equals(endingBlock))
        {
            isRunning = false;
            print("start = end");
        }
    }

    private void ExploreNeighbors(Block block)
    {
        if (!isRunning) { return; }
        
        block.SetIsExplored();

        foreach (Vector2Int direction in directions)
        {
            Vector2Int explorationCoordinates = block.GetGridPos() + direction;
            //print("Exploring " + explorationCoordinates);
            if (grid.ContainsKey(explorationCoordinates))
            {
                QueueNewNeighbors(explorationCoordinates, block);
            }
        }
    }

    private void QueueNewNeighbors(Vector2Int explorationCoordinates, Block searchingBlock)
    {
        Block neighbor = grid[explorationCoordinates];
        if ((!neighbor.isExplored) && (!queue.Contains(neighbor)))
        { 
            neighbor.exploredFrom = searchingBlock;
            queue.Enqueue(neighbor);
        }
    }

    private void LoadBlocks()
    {
        Block[] blocks = FindObjectsOfType<Block>();
        foreach(Block block in blocks)
        {
            bool isOverlapping = grid.ContainsKey(block.GetGridPos());
            if (isOverlapping)
            {
                Debug.LogWarning("Overlapping block " + block);
            }
            else
            {

                grid.Add(block.GetGridPos(), block);
                SetTopColor(block);
            }
            if (block.IsStartingBlock())
            {
                startingBlock = block;
               
            } 
            if(block.IsEndingBlock()) // not using else if in case the starting block is the same as the ending block
            {
                endingBlock = block;
            }
        }
        Debug.Log("Loaded " + grid.Count + " blocks.");
    }

    private static void SetTopColor(Block block)
    {
        Color blockColor = Color.white;
        if (block.IsStartingBlock())
        {
            blockColor = Color.green;
        }
        else if (block.IsEndingBlock())
        {
            blockColor = Color.red;
        }
        block.SetTopColor(blockColor);
    }

    private Block GetStartingBlock()
    {
        return startingBlock;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
