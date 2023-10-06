namespace RoleplayGame;

public interface IEncounter
{
  public list<Heroe> heroes;
  public list<Enemigo> enemigos;
  public void AddHero(Heroe heroe);
  public void AddEnemy(Enemigo enemigo);
  public void DoEncounter();
}
