using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OY.Theory.NumberTheory
{
    public class FieldP
    {
        public uint P { get { return this.p; } }
        protected uint p;
        public FieldP(uint p)
        {
            this.p = p;
        }

        public static bool operator == (FieldP lhs, FieldP rhs)
        {
            return lhs.p == rhs.p;
        }

        public static bool operator !=(FieldP lhs, FieldP rhs)
        {
            return lhs.p != rhs.p;
        }
    }

    public class FieldPElement
    {
        protected readonly FieldP field;
        public uint Value { get { return this.x; } }
        protected uint x;
        public FieldPElement(FieldP field, int x)
        {
            this.field = field;
            this.x = (uint) x % field.P;
        }
        public FieldPElement(FieldP field, uint x)
        {
            this.field = field;
            this.x = x % field.P;
        }
        public static FieldPElement operator + (FieldPElement lhs, FieldPElement rhs)
        {
            if (lhs.field != rhs.field)
                throw new ApplicationException("lhs and rhs are from different field");
            return new FieldPElement(lhs.field, (lhs.Value + rhs.Value) % lhs.field.P);
        }
        public static FieldPElement operator -(FieldPElement lhs, FieldPElement rhs)
        {
            if (lhs.field != rhs.field)
                throw new ApplicationException("lhs and rhs are from different field");
            return new FieldPElement(lhs.field, (lhs.Value - rhs.Value) % lhs.field.P);
        }

        public static FieldPElement operator *(FieldPElement lhs, FieldPElement rhs)
        {
            if (lhs.field != rhs.field)
                throw new ApplicationException("lhs and rhs are from different field");
            return new FieldPElement(lhs.field, (lhs.Value * rhs.Value) % lhs.field.P);
        }

        public FieldPElement GetMultiplicativeReverse()
        {
            throw new NotImplementedException();
        }

        public FieldPElement Power(int exponent)
        {
            throw new NotImplementedException();
        }
    }
}
