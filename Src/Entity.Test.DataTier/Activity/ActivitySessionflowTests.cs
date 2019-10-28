using GoodToCode.Entity.Application;
using GoodToCode.Entity.Flow;
using GoodToCode.Entity.Person;
using GoodToCode.Extensions;
using GoodToCode.Extensions.Configuration;
using GoodToCode.Framework.Data;
using GoodToCode.Framework.Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace GoodToCode.Entity.Activity
{
    /// <summary>
    /// Test framework functionality
    /// </summary>
    /// <remarks></remarks>
    [TestClass()]
    public class ActivitySessionflowTests
    {
        private static readonly object LockObject = new object();
        private static volatile List<Guid> _recycleBin = null;
        /// <summary>
        /// Singleton for recycle bin
        /// </summary>
        internal static List<Guid> RecycleBin
        {
            get
            {
                if (_recycleBin != null) return _recycleBin;
                lock (LockObject)
                {
                    if (_recycleBin == null)
                    {
                        _recycleBin = new List<Guid>();
                    }
                }
                return _recycleBin;
            }
        }

        /// <summary>
        /// Initializes class before tests are ran
        /// </summary>
        [ClassInitialize()]
        public static void ClassInit(TestContext context)
        {
            // Database is required for these tests
            var databaseAccess = false;
            var configuration = new ConfigurationManagerCore(ApplicationTypes.Native);
            using (var connection = new SqlConnection(configuration.ConnectionStringValue("DefaultConnection")))
            {
                databaseAccess = connection.CanOpen();
            }
            Assert.IsTrue(databaseAccess);
        }

        /// <summary>
        /// Workflow activity
        /// </summary>
        [TestMethod()]
        public async Task Activity_ActivitySessionflow_Get()
        {
            var readerActivity = new EntityReader<ActivitySessionflow>();
            var testEntity = new ActivitySessionflow();
            var testKey = Defaults.Guid;

            // Create test record
            await Activity_ActivitySessionflow_Create();
            testKey = RecycleBin.LastOrDefault();

            // Verify
            testEntity = readerActivity.GetByKey(testKey);
            Assert.IsTrue(!testEntity.IsNew);
            Assert.IsTrue(testEntity.Id != Defaults.Integer);
            Assert.IsTrue(testEntity.Key != Defaults.Guid);
            Assert.IsTrue(!testEntity.FailedRules.Any());
        }

        /// <summary>
        /// Workflow activity
        /// </summary>
        [TestMethod()]
        public async Task Activity_ActivitySessionflow_Create()
        {
            var readerActivity = new EntityReader<ActivitySessionflow>();
            var readerFlow = new ValueReader<FlowInfo>();
            var readerApp = new ValueReader<ApplicationInfo>();
            var testEntity = new ActivitySessionflow();
            var flow = new FlowInfo();
            var applicationKey = Defaults.Guid;
            var entityKey = Defaults.Guid;
            var resultEntity = new ActivitySessionflow();

            // Init
            flow = readerFlow.GetAll().FirstOrDefaultSafe();
            applicationKey = readerApp.GetAll().FirstOrDefaultSafe().Key;
            await new PersonInfoTests().Person_PersonInfo_Create();
            entityKey = PersonInfoTests.RecycleBin.LastOrDefault();

            //*
            //* Save
            //*
            testEntity = new ActivitySessionflow
            {
                EntityKey = entityKey,
                FlowKey = flow.Key,
                ApplicationKey = applicationKey
            };
            using (var writer = new StoredProcedureWriter<ActivitySessionflow>(testEntity, new ActivitySessionflowSPConfig()))
            {
                resultEntity = await writer.SaveAsync();
            }
            Assert.IsTrue(!resultEntity.IsNew);
            Assert.IsTrue(resultEntity.Id != Defaults.Integer);
            Assert.IsTrue(resultEntity.Key != Defaults.Guid);
            Assert.IsTrue(!resultEntity.FailedRules.Any());

            //*
            //* Verify
            //*
            testEntity = readerActivity.GetByKey(testEntity.Key);
            Assert.IsTrue(!testEntity.IsNew);
            Assert.IsTrue(testEntity.Id != Defaults.Integer);
            Assert.IsTrue(testEntity.Key != Defaults.Guid);
            Assert.IsTrue(!testEntity.FailedRules.Any());

            RecycleBin.Add(testEntity.Key);
        }

        /// <summary>
        /// Workflow activity
        /// </summary>
        [TestMethod()]
        public async Task Activity_ActivitySessionflow_Update()
        {
            var readerActivity = new EntityReader<ActivitySessionflow>();

            // Create test record
            await Activity_ActivitySessionflow_Create();
            var testKey = RecycleBin.LastOrDefault();

            // Verify
            var testEntity = readerActivity.GetByKey(testKey);
            using (var writer = new StoredProcedureWriter<ActivitySessionflow>(testEntity, new ActivitySessionflowSPConfig()))
            {
                var resultEntity = await writer.SaveAsync();
                Assert.IsTrue(resultEntity.Key == testEntity.Key);
                Assert.IsTrue(!resultEntity.FailedRules.Any());
            }
        }

        /// <summary>
        /// Cleanup all data
        /// </summary>
        [ClassCleanup()]
        public static void Cleanup()
        {
            // Object does not support deletes
        }
    }
}
