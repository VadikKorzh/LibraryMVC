using LibraryDataService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LibraryMVC.Utilities
{
    public static class Extensions
    {
        public static void AddHit(this Book book)
        {
            var hit = book.Hits.FirstOrDefault(h => h.Date == DateTime.UtcNow.Date);
            if (hit == null)
            {
                book.Hits.Add(new Hit { Date = DateTime.UtcNow.Date, Count = 1 });
            }
            else {
                hit.Count++;
            }
        }
    }
}