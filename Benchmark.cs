using System;
using System.Diagnostics;
using System.Text;

class Program
{
    static void Main()
    {
        // Create an instance of AES_Sharper
        var aes = new AES_Sharper();

        // Define key and salt (example)
        string key = "SuperSecretKey123!";
        byte[] salt = Encoding.UTF8.GetBytes("FixedSaltValue1234");
        string plaintext = "This is a test string for AES benchmarking.";

        // ----------------------------
        // Benchmark: Key Derivation
        // ----------------------------
        var sw = Stopwatch.StartNew();
        byte[] keyBytes = aes.Create_session_kdf(key, salt);
        sw.Stop();
        Console.WriteLine($"Key Derivation: {sw.ElapsedMilliseconds} ms");

        // ----------------------------
        // Benchmark: Encryption
        // ----------------------------
        sw.Restart();
        string encrypted = aes.Encode(plaintext, keyBytes, salt);
        sw.Stop();
        Console.WriteLine($"Encryption: {sw.ElapsedMilliseconds} ms");
        Console.WriteLine($"Encrypted: {encrypted.Substring(0, 50)}..."); // show only first 50 chars

        // ----------------------------
        // Benchmark: Decryption
        // ----------------------------
        sw.Restart();
        string decrypted = aes.Decode(encrypted, keyBytes, salt);
        sw.Stop();
        Console.WriteLine($"Decryption: {sw.ElapsedMilliseconds} ms");
        Console.WriteLine($"Decrypted: {decrypted}");

        // ----------------------------
        // Benchmark: Multiple Iterations (e.g., 1000 times)
        // ----------------------------
        int iterations = 1000;
        sw.Restart();
        for (int i = 0; i < iterations; i++)
        {
            string enc = aes.Encode(plaintext, keyBytes, salt);
            string dec = aes.Decode(enc, keyBytes, salt);
        }
        sw.Stop();
        Console.WriteLine($"{iterations}x Encrypt+Decrypt: {sw.ElapsedMilliseconds} ms");
        Console.WriteLine($"Average per run: {sw.ElapsedMilliseconds / (double)iterations:0.000} ms");
    }
}
