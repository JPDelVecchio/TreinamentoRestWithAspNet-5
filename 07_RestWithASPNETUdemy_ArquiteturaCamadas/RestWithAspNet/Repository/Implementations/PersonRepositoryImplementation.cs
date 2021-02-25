using RestWithAspNet.Model;
using RestWithAspNet.Model.Context; 
using System;
using System.Collections.Generic;
using System.Linq; 

namespace RestWithAspNet.Repository.Implementations
{
    public class PersonRepositoryImplementation : IPersonRepository

    {
        private MySqlContext _context;

        public PersonRepositoryImplementation(MySqlContext context)
        {
            _context = context;
        }

        public Person Create(Person person)
        {
            try
            {
                _context.Add(person);
                _context.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
            return person;
        }

        public void Delete(long id)
        {
            var result = _context.Persons.SingleOrDefault(p => p.Id.Equals(id));
            if (result != null)
            {
                try
                {
                    _context.Persons.Remove(result) ;
                    _context.SaveChanges();
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

        public Person FindById(long id)
        {
            return _context.Persons.SingleOrDefault(p => p.Id.Equals(id));
        }

        public List<Person> PersonFindAll()
        {
            return _context.Persons.ToList();
        }

        public Person Update(Person person)
        {
            if (!Exist(person.Id)) return new Person();

            var result = _context.Persons.SingleOrDefault(p => p.Id.Equals(person.Id));
            if (result != null)
            {
                try
                {
                    _context.Entry(result).CurrentValues.SetValues(person);
                    _context.SaveChanges();
                }
                catch (Exception)
                {
                    throw;
                }
            } 
            return person;
        }

        public bool Exist(long id)
        {
            return _context.Persons.Any(p => p.Id.Equals(id));
        }
    }
}
