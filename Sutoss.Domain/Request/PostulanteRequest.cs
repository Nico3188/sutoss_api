using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sutoss.Domain.Services.Domain.Request
{
    public class PostulanteRequest
    {
        public int IdPostulante { get; set; }
public int PersonaIdPersona { get; set; }
public string PostNombre { get; set; }
public string PostApellido { get; set; }
public string PostLugNac { get; set; }
public string PostNacionalidad { get; set; }
public string Postdomicilio { get; set; }
public string Postcorreo { get; set; }
public string PostEstcivil { get; set; }
public string PostRegConducir { get; set; }
public string PostCategoriareg { get; set; }
public string PostNivelestu { get; set; }
public string PostNombreinst { get; set; }
public string PostNivelalcanzado { get; set; }
public string PostTituloobt { get; set; }

    }
}
