using GoodToCode.Entity.Person;
using GoodToCode.Extensions;
using GoodToCode.Extensions.Configuration;
using GoodToCode.Extensions.Mathematics;
using GoodToCode.Extensions.Serialization;
using GoodToCode.Framework.Data;
using GoodToCode.Framework.Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace GoodToCode.Entity.Schedule
{
    [TestClass()]
    public class SlotTimeRangeTests
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

        List<SlotTimeRange> testEntities = new List<SlotTimeRange>()
        {
            new SlotTimeRange() {SlotName = "BBQ at my Housssseee!",  SlotDescription = "I want my baby back ribs!", BeginDate = DateTime.UtcNow.AddDays(30)},
            new SlotTimeRange() {SlotName = "Tutor After School", SlotDescription = "Meet you at the library for a tutor session.", BeginDate = DateTime.UtcNow.AddDays(40)},
            new SlotTimeRange() {SlotName = "Code World 2099", SlotDescription = "Nobody has to code anymore, but we cant stop anyways!", BeginDate = DateTime.UtcNow.AddDays(50)}
        };

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
        /// Schedule_SlotTimeRange
        /// </summary>
        [TestMethod()]
        public async Task Schedule_SlotTimeRange_Create()
        {
            var testEntity = new SlotTimeRange();
            var resultEntity = new SlotTimeRange();
            var reader = new EntityReader<SlotTimeRange>();

            // Create should update original object, and pass back a fresh-from-db object
            testEntity.Fill(testEntities[Arithmetic.Random(1, testEntities.Count)]);
            using (var writer = new EntityWriter<SlotTimeRange>(testEntity, new SlotTimeRangeSPConfig()))
            {
                resultEntity = await writer.SaveAsync();
            }
            Assert.IsTrue(testEntity.Id != Defaults.Integer);
            Assert.IsTrue(testEntity.Key != Defaults.Guid);
            Assert.IsTrue(resultEntity.Id != Defaults.Integer);
            Assert.IsTrue(resultEntity.Key != Defaults.Guid);
            Assert.IsTrue(!resultEntity.FailedRules.Any());

            // Object in db should match in-memory objects
            testEntity = reader.Read(x => x.Id == resultEntity.Id).FirstOrDefaultSafe();
            Assert.IsTrue(!testEntity.IsNew);
            Assert.IsTrue(testEntity.Id != Defaults.Integer);
            Assert.IsTrue(testEntity.Key != Defaults.Guid);
            Assert.IsTrue(testEntity.Id == resultEntity.Id);
            Assert.IsTrue(testEntity.Key == resultEntity.Key);
            Assert.IsTrue(!testEntity.FailedRules.Any());

            SlotTimeRangeTests.RecycleBin.Add(testEntity.Key);
        }

        /// <summary>
        /// Schedule_SlotTimeRange
        /// </summary>
        [TestMethod()]
        public async Task Schedule_SlotTimeRange_Read()
        {
            var reader = new EntityReader<SlotTimeRange>();
            var testEntity = new SlotTimeRange();
            var lastKey = Defaults.Guid;

            await Schedule_SlotTimeRange_Create();
            lastKey = SlotTimeRangeTests.RecycleBin.LastOrDefault();

            testEntity = reader.Read(x => x.Key == lastKey).FirstOrDefaultSafe();
            Assert.IsTrue(!testEntity.IsNew);
            Assert.IsTrue(testEntity.Id != Defaults.Integer);
            Assert.IsTrue(testEntity.Key != Defaults.Guid);
            Assert.IsTrue(testEntity.CreatedDate.Date == DateTime.UtcNow.Date);
            Assert.IsTrue(!testEntity.FailedRules.Any());
        }

        /// <summary>
        /// Schedule_SlotTimeRange
        /// </summary>
        [TestMethod()]
        public async Task Schedule_SlotTimeRange_Update()
        {
            var reader = new EntityReader<SlotTimeRange>();
            var resultEntity = new SlotTimeRange();
            var testEntity = new SlotTimeRange();
            var lastKey = Defaults.Guid;
            var originalId = Defaults.Integer;
            var originalKey = Defaults.Guid;

            await Schedule_SlotTimeRange_Create();
            lastKey = SlotTimeRangeTests.RecycleBin.LastOrDefault();

            testEntity = reader.Read(x => x.Key == lastKey).FirstOrDefaultSafe();
            originalId = testEntity.Id;
            originalKey = testEntity.Key;
            Assert.IsTrue(!testEntity.IsNew);
            Assert.IsTrue(testEntity.Id != Defaults.Integer);
            Assert.IsTrue(testEntity.Key != Defaults.Guid);
            Assert.IsTrue(!testEntity.FailedRules.Any());

            using (var writer = new EntityWriter<SlotTimeRange>(testEntity, new SlotTimeRangeSPConfig()))
            {
                resultEntity = await writer.SaveAsync();
            }
            Assert.IsTrue(!resultEntity.IsNew);
            Assert.IsTrue(resultEntity.Id != Defaults.Integer);
            Assert.IsTrue(resultEntity.Key != Defaults.Guid);
            Assert.IsTrue(testEntity.Id == resultEntity.Id && resultEntity.Id == originalId);
            Assert.IsTrue(testEntity.Key == resultEntity.Key && resultEntity.Key == originalKey);
            Assert.IsTrue(!testEntity.FailedRules.Any());

            testEntity = reader.Read(x => x.Id == originalId).FirstOrDefaultSafe();
            Assert.IsTrue(!testEntity.IsNew);
            Assert.IsTrue(testEntity.Id == resultEntity.Id && resultEntity.Id == originalId);
            Assert.IsTrue(testEntity.Key == resultEntity.Key && resultEntity.Key == originalKey);
            Assert.IsTrue(testEntity.Id != Defaults.Integer);
            Assert.IsTrue(testEntity.Key != Defaults.Guid);
            Assert.IsTrue(!testEntity.FailedRules.Any());
        }

        /// <summary>
        /// Schedule_SlotTimeRange
        /// </summary>
        [TestMethod()]
        public async Task Schedule_SlotTimeRange_Delete()
        {
            var reader = new EntityReader<SlotTimeRange>();
            var testEntity = new SlotTimeRange();
            var resultEntity = new SlotTimeRange();
            var lastKey = Defaults.Guid;
            var originalId = Defaults.Integer;
            var originalKey = Defaults.Guid;

            await Schedule_SlotTimeRange_Create();
            lastKey = SlotTimeRangeTests.RecycleBin.LastOrDefault();

            testEntity = reader.Read(x => x.Key == lastKey).FirstOrDefaultSafe();
            originalId = testEntity.Id;
            originalKey = testEntity.Key;
            Assert.IsTrue(testEntity.Id != Defaults.Integer);
            Assert.IsTrue(testEntity.Key != Defaults.Guid);
            Assert.IsTrue(testEntity.CreatedDate.Date == DateTime.UtcNow.Date);
            Assert.IsTrue(!testEntity.FailedRules.Any());

            using (var writer = new EntityWriter<SlotTimeRange>(testEntity, new SlotTimeRangeSPConfig()))
            {
                resultEntity = await writer.DeleteAsync();
            }
            Assert.IsTrue(resultEntity.IsNew);
            Assert.IsTrue(!testEntity.FailedRules.Any());

            testEntity = reader.Read(x => x.Id == originalId).FirstOrDefaultSafe();
            Assert.IsTrue(testEntity.Id != originalId);
            Assert.IsTrue(testEntity.Key != originalKey);
            Assert.IsTrue(testEntity.IsNew);
            Assert.IsTrue(testEntity.Key == Defaults.Guid);
            Assert.IsTrue(!testEntity.FailedRules.Any());

            // Remove from RecycleBin (its already marked deleted)
            RecycleBin.Remove(lastKey);
        }

        [TestMethod()]
        public void Schedule_SlotTimeRange_Serialize()
        {
            var searchChar = "i";
            var originalObject = new SlotTimeRange() { SlotName = searchChar, SlotDescription = searchChar };
            var resultObject = new SlotTimeRange();
            var resultString = Defaults.String;
            var serializer = new JsonSerializer<SlotTimeRange>();

            resultString = serializer.Serialize(originalObject);
            Assert.IsTrue(resultString != Defaults.String);
            resultObject = serializer.Deserialize(resultString);
            Assert.IsTrue(resultObject.SlotName == searchChar);
            Assert.IsTrue(resultObject.SlotDescription == searchChar);
        }

        /// <summary>
        /// Cleanup all data
        /// </summary>
        [ClassCleanup()]
        public static async Task Cleanup()
        {
            var reader = new EntityReader<SlotTimeRange>();
            var toDelete = new SlotTimeRange();

            foreach (Guid item in RecycleBin)
            {
                toDelete = reader.GetAll().Where(x => x.Key == item).FirstOrDefaultSafe();
                using (var db = new EntityWriter<SlotTimeRange>(toDelete, new SlotTimeRangeSPConfig()))
                {
                    await db.DeleteAsync();
                }
            }
        }
    }
}
