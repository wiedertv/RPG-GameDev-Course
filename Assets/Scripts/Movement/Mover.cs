using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


namespace RPG.Movement
{
    public class Mover : MonoBehaviour
    {
        void Update()
        {
            UpdateAnimator();
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

        public void MoveTo(Vector3 destination)
        {
            GetComponent<NavMeshAgent>().destination = destination;
        }
    }

}
