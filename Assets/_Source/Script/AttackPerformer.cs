using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace _Source.Script
{
     public class AttackPerformer : MonoBehaviour
    {
        public event Action OnStrategyChanged;
        public event Action OnAttackStarted;
        public event Action OnAttackEnded;
        
        [SerializeField] private Player player;
        [SerializeField] private Button[] buttons;
        [SerializeField] private Color activeColor = Color.yellow;
        [SerializeField] private Color defaultColor = Color.white;

        private Context _context;
        private bool _isAttacking = false;
        private int _currentAttackIndex = 0;

        private void Start()
        {
            Debug.Log($"Buttons array length: {buttons?.Length}");
            _context = new Context(player);
            
            // Подписываем кнопки на смену стратегии и врага
            buttons[0].onClick.AddListener(() => SetAttack(new Attack1(), 0));
            buttons[1].onClick.AddListener(() => SetAttack(new Attack2(), 1));
            buttons[2].onClick.AddListener(() => SetAttack(new Attack3(), 2));
            
            SetAttack(new Attack1(), 0);
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Q) && !_isAttacking)
            {
                PerformAttack();
            }
        }

        private void SetAttack(IAttackStrategy strategy, int index)
        {
            _context.SetStrategy(strategy);
            HighlightButton(index);
            _currentAttackIndex = index;
            OnStrategyChanged?.Invoke();
        }

        private void PerformAttack()
        {
            if (_isAttacking) return;
            
            _isAttacking = true;
            
            OnAttackStarted?.Invoke();
            
            _context.PerformAttack();
            
            StartCoroutine(WaitForAttackCompletion());
        }

        private IEnumerator WaitForAttackCompletion()
        {
            float attackDuration = GetAttackDuration();
            yield return new WaitForSeconds(attackDuration);
            
            _isAttacking = false;
            OnAttackEnded?.Invoke();
        }

        private float GetAttackDuration()
        {
            switch (_currentAttackIndex)
            {
                case 0: return 0.8f;
                case 1: return 1.2f; 
                case 2: return 0.6f; 
                default: return 1.0f;
            }
        }

        private void HighlightButton(int index)
        {
            for (int i = 0; i < buttons.Length; i++)
            {
                var colors = buttons[i].colors;
                colors.normalColor = i == index ? activeColor : defaultColor;
                buttons[i].colors = colors;
            }
        }
        
        public int GetCurrentAttackIndex()
        {
            return _currentAttackIndex;
        }
        
        public void SwitchToNextAttack()
        {
            int nextIndex = (_currentAttackIndex + 1) % buttons.Length;
            
            switch (nextIndex)
            {
                case 0: SetAttack(new Attack1(), 0); break;
                case 1: SetAttack(new Attack2(), 1); break;
                case 2: SetAttack(new Attack3(), 2); break;
            }
        }
    }
}