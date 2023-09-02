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

        Health target;
        float timeSinceLastAttack = 0f;

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
                    GetComponent<Mover>().MoveTo(target.transform.position);

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
            if (target.IsDeath) return;
            transform.LookAt(target.transform);
            if (timeSinceLastAttack < 0)
            {
                /// This will trigger the Hit() event
                GetComponent<Animator>().ResetTrigger("CancelAttack");
                GetComponent<Animator>().SetTrigger("Attack");
                timeSinceLastAttack = timeBetweenAttacks;
            }   
        }
        ///  Animation Event
        private void Hit()
        {
            target.TakeDamage(weaponDamge);
        }

        private bool GetIsInRange()
        {
            return Vector3.Distance(transform.position, target.transform.position) < weaponRange;
        }

        public bool CanAttack(CombatTarget combatTarget)
        {
            if(combatTarget == null) return false;
            Health possibleTarget = combatTarget.GetComponent<Health>();
            return possibleTarget != null && !possibleTarget.IsDeath;
        }

        public void Attack(CombatTarget combatTarget)
        {
            GetComponent<ActionScheduler>().ActionStart(this);
            target = combatTarget.GetComponent<Health>();

        }

        public void Cancel()
        {
            target = null;
            GetComponent<Animator>().SetTrigger("CancelAttack");
            GetComponent<Animator>().ResetTrigger("Attack");
        }



    }
}

