using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Methods
{
    // *** INSTANCE CONSTRUCTURE AND CLASSES (REFERENCE TYPES)
    class MyClass { }

    // Default constructor will be created by compiler
    class EqualMyClass
    {
        public EqualMyClass() : base() { this.e }
    }

    // Compiler will not create a default constructor
    static class StaticClass { }
    abstract class AbstractClass { }
    sealed class SealedClass { }

    // Fields initialization
    internal class SomeType
    {
        private int m_int;
        private double m_double;
        private byte m_byte;

        public SomeType()
        {
            m_byte = 0x3;
            m_int = 5;
            m_double = 7.0;
        }

        public SomeType(int mInt) : this()
        {
            m_int = mInt;
        }

        public SomeType(double mDouble, byte mByte) : this()
        {
            //...
        }

    }

    // *** INSTANCE CONSTRUCTORS AND STRUCTURES (VALUE TYPES)
    internal struct Point1
    {
        public int _x, _y;

        // Structure cannot containe explicity parameterless constructors
        //public Point1()
        //{

        //}
    }

    internal struct Point2
    {
        public int _x, _y;

        // All fields must be fully assigned
        //public Point2(int x)
        //{
        //    _x = x;
        //}
    }

    internal struct Point3
    {
        public int _x, _y;

        public Point3(int x, int y)
        {
            _x = x;
            _y = y;
        }
    }

    internal struct SomeValue
    {
        private int _x;
        public SomeValue(int x)
        {
            // Only structures can do like this :)
            this = new SomeValue();

            _x = x;
        }
    }

    // *** TYPE CONSTRUCTORS

    internal class SomeRefType
    {
        public static int x = 5;
        public int y = 5;

        static SomeRefType() { }
    }

    internal struct SomeValueType
    {
        // Non static structure member cannot have field initializator
        //public int y = 5;
        public static int y = 5;

        static SomeValueType() { }
    }

    // *** WARNING ***
    // BE CAREFULL WITH TYPE STATIC CONSTRUCTORS FOR STRUCTURES
    // BECAUSE SOMETIMES CLR DOES NOT CALL IT.
    // Example

    //struct ExampleStruture
    //{
    //    static ExampleStruture()
    //    {
    //        // this never gets displayed (for this example)
    //    }

    //    public int x;

    //}

    //class WarningExample
    //{
    //    public WarningExample()
    //    {
    //        ExampleStruture[] a = new ExampleStruture[10];
    //        a[0].x = 5;
    //    }
    //} 
    // END Example  


}
