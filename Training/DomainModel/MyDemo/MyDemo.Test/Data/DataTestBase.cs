using System;
using FluentNHibernate.Cfg.Db;
using Mavis.DataAccess;
using MyDemo.Data.NHibernateMaps;
using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;
using NUnit.Framework;
using System.IO;
using NHibernate;

namespace MyDemo.Test.Data
{
    public class DataTestBase
    {
        private const string DBFile = "Test.db";

        [SetUp]
        public virtual void SetUp()
        {
            InitializeNHibernateSessionForTest();
            LoadTestData();
        }

        [TearDown]
        public virtual void TearDown()
        {
            NHibernateSession.Clear();
        }

        protected void FlushAndClearSession()
        {
            Session.Flush();
            Session.Clear();
        }

        protected virtual void LoadTestData()
        {
        }

        protected ISession Session
        {
            get { return NHibernateSession.Current; }
        }

        private void InitializeNHibernateSessionForTest()
        {
            NHibernateSession.Init<EmployeeMap>(new SimpleSessionStorage(),
                                                SQLiteConfiguration.Standard.UsingFile(DBFile).ShowSql(),
                                                BuildSchema);
        }

        private void BuildSchema(Configuration config)
        {
            if (File.Exists(DBFile))
            {
                File.Delete(DBFile);
            }
            new SchemaExport(config).Create(false, true);
        }
    }
}