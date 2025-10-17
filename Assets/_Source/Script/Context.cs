namespace _Source.Script
{
    public class Context
    {
        private IAttackStrategy _strategy;
        private readonly Player _player;

        public Context(Player player)
        {
            _player = player;
        }

        public void SetStrategy(IAttackStrategy strategy)
        {
            _strategy = strategy;
        }

        public void PerformAttack()
        {
            _strategy?.PerformAttack(_player);
        }
    }
}
