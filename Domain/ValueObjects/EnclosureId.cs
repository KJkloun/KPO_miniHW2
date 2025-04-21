using System;

namespace Domain.ValueObjects
{
    public sealed class EnclosureId
    {
        public Guid Value { get; }
        public EnclosureId(Guid value)
        {
            if (value == Guid.Empty) throw new ArgumentException("Id cannot be empty", nameof(value));
            Value = value;
        }
        public static EnclosureId New() => new(Guid.NewGuid());
        public override bool Equals(object obj) => obj is EnclosureId e && e.Value == Value;
        public override int GetHashCode() => Value.GetHashCode();
    }
}