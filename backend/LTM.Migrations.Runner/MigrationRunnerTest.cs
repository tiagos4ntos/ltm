using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Reflection;
using System.Configuration;

namespace LTM.Migrations.Runner
{
    [TestClass]
    public class MigrationRunnerTest
    {
        [TestMethod]
        public void MigrateUp()
        {
            var migrationsAssembly = Assembly.Load("LTM.Migrations");
            var connectionString = ConfigurationManager.ConnectionStrings["ltm_connectionstring"].ConnectionString;
            var migrationsNamespace = "LTM.Migrations.Migrations";
            var migrator = new MigrationRun(connectionString, migrationsAssembly, migrationsNamespace);
            var migrationExecutedWithSuccess = migrator.MigrateToLastestVersion();
            Assert.AreEqual(true, migrationExecutedWithSuccess);
        }
    }
}
