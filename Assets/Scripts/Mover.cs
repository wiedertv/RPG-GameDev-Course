using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Mover : MonoBehaviour
{

    [Header("Target Info")]
    [field: SerializeField] private Transform target;

    void Update()
    {

        if(Input.GetMouseButtonDown(0))
        {
            MoveToCursor();
        }

        UpdateAnimator();

        // GetComponent<NavMeshAgent>().destination = target.position;

    }

    private void UpdateAnimator()
    {
        /// in this case we are getting the global velocity (global transform)
        Vector3 velocity = GetComponent<NavMeshAgent>().velocity;

        /// here we convert the transform of that velocity to locale 
        Vector3 localVelocity = transform.InverseTransformDirection(velocity);

        float speed = localVelocity.z;

        GetComponent<Animator>().SetFloat("Movement", speed);
    }

    private void MoveToCursor()
    {

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        bool isHit = Physics.Raycast(ray, out hit);

        if (isHit)
        {
            GetComponent<NavMeshAgent>().destination = hit.point;
        }

    }
}
