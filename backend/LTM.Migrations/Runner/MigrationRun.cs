using FluentMigrator.Runner;
using FluentMigrator.Runner.Announcers;
using FluentMigrator.Runner.Initialization;
using System;
using System.Reflection;

namespace LTM.Migrations.Runner
{
    public class MigrationRun
    {
        private readonly string _connectionString;
        private readonly Assembly _migrationsAssembly;
        private readonly string _migrationsNamespace;
        private readonly string _migrationsTag;

        public MigrationRun(string connectionString, Assembly migrationsAssembly)
        {
            this._connectionString = connectionString;
            this._migrationsAssembly = migrationsAssembly;
            this._migrationsNamespace = string.Empty;
        }

        public MigrationRun(string connectionString, Assembly migrationsAssembly, string migrationsNamespace)
            : this(connectionString, migrationsAssembly)
        {
            this._migrationsNamespace = migrationsNamespace;
        }

        public MigrationRun(string connectionString, Assembly migrationsAssembly, string migrationsNamespace, string tag)
            : this(connectionString, migrationsAssembly)
        {
            this._migrationsNamespace = migrationsNamespace;
            this._migrationsTag = tag;
        }

        public bool RollbackToInitialVersion()
        {
            var runner = this.CreateRunner();
            try
            {
                runner.MigrateDown(1);
            }
            catch (Exception ex)
            {
                this.Write(string.Format("An error has occured on run migration down: \n{0}", ex));
                throw;
            }

            return true;
        }

        public bool RollbackToSpecificVersion(long version)
        {
            var runner = CreateRunner();
            try
            {
                if (version <= 0)
                    throw new Exception("Invalid version.");

                runner.MigrateDown(version);
            }
            catch (Exception ex)
            {
                this.Write(string.Format("An error has occured on running migration {0}:  \n{1}", version, ex));
                throw;
            }
            return true;
        }

        public bool MigrateToLastestVersion()
        {
            var runner = this.CreateRunner();
            try
            {
                runner.MigrateUp(true);
            }
            catch (Exception ex)
            {
                this.Write(string.Format("An error has occured on run migrate to the lastest version: \n{0}", ex));
                throw;
            }

            return true;
        }

        private MigrationRunner CreateRunner()
        {
            var options = new MigrationOptions() { PreviewOnly = false, Timeout = 120 };
            var factory = new FluentMigrator.Runner.Processors.SqlServer.SqlServer2008ProcessorFactory();

            var announcer = new NullAnnouncer();
            RunnerContext migrationContext;
            if (string.IsNullOrWhiteSpace(this._migrationsTag))
            {
                migrationContext = new RunnerContext(announcer);
            }
            else
            {
                migrationContext = new RunnerContext(announcer) { Tags = new[] { this._migrationsTag } };
            }

            if (!string.IsNullOrWhiteSpace(this._migrationsNamespace))
            {
                migrationContext.Namespace = this._migrationsNamespace;
            }

            var processor = factory.Create(this._connectionString, announcer, options);
            var runner = new MigrationRunner(this._migrationsAssembly, migrationContext, processor);
            return runner;
        }

        private void Write(string text)
        {
#if DEBUG
            System.Diagnostics.Debug.WriteLine(text);
#else
            System.Console.WriteLine(text);
#endif
        }
    }
}
