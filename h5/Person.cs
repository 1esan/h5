using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace h5
{
    public class Person
    {
        private string name;
        private int age;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public int Age
        {
            get { return age; }
            set
            {
                if (value < 0) value = 0;
                age = value;
            }
        }

        public Person(string name, int age)
        {
            this.name = name;
            this.age = age;
        }

        public virtual void Print()
        {
            Console.WriteLine("Имя: {0}, Возраст: {1}", name, age);
        }

        public override string ToString()
        {
            return $"Товарищи: {name}, {age}";
        }

        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            if (obj.GetType() != this.GetType()) return false;
            Person p = (Person)obj;
            return name == p.name && age == p.age;
        }

        public override int GetHashCode()
        {
            return name.GetHashCode() ^ age.GetHashCode();
        }

        private static Person[] persons = new Person[]
        {
        new Person("Алиса", 20),
        new Person("Пётр", 25),
        new Person("Сергей", 30),
        new Person("Давид", 35),
        new Person("Ева", 40)
        };

        public static Person RandomPerson()
        {
            Random rnd = new Random();
            int index = rnd.Next(persons.Length);
            return persons[index];
        }

        public virtual object Clone()
        {
            return new Person(name, age);
        }
    }

}

