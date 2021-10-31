using Alkemy.Models;
using Alkemy.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Alkemy.Controllers
{
    [Route("movie")]
    public class PeliculasController : Controller
    {
        private IPeliculaRepository _repository;
        private IGeneroRepository _generoRepository;
        private IGeneroPeliculaRepository _generoPeliculaRepository;

        public PeliculasController(IPeliculaRepository repository, IGeneroRepository generoRepository, 
                IGeneroPeliculaRepository generoPeliculaRepository)
        {
            _repository = repository;
            _generoRepository = generoRepository;
            _generoPeliculaRepository = generoPeliculaRepository;
        }

        // ============================== LISTADO DE PELICULAS ====================================================
        public ActionResult Movies(string name, string genre, string order, string datos)
        {
            ListaPeliculas lista;


            lista = new ListaPeliculas
            {
                PeliculaSeries = _repository.GetAllMovies().Select(movie => new PeliculaSerieDTO
                {
                    Imagen = movie.Imagen,
                    Titulo = movie.Titulo,
                    FechaCreacion = movie.FechaCreacion,
                    GeneroPelicula = movie.GeneroPelicula.Select(gp => new GeneroPelicula
                    {
                        Genero = new Genero { 
                            Nombre = gp.Genero.Nombre
                        }
                    }).ToList()
                }).ToList()
            };

            if (name != "" && name != null && ((genre != "none" && genre != "" && genre != null) || (order != "" && order != null)))
            {

                if(order == "asc")
                {
                    if(genre != "" && genre != "none")
                    {
                        lista = new ListaPeliculas
                        {
                            PeliculaSeries = _generoPeliculaRepository.SearchByGenre(genre, name, order).Select(movie => new PeliculaSerieDTO
                            {
                                Imagen = movie.PeliculaSerie.Imagen,
                                Titulo = movie.PeliculaSerie.Titulo
                            }).ToList()
                        };
                    }
                    else
                    {
                        lista = new ListaPeliculas
                        {
                            PeliculaSeries = _repository.SearchByName(name, order).Select(movie => new PeliculaSerieDTO
                            {
                                Imagen = movie.Imagen,
                                Titulo = movie.Titulo,
                                FechaCreacion = movie.FechaCreacion,
                                GeneroPelicula = movie.GeneroPelicula.Select(gp => new GeneroPelicula
                                {
                                    Genero = new Genero
                                    {
                                        Nombre = gp.Genero.Nombre
                                    }
                                }).ToList()
                            }).ToList()
                        };
                    }
                }
                else if(order == "desc")
                {
                    if (genre != "" && genre != "none")
                    {
                        lista = new ListaPeliculas
                        {
                            PeliculaSeries = _generoPeliculaRepository.SearchByGenre(genre, name, order).Select(movie => new PeliculaSerieDTO
                            {
                                Imagen = movie.PeliculaSerie.Imagen,
                                Titulo = movie.PeliculaSerie.Titulo
                            }).ToList()
                        };
                    }
                    else
                    {
                        lista = new ListaPeliculas
                        {
                            PeliculaSeries = _repository.SearchByName(name, order).Select(movie => new PeliculaSerieDTO
                            {
                                Imagen = movie.Imagen,
                                Titulo = movie.Titulo,
                                FechaCreacion = movie.FechaCreacion,
                                GeneroPelicula = movie.GeneroPelicula.Select(gp => new GeneroPelicula
                                {
                                    Genero = new Genero
                                    {
                                        Nombre = gp.Genero.Nombre
                                    }
                                }).ToList()
                            }).ToList()
                        };
                    }
                }
                else
                {
                    if (genre != "" && genre != "none")
                    {
                        lista = new ListaPeliculas
                        {
                            PeliculaSeries = _generoPeliculaRepository.SearchByGenre(genre, name, order).Select(movie => new PeliculaSerieDTO
                            {
                                Imagen = movie.PeliculaSerie.Imagen,
                                Titulo = movie.PeliculaSerie.Titulo
                            }).ToList()
                        };
                    }
                    else
                    {
                        lista = new ListaPeliculas
                        {
                            PeliculaSeries = _generoPeliculaRepository.SearchByGenre(genre, name, order).Select(movie => new PeliculaSerieDTO
                            {
                                Imagen = movie.PeliculaSerie.Imagen,
                                Titulo = movie.PeliculaSerie.Titulo
                            }).ToList()
                        };
                    }
                }
            }
            else if(name != "" && name != null)
            {
                lista = new ListaPeliculas
                {
                    PeliculaSeries = _repository.SearchByName(name, order).Select(movie => new PeliculaSerieDTO
                    {
                        Imagen = movie.Imagen,
                        Titulo = movie.Titulo,
                        FechaCreacion = movie.FechaCreacion,
                        GeneroPelicula = movie.GeneroPelicula.Select(gp => new GeneroPelicula
                        {
                            Genero = new Genero
                            {
                                Nombre = gp.Genero.Nombre
                            }
                        }).ToList()
                    }).ToList()
                };
            }
            return Ok(lista);
        }

        // ============================== Filtra por nombre ====================================================
        [HttpGet("/Details{name}")]
        public ActionResult Get(string name)
        {
            PeliculaSerie peli = _repository.MovieDetails(name);

            var details = new PeliculaSerie
            {
                Id = peli.Id,
                Imagen = peli.Imagen,
                Titulo = peli.Titulo,
                FechaCreacion = peli.FechaCreacion,
                Calificacion = peli.Calificacion,
                PersonajesPelicula = peli.PersonajesPelicula.Select(pp => new PersonajePelicula
                {
                    Personaje = new Personaje
                    {
                        Nombre = pp.Personaje.Nombre
                    }
                }).ToList()
            };

            return Ok(details);
        }
    }
}
