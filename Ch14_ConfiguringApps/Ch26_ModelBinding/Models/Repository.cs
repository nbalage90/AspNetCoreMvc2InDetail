﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ch26_ModelBinding.Models
{
    public interface IRepository
    {
        IEnumerable<Person> People { get; }
        Person this[int id] { get; set; }
    }
    public class Repository : IRepository
    {
        private Dictionary<int, Person> people = new Dictionary<int, Person>
        {
            [1] = new Person { PersonId = 1, FirstName = "Bob", LastName = "Smith", Role = Role.Admin },
            [2] = new Person { PersonId = 2, FirstName = "Anne", LastName = "Douglas", Role = Role.User },
            [3] = new Person { PersonId = 3, FirstName = "Joe", LastName = "Able", Role = Role.User },
            [4] = new Person { PersonId = 4, FirstName = "Mary", LastName = "Peters", Role = Role.Guest },
        };

        public IEnumerable<Person> People => people.Values;

        public Person this[int id]
        {
            get
            {
                return people.ContainsKey(id) ? people[id] : null;
            }
            set
            {
                people[id] = value;
            }
        }
    }
}
