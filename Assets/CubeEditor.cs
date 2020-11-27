using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms;

[ExecuteInEditMode]
[SelectionBase]
[RequireComponent(typeof(Block))]
public class CubeEditor : MonoBehaviour
{

    //[SerializeField] [Range(1f,20f)] float gridSize=10f;
    
    
    Block block;
    int gridSize=0;

    private void Awake()
    {
        block = GetComponent<Block>();
 
    }

    private void Start()
    {

    }
    // Update is called once per frame
    void Update()
    {
        gridSize = block.GetGridSize();
        SnapToGrid();
        UpdateLabel();

    }

    private void SnapToGrid()
    {
        Vector2Int gridPos = block.GetGridPos();
        transform.position = new Vector3(gridPos.x*gridSize, 0f, gridPos.y*gridSize);
    }

    private void UpdateLabel()
    {
        TextMesh textMesh = GetComponentInChildren<TextMesh>();
        Vector2Int gridPos = block.GetGridPos();
        string blockText = gridPos.x + "," + gridPos.y;
        textMesh.text = blockText;
        gameObject.name = "Cube: " + blockText;
    }
}
