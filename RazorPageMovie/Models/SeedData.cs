using Microsoft.AspNetCore.Components.Forms;
using Microsoft.EntityFrameworkCore;
using RazorPageMovie.Data;

namespace RazorPageMovie.Models
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new RazorPageMovieContext(serviceProvider.GetRequiredService<DbContextOptions<RazorPageMovieContext>>()))
            {
                if (context == null || context.Movie == null)
                {
                    throw new ArgumentException("Null RazorPagesMovieContext");
                }

                //Para mirar cualquier pelicula
                if (context.Movie.Any())
                {
                    return; // DB muestra todo lo que contine la clase
                }

                context.Movie.AddRange(
                    new Movie
                    {
                        Title = "The Flintstones",
                        Description = "Una comedia familiar sobre la vida de Pedro Picapiedra y su familia en la Edad de Piedra.",
                        Author = "Hanna-Barbera",
                        RelaseDate = DateTime.Parse("1994-05-27"),
                        Genre = "Comedia, Familiar",
                        Price = 9.99M,
                        Rating ="R"
                    },
                    new Movie
                    {
                        Title = "The Lord of the Rings: The Fellowship of the Ring",
                        Description = "Un hobbit llamado Frodo debe destruir un poderoso anillo para salvar la Tierra Media.",
                        Author = "J.R.R. Tolkien",
                        RelaseDate = DateTime.Parse("2001-12-19"),
                        Genre = "Fantasía, Aventura",
                        Price = 14.99M,
                        Rating = "G"
                    },
                    new Movie
                    {
                        Title = "The Matrix",
                        Description = "Un programador descubre que la realidad que conoce es una simulación controlada por máquinas.",
                        Author = "Wachowskis",
                        RelaseDate = DateTime.Parse("1999-03-31"),
                        Genre = "Acción, Ciencia Ficción",
                        Price = 12.99M,
                        Rating = "A"
                    },
                    new Movie
                    {
                        Title = "Inception",
                        Description = "Un ladrón que roba secretos a través de los sueños tiene que implantar una idea en la mente de un magnate.",
                        Author = "Christopher Nolan",
                        RelaseDate = DateTime.Parse("2010-07-16"),
                        Genre = "Ciencia Ficción, Thriller",
                        Price = 13.99M,
                        Rating = "A"
                    },
                    new Movie
                    {
                        Title = "Interstellar",
                        Description = "Un equipo de astronautas viaja a través de un agujero de gusano en busca de un nuevo hogar para la humanidad.",
                        Author = "Christopher Nolan",
                        RelaseDate = DateTime.Parse("2014-11-07"),
                        Genre = "Ciencia Ficción, Aventura",
                        Price = 15.99M,
                        Rating = "B"
                    }
                );
                context.SaveChanges();
            }
        }
       
    }
}
