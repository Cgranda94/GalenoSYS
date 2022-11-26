using System;
using System.Collections.Generic;
using System.Text;

namespace GalenoSYS.Ws
{
    internal class bd_t_usuario
    {
        public int usr_id { get; set; }
        public string usr_login { get; set; }
        public string usr_nombre { get; set; }
        public string usr_apellido { get; set; }
        public string usr_pass { get; set; }
        public string usr_rol { get; set; }
        public string usr_estado { get; set; }
        public string usr_correo { get; set; }
        public string usr_pathfoto { get; set; }
    }
}
