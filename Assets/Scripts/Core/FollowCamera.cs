using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{

    [field:Header("Target to follow")]
    [SerializeField]
    private Transform target;

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = target.position;   
    }
}
