using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("Type\tSize (bytes)\tMin\t\t\t\tMax");
        Console.WriteLine("---------------------");

        WriteTypeInfo(typeof(sbyte));
        WriteTypeInfo(typeof(byte));
        WriteTypeInfo(typeof(short));
        WriteTypeInfo(typeof(ushort));
        WriteTypeInfo(typeof(int));
        WriteTypeInfo(typeof(uint));
        WriteTypeInfo(typeof(long));
        WriteTypeInfo(typeof(ulong));
        WriteTypeInfo(typeof(float));
        WriteTypeInfo(typeof(double));
        WriteTypeInfo(typeof(decimal));
    }

    static void WriteTypeInfo(Type type)
    {
        Console.Write("{0,-8}", type.Name);

        // Size in bytes
        Console.Write("{0,-16}", System.Runtime.InteropServices.Marshal.SizeOf(type));

        // Min value
        Console.Write("{0,-32}", GetMinValue(type));

        // Max value
        Console.Write("{0,-32}", GetMaxValue(type));
        Console.WriteLine();
    }

    static object GetMinValue(Type type)
    {
        if (type == typeof(sbyte)) return sbyte.MinValue;
        if (type == typeof(byte)) return byte.MinValue;
        if (type == typeof(short)) return short.MinValue;
        if (type == typeof(ushort)) return ushort.MinValue;
        if (type == typeof(int)) return int.MinValue;
        if (type == typeof(uint)) return uint.MinValue;
        if (type == typeof(long)) return long.MinValue;
        if (type == typeof(ulong)) return ulong.MinValue;
        if (type == typeof(float)) return float.MinValue;
        if (type == typeof(double)) return double.MinValue;
        if (type == typeof(decimal)) return decimal.MinValue;
        return null;
    }

    static object GetMaxValue(Type type)
    {
        if (type == typeof(sbyte)) return sbyte.MaxValue;
        if (type == typeof(byte)) return byte.MaxValue;
        if (type == typeof(short)) return short.MaxValue;
        if (type == typeof(ushort)) return ushort.MaxValue;
        if (type == typeof(int)) return int.MaxValue;
        if (type == typeof(uint)) return uint.MaxValue;
        if (type == typeof(long)) return long.MaxValue;
        if (type == typeof(ulong)) return ulong.MaxValue;
        if (type == typeof(float)) return float.MaxValue;
        if (type == typeof(double)) return double.MaxValue;
        if (type == typeof(decimal)) return decimal.MaxValue;
        return null;
    }
}