namespace RoleplayGame;

public class BattleEncounter : Encounter
{
  public BattleEncounter(Heroe heroe, Enemigo enemigo)
  {
    heroes.Add(heroe);
    enemigos.Add(enemigo);
  }

  public void DoEncounter()
  {
    int heroesVivos = heroes.length;
    int enemigosVivos = enemigos.length;
    
  
    //Todos los enemigos atacan una vez
    int contador = 0;
    
    foreach(enemigo in enemigos)
    {
      heroes[contador].ReceiveAttack(enemigo.AttackValue);
      contador++;
      if (contador>heroes.length-1)
      {
        contador -= heroes.length;
      }
    }

    //Todos los heroes sobrevivientes atacan a cada uno de los enemigos

    foreach(heroe in heroes)
    {
      foreach(enemigo in enemigos)
      {
        if (enemigo.Health > 0)
        {
          enemigo.ReceiveAttack(heroe.AttackValue);
        }
      }
    }
    
  }
}
