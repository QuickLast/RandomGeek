﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class RandomGeekEntities_Final1 : DbContext
    {
        public RandomGeekEntities_Final1()
            : base("name=RandomGeekEntities_Final1")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<ContentSelection> ContentSelection { get; set; }
        public virtual DbSet<Game> Game { get; set; }
        public virtual DbSet<GameGenre> GameGenre { get; set; }
        public virtual DbSet<Movie> Movie { get; set; }
        public virtual DbSet<MovieGenre> MovieGenre { get; set; }
        public virtual DbSet<MovieType> MovieType { get; set; }
        public virtual DbSet<Selection> Selection { get; set; }
        public virtual DbSet<User> User { get; set; }
    }
}
