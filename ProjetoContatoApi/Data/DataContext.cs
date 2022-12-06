using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using ProjetoContato_API.Models;

namespace ProjetoContato_API.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base (options) 
        { 

        }  

        public DbSet<Pessoa> pessoas { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {            
            builder.Entity<Pessoa>()
                .HasData(new List<Pessoa>(){
                    new Pessoa() { 
                        Id = 1, 
                        Nome = "Maria", 
                        Sobrenome = "José", 
                        DataNasc = "01/05/2000",
                        Telefone = "81784568898"
                    },
                    new Pessoa() { 
                        Id = 2, 
                        Nome = "João", 
                        Sobrenome = "Paulo", 
                        DataNasc = "25/06/1999",
                        Telefone = "81445575525"
                    },
                    new Pessoa() { 
                        Id = 3, 
                        Nome = "Lucas", 
                        Sobrenome = "Machado", 
                        DataNasc = "11/07/1980",
                        Telefone = "81578962542"
                    },
                    new Pessoa() { 
                        Id = 4, 
                        Nome = "Juca", 
                        Sobrenome = "Chaves", 
                        DataNasc = "04/02/1999",
                        Telefone = "81568896647"
                    },
                    new Pessoa() { 
                        Id = 5, 
                        Nome = "Luciano", 
                        Sobrenome = "Gomes", 
                        DataNasc = "22/09/2010",
                        Telefone = "81487554878"
                    },
                    new Pessoa() { 
                        Id = 6, 
                        Nome = "Antônio", 
                        Sobrenome = "Ferreira", 
                        DataNasc = "29/07/1987",
                        Telefone = "81545666822"
                    },
                    new Pessoa() { 
                        Id = 7, 
                        Nome = "Larissa", 
                        Sobrenome = "Cruz", 
                        DataNasc = "12/05/2010",
                        Telefone = "81456387864"
                    },
                    new Pessoa() { 
                        Id = 8, 
                        Nome = "Claudio", 
                        Sobrenome = "Fernandes", 
                        DataNasc = "22/10/1982",
                        Telefone = "81478963458"
                    },
                    new Pessoa() { 
                        Id = 9, 
                        Nome = "Emanuel", 
                        Sobrenome = "Lima", 
                        DataNasc = "05/05/2015",
                        Telefone = "81489365425"
                    },
                    new Pessoa() { 
                        Id = 10, 
                        Nome = "Lidiane", 
                        Sobrenome = "Almeida", 
                        DataNasc = "14/07/2012",
                        Telefone = "81455224568"
                    }
                });
        }
    }
}