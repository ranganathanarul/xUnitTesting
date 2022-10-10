using System.Collections.Generic;
using System;
using DemoAPIwithSample.Model;

namespace DemoAPIwithSample.Data.Services
{
    public interface IMovieService
    {
        IEnumerable<Movies> GetAll();
        Movies Add(Movies newMovie);
        Movies GetById(Guid id);
        void Remove(Guid id);
    }
}