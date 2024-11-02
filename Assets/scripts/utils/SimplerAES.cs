using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using System.IO;
using System;
using System.Security.Cryptography;
using System.Text;


public class SimplerAES
{
    private static byte[] key = { 163, 215, 42, 150, 5, 164, 106, 234, 127, 28, 228, 110, 128, 81, 207, 98, 100, 14, 136, 204, 116, 121, 94, 201, 15, 114, 181, 75, 16, 71, 233, 122 };

    // a hardcoded IV should not be used for production AES-CBC code
    // IVs should be unpredictable per ciphertext
    private static byte[] vector = { 49, 45, 107, 32, 55, 85, 65, 149, 47, 212, 175, 126, 47, 43, 151, 181 };

    private ICryptoTransform encryptor, decryptor;
    private UTF8Encoding encoder;

    public SimplerAES()
    {
        RijndaelManaged rm = new RijndaelManaged();
        encryptor = rm.CreateEncryptor(key, vector);
        decryptor = rm.CreateDecryptor(key, vector);
        encoder = new UTF8Encoding();
    }

    public string Encrypt(string unencrypted)
    {
        return Convert.ToBase64String(Encrypt(encoder.GetBytes(unencrypted)));
    }

    public string Decrypt(string encrypted)
    {
        return encoder.GetString(Decrypt(Convert.FromBase64String(encrypted)));
    }

    public byte[] Encrypt(byte[] buffer)
    {
        return Transform(buffer, encryptor);
    }

    public byte[] Decrypt(byte[] buffer)
    {
        return Transform(buffer, decryptor);
    }

    protected byte[] Transform(byte[] buffer, ICryptoTransform transform)
    {
        MemoryStream stream = new MemoryStream();
        using (CryptoStream cs = new CryptoStream(stream, transform, CryptoStreamMode.Write))
        {
            cs.Write(buffer, 0, buffer.Length);
        }
        return stream.ToArray();
    }
}
