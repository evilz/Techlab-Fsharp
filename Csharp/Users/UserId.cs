using System;

namespace ShopOnCore.Users
{
    public class UserId : IEquatable<UserId>
    {
        private readonly string _id;

        public UserId(string id)
        {
            _id = id;
        }

        public string Value => _id;

        public override string ToString()
        {
            return $"UserID{{id='{_id}{'\''}{'}'}";
        }

        public bool Equals(UserId other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return string.Equals(_id, other._id);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((UserId) obj);
        }

        public override int GetHashCode()
        {
            return (_id != null ? _id.GetHashCode() : 0);
        }

        public static bool operator ==(UserId left, UserId right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(UserId left, UserId right)
        {
            return !Equals(left, right);
        }
    }
}
