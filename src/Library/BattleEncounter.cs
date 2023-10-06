namespace RoleplayGame;

public class BattleEncounter : IEncounter
{
  public BattleEncounter(Heroe heroe, Enemigo enemigo)
  {
    heroes.Add(heroe);
    enemigos.Add(enemigo);
  }

  public void AddHero(Heroe heroe)
  {
    heroes.Add(heroe);
  }

  public void AddEnemy(Enemigo enemigo)
  {
    enemigos.Add(enemigo);
  }

  public void DoEncounter()
  {
    //Preparación previa al búcle de batalla
    int heroesVivos = heroes.length;
    int enemigosVivos = enemigos.length;
    list<int> VPGanados = new list<int>;
    foreach (heroe in heroes)
    {
      VPGanados.Add(0); //Define una lista con espacios para las cantidades de VP que obtuvo cada heroe en el encuentro.
    }

    //Búcle de Batalla

    while(enemigosVivos > 0 && heroesVivos > 0)
    {
      //Todos los enemigos atacan una vez
    
      int contador = 0;
      foreach(enemigo in enemigos)
      {
        if (heroesVivos > 0) //Comprueba que haya heroes vivos
        {
          //Comprueba que el heroe a atacar este vivo
          while(heroes[contador].Health <= 0)
          {
            contador++;
            if (contador>heroes.length-1)
            {
              contador -= heroes.length;
            }
          }

          //Ataca al heroe que le toca
          heroes[contador].ReceiveAttack(enemigo.AttackValue);
          if(heroes[contador].Health < 0)
          {
            //El enemigo mató al heroe con su ataque
            heroesVivos--;
          }
          contador++;
          if (contador>heroes.length-1)
          {
            contador -= heroes.length;
          }
        }
      }

      //Todos los heroes sobrevivientes atacan a cada uno de los enemigos

      foreach(heroe in heroes)
      {
        if (enemigosVivos > 0)
        {
          foreach(enemigo in enemigos)
          {
            if (enemigo.Health > 0)
            {
              enemigo.ReceiveAttack(heroe.AttackValue);
              if (enemigo.Health < 0)
              {
                //El heroe mató al enemigo con su ataque
                heroe.VPCount += enemigo.VPValue;
                VPGanados[heroes.IndexOf(heroe)] += enemigo.VPValue;
                enemigosVivos--;
              }
            }
          }
        }  
      }
    }

    //Tras terminar el búcle de batalla, curar los héroes que hayan ganado 5 VP o más.
    foreach(heroe in heroes)
    {
      if(VPGanados[heroes.IndexOf(heroe)] >= 5)
      {
        heroe.Cure();
      } 
    }
  }
}
