using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using ResourceManagementF.Models;

namespace ResourceManagementF.DataLayer
{
    public class DataContext : DbContext
    {
        public DataContext() : base("Database")
        {

        }
        public DbSet<Department> Departements { get; set; }
        public DbSet<Provider> Fournisseurs { get; set; }
        public DbSet<Teacher> Enseignants { get; set; }
        public DbSet<Administrative> Administratifs { get; set; }
        public DbSet<Computer> Ordinateurs { get; set; }
        public DbSet<Printer> Impriments { get; set; }
        public DbSet<MaintenanceService> Services { get; set; }
        public DbSet<AcompDep> Affectation_Comp_Dep { get; set; }
        public DbSet<AprintDep> Affectation_Print_Dep { get; set; }
        public DbSet<AcompT> Affectation_Comp_Teacher { get; set; }
        public DbSet<AprintT> Affectation_Print_Teacher { get; set; }

    }
}