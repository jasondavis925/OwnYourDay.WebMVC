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
                    OwnerId = _userId,
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
                        //.Where(e => e.OwnerId == _userId)
                        .Select(
                            e =>
                                new LandListItem
                                {
                                    LandId = e.LandId,
                                    PropertyDescription = e.PropertyDescription,
                                    Location = e.Location,
                                    Occupancy = e.Occupancy,
                                    Activities = e.Activities
                                }
                        );

                return query.ToArray();
            }
        }
        public Land GetLandById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Lands
                        .Single(e => e.LandId == id);
                return
                    new Land
                    {
                        LandId = entity.LandId,
                        PropertyDescription = entity.PropertyDescription,
                        Location = entity.Location,
                        Activities = entity.Activities,
                    };
            }
        }

        public bool UpdateLand(LandEdit model)
            {
                using (var ctx = new ApplicationDbContext())
                {
                    var entity =
                        ctx
                            .Lands
                            .Single(e => e.LandId == model.LandId);
                entity.LandId = model.LandId;
                    entity.PropertyDescription = model.PropertyDescription;
                    entity.Location = model.Location;
                    entity.Occupancy = model.Occupancy;
                    entity.Activities = model.Activities;

                    return ctx.SaveChanges() == 1;
                }
            }
        public bool DeleteLand(int landId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Lands
                        .Single(e => e.LandId == landId);

                ctx.Lands.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}