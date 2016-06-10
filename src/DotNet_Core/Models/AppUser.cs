using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Bristrong.Official.WebService.Models
{
    [Table("appuser")]
    public class AppUser
    {
        [Column("id")]
        [JsonProperty("id")]
        public int Id { get; set; }

        [Column("username")]
        [JsonProperty("userName")]
        public string UserName { get; set; }

        [Column("password")]
        [JsonProperty("password")]
        public string Password { get; set; }
    }
}
