namespace RoleplayGame;

public interface Encounter
{
  public list<Heroe> heroes;
  public list<Enemigo> enemigos;
  public void DoEncounter();
}
