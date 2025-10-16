using UnityEngine;
using UnityEngine.UI;

namespace Script
{
    public class AttackPerformer : MonoBehaviour
    {
        [SerializeField] private Player _player;
        [SerializeField] private Button[] _buttons;
        [SerializeField] private Color _activeColor = Color.yellow;
        [SerializeField] private Color _defaultColor = Color.white;

        private Context _context;

        private void Start()
        {
            Debug.Log($"Buttons array length: {_buttons?.Length}");
            _context = new Context(_player);
            
            _buttons[0].onClick.AddListener(() => SetAttack(new Attack1(), 0));
            _buttons[1].onClick.AddListener(() => SetAttack(new Attack2(), 1));
            _buttons[2].onClick.AddListener(() => SetAttack(new Attack3(), 2));
            
            SetAttack(new Attack1(), 0);
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                _context.PerformAttack();
            }
        }

        private void SetAttack(IAttackStrategy strategy, int index)
        {
            _context.SetStrategy(strategy);
            HighlightButton(index);
        }

        private void HighlightButton(int index)
        {
            for (int i = 0; i < _buttons.Length; i++)
            {
                var colors = _buttons[i].colors;
                colors.normalColor = i == index ? _activeColor : _defaultColor;
                _buttons[i].colors = colors;
            }
        }
    }
}