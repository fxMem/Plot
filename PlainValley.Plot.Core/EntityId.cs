using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlainValley.Plot.Core
{
    abstract public class EntityId
    {
        sealed public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }

            var currentType = this.GetType();
            var comparandType = obj.GetType();
            if (currentType != comparandType)
            {
                return false;
            }

            return EqualsInternal(obj);
        }

        public static bool operator ==(EntityId a, EntityId b)
        {
            if (((object)a) == null && ((object)b) == null)
            {
                return true;
            }

            if (((object)a) == null && ((object)b) != null || ((object)b) == null && ((object)a) != null)
            {
                return false;
            }

            return a.Equals(b);
        }

        public static bool operator !=(EntityId a, EntityId b)
        {
            return !(a == b);
        }

        sealed public override int GetHashCode()
        {
            return GetHashCodeInternal();
        }

        public override string ToString()
        {
            return $"[Id ({GetType().Name}): {FormatIdString()}]";
        }

        protected abstract int GetHashCodeInternal();

        protected abstract bool EqualsInternal(object obj);

        protected abstract string FormatIdString();

    }
}
