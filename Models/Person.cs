using System;
using System.ComponentModel.DataAnnotations;

namespace UdemyManageAPI.Models
{
    public class Person
    {
        [Key]
        public int Person_id { get; set; }

        public string Name { get; set; }

        public int Age { get; set; }

        public string Date_init { get; set; }

    }
}