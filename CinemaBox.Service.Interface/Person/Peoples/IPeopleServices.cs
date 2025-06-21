using CinemaBox.Domain.Person.Peoples;
using CinemaBox.Model.Imdb.Cast;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaBox.Service.Interface.Person.Peoples
{
    public interface IPeopleServices
    {
        Task<People> CreateOrUpdatePeople(CreditModel creditModel, string path);
        Task<People> GetPeople(string peopleId);

    }
}
