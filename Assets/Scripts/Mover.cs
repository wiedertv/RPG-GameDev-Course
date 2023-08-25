using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Mover : MonoBehaviour
{

    [Header("Target Info")]
    [field: SerializeField] private Transform target;


    private Ray lastRay;

    // Start is called before the first frame update
    void Start()
    {
         
    }

    // Update is called once per frame
    void Update()
    {

        if(Input.GetMouseButtonDown(0))
        {
            // get main camera and use ScreenPointToRay in the mouse position, to know where the player is clicking.
            lastRay = Camera.main.ScreenPointToRay(Input.mousePosition);         
        }

        Debug.DrawRay(lastRay.origin, lastRay.direction* 100);
        // GetComponent<NavMeshAgent>().destination = target.position;

    }
}
