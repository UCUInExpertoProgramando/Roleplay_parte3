using System.Collections.Generic;
namespace RoleplayGame
{
    public class Wizard: MagicCharacter
    {
        private int health = 100;

        private List<Item> items = new List<Item>();

        private List<MagicalItem> magicalItems = new List<MagicalItem>();

        public Wizard(string name)
        {
            this.Name = name;
            
            this.AddItem(new Staff());
        }

        public string Name { get; set; }
        
        public int AttackValue
        {
            get
            {
                int value = 0;
                foreach (Item item in this.items)
                {
                    if (item is AttackItem)
                    {
                        value += (item as AttackItem).AttackValue;
                    }
                }
                foreach (MagicalItem item in this.magicalItems)
                {
                    if (item is IMagicalAttackItem)
                    {
                        value += (item as MagicalAttackItem).AttackValue;
                    }
                }
                return value;
            }
        }

        public int DefenseValue
        {
            get
            {
                int value = 0;
                foreach (Item item in this.items)
                {
                    if (item is DefenseItem)
                    {
                        value += (item as DefenseItem).DefenseValue;
                    }
                }
                foreach (MagicalItem item in this.magicalItems)
                {
                    if (item is MagicalDefenseItem)
                    {
                        value += (item as MagicalDefenseItem).DefenseValue;
                    }
                }
                return value;
            }
        }

        public int Health
        {
            get
            {
                return this.health;
            }
            private set
            {
                this.health = value < 0 ? 0 : value;
            }
        }

        public void ReceiveAttack(int power)
        {
            if (this.DefenseValue < power)
            {
                this.Health -= power - this.DefenseValue;
            }
        }

        public void Cure()
        {
            this.Health = 100;
        }

        public void AddItem(Item item)
        {
            this.items.Add(item);
        }

        public void RemoveItem(Item item)
        {
            this.items.Remove(item);
        }

        public void AddItem(MagicalItem item)
        {
            this.magicalItems.Add(item);
        }

        public void RemoveItem(MagicalItem item)
        {
            this.magicalItems.Remove(item);
        }

    }
}
