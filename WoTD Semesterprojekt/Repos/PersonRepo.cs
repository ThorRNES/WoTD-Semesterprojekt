﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using WorkOutToDO.Models;

namespace WoTD_Semesterprojekt.Repos
{
    public class PersonRepo
    {
        private readonly List<Person> _persons = new();

        public PersonRepo()
        {
        }

        public IEnumerable<Person> GetAll()
        {
            return new List<Person>(_persons);
        }
        public Person? GetById(int id)
        {
            return _persons.Find(person => person.Id == id);
        }

        public IEnumerable<Person> Get(string? fname = null, string? gender = null, int? age = null, int? avgPulse = null, int? weight = null, int? height = null, string? orderBy = null)
        {
            IEnumerable<Person> result = new List<Person>(_persons);
            // Filtering
            if (!string.IsNullOrEmpty(fname))
            {
                result = result.Where(m => m.FName.Contains(fname, StringComparison.OrdinalIgnoreCase));
            }
            if (!string.IsNullOrEmpty(gender))
            {
                result = result.Where(m => m.Gender.Contains(gender, StringComparison.OrdinalIgnoreCase));
            }
            if (age.HasValue)
            {
                result = result.Where(m => m.Age == age.Value);
            }
            if (avgPulse.HasValue)
            {
                result = result.Where(m => m.AvgPulse == avgPulse.Value);
            }
            if (weight.HasValue)
            {
                result = result.Where(m => m.Weight == weight.Value);
            }
            if (height.HasValue)
            {
                result = result.Where(m => m.Height == height.Value);
            }
            // Ordering aka. sorting
            if (orderBy != null)
            {
                orderBy = orderBy.ToLower();
                switch (orderBy)
                {
                    case "fname": // fall through to next case
                    case "fname_asc":
                        result = result.OrderBy(m => m.FName);
                        break;
                    case "fname_desc":
                        result = result.OrderByDescending(m => m.FName);
                        break;

                    case "gender": // fall through to next case
                    case "gender_asc":
                        result = result.OrderBy(m => m.Gender);
                        break;
                    case "gender_desc":
                        result = result.OrderByDescending(m => m.Gender);
                        break;


                    case "age":
                    case "age_asc":
                        result = result.OrderBy(m => m.Age);
                        break;
                    case "age_desc":
                        result = result.OrderByDescending(m => m.Age);
                        break;

                    case "avgpulse":
                    case "avgpulse_asc":
                        result = result.OrderBy(m => m.AvgPulse);
                        break;
                    case "avgpulse_desc":
                        result = result.OrderByDescending(m => m.AvgPulse);
                        break;


                    case "weight":
                    case "weight_asc":
                        result = result.OrderBy(m => m.Weight);
                        break;
                    case "weight_desc":
                        result = result.OrderByDescending(m => m.Weight);
                        break;

                    case "height":
                    case "height_asc":
                        result = result.OrderBy(m => m.Height);
                        break;
                    case "height_desc":
                        result = result.OrderByDescending(m => m.Height);
                        break;

                    default:
                        break; // do nothing
                               //throw new ArgumentException("Unknown sort order: " + orderBy);
                }
            }
            return result;
        }
        public Person Add(Person person)
        {
            person.Validate();
            //person.Id = _nextId++;
            _persons.Add(person);
            return person;
        }
        public Person? Remove(int id)
        {
            Person? person = GetById(id);
            if (person == null)
            {
                return null;
            }
            _persons.Remove(person);
            return person;
        }
        public Person? Update(int id, Person person)
        {
            person.Validate();
            Person? existingPerson = GetById(id);
            if (existingPerson == null)
            {
                return null;
            }
            existingPerson.FName = person.FName;
            existingPerson.Age = person.Age;
            existingPerson.AvgPulse = person.AvgPulse;
            existingPerson.Weight = person.Weight;
            existingPerson.Height = person.Height;
            return existingPerson;
        }
    }
}