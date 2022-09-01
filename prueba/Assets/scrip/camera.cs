using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform target;
    public Vector3 offset;
    [Range(1, 10)]
    public float smootherFactor;

    // Update is called once per frame
    void Update()
    {
        var targetPosition = target.position + offset;
        var smootherPosition = Vector3.Lerp(transform.position, targetPosition, smootherFactor * Time.fixedDeltaTime);
        transform.position = smootherPosition;    }
}
