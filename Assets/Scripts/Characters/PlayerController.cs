using RPG.Combat;
using RPG.Movement;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace RPG.Control
{

    public class PlayerController : MonoBehaviour
    {
        void Update()
        {
            if(InteractWithCombat()) return;
            if(InteractWithMovement()) return;
            print("CANT MOOOVEEEE");

        }

        private bool InteractWithCombat()
        {
            RaycastHit[] hits = Physics.RaycastAll(GetMouseRay());
            foreach (RaycastHit hit in hits)
            {
                CombatTarget target = hit.transform.GetComponent<CombatTarget>();
                if(target != null && !target.GetComponent<PlayerController>())
                {
                    if(Input.GetMouseButtonDown(0)) 
                    {
                        GetComponent<Fighter>().Attack(target);
                    }
                    return true;

                }
            }
            return false;
        }

        private bool InteractWithMovement()
        {
            RaycastHit hit;
            bool isHit = Physics.Raycast(GetMouseRay(), out hit);

            if (isHit)
            {
                if (Input.GetMouseButton(0))
                {
                    GetComponent<Mover>().OnActionMove(hit.point);
                }
                return true;
            }
            return false;

        }

        private static Ray GetMouseRay()
        {
            return Camera.main.ScreenPointToRay(Input.mousePosition);
        }
    }
}
