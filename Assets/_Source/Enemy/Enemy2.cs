using UnityEngine;

namespace _Source.Enemy
{
    public class RangedEnemy : Enemy
    {
        private Animator _animator;
        private bool _isAttacking = false;
    
        [SerializeField] private GameObject projectilePrefab;
        [SerializeField] private Transform firePoint;
        [SerializeField] private float attackRate = 1f;

        private void Awake()
        {
            _animator = GetComponent<Animator>();
        }

        protected override void PerformAttackPattern()
        {
            Debug.Log("Ranged Enemy starts spamming attacks.");
            _isAttacking = true;
            if (gameObject.activeSelf == true)
            {
                InvokeRepeating(nameof(Shoot), 0f, attackRate);
            }
        }

        private void Shoot()
        {
            if (!gameObject.activeSelf) return;
            
            if (!_isAttacking) return;
            
            // Создаем снаряд
            if (projectilePrefab != null && firePoint != null)
            {
                Instantiate(projectilePrefab, firePoint.position, firePoint.rotation);
            }
        }

        public override void Deactivate()
        {
            _isAttacking = false;
            CancelInvoke(nameof(Shoot));
            base.Deactivate();
        }
    }
}