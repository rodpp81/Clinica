using System;
using System.Collections.Generic;
using System.Text;
using Clinica.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Clinica.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public DbSet<Especialidade> Especialidades { get; set; }
        public DbSet<Medico> Medicos { get; set; }
        public DbSet<Medicamento> Medicamentos { get; set; }
        public DbSet<Paciente> Pacientes { get; set; }
        public DbSet<Agenda> Agendas { get; set; }
        public DbSet<ExameTipo> ExameTipos { get; set; }      
        public DbSet<TipoUsuario> TipoUsuariosTipoUsuarios { get; set; }
        public DbSet<PerfilUsuario> PerfilUsuarios { get; set; }
        public DbSet<AcessoTipoUsuario> AcessoTipoUsuarios { get; set; }
        public DbSet<Consulta> Consultas { get; set; }
        public DbSet<AgendaMedica> AgendaMedicas { get; set; }
        public DbSet<ExameAgenda> ExameAgendas { get; set; }
        public DbSet<Clinica.Models.Receita> Receita { get; set; }
        public DbSet<IdentityUser> Usuario { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<ExameTipo>()
                .HasData(
                new ExameTipo { Id = 1, Descricao = "HEMOGRAMA" },
                new ExameTipo { Id = 2, Descricao = "ELETROCARDIOGRAMA" },
                new ExameTipo { Id = 3, Descricao = "UREIA E CREATINA" },
                new ExameTipo { Id = 4, Descricao = "ULTRASSON" },
                new ExameTipo { Id = 5, Descricao = "TESTE ERGOMÉTRICO" }
                );

        }

      

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }

      

        public DbSet<Clinica.Models.Exame> Exame { get; set; }    

        public DbSet<Clinica.Models.Prontuario> Prontuario { get; set; }

       
    }
}
