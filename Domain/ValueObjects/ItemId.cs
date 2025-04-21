using System;

namespace Domain.ValueObjects
{
    public sealed class ItemId
    {
        public Guid Value { get; }
        public ItemId(Guid value)
        {
            if (value == Guid.Empty) throw new ArgumentException("Id cannot be empty", nameof(value));
            Value = value;
        }
        public static ItemId New() => new(Guid.NewGuid());
        public override bool Equals(object obj) => obj is ItemId i && i.Value == Value;
        public override int GetHashCode() => Value.GetHashCode();
    }
}