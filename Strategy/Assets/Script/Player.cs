using System;
using UnityEngine;

namespace Script
{
    public class Player : MonoBehaviour
    {
        public Animator _animator;

        private void Start()
        {
            _animator = GetComponent<Animator>();
        }
        
        public void SetAnimantion(string animName)
        {   
            _animator.SetTrigger(animName);
        }
    }
}