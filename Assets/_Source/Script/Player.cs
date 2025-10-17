using System;
using UnityEngine;

namespace _Source.Script
{
    public class Player : MonoBehaviour
    {
        public event Action OnAttack;
        
        [SerializeField] private Animator animator;

        private void Start()
        {
            animator = GetComponent<Animator>();
        }

        public void SetAnimation(string animName)
        {
            animator.SetTrigger(animName);
            if (animName.StartsWith("Attack"))
                OnAttack?.Invoke();
        }
    }
}