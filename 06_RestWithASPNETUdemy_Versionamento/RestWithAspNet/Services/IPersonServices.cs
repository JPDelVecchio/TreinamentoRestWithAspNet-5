﻿using System.Collections.Generic;
using RestWithAspNet.Model;

namespace RestWithAspNet.Services
{
    public interface IPersonServices
    {
        Person Create(Person person);
        Person FindById(long id);
        Person Update(Person person);
        void Delete(long id);
        List<Person> PersonFindAll();
    }
}
