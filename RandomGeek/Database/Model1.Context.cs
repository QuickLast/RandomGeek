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
    
    public partial class RandomGeek_KamilEntities : DbContext
    {
        public RandomGeek_KamilEntities()
            : base("name=RandomGeek_KamilEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<AgeRating> AgeRating { get; set; }
        public virtual DbSet<Game> Game { get; set; }
        public virtual DbSet<GameGenre> GameGenre { get; set; }
        public virtual DbSet<GenreGame> GenreGame { get; set; }
        public virtual DbSet<GenreMovie> GenreMovie { get; set; }
        public virtual DbSet<Movie> Movie { get; set; }
        public virtual DbSet<MovieGenre> MovieGenre { get; set; }
        public virtual DbSet<MovieType> MovieType { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<User> User { get; set; }
    }
}