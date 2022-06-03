using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DistortionFixer : MonoBehaviour
{
    public Transform boardLocation;
    public Transform glassesLocation;

    public float maxOffsetDistance = 0;

    Vector3 originalPosition;

    void Start()
    {
        originalPosition = transform.position;
    }

    void LateUpdate()
    {
        var direction = Vector3.Normalize(glassesLocation.position - boardLocation.position);
        var angle = Vector3.Angle(Vector3.up, direction);
        var offsetDir = Vector3.Normalize(Vector3.ProjectOnPlane(glassesLocation.position - boardLocation.position, Vector3.up));

        var offset = offsetDir * Mathf.Sin(angle*Mathf.Deg2Rad) * maxOffsetDistance;

        transform.position = originalPosition + offset;
    }
}
