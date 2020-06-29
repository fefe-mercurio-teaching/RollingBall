using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowObject : MonoBehaviour
{
    [SerializeField] Transform objectToFollow;
    [SerializeField] Vector3 offset;

    void Update()
    {
        transform.position = new Vector3(objectToFollow.position.x,
            transform.position.y,
            objectToFollow.position.z) + offset;
    }
}
