using System;
using System.Collections.Generic;

public class BitArray64 : IEnumerable<int>
{
    private const byte CellCapacity = 64;
    private readonly ulong _number;

    // constructor
    public BitArray64(uint number)
    {
        this._number = number;
    }

    public int this[int index]
    {
        get
        {
            if (!(index < 0 || index > 63))
            {
                throw new ArgumentException();
            }
            int[] bits = this.GetBits();
            return bits[index];
        }
    }

    private int[] GetBits()
    {
        ulong number = this._number;
        int place = CellCapacity - 1;
        int[] bits = new int[CellCapacity];
        while (number > 0)
        {

            bits[place] = (int)number % 2;
            number = number / 2;
            place--;
        }
        do
        {
            bits[place] = 0;
            place--;
        } while (place >= 0);
        return bits;
    }

    public IEnumerator<int> GetEnumerator()
    {
        int[] bits = this.GetBits();
        foreach (var bit in bits)
        {
            yield return bit;
        }
    }

    System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator();
    }

    public bool Equals(BitArray64 value)
    {
        return Equals(this._number, value._number);
    }

    public override bool Equals(object obj)
    {
        BitArray64 val = obj as BitArray64;
        return val != null && this.Equals(val);
    }

    public override int GetHashCode()
    {
        unchecked
        {
            int hash = 17;
            hash = (hash * 23) + this._number.GetHashCode();
            return hash;
        }
    }
    public static bool operator ==(BitArray64 number1,
                              BitArray64 number2)
    {
        return Equals(number1, number2);
    }

    public static bool operator !=(BitArray64 number1, BitArray64 number2)
    {
        return !Equals(number1, number2);
    }
    
}
