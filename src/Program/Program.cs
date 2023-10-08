using System;
using RoleplayGame;

namespace Program
{
    class Program
    {
        static void Main()
        {
            SpellsBook book = new();
            book.AddSpell(new BasicSpell());
            book.AddSpell(new BasicSpell());

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
