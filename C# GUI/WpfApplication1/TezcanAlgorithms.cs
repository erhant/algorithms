﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApplication1
{
    class TezcanAlgorithms
    {
        public static String collatzTezcanForm_2nd(long num)
        {
            String s = "";
            long twos = 0, threes = 0;
            while (num != 1)
            {
                if (num % 2 == 0)
                {
                    num = num >> 1;
                    twos++;
                    if (num % 2 == 1)
                    {
                        s += "2(" + twos + "), ";
                    }
                }
                else
                {
                    num = num << 2;
                    num += num;
                    num++;
                    threes++;
                }
            }
            s += "3(" + threes + ")";
            return s;
        }

        public static String collatzTezcanForm_1st(long num)
        {
            String s = "";

            while (num != 1)
            {
                if (num % 2 == 0)
                {
                    num = num >> 1;
                    s += "2, ";
                }
                else
                {
                    // num = num * 3 + 1
                    num = num << 2;
                    num += num;
                    num++;
                    s += "3, ";
                }
            }

            return s;
        }

        public static bool satisfy_N_piece(long num, int piece)
        {
            long ans = (long)(Math.Pow(3, piece) * num + Math.Pow(3, piece - 1));
            //System.out.println("Num = "+num+" , Piece = "+piece+" , Ans = "+ans);
            for (int i = piece - 2; i >= 0; i--)
            {
                while (ans % 2 == 0)
                {
                    ans = ans / 2;
                }
                ans += (long)Math.Pow(3, i);
            }
            while (ans > 1 && ans % 2 == 0)
            {
                ans = ans / 2;
            }
            if (ans == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static List<long> satisfies_M_PIECE_UPTO_N(long n, int m)
        {
            List<long> list = new List<long>();
            for (long i = 1; i <= n; i += 2)
            {
                if (satisfy_N_piece(i, m))
                {
                    list.Add(i);
                }
            }
            return list;
        }

        public static List<int> satisfies_M_PIECE_UPTO_N_UNIQUE(long n, int m)
        {
            List<int> list = new List<int>();
            for (int i = 1; i <= n; i += 2)
            {
                if (satisfy_N_piece(i, m) && !(satisfy_N_piece(i, m - 1)))
                {
                    list.Add(i);
                }
            }
            return list;
        }

        public static double satisifiers_UPTO_N_ratio(long n, int piece)
        {
            double ans = 0;
            for (long i = 1; i <= n; i += 2)
            {
                if (satisfy_N_piece(i, piece))
                {
                    ans++;
                }
            }
            ans = ans / ((n + 1) / 2);

            return ans;
        }

        public static int pieceSize(long num)
        {
            int ans = 0;
            while (num != 1)
            {
                if (num % 2 == 0)
                {
                    num = num >> 1;
                }
                else
                {
                    num = num << 2;
                    num += num;
                    num++;
                    ans++;
                }
            }
            return ans;
        }

        public static String max_piece_UPTO_N(long n)
        {
            int maxno = 1, maxpiece = 0;
            for (int i = 1; i <= n; i++)
            {
                if (pieceSize(i) >= maxpiece)
                {
                    maxpiece = pieceSize(i);
                    maxno = i;
                }
            }
            return "Number " + maxno + " with " + maxpiece + " pieces has the maximum piece count";
        }

    }
}
