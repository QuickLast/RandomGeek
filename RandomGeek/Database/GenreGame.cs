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
    
    public partial class GenreGame
    {
        public int IDGenreGane { get; set; }
        public int IDGame { get; set; }
        public int IDGameGenre { get; set; }
    
        public virtual Game Game { get; set; }
        public virtual GameGenre GameGenre { get; set; }
    }
}
