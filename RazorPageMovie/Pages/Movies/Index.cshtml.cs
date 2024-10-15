using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RazorPageMovie.Data;
using RazorPageMovie.Models;

namespace RazorPageMovie.Pages.Movies
{
    public class IndexModel : PageModel
    {
        private readonly RazorPageMovie.Data.RazorPageMovieContext _context;

        public IndexModel(RazorPageMovie.Data.RazorPageMovieContext context)
        {
            _context = context;
        }

        // Define una lista de películas que será utilizada para mostrar los resultados en la vista.
        public IList<Movie> Movie { get; set; } = default!;

        // Propiedad enlazada que admite la recuperación mediante parámetros GET.
        // Almacena la cadena de búsqueda ingresada por el usuario.
        [BindProperty(SupportsGet = true)]
        public string? SearchString { get; set; }

        // Define una lista desplegable de géneros que se utilizará en la interfaz para filtrar películas.
        public SelectList? Genres { get; set; }

        // Otra propiedad enlazada que admite recuperación mediante parámetros GET.
        // Almacena el género seleccionado por el usuario para el filtro.
        [BindProperty(SupportsGet = true)]
        public string? MovieGenre { get; set; }

        // Método asincrónico que se ejecuta cuando la página se carga utilizando una solicitud GET.
        public async Task OnGetAsync()
        {
            // Inicia la consulta seleccionando todas las películas de la base de datos.
            var movies = from m in _context.Movie select m;

            IQueryable<string> genreQuery = from m in _context.Movie orderby m.Genre select m.Genre;

            // Verifica si el usuario ha ingresado una cadena de búsqueda.
            if (!string.IsNullOrEmpty(SearchString))
            {
                // Aplica un filtro a la consulta para que solo incluya películas
                // cuyo título contenga la cadena de búsqueda.
                movies = movies.Where(s => s.Title.Contains(SearchString));

                //// Ejecuta la consulta filtrada y asigna los resultados a la propiedad Movie.
                //Movie = await movies.ToListAsync();

                //// Finaliza la ejecución del método y devuelve los resultados filtrados.
                //return;
            }
            if (!string.IsNullOrEmpty(MovieGenre))
            {
                
                movies = movies.Where(x => x.Genre == MovieGenre);
            }
            // Si la base de datos contiene películas, las recupera y las asigna a Movie.
            if (_context.Movie != null)
            {
                // Asigna todas las películas de la base de datos si no hay filtro de búsqueda.
                //Movie = await _context.Movie.ToListAsync();

                Genres = new SelectList(await genreQuery.Distinct().ToListAsync());
                Movie = await movies.ToListAsync();
            }
        }

    }
}
