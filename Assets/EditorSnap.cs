using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
[SelectionBase]
[RequireComponent(typeof(Block))]
public class EditorSnap : MonoBehaviour
{
    

    Block Waypoint;
    private void Awake()
    {
        Waypoint = GetComponent<Block>();
    }
    
    // Update is called once per frame
    void Update()
    {
        SnapToGrid();
        UpdateLabel();
    }

    private void SnapToGrid()
    {
        int gridSize = Waypoint.GetGridSize();
        transform.position = new Vector3(
           Waypoint.GetGridPos().x * gridSize, 
            0f, 
           Waypoint.GetGridPos().y * gridSize
        );
    }

    private void UpdateLabel()
    {
        int gridSize = Waypoint.GetGridSize();
        TextMesh textMesh = GetComponentInChildren<TextMesh>();
        string LabelText = Waypoint.GetGridPos().x + "," + Waypoint.GetGridPos().y;
        textMesh.text = LabelText;
        gameObject.name = LabelText;
    }
}
