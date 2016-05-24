using System.Collections;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using Google.DataTable.Net.Wrapper;

namespace LibraryDataService.Models
{
    public class Book
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int AuthorId { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 2)]
        public string Title { get; set; }

        public string ISBN { get; set; }

        public virtual Writer Author { get; set; }

        public virtual IList<Hit> Hits { get; set; }

        public Book()
        {
            Hits = new List<Hit>();
        }

        public string GoogleChartData
        {
            get
            {
                //let's instantiate the DataTable.
                var dt = new Google.DataTable.Net.Wrapper.DataTable();
                dt.AddColumn(new Column(ColumnType.Date, "Day", "Day"));
                dt.AddColumn(new Column(ColumnType.Number, "Count", "Hits"));

                foreach (Hit hit in Hits)
                {
                    Row r = dt.NewRow();
                    r.AddCellRange(new Cell[]
                    {
                        new Cell(hit.Date),
                        new Cell(hit.Count)
                    });
                    dt.AddRow(r);
                }

                //Let's create a Json string as expected by the Google Charts API.
                return dt.GetJson();
            }
        }
    }
}