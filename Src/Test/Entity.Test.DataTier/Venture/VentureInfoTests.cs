//-----------------------------------------------------------------------
// <copyright file="VentureInfoTests.cs" company="Genesys Source">
//      Copyright (c) Genesys Source. All rights reserved.
//      All rights are reserved. Reproduction or transmission in whole or in part, in
//      any form or by any means, electronic, mechanical or otherwise, is prohibited
//      without the prior written consent of the copyright owner.
// </copyright>
//-----------------------------------------------------------------------
using Genesys.Entity.Person;
using Genesys.Extensions;
using Genesys.Extras.Configuration;
using Genesys.Extras.Mathematics;
using Genesys.Extras.Serialization;
using Genesys.Framework.Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace Genesys.Entity.Venture
{
    [TestClass()]
    public class VentureInfoTests
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

        List<VentureInfo> testEntities = new List<VentureInfo>()
        {
            new VentureInfo() {Name = "BBQ at my Housssseee!",  Description = "I want my baby back ribs!"},
            new VentureInfo() {Name = "Tutor After School", Description = "Meet you at the library for a tutor session."},
            new VentureInfo() {Name = "Code World 2099", Description = "Nobody has to code anymore, but we cant stop anyways!"}
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
        /// Venture_VentureInfo
        /// </summary>
        [TestMethod()]
        public void Venture_VentureInfo_Create()
        {
            var testEntity = new VentureInfo();
            var resultEntity = new VentureInfo();
            var testItem = new VentureInfo();
            var reader = new EntityReader<VentureInfo>();

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

            VentureInfoTests.RecycleBin.Add(testEntity.Key);
        }

        /// <summary>
        /// Venture_VentureInfo
        /// </summary>
        [TestMethod()]
        public void Venture_VentureInfo_Read()
        {
            var reader = new EntityReader<VentureInfo>();
            var testItem = new VentureInfo();
            var lastKey = Defaults.Guid;

            Venture_VentureInfo_Create();
            lastKey = VentureInfoTests.RecycleBin.LastOrDefault();

            testItem = reader.Read(x => x.Key == lastKey).FirstOrDefaultSafe();
            Assert.IsTrue(!testItem.IsNew);
            Assert.IsTrue(testItem.Id != Defaults.Integer);
            Assert.IsTrue(testItem.Key != Defaults.Guid);
            Assert.IsTrue(testItem.CreatedDate.Date == DateTime.UtcNow.Date);
            Assert.IsTrue(!testItem.FailedRules.Any());
        }

        /// <summary>
        /// Venture_VentureInfo
        /// </summary>
        [TestMethod()]
        public void Venture_VentureInfo_Update()
        {
            var reader = new EntityReader<VentureInfo>();
            var writer = new StoredProcedureWriter<VentureInfo>();
            var resultEntity = new VentureInfo();
            var testItem = new VentureInfo();
            var uniqueValue = Guid.NewGuid().ToString().Replace("-", "");
            var lastKey = Defaults.Guid;
            var originalId = Defaults.Integer;
            var originalKey = Defaults.Guid;

            Venture_VentureInfo_Create();
            lastKey = VentureInfoTests.RecycleBin.LastOrDefault();

            testItem = reader.Read(x => x.Key == lastKey).FirstOrDefaultSafe();
            originalId = testItem.Id;
            originalKey = testItem.Key;
            Assert.IsTrue(!testItem.IsNew);
            Assert.IsTrue(testItem.Id != Defaults.Integer);
            Assert.IsTrue(testItem.Key != Defaults.Guid);
            Assert.IsTrue(!testItem.FailedRules.Any());

            testItem.Name = uniqueValue;
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
        /// Venture_VentureInfo
        /// </summary>
        [TestMethod()]
        public void Venture_VentureInfo_Delete()
        {
            var reader = new EntityReader<VentureInfo>();
            var testItem = new VentureInfo();
            var result = new VentureInfo();
            var lastKey = Defaults.Guid;
            var originalId = Defaults.Integer;
            var originalKey = Defaults.Guid;

            Venture_VentureInfo_Create();
            lastKey = VentureInfoTests.RecycleBin.LastOrDefault();

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
        public void Venture_VentureInfo_Serialize()
        {
            var searchChar = "i";
            var originalObject = new VentureInfo() { Name = searchChar, Description = searchChar };
            var resultObject = new VentureInfo();
            var resultString = Defaults.String;
            var serializer = new JsonSerializer<VentureInfo>();

            resultString = serializer.Serialize(originalObject);
            Assert.IsTrue(resultString != Defaults.String);
            resultObject = serializer.Deserialize(resultString);
            Assert.IsTrue(resultObject.Name == searchChar);
            Assert.IsTrue(resultObject.Description == searchChar);
        }

        /// <summary>
        /// Cleanup all data
        /// </summary>
        [ClassCleanup()]
        public static void Cleanup()
        {
            var writer = new StoredProcedureWriter<VentureInfo>();
            var reader = new EntityReader<VentureInfo>();
            foreach (Guid item in RecycleBin)
            {
                writer.Delete(reader.GetByKey(item));
            }
        }
    }
}
