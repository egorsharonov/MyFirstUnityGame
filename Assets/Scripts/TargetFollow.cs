using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetFollow : MonoBehaviour
{
    [SerializeField] private Vector3 offset;
    [SerializeField, Range(0f, 1f)] private float smothtime = 0f;
    Vector3 velocity = Vector3.zero;
    [SerializeField] private Transform target;

    // Update is called once per frame
    void Update()
    {
        Vector3 targetPostion = target.position + offset;
        transform.position = Vector3.SmoothDamp(transform.position, targetPostion,ref velocity , smothtime);
    }
}
