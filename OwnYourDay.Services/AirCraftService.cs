using OwnYourDay.Data;
using OwnYourDay.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OwnYourDay.Services
{
    public class AirCraftService
    {
        private readonly Guid _userId;

        public AirCraftService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateAirCraft(AirCraftCreate model)
        {
            var entity =
                new AirCraft()
                {
                    OwnerId = _userId,
                    OccupancyCount = model.OccupancyCount,
                    VehicleMake = model.VehicleMake,
                    VehicleModel = model.VehicleModel,
                    Pilot = model.Pilot
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.AirCrafts.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        public IEnumerable<AirCraftListItem> GetAirCrafts()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .AirCrafts
                        //.Where(e => e.OwnerId == _userId)
                        .Select(
                            e =>
                                new AirCraftListItem
                                {
                                    AirCraftId = e.AirCraftId,
                                    OccupancyCount = e.OccupancyCount,
                                    VehicleMake = e.VehicleMake,
                                    VehicleModel = e.VehicleModel,
                                    Pilot = e.Pilot
                                }
                        );

                return query.ToArray();
            }
        }

        public AirCraft GetAirCraftById (int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .AirCrafts
                        .Single(e => e.AirCraftId == id);
                return
                    new AirCraft
                    {
                        AirCraftId = entity.AirCraftId,
                        OccupancyCount = entity.OccupancyCount,
                        VehicleMake = entity.VehicleMake,
                        VehicleModel = entity.VehicleModel,
                        Pilot = entity.Pilot,
                    };
            }
        }

        public bool UpdateAirCraft(AirCraftEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .AirCrafts
                        .Single(e => e.AirCraftId == model.AirCraftId);

                entity.AirCraftId = model.AirCraftId;
                entity.OccupancyCount = model.OccupancyCount;
                entity.VehicleMake = model.VehicleMake;
                entity.VehicleModel = model.VehicleModel;
                entity.Pilot = model.Pilot;

                return ctx.SaveChanges() == 1;
            }
        }
        public bool DeleteAirCraft(int aircraftId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .AirCrafts
                        .Single(e => e.AirCraftId == aircraftId);

                ctx.AirCrafts.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
