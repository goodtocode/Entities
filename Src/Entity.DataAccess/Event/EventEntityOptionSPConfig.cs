
using GoodToCode.Framework.Data;
using GoodToCode.Framework.Entity;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace GoodToCode.Entity.Event
{
    /// <summary>
    /// EventEntity DAO
    /// </summary>

    public class EventEntityOptionSPConfig : EntityConfiguration<EventEntityOption>
	{
        /// <summary>
        /// Entity Create/Insert Stored Procedure
        /// </summary>
        public override StoredProcedure<EventEntityOption> CreateStoredProcedure
        => new StoredProcedure<EventEntityOption>()
        {
            StoredProcedureName = "EventEntityOptionSave",
            Parameters = new List<SqlParameter>()
            {
                new SqlParameter("@EventKey", Entity.EventKey),
                new SqlParameter("@EntityKey", Entity.EntityKey),
                new SqlParameter("@OptionKey", Entity.OptionKey)
                
            }
        };

        /// <summary>
        /// Entity Update Stored Procedure
        /// </summary>
        public override StoredProcedure<EventEntityOption> UpdateStoredProcedure
        => new StoredProcedure<EventEntityOption>()
        {
            StoredProcedureName = "EventEntityOptionSave",
            Parameters = new List<SqlParameter>()
            {
                new SqlParameter("@EventKey", Entity.EventKey),
                new SqlParameter("@EntityKey", Entity.EntityKey),
                new SqlParameter("@OptionKey", Entity.OptionKey)
                
            }
        };

        /// <summary>
        /// Entity Delete Stored Procedure
        /// </summary>
        public override StoredProcedure<EventEntityOption> DeleteStoredProcedure
        => new StoredProcedure<EventEntityOption>()
        {
            StoredProcedureName = "EventEntityOptionDelete",
            Parameters = new List<SqlParameter>()
            {
                new SqlParameter("@Id", Entity.Id),
                new SqlParameter("@Key", Entity.Key)
                
            }
        };
    }
}
