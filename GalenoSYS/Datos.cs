using System;
using System.Collections.Generic;
using System.Text;

namespace GalenoSYS
{
    internal class Datosbd
    {
        public int cita_id { get; set; }
        public string cita_nombrepaciente { get; set; }
        public string fecha_cita { get; set; }
        public string hora_cita { get; set; }
        public string nombre_doctor { get; set; }
        public string especialidad_doctor { get; set; }
        public int cita_estado { get; set; }
        



    }
    internal class Datose
    {
        public int id_especialidad { get; set; }
        public string especialidad { get; set; }
        public int id_medico { get; set; }
        public string nombre_medico { get; set; }
        public string especialidad_medico { get; set; }

    }

    

}
