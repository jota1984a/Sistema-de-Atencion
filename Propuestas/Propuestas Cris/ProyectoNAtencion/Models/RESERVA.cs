//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ProyectoNAtencion.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class RESERVA
    {
        public int ID_RESERVA { get; set; }
        public int ID_SUCURSAL { get; set; }
        public int ID_CLIENTE { get; set; }
        public Nullable<int> ID_ATENCION { get; set; }
        public string TIPO_RESERVA { get; set; }
        public Nullable<System.DateTime> HORA_RESERVA { get; set; }
    
        public virtual CLIENTE CLIENTE { get; set; }
        public virtual TIEMPO_ATENCION TIEMPO_ATENCION { get; set; }
        public virtual SUCURSAL SUCURSAL { get; set; }
    }
}
