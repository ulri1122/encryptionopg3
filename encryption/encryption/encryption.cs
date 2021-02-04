using System;
using System.Collections.Generic;
using System.Text;

namespace encryption
{

    public class Encryption
    {

        public byte[] EncryptByte(byte[] bytes, string key)
        {

            byte[] bkey = Encoding.ASCII.GetBytes(key);
            /*
            double byteslength = Math.Ceiling(Convert.ToDouble(bytes.Length) / 4);
            byte[,] bbytes2d = new byte[Convert.ToInt32(byteslength), 4];
            int c = 0;
            for (int j = 0; j < bbytes2d.GetLength(0); j++)
            {
                for (int k = 0; k <= bbytes2d.Length; k++)
                {
                    if (c >= bytes.Length)
                    {
                        c = 0;
                        bbytes2d[j, k] = bytes[Convert.ToInt32(c)];
                        break;
                    }
                    bbytes2d[j, k] = bytes[c];

                    c++;
                }
            }

            */
            int a = 0;
            for (int i = 0; i < bytes.Length; i++)
            {
                if (a >= bkey.Length - 1)
                {
                    a = 0;
                }
                int change = i + bkey[a];

                while (change + bytes[i] > 255) change -= 256;
                bytes[i] += (byte)change;
                bytes[i] += bkey[a];


                a++;
            }



            return bytes;
        }

        public byte[] DecryptByte(byte[] bytes, string key)
        {
            byte[] bkey = Encoding.ASCII.GetBytes(key);
            /*
            int arraylength = 0;
            for (int b = 0; b < bytes.Length; ++b)
            {
                if (bytes[b] == 0)
                {
                    arraylength = b;
                    break;

                }
            }
            Array.Resize(ref bytes, arraylength);
            double byteslength = Math.Ceiling(Convert.ToDouble(bytes.Length) / 4);

            byte[,] bbytes2d = new byte[Convert.ToInt32(byteslength), 4];
            int c = 0;
            for (int j = 0; j < bbytes2d.GetLength(0); j++)
            {
                for (int k = 0; k <= bbytes2d.Length; k++)
                {
                    if (c >= bytes.Length)
                    {
                        c = 0;
                        bbytes2d[j, k] = bytes[Convert.ToInt32(c)];
                        break;
                    }
                    bbytes2d[j, k] = bytes[c];

                    c++;
                }
            }
            */
            int a = 0;

            for (int i = 0; i < bytes.Length; i++)
            {
                if (a >= bkey.Length - 1)
                {
                    a = 0;
                }
                int change = i + bkey[a];
                while (change - bytes[i] < 0) change += 256;
                bytes[i] -= (byte)change;
                bytes[i] -= bkey[a];
                a++;
            }
            return bytes;

        }

        public void PrintBytesUTF8(byte[] bytes)
        {
            string toPrint = Encoding.UTF8.GetString(bytes);
            Console.WriteLine(toPrint);
        }
    }
}