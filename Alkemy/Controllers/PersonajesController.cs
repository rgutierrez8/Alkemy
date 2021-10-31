using Alkemy.Models;
using Alkemy.Repositories;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Alkemy.Controllers
{
    [Route("character")]
    public class PersonajesController : Controller
    {
        private IPersonajeRepository _repository;
        private IPeliculaRepository _peliculaRepository;
        private IGeneroPeliculaRepository _generoPeliculaRepository;
        private IPersonajePeliculaRepository _personajePeliculaRepository;

        public PersonajesController(IPersonajeRepository repository, IPeliculaRepository peliculaRepository, 
            IGeneroPeliculaRepository generoPeliculaRepository, IPersonajePeliculaRepository personajePeliculaRepository)
        {
            _repository = repository;
            _peliculaRepository = peliculaRepository;
            _generoPeliculaRepository = generoPeliculaRepository;
            _personajePeliculaRepository = personajePeliculaRepository;
        }
        public ActionResult Characters(string name, int age, float weight, int idMovie)
      {

            ListaPersonajes personajes = new ListaPersonajes
            {
                Personajes = _repository.GetAllCharacters().Select(pers => new PersonajeDTO
                {
                    Imagen = pers.Imagen,
                    Nombre = pers.Nombre
                }).ToList()
            };

            if(name != "" && name != null)
            {
                if(age > 0) 
                {
                    personajes = new ListaPersonajes
                    {
                        Personajes = _repository.SearchByName(name, age, weight).Select(pers => new PersonajeDTO
                        {
                            Imagen = pers.Imagen,
                            Nombre = pers.Nombre
                        }).ToList()
                    };
                }
                else if(weight > 0)
                {
                    personajes = new ListaPersonajes
                    {
                        Personajes = _repository.SearchByName(name, age, weight).Select(pers => new PersonajeDTO
                        {
                            Imagen = pers.Imagen,
                            Nombre = pers.Nombre
                        }).ToList()
                    };
                }
                else if(idMovie > 0)
                {
                    personajes = new ListaPersonajes
                    {
                        Personajes = _personajePeliculaRepository.Search(name, idMovie).Select(pers => new PersonajeDTO
                        {
                            Imagen = pers.Personaje.Imagen,
                            Nombre = pers.Personaje.Nombre
                        }).Distinct().ToList()
                    };
                }
                else
                {
                    personajes = new ListaPersonajes
                    {
                        Personajes = _repository.SearchByName(name, age, weight).Select(pers => new PersonajeDTO
                        {
                            Imagen = pers.Imagen,
                            Nombre = pers.Nombre
                        }).ToList()
                    };
                }
            }

            return Ok(personajes);
        }

        [HttpPost("movies")]
        public IActionResult Movies()
        {
            Array listMovies = _peliculaRepository.GetAllMovies().Select(movie => new PeliculaSerie
            {
                Id = movie.Id,
                Titulo = movie.Titulo
            }).ToArray();


            return Ok(listMovies);
        }
    }
}
