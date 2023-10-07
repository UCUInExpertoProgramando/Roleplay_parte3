using NUnit.Framework;

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

                4-Test de Encuentro Uno Contra Uno: comprobar que funcionan los encuentros,
                para esto realizar un encuentro de un heroe contra un enemigo, luego de
                tres heroes contra tres enemigos, luego de seis heroes contra tres enemigos, y
                luego de tres heroes contra seis enemigos.
                Después de cada encuentro se debe comprobar que los personajes involucrados 
                tienen los valores de vida y de puntos de victoria correspondientes.

            */
        }

        [Test]
        public void Test1()
        {
            Assert.Pass();
        }
    }
}