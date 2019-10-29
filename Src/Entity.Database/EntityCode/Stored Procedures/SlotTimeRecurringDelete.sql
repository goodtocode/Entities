﻿Create Procedure [EntityCode].[SlotTimeRecurringDelete]
	@Id	                INT,
    @Key				uniqueidentifier
AS
    Begin
    	
		Begin Try			
			If (@Id = -1 AND @Key <> '00000000-0000-0000-0000-000000000000') Select Top 1 @Id = IsNull(SlotId, -1) From [Entity].[Slot] P Where [SlotKey] = @Key
            If (@Id <> -1)
			Begin
	            Update	[Entity].[SlotTimeRecurring]
                Set     RecordStateKey = '081C6A5B-0817-4161-A3AD-AD7924BEA874'
	            Where	SlotTimeRecurringId = @Id
			End
			
		End Try
		Begin Catch
			
			Exec [Activity].[ExceptionLogInsertByException];
			
		End Catch
    End