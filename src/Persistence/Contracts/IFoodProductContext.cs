// ==========================================================================
// Copyright (C) 2022 by Genetec, Inc.
// All rights reserved.
// May be used only in accordance with a valid Source Code License Agreement.
// ==========================================================================

namespace Persistence.Contracts;

using Bistro.Common.Models;

public interface IFoodProductContext
{
    Task AddProductsAsync(IEnumerable<FoodProduct> products);
    Task<IEnumerable<FoodProduct>> GetProductsAsync();
}
