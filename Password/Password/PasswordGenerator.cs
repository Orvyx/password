using System;
using System.Collections.Generic;
using System.Text;

namespace Password
{
    class PasswordGenerator
    {
        private String Pass;
        
        public PasswordGenerator(String pass)
        {
            this.Pass = pass;
        }
        public String Generate(String key, int length = 8, bool specialChars = false)
        {
            int types = 3;
            Random rand_key = new Random(ToInt(key));
            Random rand_pass = new Random(ToInt(Pass));
            if (specialChars)
                types = 4;
            return Generate(key, length, types, rand_key, rand_pass);
        }
        public static int ToInt(String s)
        {
            int final = 1;
            for (int i = 0; i < s.Length; i++)
            {
                final *= 100;
                final += Convert.ToInt32(s[i]);
                final /= 11;
            }
            return final;
        }
        private String Generate(String key, int length, int types, Random rand_key, Random rand_pass)
        {
            String password = String.Empty;
            bool[] contains = { false, false, false, false };
            bool containsAll = true;
            rand_pass.Next(ToInt(key), ToInt(key) + 1);
            rand_key.Next(ToInt(Pass), ToInt(Pass) + 1);
            for (int i = 0; i < length; i++)
            {
                rand_key = new Random((rand_key.Next() % rand_pass.Next()));
                rand_pass = new Random((rand_pass.Next() % rand_pass.Next()));
                rand_key = new Random((rand_key.Next() % rand_pass.Next())%(rand_key.Next() % rand_pass.Next()));
                rand_key.Next(ToInt(Pass), ToInt(Pass) + 1);
                int type = rand_pass.Next(1, types + 1);
                int nextChar = 0;
                if (type == 1)
                {
                    contains[0] = true;
                    nextChar = rand_key.Next(97, 122);
                }
                else if (type == 2)
                {
                    contains[1] = true;
                    nextChar = rand_key.Next(65, 90);
                }
                else if (type == 3)
                {
                    contains[2] = true;
                    nextChar = rand_key.Next(48, 57);
                }
                else if (type == 4)
                {
                    contains[3] = true;
                    type = rand_pass.Next(1, 2);
                    if (type == 1)
                        nextChar = rand_key.Next(33, 47);
                    else
                        nextChar = rand_key.Next(58, 64);
                }
                password += Convert.ToChar(nextChar);
            }
            for (int i = 0; i < types; i++)
            {
                if (!contains[i])
                    containsAll = false;
            }
            if (!containsAll)
                return Generate(key, length, types, rand_key, rand_pass);
            else
                return password;
        }
    }
}
