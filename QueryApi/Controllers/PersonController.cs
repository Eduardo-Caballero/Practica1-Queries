using System.Collections;
using Microsoft.AspNetCore.Mvc;
using QueryApi.Repositories;
using QueryApi.Domain;
using System;
using System.Collections.Generic;

namespace Controllers
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
    [ApiController]
    [Route("api/[controller]")]
    public class PersonController : ControllerBase
    {
        [HttpGet]
        [Route("")]
        public IActionResult GetAll()
        {
            var repository = new PersonRepository();
            var persons = repository.GetAll();
            return Ok(persons);
        } 

        [HttpGet]
        [Route("Consults/Information")]
        public IActionResult GetInformation()
        {
            var repository = new PersonRepository();
            var persons = repository.GetInformation();
            return Ok(persons);
        } 

        [HttpGet]
        [Route("Consults/ByGender/{gender}")]
        public IActionResult GetByGender(char gender)
        {
            var repository = new PersonRepository();
            var persons = repository.GetByGender(gender);
            return Ok(persons);
        }

        [HttpGet]
        [Route("Consults/Jobs")]
        public IActionResult GetJobs()
        {
            var repository = new PersonRepository();
            var persons = repository.GetJobs();
            return Ok(persons);
        }

        [HttpGet]
        [Route("Consults/PartOfName/{partName}")]
        public IActionResult GetContains(string partName)
        {
            var repository = new PersonRepository();
            var persons = repository.GetContains(partName);
            return Ok(persons);
        }

        [HttpGet]
        [Route("Consults/AgesSpecific/{age1}/{age2}/{age3}")]
        public IActionResult GetByAges(int age1, int age2, int age3)
        {
            var repository = new PersonRepository();
            var persons = repository.GetByAges(age1, age2, age3);
            return Ok(persons);
        }

        [HttpGet]
        [Route("Consults/AgeRange/{age1}/{age2}")]
        public IActionResult GetByRangeAge(int age1, int age2)
        {
            var repository = new PersonRepository();
            var persons = repository.GetByRangeAge(age1, age2);
            return Ok(persons);
        }

        [HttpGet]
        [Route("Consults/AgeOrdered/{age}")]
        public IActionResult GetPersonsOrdered(int age)
        {
            var repository = new PersonRepository();
            var persons = repository.GetPersonsOrdered(age);
            return Ok(persons);
        }

        [HttpGet]
        [Route("Consults/GenderAgeDescOrdered/{age1}/{age2}/{gender}")]
        public IActionResult GetPersonsOrderedDesc(int age1, int age2, char gender)
        {
            var repository = new PersonRepository();
            var persons = repository.GetPersonsOrderedDesc(age1, age2, gender);
            return Ok(persons);
        }

        [HttpGet]
        [Route("Consults/CountByGender/{gender}")]
        public IActionResult CountPeople(char gender)
        {
            var repository = new PersonRepository();
            var persons = repository.CountPeople(gender);
            return Ok(persons);
        }

        [HttpGet]
        [Route("Consults/Exist/{lastName}")]
        public IActionResult ExistPerson(string lastName)
        {
            var repository = new PersonRepository();
            var persons = repository.ExistPerson(lastName);
            return Ok(persons);
        }

        [HttpGet]
        [Route("Consults/PersonByJobAge/{job}/{age}")]
        public IActionResult GetPerson(string job, int age)
        {
            var repository = new PersonRepository();
            var persons = repository.GetPerson(job, age);
            return Ok(persons);
        }

        [HttpGet]
        [Route("Consults/TakeByJob/{job}/{take}")]
        public IActionResult TakePeople(string job, int take)
        {
            var repository = new PersonRepository();
            var persons = repository.TakePeople(job, take);
            return Ok(persons);
        }

        [HttpGet]
        [Route("Consults/SkipByJob/{job}/{skip}")]
        public IActionResult SkipPeople(string job, int skip)
        {
            var repository = new PersonRepository();
            var persons = repository.SkipPeople(job, skip);
            return Ok(persons);
        }

        [HttpGet]
        [Route("Consults/SkipTakeByJob/{job}/{skip}/{take}")]
        public IActionResult SkipTakePeople(string job, int skip, int take)
        {
            var repository = new PersonRepository();
            var persons = repository.SkipTakePeople(job, skip, take);
            return Ok(persons);
        }
    }
}