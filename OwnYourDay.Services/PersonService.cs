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
                        //.Where(e => e.OwnerId == _userId)
                        .Select(
                            e =>
                                new PersonListItem
                                {
                                    PersonId = e.PersonId,
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
        public Person GetPersonById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Prospects
                        .Single(e => e.PersonId == id);
                return
                    new Person
                    {
                        PersonId = entity.PersonId,
                        AdultCount = entity.AdultCount,
                        ChildCount = entity.ChildCount,
                        Email = entity.Email,
                        Destination = entity.Destination,
                        TravelMode = entity.TravelMode
                    };
            }
        }
        public bool UpdatePerson(PersonEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Prospects
                        .Single(e => e.PersonId == model.PersonId);

                entity.PersonId = model.PersonId;
                entity.AdultCount = model.AdultCount;
                entity.ChildCount = model.ChildCount;
                entity.Email = model.Email;
                entity.Destination = model.Destination;
                entity.TravelMode = model.TravelMode;

                return ctx.SaveChanges() == 1;
            }
        }
        public bool DeletePerson(int personId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Prospects
                        .Single(e => e.PersonId == personId);

                ctx.Prospects.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}

