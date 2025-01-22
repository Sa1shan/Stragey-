namespace Script
{
    public class Context
    {
        private IStrategy _strategy;

        public void SetStrategy(IStrategy strategy)
        {
            _strategy = strategy;
        }

        public void PerformAttack()
        {
            if (_strategy != null)
            {
                _strategy.PerformAttack();
            }
        }
    }
}
