using System.Collections.Generic;
using Site.Domain.Entities;

namespace Site.WebUI.Models
{
    public class VinylListViewModel
    {
        public IEnumerable<Vinyl> products { get; set; }
        public PagingInfo PagingInfo { get; set; }
        public string CurrentStyle { get; set; }
    }
}