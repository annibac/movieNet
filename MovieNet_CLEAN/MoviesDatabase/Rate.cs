//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré à partir d'un modèle.
//
//     Des modifications manuelles apportées à ce fichier peuvent conduire à un comportement inattendu de votre application.
//     Les modifications manuelles apportées à ce fichier sont remplacées si le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MoviesDatabase
{
    using System;
    using System.Collections.Generic;
    
    public partial class Rate
    {
        public int Id { get; set; }
        public long Score { get; set; }
        public string Comment { get; set; }
    
        public virtual User User { get; set; }
        public virtual Movies Movies { get; set; }
    }
}
