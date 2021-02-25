using RestWithAspNet.Model; 
using RestWithAspNet.Repository;
using System;
using System.Collections.Generic;
using System.Linq; 

namespace RestWithAspNet.Business.Implementations
{
    public class PersonBusinessImplementation : IPersonBusiness
    {
        private readonly IPersonRepository _repository;

        public PersonBusinessImplementation(IPersonRepository repository)
        {
            _repository = repository;
        }

        public Person Create(Person person)
        {
            return _repository.Create(person);
        }

        public void Delete(long id)
        {
            _repository.Delete(id);
        }

        public Person FindById(long id)
        {
            return _repository.FindById(id);
        }

        public List<Person> PersonFindAll()
        {
            return _repository.PersonFindAll();
        }

        public Person Update(Person person)
        {
            return _repository.Update(person);
        } 
    }
}
