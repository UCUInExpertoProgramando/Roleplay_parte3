using System.Net.Http.Headers;
using System.Threading;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using RoleplayGame;

namespace Test.Library
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
            /*
                Justificaciones de los Tests:

                1-Test de Estadísticas Base: comprobar si tras crear un heroe 
                se puede obtener su nombre, ataque, defensa y vida.

                2-Test de Items: comprobar si se pueden añadir y remover items
                tanto a un heroe como a un enemigo, y que no se pueden añadir ni
                remover items mágicos a un heroe no mágico o a un enemigo no mágico.

                3-Test de Ataque y Curacion: comprobar que se puede atacar a un
                personaje y que su vida se reducirá, y comprobar que tras curarse,
                la vida regresa al máximo.

                4-Test de Encuentros: comprobar que funcionan los encuentros,
                para esto realizar un encuentro de un heroe contra un enemigo, luego de
                dos heroes contra dos enemigos, luego de dos heroes contra tres enemigos
                Después de cada encuentro se debe comprobar que los personajes involucrados 
                tienen los valores de vida y de puntos de victoria correspondientes.

            */
        }

        [Test]
        public void TestEstadisticasBase()
        {
            Archer legolas = new("Legolas"); //Creación del personaje
            Assert.AreEqual(100, legolas.Health); //Control de vida
            Assert.AreEqual(15, legolas.AttackValue); //Control de ataque
            Assert.AreEqual(18, legolas.DefenseValue); //Control de defensa
            Assert.AreEqual(2, legolas.items.Count); //Control de cantidad de items
        }

        [Test]
        public void TestItems()
        {
            Dwarf lucas = new("Lucas");
            Assert.AreEqual(2, lucas.items.Count);
            Assert.IsTrue(lucas.items[1] is Helmet);
            lucas.RemoveItem(lucas.items[1]);
            Assert.AreEqual(1, lucas.items.Count);
            lucas.AddItem(new Armor());
            Assert.AreEqual(2, lucas.items.Count);
            Assert.IsTrue(lucas.items[1] is Armor);

            Goblin goblin = new("Goblin");
            Assert.AreEqual(1, goblin.items.Count);
            Assert.IsTrue(goblin.items[0] is Dagger);
            goblin.RemoveItem(goblin.items[0]);
            Assert.AreEqual(0, goblin.items.Count);
            goblin.AddItem(new Shield());
            Assert.AreEqual(1, goblin.items.Count);
            Assert.IsTrue(goblin.items[0] is Shield);
        }

        [Test]
        public void TestAtaqueYCuracion()
        {
            //Creación y preparación de personajes
            Goblin goblin = new("Goblin");
            Wizard dumbledore = new("Dumbledore");
            SpellsBook grimorio = new();
            dumbledore.AddItem(grimorio);

            //Testeo de vida antes de los ataques
            Assert.AreEqual(150, goblin.Health);
            Assert.AreEqual(100, dumbledore.health);

            //Ataques y checkeo de vida posterior
            dumbledore.ReceiveAttack(goblin.AttackValue);
            goblin.ReceiveAttack(dumbledore.AttackValue);
            grimorio.AddSpell(new BasicSpell());
            Assert.AreEqual(90, dumbledore.health);
            Assert.AreEqual(50, goblin.Health);

            //Curación
            dumbledore.Cure();
            goblin.Cure();
            Assert.AreEqual(150, goblin.Health);
            Assert.AreEqual(100, dumbledore.health);
        }

        [Test]
        public void TestEncuentros()
        {
            //Encuentro de un héroe contra un enemigo
            Knight quijote = new("Don Quijote de la Mancha");
            ArmoredGoblin armGoblin = new("Armored Goblin");

            //Testeo previo al combate
            Assert.AreEqual(100, quijote.Health);
            Assert.AreEqual(0, quijote.VPCount);
            Assert.AreEqual(150, armGoblin.Health);
            Assert.AreEqual(2, armGoblin.VPValue);

            //Combate
            BattleEncounter batalla = new(quijote, armGoblin);
            batalla.DoEncounter();

            //Testeo posterior al combate
            Assert.AreEqual(100, quijote.Health);
            Assert.AreEqual(0, quijote.VPCount);
            Assert.AreEqual(150, armGoblin.Health);
            Assert.AreEqual(2, armGoblin.VPValue);



            //Encuentro de dos heroes contra dos enemigos
            Goblin goblin = new("Goblin");
            Lizard lizard = new("Lizard");
            Wizard dumbledore = new("Dumbledore");
            SpellsBook grimorio = new();
            grimorio.AddSpell(new BasicSpell());
            dumbledore.AddItem(grimorio);
            Dwarf lucas = new("Lucas");

            //Testeo previo al combate
            Assert.AreEqual(100, dumbledore.Health);
            Assert.AreEqual(0, dumbledore.VPCount);
            Assert.AreEqual(100, lucas.Health);
            Assert.AreEqual(0, lucas.VPCount);
            Assert.AreEqual(150, goblin.Health);
            Assert.AreEqual(1, goblin.VPValue);
            Assert.AreEqual(200, lizard.Health);
            Assert.AreEqual(2, lizard.VPValue);

            //Combate
            BattleEncounter dosContraDos = new(dumbledore, goblin);
            dosContraDos.AddHero(lucas);
            dosContraDos.AddEnemy(lizard);
            dosContraDos.DoEncounter();

            //Testeo posterior al combate
            Assert.AreEqual(100, dumbledore.Health);
            Assert.AreEqual(2, dumbledore.VPCount);
            Assert.AreEqual(100, lucas.Health);
            Assert.AreEqual(1, lucas.VPCount);
            Assert.AreEqual(0, goblin.Health);
            Assert.AreEqual(1, goblin.VPValue);
            Assert.AreEqual(0, lizard.Health);
            Assert.AreEqual(2, lizard.VPValue);




            //Encuentro de dos heroes contra tres enemigos
            Lizard lizard1 = new("Lizard 1");
            Lizard lizard2 = new("Lizard 2");
            Demon jefeFinal = new("Demonio Oscuro");
            Archer legolas = new("Legolas");
            


            //Testeo previo al combate
            Assert.AreEqual(200, lizard1.Health);
            Assert.AreEqual(2, lizard1.VPValue);
            Assert.AreEqual(200, lizard2.Health);
            Assert.AreEqual(2, lizard2.VPValue);
            Assert.AreEqual(500, jefeFinal.Health);
            Assert.AreEqual(5, jefeFinal.VPValue);
            Assert.AreEqual(100, legolas.Health);
            Assert.AreEqual(0, legolas.VPCount);

            //Combate
            BattleEncounter batallaFinal = new(legolas, jefeFinal);
            dumbledore.Cure();
            batallaFinal.AddHero(dumbledore);
            batallaFinal.AddEnemy(lizard1);
            batallaFinal.AddEnemy(lizard2);
            batallaFinal.DoEncounter();

            //Testeo posterior al combate
            Assert.AreEqual(0, lizard1.Health);
            Assert.AreEqual(2, lizard1.VPValue);
            Assert.AreEqual(0, lizard2.Health);
            Assert.AreEqual(2, lizard2.VPValue);
            Assert.AreEqual(0, jefeFinal.Health);
            Assert.AreEqual(5, jefeFinal.VPValue);
            Assert.AreEqual(0, legolas.Health);
            Assert.AreEqual(0, legolas.VPCount);
            Assert.AreEqual(100, dumbledore.Health);
            Assert.AreEqual(11, dumbledore.VPCount);
        }



    }
}