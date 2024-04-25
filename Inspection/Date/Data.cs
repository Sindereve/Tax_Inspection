using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace Inspection.Date
{
    public class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }

        public ObservableCollection<Person> dataSet()
        {
            // Создание коллекции объектов
            ObservableCollection<Person> people = new ObservableCollection<Person>();

            // Добавление объектов в коллекцию
            people.Add(new Person { Name = "Иван", Age = 30 });
            people.Add(new Person { Name = "Мария", Age = 25 });
            people.Add(new Person { Name = "Петр", Age = 35 });
            for (int i = 1; i <= 100; i++)
            {
                people.Add(new Person { Name = $"Человек {i}", Age = i });
            }

            return people;
        }
    }

    
}
