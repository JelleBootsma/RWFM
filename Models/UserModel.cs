using System;

namespace RWFM.Models
{
    public class User
    {
        public int Id {get; set;}
        public string Username { get; set; }

        public string Hash { get; set; }
    }
}