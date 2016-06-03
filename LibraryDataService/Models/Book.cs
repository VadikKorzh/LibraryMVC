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

        //[RegularExpression(@"^ISBN\s(?=[-0 - 9xX]{13}$)(?:[0-9]+[- ]){3}[0-9]*[xX0 - 9]$]")]
        [RegularExpression(@"(ISBN[-]*(1[03])*[ ]*(: ){0,1})*(([0-9Xx][- ]*){13}|([0-9Xx][- ]*){10})",
            ErrorMessage = "The ISBN is not correct. (Samples: 1121241241241 (13 digits), ISBN 1-56389-668-0)")]
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