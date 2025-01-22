using UnityEngine;
namespace Script
{
    public class AttackPerformer: MonoBehaviour
    {
        private Context _context;

        private void Start()
        {
            _context = new Context();
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                _context.PerformAttack();
            }
        }
        
        public void OnButtonClicked1()
        {
            _context.SetStrategy(new Attack1());
        }
        public void OnButtonClicked2()
        {
            _context.SetStrategy(new Attack2());
        }
        public void OnButtonClicked3()
        {
            _context.SetStrategy(new Attack3());
        }
    }
}