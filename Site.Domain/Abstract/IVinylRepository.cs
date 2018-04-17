using System;
using System.Collections.Generic;
using Site.Domain.Entities;

namespace Site.Domain.Abstract
{
    public interface IVinylRepository
    {
        IEnumerable<Vinyl> products { get; }
        void SaveProduct(Vinyl vinyl);
        Vinyl DeteteProduct(int vinylId);
    }
}
