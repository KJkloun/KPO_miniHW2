using System;
using Domain.ValueObjects;

namespace Domain.Entities
{
    public class Item
    {
        public ItemId Id { get; }
        public string Name { get; private set; }
        public int Quantity { get; private set; }
        public Item(ItemId id, string name, int quantity)
        {
            if (string.IsNullOrWhiteSpace(name)) throw new ArgumentException("Name is required", nameof(name));
            if (quantity < 0) throw new ArgumentOutOfRangeException(nameof(quantity), "Quantity cannot be negative");
            Id = id; Name = name; Quantity = quantity;
        }
        public void UpdateQuantity(int newQuantity)
        {
            if (newQuantity < 0) throw new ArgumentOutOfRangeException(nameof(newQuantity));
            Quantity = newQuantity;
        }
    }
}