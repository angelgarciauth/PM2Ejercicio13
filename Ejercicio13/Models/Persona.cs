using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace PM022PP0122.Models
{
    public class Persona
    {
        [PrimaryKey, AutoIncrement]
        public int id { get; set; }
        public String nombre { get; set; }

        public String apellido { get; set; }

        public int edad { get; set; }

        public String correo { get; set; }

        public String direccion { get; set; }
    }
}
