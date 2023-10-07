namespace RoleplayGame
{
    public interface IMagicHero: IHero
    {
        public void AddItem(IMagicalItem item);
        public void RemoveItem(IMagicalItem item);
    }
}
