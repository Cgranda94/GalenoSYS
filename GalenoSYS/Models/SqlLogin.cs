using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace GalenoSYS.Models
{
    public class SqlLogin
    { 
        [PrimaryKey, AutoIncrement]

        public int usr_id { get; set; }
        [MaxLength(50)]

        public string usr_login { get; set; }
        [MaxLength(50)]

        public string usr_nombre { get; set; }
        [MaxLength(100)]

        public string usr_apellido { get; set; }
        [MaxLength(100)]

        public string usr_pass { get; set; }
        [MaxLength(50)]

        public string usr_rol { get; set; }
        [MaxLength(50)]

        public string usr_estado { get; set; }
        [MaxLength(50)]

        public string usr_correo { get; set; }

    }
}
