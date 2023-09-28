namespace RoleplayGame
{
    public abstract class MagicCharacter: Character
    {
        abstract void AddItem(MagicalItem item);
        abstract void RemoveItem(MagicalItem item);
    }
}
