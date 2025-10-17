using UnityEngine;

namespace _Source.Enemy
{
    public class MeleeEnemy : Enemy
    {
        private Animator _animator;

        private void Awake()
        {
            _animator = GetComponent<Animator>();
        }
        
        protected override void PerformAttackPattern()
        {
            Debug.Log("Melee Enemy performs a single attack.");
            if (_animator != null)
            {
                _animator.SetTrigger("EnemyAttack1");
            }
        }

        protected override void PlayIdleAnimation()
        {
            base.PlayIdleAnimation();
            if (_animator != null)
            {
                _animator.SetBool("Idle", true);
            }
        }

        public override void Deactivate()
        {
            if (_animator != null)
            {
                _animator.SetBool("Idle", false);
            }
            base.Deactivate();
        }
    }
}
