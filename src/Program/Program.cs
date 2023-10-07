using System;
using RoleplayGame;

namespace Program
{
    class Program
    {
        static void Main()
        {
            SpellsBook book = new();
            book.AddSpell(new SpellOne());
            book.AddSpell(new SpellOne());

            Wizard gandalf = new("Gandalf");
            gandalf.AddItem(book);

            Dwarf gimli = new("Gimli");

            Console.WriteLine($"Gimli has ❤️ {gimli.Health}");
            Console.WriteLine($"Gandalf attacks Gimli with ⚔️ {gandalf.AttackValue}");

            gimli.ReceiveAttack(gandalf.AttackValue);

            Console.WriteLine($"Gimli has ❤️ {gimli.Health}");

            gimli.Cure();

            Console.WriteLine($"Someone cured Gimli. Gimli now has ❤️ {gimli.Health}");
        }
    }
}
