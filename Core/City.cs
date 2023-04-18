using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public class City
    {
    [Column("Id")]
    public int Id { get; set; }
    [Column("name")]
    public string Name { get; set; }
    public List <Street> Streets { get; set; }
    }
}
