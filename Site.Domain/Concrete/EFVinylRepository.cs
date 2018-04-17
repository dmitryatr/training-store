using System.Collections.Generic;
using Site.Domain.Entities;
using Site.Domain.Abstract;
using System;

namespace Site.Domain.Concrete
{
    public class EFVinylRepository : IVinylRepository
    {
        EFDbContext context = new EFDbContext();

        public IEnumerable<Vinyl> products
        {
            get { return context.products; }
        }

        public void SaveProduct(Vinyl vinyl)
        {
            if (vinyl.VinylId == 0)
                context.products.Add(vinyl);
            else
            {
                Vinyl dbEntry = context.products.Find(vinyl.VinylId);
                if (dbEntry != null)
                {
                    dbEntry.Artist = vinyl.Artist;
                    dbEntry.Title = vinyl.Title;
                    dbEntry.Price = vinyl.Price;
                    dbEntry.Style = vinyl.Style;
                    dbEntry.Country = vinyl.Country;
                    dbEntry.ImageData = vinyl.ImageData;
                    dbEntry.ImageMimeType = vinyl.ImageMimeType;
                }
            }
            context.SaveChanges();
        }

        public Vinyl DeteteProduct(int vinylId)
        {
            Vinyl dbEntry = context.products.Find(vinylId);
            if (dbEntry != null)
            {
                context.products.Remove(dbEntry);
                context.SaveChanges();
            }
            return dbEntry;
        }
    }
}
