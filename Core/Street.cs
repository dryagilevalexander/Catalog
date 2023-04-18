using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public class Street
    {
    [Column("id")]
    public int Id { get; set; }
    [Column("name")]
    public string Name { get; set; }
    public List<House> Houses { get; set; }
    [Column("city_id")]
    public int CityId { get; set; }
    public City City { get; set; }
    }
}