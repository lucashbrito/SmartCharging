using System;
using System.Collections.Generic;
using System.Text;

namespace SmartCharging.Domain.DomainObjects
{
    public abstract class ValueObject<T> where T : ValueObject<T>
    {
        protected abstract bool EqualsCore(T other);

        public override bool Equals(object obj)
        {
            var valueObject = obj as T;

            if (ReferenceEquals(valueObject, null))
                return false;

            return EqualsCore(valueObject);
        }

        public override int GetHashCode()
        {
            return GetType().GetHashCode();
        }

        public static bool operator ==(ValueObject<T> a, ValueObject<T> b)
        {
            if (ReferenceEquals(a, null) && ReferenceEquals(b, null))
                return true;

            if (ReferenceEquals(a, null) || ReferenceEquals(b, null))
                return true;

            return a.Equals(b);
        }

        public static bool operator !=(ValueObject<T> a, ValueObject<T> b)
        {
            return !(a == b);
        }
    }
}
