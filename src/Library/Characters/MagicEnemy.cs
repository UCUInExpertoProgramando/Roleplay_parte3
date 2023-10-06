namespace RoleplayGame;

public abstract class MagicEnemy : Enemy
{
  public abstract void AddItem(MagicalItem item);
  public abstract void RemoveItem(MagicalItem item);
}
