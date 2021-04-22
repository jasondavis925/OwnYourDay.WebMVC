using OwnYourDay.Data;
using OwnYourDay.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OwnYourDay.Services
{
    public class LandService
    {
        private readonly Guid _userId;

        public LandService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateLand(LandCreate model)
        {
            var entity =
                new Land()
                {
                    PropertyDescription = model.PropertyDescription,
                    Location = model.Location,
                    Occupancy = model.Occupancy,
                    Activities = model.Activities
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Lands.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        public IEnumerable<LandListItem> GetLands()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Lands
                        .Where(e => e.OwnerId == _userId)
                        .Select(
                            e =>
                                new LandListItem
                                {
                                    PropertyDescription = e.PropertyDescription,
                                    Location = e.Location,
                                    Occupancy = e.Occupancy,
                                    Activities = e.Activities
                                }
                        );

                return query.ToArray();
            }
        }
    }
}
