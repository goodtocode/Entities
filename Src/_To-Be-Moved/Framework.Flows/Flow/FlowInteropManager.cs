﻿
//using System;
//using GoodToCode.Extensions;
//using GoodToCode.Entity.Activity;
//using GoodToCode.Framework.Worker;
//using GoodToCode.Framework.Session;

//namespace GoodToCode.Framework.Flow
//{
//    /// <summary>
//    /// Handles workflow interop of data and types across tiers
//    /// </summary>
//    /// <typeparam name="TDataInInterface">Type of the data to be sent to the workflow</typeparam>

//    public abstract class FlowInteropManager<TDataInInterface> : IFlowInteropManager<TDataInInterface>, IActivitySessionflowId
//    {
//        /// <summary>
//        /// Setting to throw exception
//        /// </summary>
//        protected bool throwException = Defaults.Boolean;
//        private string rootUrl = Defaults.String;
//        /// <summary>
//        /// Context and Data
//        /// </summary>
//        protected WorkerParameter<TDataInInterface> parameterField = new WorkerParameter<TDataInInterface>();
//        private WorkerResult result = new WorkerResult();

//        /// <summary>
//        /// Sessionflow activity is the Id of activity of all user experience elements (screen flows, queue messages, etc.)
//        /// </summary>
//        public int ActivitySessionflowId { get; set;  } = Defaults.Integer;

//        /// <summary>
//        /// Root Url without trailing slash
//        /// </summary>
//        public string RootUrl { get { return rootUrl; } set { UrlSet(value); } }

//        /// <summary>
//        /// Route to the App Services, residing in DMZ as a Mvc web app would
//        /// </summary>
//        public abstract IFlowRoute WebServicesRoute { get; protected set; }

//        /// <summary>
//        /// Route to Mid Services, hosting the middle tier layer in the inner domain (not in DMZ)
//        /// </summary>
//        public abstract IFlowRoute MidServicesRoute { get; protected set; }

//        /// <summary>
//        /// Context and data
//        /// </summary>
//        public WorkerParameter<TDataInInterface> Parameter { get; set; }

//        /// <summary>
//        /// Parameter
//        /// </summary>
//        IWorkerParameter<TDataInInterface> IFlowInteropManager<TDataInInterface>.Parameter { get { return Parameter; } set { Parameter = value as WorkerParameter<TDataInInterface>; } }

//        /// <summary>
//        /// Constructor
//        /// </summary>
//        public FlowInteropManager() : base() { }

//        /// <summary>
//        /// Constructor for route-less usage with just data
//        /// </summary>
//        public FlowInteropManager(ISessionContext context, TDataInInterface dataIn) : this()
//        {
//            Parameter = new WorkerParameter<TDataInInterface>(context, dataIn);
//            #if (DEBUG)
//                throwException = true;
//            #endif
//        }

//        /// <summary>
//        /// Constructor for usage with routes and data
//        /// </summary>
//        public FlowInteropManager(string urlRoot, ISessionContext context, TDataInInterface dataIn) : this(context, dataIn)
//        {
//            rootUrl = urlRoot;
//        }

//        /// <summary>
//        /// Constructor
//        /// </summary>
//        public FlowInteropManager(string urlRoot, ISessionContext context, TDataInInterface dataIn, int sessionActivityFlowId) : this(urlRoot, context, dataIn)
//        {
//            ActivitySessionflowId = sessionActivityFlowId;
//        }

//        /// <summary>
//        /// Sets the url and propagates changes through object
//        /// </summary>
//        /// <param name="urlRoot">Root Url of the destination service</param>
//        private void UrlSet(string urlRoot)
//        {
//            rootUrl = urlRoot.Trim().RemoveLast("/");
//            WebServicesRoute.RootUrl = this.RootUrl;
//            MidServicesRoute.RootUrl = this.RootUrl;
//        }
//    }
//}