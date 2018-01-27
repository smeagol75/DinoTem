using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Team_Editor_Manager_New_Generation.persistence
{
    public static class MyBinary
    {
        //reverse
        public static string Reverse32(byte[] blocco)
        {
            StringBuilder sba2 = new StringBuilder();
            foreach (byte read2 in blocco)
                sba2.Append(read2.ToString("X2"));
            string hexStringm2 = sba2.ToString();

            string byte_rev = hexStringm2.Substring(0, 8);
            byte_rev = byte_rev.Substring(6, 2) + byte_rev.Substring(4, 2) + byte_rev.Substring(2, 2) + byte_rev.Substring(0, 2);
            byte_rev = Convert.ToString(Convert.ToInt64(byte_rev, 16), 2).PadLeft(32, '0');

            return byte_rev;
        }

        //byte to binary X
        public static string ToBinaryX(int value, int byteBinary)
        {
            return Convert.ToString(value, 2).PadLeft(byteBinary, '0');
        }

        //byte to binary 8
        public static string ToBinary8(this byte value)
        {
            return Convert.ToString(value, 2).PadLeft(8, '0');
        }

        //byte to binary 16
        public static string ToBinary16(this byte value)
        {
            return Convert.ToString(value, 2).PadLeft(16, '0');
        }

        public static string ToBinary16(ushort block)
        {
            return Convert.ToString(block, 2).PadLeft(16, '0');
        }

        //byte to binary 32
        public static string ToBinary32(this byte value)
        {
            return Convert.ToString(value, 2).PadLeft(32, '0');
        }

        public static int BinaryToInt(string input)
        {
            return Convert.ToInt32(input, 2);
        }

        public static string IntToHex(int inputSave)
        {
            int value = inputSave;
            string temp = value.ToString("X4");
            temp = temp.Substring(2, 2) + " " + temp.Substring(0, 2);

            return temp;
        }
    }
}
