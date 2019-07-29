//-----------------------------------------------------------------------
// <copyright file="SlotTimeRecurringTests.cs" company="GoodToCode">
//      Copyright (c) GoodToCode. All rights reserved.
//      All rights are reserved. Reproduction or transmission in whole or in part, in
//      any form or by any means, electronic, mechanical or otherwise, is prohibited
//      without the prior written consent of the copyright owner.
// </copyright>
//-----------------------------------------------------------------------
using GoodToCode.Entity.Person;
using GoodToCode.Extensions;
using GoodToCode.Extras.Configuration;
using GoodToCode.Extras.Mathematics;
using GoodToCode.Extras.Serialization;
using GoodToCode.Framework.Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace GoodToCode.Entity.Schedule
{
    [TestClass()]
    public class SlotTimeRecurringTests
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

        List<SlotTimeRecurring> testEntities = new List<SlotTimeRecurring>()
        {
            new SlotTimeRecurring() {SlotName = "BBQ at my Housssseee!",  SlotDescription = "I want my baby back ribs!", BeginDay = 1, EndDay = 1, BeginTime = new DateTime(1900,01,01,8,0,0), EndTime = new DateTime(1900,01,01,17,0,0)},
            new SlotTimeRecurring() {SlotName = "Tutor After School", SlotDescription = "Meet you at the library for a tutor session.", BeginDay = 1, EndDay = 1, BeginTime = new DateTime(1900,01,01,8,0,0), EndTime = new DateTime(1900,01,01,17,0,0)},
            new SlotTimeRecurring() {SlotName = "Code World 2099", SlotDescription = "Nobody has to code anymore, but we cant stop anyways!", BeginDay = 1, EndDay = 1, BeginTime = new DateTime(1900,01,01,8,0,0), EndTime = new DateTime(1900,01,01,17,0,0)},
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
        /// Schedule_SlotTimeRecurring
        /// </summary>
        [TestMethod()]
        public void Schedule_SlotTimeRecurring_Create()
        {
            var testEntity = new SlotTimeRecurring();
            var resultEntity = new SlotTimeRecurring();
            var testItem = new SlotTimeRecurring();
            var reader = new EntityReader<SlotTimeRecurring>();

            // Create should update original object, and pass back a fresh-from-db object
            testEntity.Fill(testEntities[Arithmetic.Random(1, testEntities.Count)]);
            resultEntity = testEntity.Save();
            Assert.IsTrue(testEntity.Id != Defaults.Integer);
            Assert.IsTrue(testEntity.Key != Defaults.Guid);
            Assert.IsTrue(resultEntity.Id != Defaults.Integer);
            Assert.IsTrue(resultEntity.Key != Defaults.Guid);
            Assert.IsTrue(!resultEntity.FailedRules.Any());

            // Object in db should match in-memory objects
            testItem = reader.Read(x => x.Id == resultEntity.Id).FirstOrDefaultSafe();
            Assert.IsTrue(!testItem.IsNew);
            Assert.IsTrue(testItem.Id != Defaults.Integer);
            Assert.IsTrue(testItem.Key != Defaults.Guid);
            Assert.IsTrue(testItem.Id == resultEntity.Id);
            Assert.IsTrue(testItem.Key == resultEntity.Key);
            Assert.IsTrue(!testItem.FailedRules.Any());

            SlotTimeRecurringTests.RecycleBin.Add(testEntity.Key);
        }

        /// <summary>
        /// Schedule_SlotTimeRecurring
        /// </summary>
        [TestMethod()]
        public void Schedule_SlotTimeRecurring_Read()
        {
            var reader = new EntityReader<SlotTimeRecurring>();
            var testItem = new SlotTimeRecurring();
            var lastKey = Defaults.Guid;

            Schedule_SlotTimeRecurring_Create();
            lastKey = SlotTimeRecurringTests.RecycleBin.LastOrDefault();

            testItem = reader.Read(x => x.Key == lastKey).FirstOrDefaultSafe();
            Assert.IsTrue(!testItem.IsNew);
            Assert.IsTrue(testItem.Id != Defaults.Integer);
            Assert.IsTrue(testItem.Key != Defaults.Guid);
            Assert.IsTrue(testItem.CreatedDate.Date == DateTime.UtcNow.Date);
            Assert.IsTrue(!testItem.FailedRules.Any());
        }

        /// <summary>
        /// Schedule_SlotTimeRecurring
        /// </summary>
        [TestMethod()]
        public void Schedule_SlotTimeRecurring_Update()
        {
            var reader = new EntityReader<SlotTimeRecurring>();
            var writer = new StoredProcedureWriter<SlotTimeRecurring>();
            var resultEntity = new SlotTimeRecurring();
            var testItem = new SlotTimeRecurring();
            var uniqueValue = Guid.NewGuid().ToString().Replace("-", "");
            var lastKey = Defaults.Guid;
            var originalId = Defaults.Integer;
            var originalKey = Defaults.Guid;

            Schedule_SlotTimeRecurring_Create();
            lastKey = SlotTimeRecurringTests.RecycleBin.LastOrDefault();

            testItem = reader.Read(x => x.Key == lastKey).FirstOrDefaultSafe();
            originalId = testItem.Id;
            originalKey = testItem.Key;
            Assert.IsTrue(!testItem.IsNew);
            Assert.IsTrue(testItem.Id != Defaults.Integer);
            Assert.IsTrue(testItem.Key != Defaults.Guid);
            Assert.IsTrue(!testItem.FailedRules.Any());

            testItem.SlotName = uniqueValue;
            resultEntity = testItem.Save();
            Assert.IsTrue(!resultEntity.IsNew);
            Assert.IsTrue(resultEntity.Id != Defaults.Integer);
            Assert.IsTrue(resultEntity.Key != Defaults.Guid);
            Assert.IsTrue(testItem.Id == resultEntity.Id && resultEntity.Id == originalId);
            Assert.IsTrue(testItem.Key == resultEntity.Key && resultEntity.Key == originalKey);
            Assert.IsTrue(!testItem.FailedRules.Any());

            testItem = reader.Read(x => x.Id == originalId).FirstOrDefaultSafe();
            Assert.IsTrue(!testItem.IsNew);
            Assert.IsTrue(testItem.Id == resultEntity.Id && resultEntity.Id == originalId);
            Assert.IsTrue(testItem.Key == resultEntity.Key && resultEntity.Key == originalKey);
            Assert.IsTrue(testItem.Id != Defaults.Integer);
            Assert.IsTrue(testItem.Key != Defaults.Guid);
            Assert.IsTrue(!testItem.FailedRules.Any());
        }

        /// <summary>
        /// Schedule_SlotTimeRecurring
        /// </summary>
        [TestMethod()]
        public void Schedule_SlotTimeRecurring_Delete()
        {
            var reader = new EntityReader<SlotTimeRecurring>();
            var testItem = new SlotTimeRecurring();
            var result = new SlotTimeRecurring();
            var lastKey = Defaults.Guid;
            var originalId = Defaults.Integer;
            var originalKey = Defaults.Guid;

            Schedule_SlotTimeRecurring_Create();
            lastKey = SlotTimeRecurringTests.RecycleBin.LastOrDefault();

            testItem = reader.Read(x => x.Key == lastKey).FirstOrDefaultSafe();
            originalId = testItem.Id;
            originalKey = testItem.Key;
            Assert.IsTrue(testItem.Id != Defaults.Integer);
            Assert.IsTrue(testItem.Key != Defaults.Guid);
            Assert.IsTrue(testItem.CreatedDate.Date == DateTime.UtcNow.Date);
            Assert.IsTrue(!testItem.FailedRules.Any());

            result = testItem.Delete();
            Assert.IsTrue(result.IsNew);
            Assert.IsTrue(!testItem.FailedRules.Any());

            testItem = reader.Read(x => x.Id == originalId).FirstOrDefaultSafe();
            Assert.IsTrue(testItem.Id != originalId);
            Assert.IsTrue(testItem.Key != originalKey);
            Assert.IsTrue(testItem.IsNew);
            Assert.IsTrue(testItem.Key == Defaults.Guid);
            Assert.IsTrue(!testItem.FailedRules.Any());

            // Remove from RecycleBin (its already marked deleted)
            RecycleBin.Remove(lastKey);
        }

        [TestMethod()]
        public void Schedule_SlotTimeRecurring_Serialize()
        {
            var searchChar = "i";
            var originalObject = new SlotTimeRecurring() { SlotName = searchChar, SlotDescription = searchChar };
            var resultObject = new SlotTimeRecurring();
            var resultString = Defaults.String;
            var serializer = new JsonSerializer<SlotTimeRecurring>();

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
        public static void Cleanup()
        {
            var writer = new StoredProcedureWriter<SlotTimeRecurring>();
            var reader = new EntityReader<SlotTimeRecurring>();
            foreach (Guid item in RecycleBin)
            {
                writer.Delete(reader.GetByKey(item));
            }
        }
    }
}
