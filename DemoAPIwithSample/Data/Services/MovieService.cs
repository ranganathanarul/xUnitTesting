using DemoAPIwithSample.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DemoAPIwithSample.Data.Services
{
    public class MovieService : IMovieService
    {
        private readonly List<Movies> _movies;
        public MovieService()
        {
            _movies = new List<Movies>()
            {
                 new Movies()
                {
                    Id = new Guid("ab2bd817-98cd-4cf3-a80a-53ea0cd9c200"),
                    Title="A Space Odyssey",
                    Description="Stanley Kubrick and sci-fi seer Arthur C Clarke. ‘I understand he’s a nut who lives in a tree in India somewhere,...",
                    Director= "Stanley Kubrick",
                },
                new Movies()
                {
                    Id= new Guid("117366b8-3541-4ac5-8732-860d698e26a2"),
                    Title="The Godfather",
                    Description="Francis Ford Coppola’s magnum opus is the ultimate patriarch of the Mafia genre",
                    Director= "Francis Ford Coppola",
                },
                new Movies()
                {
                    Id= new Guid("66ff5116-bcaa-4061-85b2-6f58fbb6db25"),
                    Title="Citizen Kane",
                    Description="Citizen Kane always finds a way to renew itself for a new generation of film lovers",
                    Director= "George Orson Welles"
                },
                new Movies()
                {
                    Id =  new Guid("cd5089dd-9754-4ed2-b44c-488f533243ef"),
                    Title = "Jeanne Dielman",
                    Description = "film examines a single mother's regimented schedule of cooking, cleaning and mothering over three days. The mother, Jeanne Dielman (whose name is only derived from the title and from a letter she reads to her son), has sex with male clients in her house each afternoon, for her and her son's subsistence...",
                    Director = "Chantal Akerman"
                },
                new Movies()
                {
                    Id =  new Guid("d81e0829-55fa-4c37-b62f-f578c692af78"),
                    Title = "Raiders of the Lost Ark",
                    Description = "Lucas team up to bring the audiences who flocked to Star Wars and Close Encounters a replay of the innocent pleasures of Saturday serials, but done at two hours length with a much larger budget than the old cliffhangers could command...",
                    Director = "chutzpah whizzkids Spielberg"
                }
            };
        }
        public IEnumerable<Movies> GetAll()
        {
            return _movies;
        }

        public Movies Add(Movies newMovie)
        {
            newMovie.Id = Guid.NewGuid();
            _movies.Add(newMovie);
            return newMovie;
        }

        public Movies GetById(Guid id) => _movies.Where(a => a.Id == id).FirstOrDefault();

        public void Remove(Guid id)
        {
            var existing = _movies.First(a => a.Id == id);
            _movies.Remove(existing);
        }
    }
}
