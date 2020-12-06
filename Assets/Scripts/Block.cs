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

    [Header("Features")]
    [SerializeField] GameObject towerObject;
    [SerializeField] Transform parent;
    [SerializeField] Vector3 offset;

    // public is ok here because it is a data class
    public bool isExplored = false; // 
    public Block exploredFrom;
    public bool isPlaceable = true;
    private GameObject tower;

    const int gridSize = 10;
    Vector2Int gridPos;

    // Start is called before the first frame update
    void Start()
    {
        isPlaceable = true;
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
        return new Vector2Int(Mathf.RoundToInt(transform.position.x / gridSize),
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

    void OnMouseOver()
    {
        //   print("Mouse over: " + GetGridPos());
        // detect mouse click
        // if click
     //   if (Input.GetMouseButtonDown(0)) // left mouse button
     //   {
     //       print("Grid: " + GetGridPos() + " clicked.");
     //   }
    }

    private void OnMouseDown()
    {
        if (isPlaceable)
        {
            Vector3 newPosition = transform.position + offset;
            //            print("Mouse down " + GetGridPos());
            tower = Instantiate(towerObject, newPosition, Quaternion.identity);
            tower.transform.parent = parent;
            isPlaceable = false;
        }
        else
        {
            print("Can't place block at: " + GetGridPos());
        }
    }
}
