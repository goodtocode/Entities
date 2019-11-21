using GoodToCode.Framework.Data;
using GoodToCode.Framework.Entity;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace GoodToCode.Entity
{
    /// <summary>
    /// Events
    /// </summary>
    public class EntityTimeRecurringSPConfig : EntityConfiguration<EntityTimeRecurring>
    {
        /// <summary>
        /// Entity Create/Insert Stored Procedure
        /// </summary>
        public override StoredProcedure<EntityTimeRecurring> CreateStoredProcedure
        => new StoredProcedure<EntityTimeRecurring>()
        {
            StoredProcedureName = "EntityTimeRecurringSave",
            Parameters = new List<SqlParameter>()
            {
                new SqlParameter("@Id", Entity.Id),
                new SqlParameter("@Key", Entity.Key),
                new SqlParameter("@EntityKey", Entity.EntityKey),
                new SqlParameter("@BeginDay", Entity.BeginDay),
                new SqlParameter("@EndDay", Entity.EndDay),
                new SqlParameter("@BeginTime", Entity.BeginTime),
                new SqlParameter("@EndTime", Entity.EndTime),
                new SqlParameter("@TimeTypeKey", Entity.TimeTypeKey)
                
            }
        };

        /// <summary>
        /// Entity Update Stored Procedure
        /// </summary>
        public override StoredProcedure<EntityTimeRecurring> UpdateStoredProcedure
        => new StoredProcedure<EntityTimeRecurring>()
        {
            StoredProcedureName = "EntityTimeRecurringSave",
            Parameters = new List<SqlParameter>()
            {
                new SqlParameter("@Id", Entity.Id),
                new SqlParameter("@Key", Entity.Key),
                new SqlParameter("@EntityKey", Entity.EntityKey),
                new SqlParameter("@BeginDay", Entity.BeginDay),
                new SqlParameter("@EndDay", Entity.EndDay),
                new SqlParameter("@BeginTime", Entity.BeginTime),
                new SqlParameter("@EndTime", Entity.EndTime),
                new SqlParameter("@TimeTypeKey", Entity.TimeTypeKey)
                
            }
        };

        /// <summary>
        /// Entity Delete Stored Procedure
        /// </summary>
        public override StoredProcedure<EntityTimeRecurring> DeleteStoredProcedure
        => new StoredProcedure<EntityTimeRecurring>()
        {
            StoredProcedureName = "EntityTimeRecurringDelete",
            Parameters = new List<SqlParameter>()
            {
                new SqlParameter("@Id", Entity.Id),
                new SqlParameter("@Key", Entity.Key)
                
            }
        };
   }
}