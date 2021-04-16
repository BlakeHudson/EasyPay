﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

/// <summary>
/// This is an Encrypt/Decrypt password class 
/// created by Eddie Jackson
/// http://eddiejackson.net/wp/?p=13434
/// </summary>

namespace EasyPay
{
    class Encode_Decode
    {
        public static class Global
    {
        // set permutations
        public const String strPermutation = "ouiveyxaqtd";
        public const Int32 bytePermutation1 = 0x19;
        public const Int32 bytePermutation2 = 0x59;
        public const Int32 bytePermutation3 = 0x17;
        public const Int32 bytePermutation4 = 0x41;
    }

    // encoding
    public static string Encrypt(string strData)
    {

        return Convert.ToBase64String(Encrypt(Encoding.UTF8.GetBytes(strData)));
        // reference https://msdn.microsoft.com/en-us/library/ds4kkd55(v=vs.110).aspx

    }


    // decoding
    public static string Decrypt(string strData)
    {
        return Encoding.UTF8.GetString(Decrypt(Convert.FromBase64String(strData)));
        // reference https://msdn.microsoft.com/en-us/library/system.convert.frombase64string(v=vs.110).aspx

    }

    // encrypt
    public static byte[] Encrypt(byte[] strData)
    {
        PasswordDeriveBytes passbytes =
        new PasswordDeriveBytes(Global.strPermutation,
        new byte[] { Global.bytePermutation1,
                         Global.bytePermutation2,
                         Global.bytePermutation3,
                         Global.bytePermutation4
        });

        MemoryStream memstream = new MemoryStream();
        Aes aes = new AesManaged();
        aes.Key = passbytes.GetBytes(aes.KeySize / 8);
        aes.IV = passbytes.GetBytes(aes.BlockSize / 8);

        CryptoStream cryptostream = new CryptoStream(memstream,
        aes.CreateEncryptor(), CryptoStreamMode.Write);
        cryptostream.Write(strData, 0, strData.Length);
        cryptostream.Close();
        return memstream.ToArray();
    }

    // decrypt
    public static byte[] Decrypt(byte[] strData)
    {
        PasswordDeriveBytes passbytes =
        new PasswordDeriveBytes(Global.strPermutation,
        new byte[] { Global.bytePermutation1,
                         Global.bytePermutation2,
                         Global.bytePermutation3,
                         Global.bytePermutation4
        });

        MemoryStream memstream = new MemoryStream();
        Aes aes = new AesManaged();
        aes.Key = passbytes.GetBytes(aes.KeySize / 8);
        aes.IV = passbytes.GetBytes(aes.BlockSize / 8);

        CryptoStream cryptostream = new CryptoStream(memstream,
        aes.CreateDecryptor(), CryptoStreamMode.Write);
        cryptostream.Write(strData, 0, strData.Length);
        cryptostream.Close();
        return memstream.ToArray();
    }
    // reference
    // https://msdn.microsoft.com/en-us/library/system.security.cryptography(v=vs.110).aspx
    // https://msdn.microsoft.com/en-us/library/system.security.cryptography.cryptostream%28v=vs.110%29.aspx?f=255&MSPPError=-2147217396
    // https://msdn.microsoft.com/en-us/library/system.security.cryptography.rfc2898derivebytes(v=vs.110).aspx
    // https://msdn.microsoft.com/en-us/library/system.security.cryptography.aesmanaged%28v=vs.110%29.aspx?f=255&MSPPError=-2147217396
}
}
