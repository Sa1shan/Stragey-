namespace Script
{
    public interface IStrategy
    {
        void PerformAttack();
    }

    public class Attack1 : Player, IStrategy
    {
        public void PerformAttack()
        {
            SetAnimantion("Attack1");
        }
    }

    public class Attack2 : Player, IStrategy
    {
        public void PerformAttack()
        {
            SetAnimantion("Attack2");
        }
    }

    public class Attack3 : Player, IStrategy
    {
        public void PerformAttack()
        {
            SetAnimantion("Attack3");
        }
    }
}