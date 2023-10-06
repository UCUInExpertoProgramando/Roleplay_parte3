namespace RoleplayGame
{
    public abstract class MagicHero: Hero
    {
        abstract void AddItem(MagicalItem item);
        abstract void RemoveItem(MagicalItem item);
    }
}
