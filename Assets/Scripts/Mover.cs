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

        // GetComponent<NavMeshAgent>().destination = target.position;

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
