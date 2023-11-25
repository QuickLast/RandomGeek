//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace RandomGeek.Database
{
    using System;
    using System.Collections.Generic;
    
    public partial class Game
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Game()
        {
            this.ContentSelection = new HashSet<ContentSelection>();
        }
    
        public int IDGame { get; set; }
        public string Name { get; set; }
        public string Developer { get; set; }
        public string Publisher { get; set; }
        public string Platforms { get; set; }
        public Nullable<int> Year { get; set; }
        public int IDGameGenre { get; set; }
        public Nullable<int> Part { get; set; }
        public Nullable<double> Rating { get; set; }
        public int IDAgeRating { get; set; }
        public string Description { get; set; }
        public byte[] Photo { get; set; }
    
        public virtual AgeRating AgeRating { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ContentSelection> ContentSelection { get; set; }
        public virtual GameGenre GameGenre { get; set; }
    }
}
