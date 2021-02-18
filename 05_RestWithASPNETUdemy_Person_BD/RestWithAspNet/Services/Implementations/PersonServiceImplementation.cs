using RestWithAspNet.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace RestWithAspNet.Services.Implementations
{
    public class PersonServiceImplementation : IPersonServices
    {
        private volatile int count ;

        public Person Create(Person person)
        {
            return person;
        }

        public void Delete(long id)
        { 
        }

        public Person FindById(long id)
        {
            return new Person
            {
                Id = IncrementAndGet(),
                FirtName = "Lima",
                LastName = "Papai",
                Address = "Atibaia - SP - Brasil",
                Gender = "Male"

            };
        }

        public List<Person> PersonFindAll()
        {
            List<Person> persons = new List<Person>();
            for (int i = 0; i < 8; i++ )
            {
                Person person = MockPerson(i);
                persons.Add(person);   
            }
            return persons;
        }

        private Person MockPerson(int i)
        {
            return new Person
            {
                Id = IncrementAndGet(),
                FirtName = "Persin Name" + i,
                LastName = "Person last Name" + i,
                Address = "Address - Brasil" + i,
                Gender = "Male/Female"

            };
        }

        private long IncrementAndGet()
        {
            return Interlocked.Increment(ref count);
        }

        public Person Update(Person person)
        {
            return person;
        }
    }
}
