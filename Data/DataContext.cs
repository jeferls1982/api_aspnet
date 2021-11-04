using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WEB_API_TAREFAS.Models;

namespace WEB_API_TAREFAS.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext>options):base(options){}

        public DbSet<Aluno> Alunos{ get; set; }
        public DbSet<Professor> Professores { get; set; }
    }
}