using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public class House
    {

    [Column("id")]
    public int Id { get; set; }

    [Column("number")]
    public string Number { get; set; }

    [Column("street_id")]
    public int StreetId { get; set; }
    public Street Street { get; set; }
    public List<Apartment> Apartments { get; set; }
    }
}
