using System;
namespace CloneAndCompare
{
    class Person : ICloneable, IComparable<Person>
    {
        private string Name { get; set; }
        private int Age { get; set; }
        public Person(string name, int age)
        {
            Name = name;
            Age = age;
        }
        public object Clone()
        {
            return new Person(this.Name, this.Age);
        }
        public int CompareTo(Person other)
        {
            if (other == null)
            {
                return 1;
            }
            else
            {
                return this.Age.CompareTo(other.Age);
            }
        }
        public override string ToString()
        {
            return $"Name: {Name}, Age: {Age}";
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Person person1 = new Person("Иван", 18);
            Person person2 = (Person)person1.Clone();
            Console.WriteLine("Сравнение:");
            Console.WriteLine(person1.CompareTo(person2));
            Console.WriteLine("Информация:");
            Console.WriteLine(person1.ToString());
            Console.ReadKey();
        }
    }
}