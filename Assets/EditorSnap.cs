﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class EditorSnap : MonoBehaviour
{
    [SerializeField] [Range(1f, 10f)] float gridSize = 10f;
    TextMesh textMesh;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 snapPos;

        snapPos.x = Mathf.RoundToInt(transform.position.x / gridSize) * gridSize;
        snapPos.z = Mathf.RoundToInt(transform.position.z / gridSize) * gridSize;

        textMesh = GetComponentInChildren<TextMesh>();
        string LabelText = snapPos.x / gridSize + "," + snapPos.z / gridSize;
        textMesh.text = LabelText;

        gameObject.name = LabelText;

        transform.position = new Vector3(snapPos.x, 0f, snapPos.z);

    }
}
