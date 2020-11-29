using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{

    [Header("Game Play")]
    [SerializeField] bool StartingBlock = false;
    [SerializeField] bool EndingBlock = false;

    [Header("Effects")]
    [SerializeField] Color exploredColor = Color.blue;

    // public is ok here because it is a data class
    public bool isExplored = false; // 
    public Block exploredFrom;

    const int gridSize = 10;
    Vector2Int gridPos;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public int GetGridSize()
    {
        return gridSize;
    }
    public Vector2Int GetGridPos()
    {
        return new Vector2Int(Mathf.RoundToInt(transform.position.x / gridSize) ,
         Mathf.RoundToInt(transform.position.z / gridSize));
    }
    public void SetTopColor(Color color)
    {
        Transform parentTransform = transform.Find("Top");
        MeshRenderer meshRenderer = parentTransform.GetComponent<MeshRenderer>();
        meshRenderer.material.color = color;
    }
    public bool IsStartingBlock()
    { 
        return StartingBlock; 
    }
    public bool IsEndingBlock()
    {
        return EndingBlock;
    }

    public void SetIsExplored()
    {
        SetTopColor(exploredColor);
        isExplored = true;
    }
}
