using OwnYourDay.Data;
using OwnYourDay.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OwnYourDay.Services
{
    public class PersonService
    {
        private readonly Guid _userId;

        public PersonService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreatePerson(PersonCreate model)
        {
            var entity =
                new Person()
                {
                    OwnerId = _userId,
                    AdultCount = model.AdultCount,
                    ChildCount = model.ChildCount,
                    Email = model.Email,
                    Destination = model.Destination,
                    TravelMode = model.TravelMode
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Prospects.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        public IEnumerable<PersonListItem> GetPersons()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Prospects
                        .Where(e => e.OwnerId == _userId)
                        .Select(
                            e =>
                                new PersonListItem
                                {
                                    AdultCount = e.AdultCount,
                                    ChildCount = e.ChildCount,
                                    Email = e.Email,
                                    Destination = e.Destination,
                                    TravelMode = e.TravelMode
                                }
                        );

                return query.ToArray();
            }
        }
    }
}

