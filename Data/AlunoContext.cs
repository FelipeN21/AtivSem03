using AtivSem03.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace AtivSem03.Data
{
    public class AlunoContext : DbContext
    {
        public AlunoContext()
        { 
        }
        public DbSet<Aluno> Alunos { get; set; }
        public DbSet<Carro> Carros { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=AtivSem03;Data Source=PIT-DESKTOP\SQLEXPRESS01");
        }
    }
}
