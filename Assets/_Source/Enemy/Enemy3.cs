using _Source.Script;
using UnityEngine;

namespace _Source.Enemy
{
    public class MimicEnemy : Enemy
    {
        private Animator _animator;
        private AttackPerformer _playerAttackPerformer;

        private void Awake()
        {
            _animator = GetComponent<Animator>();
            _playerAttackPerformer = FindObjectOfType<AttackPerformer>();
        }

        protected override void PerformAttackPattern()
        {
            Debug.Log("Mimic Enemy will synchronize with player.");
        
            if (_playerAttackPerformer != null)
            {
                _playerAttackPerformer.OnAttackStarted += OnPlayerAttack;
                _playerAttackPerformer.OnAttackEnded += OnPlayerIdle;
            }
        }

        private void OnPlayerAttack()
        {
            if (_animator != null)
            {
                _animator.SetTrigger("EnemyAttack3");
            }
            Debug.Log("Mimic Enemy attacks with player!");
        }

        private void OnPlayerIdle()
        {
            if (_animator != null)
            {
                _animator.SetTrigger("Idle");
            }
            Debug.Log("Mimic Enemy idles with player.");
        }

        public override void Deactivate()
        {
            if (_playerAttackPerformer != null)
            {
                _playerAttackPerformer.OnAttackStarted -= OnPlayerAttack;
                _playerAttackPerformer.OnAttackEnded -= OnPlayerIdle;
            }
            base.Deactivate();
        }
    }
}
