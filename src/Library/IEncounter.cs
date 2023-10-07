using System.Collections.Generic;

namespace RoleplayGame;

public abstract class Encounter
{
  public List<IHero> heroes;
  public List<IEnemy> enemigos;
  public abstract void AddHero(IHero heroe);
  public abstract void AddEnemy(IEnemy enemigo);
  public abstract void DoEncounter();
}
