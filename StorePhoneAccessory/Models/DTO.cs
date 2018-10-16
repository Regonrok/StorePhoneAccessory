using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StorePhoneAccessory.Models
{
    public class DTO
    {
        public class LoginJson
        {
            [JsonProperty("phone")]
            public string Phone { get; set; }

            [JsonProperty("password")]
            public string Password { get; set; }
        }

        public class RegistrJson
        {
            [JsonProperty("firstName")]
            public string FirstName { get; set; }
            [JsonProperty("lastName")]
            public string LastName { get; set; }
            [JsonProperty("middleName")]
            public string MiddleName { get; set; }
            [JsonProperty("phoneNumber")]
            public string PhoneNumber { get; set; }
            [JsonProperty("pass")]
            public string Pass { get; set; }
            [JsonProperty("idRole")]
            public int IdRole { get; set; }
        }
    }
}
