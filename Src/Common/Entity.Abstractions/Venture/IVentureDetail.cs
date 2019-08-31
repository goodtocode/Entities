﻿//-----------------------------------------------------------------------
// <copyright file="IVentureDetail.cs" company="GoodToCode">
//      Copyright (c) GoodToCode. All rights reserved.
//      All rights are reserved. Reproduction or transmission in whole or in part, in
//      any form or by any means, electronic, mechanical or otherwise, is prohibited
//      without the prior written consent of the copyright owner.
// </copyright>
//-----------------------------------------------------------------------
using GoodToCode.Entity.Detail;

namespace GoodToCode.Entity.Venture
{
    /// <summary>
    /// Detail of an Venture, like parking, tickets, etc.
    /// </summary>

    public interface IVentureDetail : IVentureKey, IDetail
    {
    }
}
