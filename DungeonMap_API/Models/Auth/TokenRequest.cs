using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace DungeonMap_API.Models.Auth
{
    public class TokenRequest
    {
        public string Username { get; set; }
        public string Password { get; set; }

        [DisplayName("grant_type")]
        public string GrantType { get; set; }
    }
}
