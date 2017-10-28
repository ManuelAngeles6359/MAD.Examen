using Dapper.Contrib.Extensions;
using System;


namespace MAD.Examen.Models
{
    public class Person
    {

        [Key]
        public int PersonID { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public DateTime HireDate { get; set; }
        public DateTime EnrollmentDate { get; set; }

    }
}
