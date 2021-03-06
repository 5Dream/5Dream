﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Security.Cryptography;

namespace BLL
{
   public class PWDProcess
    {
        public static string MD5Encrypt(string pToEncrypt, string Key)
        {
            DESCryptoServiceProvider des = new DESCryptoServiceProvider();
            byte[] inputByteArray = Encoding.Default.GetBytes(pToEncrypt);
            des.Key = ASCIIEncoding.ASCII.GetBytes(Key);
            des.IV = ASCIIEncoding.ASCII.GetBytes(Key);
            MemoryStream ms = new MemoryStream();
            CryptoStream cs = new CryptoStream(ms,des.CreateEncryptor(),CryptoStreamMode.Write);
            cs.Write(inputByteArray,0,inputByteArray.Length);
            cs.FlushFinalBlock();
            StringBuilder ret = new StringBuilder();
            foreach (byte b in ms.ToArray())
            {
                ret.AppendFormat("{0:X2}",b);
            }
            ret.ToString();
            return ret.ToString();
            }
        public static string CreateKey(string inputstr)
        {
            StringBuilder sb = new StringBuilder();
            string str = "Y59JGF478";
            if (CheckStringIsNumString(inputstr) && inputstr.Length >= 9)
            {
                for (int i = 1; i <= 8; i++)
                {
                    sb.Append(str[Convert.ToInt32(inputstr[i].ToString())]);
                }
                return sb.ToString();
            }
            else
            {
                return "CYR3E87K";
           
            }

        }
        public static bool CheckStringIsNumString(string str)
        {
            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] < '0' || str[i] > '9')
                    return false;

            }
            return true;
        }
    }
}
