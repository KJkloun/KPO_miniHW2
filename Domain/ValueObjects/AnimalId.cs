using System;

namespace Domain.ValueObjects
{
    public sealed class AnimalId
    {
        public Guid Value { get; }
        public AnimalId(Guid value)
        {
            if (value == Guid.Empty) throw new ArgumentException("Id cannot be empty", nameof(value));
            Value = value;
        }
        public static AnimalId New() => new(Guid.NewGuid());
        public override bool Equals(object obj) => obj is AnimalId a && a.Value == Value;
        public override int GetHashCode() => Value.GetHashCode();
    }
}