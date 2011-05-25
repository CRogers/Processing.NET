using System;

namespace Processing.NET
{
    public struct PVector
    {
        public double X, Y, Z;

        public double Magnitude
        {
            get { return Math.Sqrt(this.Dot(this)); }
        }

        public PVector(double x, double y, double z = 0)
        {
            X = x;
            Y = y;
            Z = z;
        }

        public static readonly PVector Zero = new PVector(0,0);


        public PVector Add(PVector p)
        {
            return new PVector(X + p.X, Y + p.Y, Z + p.Z);
        }

        public PVector Subtract(PVector p)
        {
            return new PVector(X - p.X, Y - p.Y, Z - p.Z);
        }

        public PVector Multiply(double s)
        {
            return new PVector(s*X,s*Y,s*Z);
        }

        public PVector Divide(double s)
        {
            return new PVector(X/s,Y/s,Z/s);
        }

        public double Dot(PVector p)
        {
            return X * p.X + Y * p.Y + Z * p.Z;
        }

        public PVector Cross(PVector p)
        {
            return new PVector(Z*p.Y - Y*p.Z, Z*p.Z - X*p.Z, X*p.Y - Y*p.X);
        }


        public double Dist(PVector p)
        {
            return (this - p).Magnitude;
        }

        public PVector Normalize()
        {
            return Divide(Magnitude);
        }

        public double AngleBetween(PVector p)
        {
            return Math.Acos(this.Dot(p)/p.Magnitude/this.Magnitude);
        }

        public PVector Limit(double mag)
        {
            return this.Multiply(mag/this.Magnitude);
        }




        public static PVector operator +(PVector p, PVector q)
        {
            return p.Add(q);
        }

        public static PVector operator -(PVector p, PVector q)
        {
            return p.Subtract(q);
        }


        public static double operator *(PVector p, PVector q)
        {
            return p.Dot(q);
        }

        public static PVector operator *(PVector p, double s)
        {
            return p.Multiply(s);
        }

        public static PVector operator *(double s, PVector p)
        {
            return p.Multiply(s);
        }


        public static PVector operator /(PVector p, double s)
        {
            return p.Divide(s);
        }

        public static PVector operator /(double s, PVector p)
        {
            return p.Divide(s);
        }


        public static PVector operator ^(PVector p, PVector q)
        {
            return p.Cross(q);
        }
    }
}
