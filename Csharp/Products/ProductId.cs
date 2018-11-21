using System;

namespace ShopOnCore.Products
{
    public class ProductId : IEquatable<ProductId>
    {
        private readonly int _id;

        public ProductId(int id)
        {
            _id = id;
        }

        public bool Equals(ProductId other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return _id == other._id;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((ProductId) obj);
        }

        public override int GetHashCode()
        {
            return _id;
        }

        public static bool operator ==(ProductId left, ProductId right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(ProductId left, ProductId right)
        {
            return !Equals(left, right);
        }
    }
}