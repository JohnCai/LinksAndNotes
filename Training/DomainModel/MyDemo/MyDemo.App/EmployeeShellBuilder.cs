using System;
using System.IO;
using FluentNHibernate.Cfg.Db;
using Mavis.MVVM;
using MyDemo.Core.DataInterfaces;
using MyDemo.Data.Repositories;
using MyDemo.ViewModel;
using Mavis.Core;
using Mavis.DataAccess;
using MyDemo.Data.NHibernateMaps;
using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;

namespace MyDemo.App
{
    public class EmployeeShellBuilder: UnityShellBuilder
    {
        public EmployeeShellBuilder(): this(InitializeNHibernateSession)
        {
            
        }

        private static void InitializeNHibernateSession()
        {
            NHibernateSession.Init<EmployeeMap>(_simpleSessionStorage, "NHibernate.config");
            return;
            NHibernateSession.Init<EmployeeMap>(_simpleSessionStorage,
                                                SQLiteConfiguration.Standard.UsingFile("employeedb.db"), BuildSchema);
        }

        private static void BuildSchema(Configuration obj)
        {
            if (File.Exists("employeedb.db"))
            {
                File.Delete("employeedb.db");
            }

            new SchemaExport(obj).Create(true, true);
        }

        public EmployeeShellBuilder(Action nHibernateInitializer)
        {
            Singleton<RunOnce>.Instance.Run(nHibernateInitializer);
        }

        protected override void ConfigureIocContainer()
        {
            base.ConfigureIocContainer();

            IocContainer.AddComponent<IEmployeeRepository, EmployeeRepository>();
        }

        protected override object CreateShell()
        {
            return new EmployeeViewModel(IocContainer.Resolve<IEmployeeRepository>());
        }

        private static readonly ISessionStorage _simpleSessionStorage = new SimpleSessionStorage();
    }
}