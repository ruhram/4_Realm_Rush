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
           Waypoint.GetGridPos().x, 
            0f, 
           Waypoint.GetGridPos().y
        );
    }

    private void UpdateLabel()
    {
        TextMesh textMesh = GetComponentInChildren<TextMesh>();
        string LabelText = Waypoint.GetGridPos().x / Waypoint.GetGridSize() + "," + Waypoint.GetGridPos().x / Waypoint.GetGridSize();
        textMesh.text = LabelText;
        gameObject.name = LabelText;
    }
}
