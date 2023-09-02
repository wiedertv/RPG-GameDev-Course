using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG.Combat
{
    public class Health : MonoBehaviour
    {

        [SerializeField] private float health = 100f;

        public bool IsDeath { get; private set; } = false;


        public void TakeDamage(float damage)
        {
            if (IsDeath) return;
            health = Mathf.Max(health - damage, 0);
            print(health);
            if(health == 0)
                TriggerDeathAnimation();
        }


        public void TriggerDeathAnimation()
        {
            GetComponent<Animator>().SetTrigger("Death");
            IsDeath = true;
        }

    }

}
