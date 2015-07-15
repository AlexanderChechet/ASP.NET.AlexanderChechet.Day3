using System;
using System.Text;

namespace Polynom
{
    public class CustomPolynom : IEquatable<CustomPolynom>, ICloneable
    {
        #region private members
        private double?[] polynom;
        #endregion

        #region Ctors
        public CustomPolynom(CustomPolynom customPolynom)
        {
            MaxPower = customPolynom.MaxPower;
            polynom = new double?[MaxPower];
            for (int i = 0; i < MaxPower; i++)
            {
                polynom[i] = customPolynom[i];
            }
        }

        public CustomPolynom(params double?[] array)
        {
            if (array == null)
                throw new ArgumentNullException();
            MaxPower = array.Length;
            polynom = new double?[MaxPower];
            array.CopyTo(polynom, 0);
        }
        #endregion

        #region Static methods
        public static CustomPolynom Add(CustomPolynom left, CustomPolynom right)
        {
            int max = Math.Max(left.MaxPower, right.MaxPower);
            var array = new double?[max];
            for (int i = 0; i < max; i++)
            {
                array[i] = (left[i] ?? 0) + (right[i] ?? 0);
            }
            return new CustomPolynom(array);
        }

        public static CustomPolynom Substract(CustomPolynom left, CustomPolynom right)
        {
            int max = Math.Max(left.MaxPower, right.MaxPower);
            var array = new double?[max];
            for (int i = 0; i < max; i++)
            {
                array[i] = (left[i] ?? 0) - (right[i] ?? 0);
            }
            return new CustomPolynom(array);
        }

        public static CustomPolynom MultyplyNumber(CustomPolynom left, double right)
        {
            int max = left.MaxPower;
            var array = new double?[max];
            for (int i = 0; i < max; i++)
            {
                array[i] = (left[i] ?? 0) * right;
            }
            return new CustomPolynom(array);
        }

        public static CustomPolynom MultyplyNumber(double left, CustomPolynom right)
        {
            return MultyplyNumber(right, left);
        }
        #endregion

        #region Properties
        public int MaxPower { get; private set; }

        public double? this[int index]
        {
            get
            {
                if ((index < MaxPower) && (index > -1))
                    return polynom[index];
                return null;
            }
        }
        #endregion     

        #region Object virtual methods override
        public bool Equals(CustomPolynom other)
        {
            if (MaxPower == other.MaxPower)
            {
                int i = 0;
                while ((i < MaxPower) && (this[i] == other[i]))
                    i++;
                if (i == MaxPower)
                    return true;
            }
            return false;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) 
                return false;
            if (ReferenceEquals(this, obj)) 
                return true;
            return obj is CustomPolynom && Equals((CustomPolynom)obj);
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            for (int i = 0; i < MaxPower; i++)
            {
                if (this[i].GetValueOrDefault() != 0)
                    sb.Append(String.Format("{0:0.00}*x^{1}", this[i], i));
            }
            return base.ToString();
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public object Clone()
        {
            return new CustomPolynom(polynom);
        }
        #endregion
        
        #region Operator overload
        public static CustomPolynom operator +(CustomPolynom left, CustomPolynom right)
        {
            return Add(left, right);
        }

        public static CustomPolynom operator -(CustomPolynom left, CustomPolynom right)
        {
            return Substract(left, right);
        }

        public static CustomPolynom operator *(CustomPolynom left, int right)
        {
            return MultyplyNumber(left, right);
        }

        public static CustomPolynom operator *(int left, CustomPolynom right)
        {
            return MultyplyNumber(right, left);
        }
        
        public static bool operator ==(CustomPolynom left, CustomPolynom right)
        {
            return left.Equals(right);
        }
         
        public static bool operator !=(CustomPolynom left, CustomPolynom right)
        {
            return !(left == right);
        }
        #endregion 
    }
}
