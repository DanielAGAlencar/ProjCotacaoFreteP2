//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ProjCotacaoFreteP2
{
    using System;
    using System.Collections.Generic;
    
    public partial class cotacao
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public cotacao()
        {
            this.frete = new HashSet<frete>();
        }
    
        public int Id { get; set; }
        public int fkpedido { get; set; }
        public int fktransportadora { get; set; }
        public int dias_entrega { get; set; }
        public string valor { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<frete> frete { get; set; }
        public virtual pedido pedido { get; set; }
        public virtual transportadora transportadora { get; set; }
    }
}
