using OwnYourDay.Data;
using OwnYourDay.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OwnYourDay.Services
{
    public class WaterCraftService
    {
        private readonly Guid _userId;

        public WaterCraftService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateWaterCraft(WaterCraftCreate model)
        {
            var entity =
                new WaterCraft()
                {
                    OwnerId = _userId,
                    OccupancyCount = model.OccupancyCount,
                    VehicleMake = model.VehicleMake,
                    VehicleModel = model.VehicleModel,
                    Captain = model.Captain
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.WaterCrafts.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        public IEnumerable<WaterCraftListItem> GetWaterCrafts()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .WaterCrafts
                        //.Where(e => e.OwnerId == _userId)
                        .Select(
                            e =>
                                new WaterCraftListItem
                                {
                                    WaterCraftId = e.WaterCraftId,
                                    OccupancyCount = e.OccupancyCount,
                                    VehicleMake = e.VehicleMake,
                                    VehicleModel = e.VehicleModel,
                                    Captain = e.Captain
                                }
                        );

                return query.ToArray();
            }
        }

        public WaterCraft GetWaterCraftById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .WaterCrafts
                        .Single(e => e.WaterCraftId == id);
                return
                    new WaterCraft
                    {
                        WaterCraftId = entity.WaterCraftId,
                        OccupancyCount = entity.OccupancyCount,
                        VehicleMake = entity.VehicleMake,
                        VehicleModel = entity.VehicleModel,
                        Captain = entity.Captain,
                    };
            }
        }
        public bool UpdateWaterCraft(WaterCraftEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .WaterCrafts
                        .Single(e => e.WaterCraftId == model.WaterCraftId);

                entity.WaterCraftId = model.WaterCraftId;
                entity.OccupancyCount = model.OccupancyCount;
                entity.VehicleMake = model.VehicleMake;
                entity.VehicleModel = model.VehicleModel;
                entity.Captain = model.Captain;

                return ctx.SaveChanges() == 1;
            }
        }
        public bool DeleteWaterCraft(int watercraftId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .WaterCrafts
                        .Single(e => e.WaterCraftId == watercraftId);

                ctx.WaterCrafts.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
