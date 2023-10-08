namespace RoleplayGame
{
    public class MagicBarrier: Spell
    {
        public override int AttackValue
        {
            get
            {
                return 0;
            }
        }

        public override int DefenseValue
        {
            get
            {
                return 100;
            }
        }
    }
}
