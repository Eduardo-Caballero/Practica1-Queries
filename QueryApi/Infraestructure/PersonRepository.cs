using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.IO;
using QueryApi.Domain;
using System.Threading.Tasks;

namespace QueryApi.Repositories
{
    public class PersonRepository
    {
        /*
    Nombre de la escuela: Universidad Tecnológica Metropolitana
    Asignatura: Aplicaciones Web Orientadas a Servicios
    Nombre del maestro: Joel Ivan Chuc Uc
    Nombre de la actividad: Practica 1 "Peticiones y routeo al controlador"
    Nombre del alumno: Eduardo Antonio Caballero Pech
    Cuatrimestre: 4
    Grupo: B
    Parcial: 2
    */
        List<Person> _persons;

        public PersonRepository()
        {
            var fileName = "dummy.data.queries.json";
            if(File.Exists(fileName))
            {
                var json = File.ReadAllText(fileName);
                _persons = JsonSerializer.Deserialize<IEnumerable<Person>>(json).ToList();
            }
        }

        // retornar todos los valores
        public IEnumerable<Person> GetAll()
        {
            var query = _persons.Select(person => person);
            return query;
        }

        // retornar campos especificos
        public IEnumerable<Object> GetInformation()
        {
            var query = _persons.Select(person => new{
                NombreCompleto=$"{person.FirstName} {person.LastName}",
                AnioNacimiento=DateTime.Now.AddYears(person.Age * -1).Year,
                CorreoElectronico=person.Email
            });

            return query;
        }

        // retornar elementos que sean iguales
        public IEnumerable<Person> GetByGender(char gender)
        {
            var Genero=gender;
            var query = _persons.Where(person => person.Gender==Genero);
            return query;
        }
        
        // Retornar elementos que sean diferentes
        public IEnumerable<string> GetJobs()
        {
            var query = _persons.Select(person => person.Job).Distinct();
            return query;
        }
        
        // retornar valores que contengan
        public IEnumerable<Person> GetContains(string partName)
        {
            var query = _persons.Where(person => person.FirstName.Contains(partName));
            return query;
        }

         public IEnumerable<Person> GetByAges(int age1, int age2, int age3)
        {
            var ages=new List<int>();
            ages.Add(age1);
            ages.Add(age2);
            ages.Add(age3);
            var query = _persons.Where(person => ages.Contains(person.Age));
            return query;
        }
        
        // retornar valores entre un rango
        public IEnumerable<Person> GetByRangeAge(int age1, int age2)
        {
            var query = _persons.Where(person => person.Age>=age1 && person.Age<=age2);
            return query;
        }
        
        // retornar elementos ordenados
        public IEnumerable<Person> GetPersonsOrdered(int age)
        {
            var query = _persons.Where(person => person.Age>age).OrderBy(person => person.Age);
            return query;
        }

        public IEnumerable<Person> GetPersonsOrderedDesc(int age1, int age2, char gender)
        {
            var query = _persons.Where(person =>person.Gender==gender && person.Age>=age1 && person.Age<=age2).
            OrderByDescending(person=>person.Age);
            return query;
        }
        
        // retorno cantidad de elementos
        public int CountPeople(char gender)
        {
            var query = _persons.Count(person => person.Gender==gender);
            return query;
        }
        
        // Evalua si un elemento existe
        public bool ExistPerson(string lastName)
        {
            var query=_persons.Exists(person => person.LastName==lastName);
            return query;
        }
        
        // retornar solo un elemento
        public Person GetPerson(string job, int age)
        {
            var query=_persons.FirstOrDefault(person=>person.Job==job && person.Age==age);

            return query;
        }
        
        // retornar solamente unos elementos
        public IEnumerable<Person> TakePeople(string job, int take)
        {
            var query = _persons.Where(person =>person.Job==job).Take(take);
            return query;
        }
        
        // retornar elementos saltando posición
        public IEnumerable<Person> SkipPeople(string job, int skip)
        {
            var query = _persons.Where(person =>person.Job==job).Skip(skip);
            return query;
        }

        public IEnumerable<Person> SkipTakePeople(string job, int skip, int take)
        {
            var query = _persons.Where(person =>person.Job==job).Skip(skip).Take(take);
            return query;
        }
        
    }
}