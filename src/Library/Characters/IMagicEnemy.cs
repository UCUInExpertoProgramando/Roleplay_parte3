namespace RoleplayGame;

public interface IMagicEnemy : IEnemy
{
  public void AddItem(IMagicalItem item);
  public void RemoveItem(IMagicalItem item);
}
