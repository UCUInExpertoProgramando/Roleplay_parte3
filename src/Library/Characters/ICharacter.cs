namespace RoleplayGame
{
    public interface ICharacter
    {
        string Name { get; set; }

        public int Health { get; }

        public int AttackValue { get; }

        public int DefenseValue { get; }

        void AddItem(IItem item);

        void RemoveItem(IItem item);

        void Cure();

        void ReceiveAttack(int power);
    }
}