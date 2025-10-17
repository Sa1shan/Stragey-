using UnityEngine;

namespace _Source.Enemy
{
    public abstract class Enemy : MonoBehaviour
    {
        public virtual void Activate()
        {
            gameObject.SetActive(true);
            Debug.Log($"{gameObject.name} activated");
            DoTemplateBehaviour();
        }
        
        public void DoTemplateBehaviour()
        {
            PlaySpawnAnimation();
            PerformAttackPattern();
            PlayIdleAnimation();
        }
        
        protected virtual void PlaySpawnAnimation()
        {
            Debug.Log($"{gameObject.name} appears on the scene.");
        }
        
        protected abstract void PerformAttackPattern();
        
        protected virtual void PlayIdleAnimation()
        {
            Debug.Log($"{gameObject.name} is now idling.");
        }
        
        public virtual void Deactivate()
        {
            gameObject.SetActive(false);
            Debug.Log($"{gameObject.name} deactivated");
        }
    }
}