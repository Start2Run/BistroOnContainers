// ==========================================================================
// Copyright (C) 2022 by Genetec, Inc.
// All rights reserved.
// May be used only in accordance with a valid Source Code License Agreement.
// ==========================================================================

namespace Persistence.Models;

using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.IdGenerators;

internal sealed record FoodProductPersistence
{
    [BsonId(IdGenerator = typeof(StringObjectIdGenerator))]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; init; }
    public string Category { get; init; }
    public byte[] Image { get; init; }
    public string Name { get; init; }
    public float Price { get; init; }
}
