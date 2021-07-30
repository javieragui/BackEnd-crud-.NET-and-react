using System;
using System.ComponentModel.DataAnnotations;

namespace UdemyManageAPI.Models
{
    public class Person
    {
        [Key]
        public int person_id { get; set; }

        public string name { get; set; }

        public int age { get; set; }

        public string date_init { get; set; }

    }
}