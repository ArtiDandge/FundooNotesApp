using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using FundooModels;

namespace FundooRepository.Context
{
    public class UserContext : DbContext
    {
        public UserContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<RegistrationModel> Users { get; set; }

        public DbSet<NotesModel> FundooNotes { get; set; }

        public DbSet<LableModel> Lables { get; set; }

        public DbSet<CollaboratorsModel> Collaborators { get; set;}
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}
