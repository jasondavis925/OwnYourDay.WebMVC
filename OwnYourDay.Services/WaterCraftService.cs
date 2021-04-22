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
                        .Where(e => e.OwnerId == _userId)
                        .Select(
                            e =>
                                new WaterCraftListItem
                                {
                                    OccupancyCount = e.OccupancyCount,
                                    VehicleMake = e.VehicleMake,
                                    VehicleModel = e.VehicleModel,
                                    Captain = e.Captain
                                }
                        );

                return query.ToArray();
            }
        }
    }
}
