using System;
using UnityEngine;

namespace Script
{
    public class Player : MonoBehaviour
    {
        private Animator _animator;

        private void Awake()
        {
            _animator = GetComponent<Animator>();
        }

        public void SetAnimation(string animName)
        {
            _animator.SetTrigger(animName);
        }
    }
}