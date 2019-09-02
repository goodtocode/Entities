﻿////-----------------------------------------------------------------------
//// <copyright file="IFlowExecuter.cs" company="GoodToCode">
////      Copyright (c) GoodToCode. All rights reserved.
////      All rights are reserved. Reproduction or transmission in whole or in part, in
////      any form or by any means, electronic, mechanical or otherwise, is prohibited
////      without the prior written consent of the copyright owner.
//// </copyright>
////-----------------------------------------------------------------------
//using GoodToCode.Framework.Worker;
//using GoodToCode.Framework.Session;

//namespace GoodToCode.Framework.Flow
//{
//    /// <summary>
//    /// Methods to create and execute a Flow
//    /// </summary>
//    public interface IFlowExecuter<TDataInConcrete> : IFlowClass
//    {
//        /// <summary>
//        /// Constructs and performs the initial save of data, before processing
//        /// </summary>
//        /// <param name="context">Device, application, module and user info</param>
//        /// <param name="inputData">Data to process</param>
//        void Create(ISessionContext context, TDataInConcrete inputData);

//        /// <summary>
//        /// Executes the Flow
//        /// </summary>
//        /// <returns></returns>
//        WorkerResult Execute();

//        /// <summary>
//        /// Results of the workflow
//        /// </summary>
//        WorkerResult Result { get; }
//    }
//}
