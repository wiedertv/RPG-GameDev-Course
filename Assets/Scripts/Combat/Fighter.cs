using RPG.Core;
using RPG.Movement;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace RPG.Combat
{
    public class Fighter : MonoBehaviour, IAction
    {
        [Header("Weapon")]
        [field: SerializeField]
        private float weaponRange = 2f;
        [field: SerializeField]
        private float timeBetweenAttacks = 1f;
        [field: SerializeField]
        private float weaponDamge = 5f;

        Transform target;
        float timeSinceLastAttack = 0f;
        Health healthTarget;

        private void Awake()
        {
        }

        private void Update()
        {
            timeSinceLastAttack -= Time.deltaTime;
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
                    GetComponent<Mover>().Cancel();
                    AttackBehaviour();
                }
            }
        }

        private void AttackBehaviour()
        {
            if(timeSinceLastAttack < 0)
            {
                /// This will trigger the Hit() event
                GetComponent<Animator>().SetTrigger("Attack");
                timeSinceLastAttack = timeBetweenAttacks;
                healthTarget = target.GetComponent<Health>();
            }   
        }
        ///  Animation Event
        private void Hit()
        {
            healthTarget.TakeDamage(weaponDamge);
        }

        private bool GetIsInRange()
        {
            return Vector3.Distance(transform.position, target.position) < weaponRange;
        }

        public void Attack(CombatTarget combatTarget)
        {
            GetComponent<ActionScheduler>().ActionStart(this);
            target = combatTarget.transform;
        }

        public void Cancel()
        {
            target = null;
        }



    }
}

