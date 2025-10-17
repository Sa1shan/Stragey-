namespace _Source.Script
{
    public interface IAttackStrategy
    {
        public void PerformAttack(Player player);
    }
    
    public class Attack1 : IAttackStrategy
    {

        public void PerformAttack(Player player)
        {
            player.SetAnimation("Attack1");
        }
    }

    public class Attack2 : IAttackStrategy
    {
        public void PerformAttack(Player player)
        {
            player.SetAnimation("Attack2");
        }
    }

    public class Attack3 : IAttackStrategy
    {
        public void PerformAttack(Player player)
        {
            player.SetAnimation("Attack3");
        }
    }
}