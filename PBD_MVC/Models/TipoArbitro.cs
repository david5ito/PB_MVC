//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PBD_MVC.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class TipoArbitro
    {
        public TipoArbitro()
        {
            this.ArbitroTipoArbitro = new HashSet<ArbitroTipoArbitro>();
        }
    
        public int idTipoArbitro { get; set; }
        public string numero { get; set; }
        public string nombre { get; set; }
        public Nullable<bool> estatus { get; set; }
        public Nullable<int> idUsuarioCrea { get; set; }
        public Nullable<System.DateTime> fechaCrea { get; set; }
        public Nullable<int> idUsuarioModifica { get; set; }
        public Nullable<System.DateTime> fechaModifica { get; set; }
    
        public virtual ICollection<ArbitroTipoArbitro> ArbitroTipoArbitro { get; set; }
        public virtual Usuario Usuario { get; set; }
        public virtual Usuario Usuario1 { get; set; }
    }
}