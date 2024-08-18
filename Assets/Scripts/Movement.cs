using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Movement : MonoBehaviour
{
    [SerializeField] public Status status;
    
    void Walk()
    {
        transform.position = Vector3.MoveTowards(transform.position, (Vector3)status.targetPos, status.walkSpeed * Time.deltaTime);
    }

    void Start()
    {
    }

    void Update()
    {
        Walk();
    }
}
