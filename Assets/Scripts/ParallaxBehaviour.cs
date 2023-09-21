using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements.Experimental;

public class ParallaxBehaviour : MonoBehaviour
{
    [SerializeField] Transform targetToFollow;
    [SerializeField, Range(0f, 1f)] float xParallaxStrength;
    [SerializeField, Range(0f, 1f)] float yParallaxStrength;
    [SerializeField] bool disableVerticalParallax;
    Vector3 targetPreviousPosition;
    
    // Start is called before the first frame update
    void Start()
    {
        if (!targetToFollow)
        {
            targetToFollow = Camera.main.transform;
        }
        targetPreviousPosition = targetToFollow.position;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 delta = targetToFollow.position - targetPreviousPosition;
        if (disableVerticalParallax)
            delta.y = 0;
        targetPreviousPosition = targetToFollow.position;
        transform.position += new Vector3(delta.x * xParallaxStrength, delta.y * yParallaxStrength,0);
    }
}
