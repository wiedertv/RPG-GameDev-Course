using RPG.Movement;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace RPG.Combat
{
    public class Fighter : MonoBehaviour
    {
        [Header("Weapon")]
        [field: SerializeField]
        private float weaponRange = 2f;

        Transform target;

        private void Awake()
        {
        }

        private void Update()
        {
            MoveToRange();
        }

        private void MoveToRange()
        {
            if (target != null)
            {

                if (!GetIsInRange())
                {
                    GetComponent<Mover>().MoveTo(target.position);

                }
                else
                {
                    GetComponent<Mover>().Stop();
                }
            }
        }

        private bool GetIsInRange()
        {
            return Vector3.Distance(transform.position, target.position) < weaponRange;
        }

        public void Attack(CombatTarget combatTarget)
        {
            target = combatTarget.transform;
        }

        public void Cancel()
        {
            target = null;
        }
    }
}

