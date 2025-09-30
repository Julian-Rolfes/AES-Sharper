#  AES-Sharper

[![MIT License](https://img.shields.io/badge/license-MIT-green.svg)](./LICENSE)
[![.NET](https://img.shields.io/badge/.NET-6.0+-purple.svg)](https://dotnet.microsoft.com/)
[![Made with ❤ by Julian-Rolfes](https://img.shields.io/badge/made%20by-Julian%20Rolfes-blue)](https://github.com/Julian-Rolfes)

> **AES-Sharper** is a standalone, lightweight extension to [`sharper v2`](https://github.com/Julian-Rolfes/sharper), providing secure AES-256 encryption & decryption for .NET projects.

---

##  Features

- AES-256 CBC encryption and decryption
- Secure key derivation (PBKDF2 + SHA256)
- Minimal code, easy integration
- Independent from `sharper`, but compatible
- MIT License – Open Source, no restrictions

---

##  Quick Start

```csharp
using System.Security.Cryptography;

// Initialize
var aes = new AES_Sharper();

// Generate salt (store it securely)
byte[] salt = RandomNumberGenerator.GetBytes(16);

// Derive key
byte[] key = aes.Create_session_kdf("yourSecret", salt);

// Encrypt
string encrypted = aes.Encode("secret text", key, salt);

// Decrypt
string decrypted = aes.Decode(encrypted, key, salt);

Console.WriteLine(decrypted); // "secret text"
```

---

##  Integration

Simply copy [`AES_Sharper.cs`](./AES_Sharper.cs) into your project.  
No dependencies besides the standard .NET libraries.

---

##  Security Notes

> ** Note:**  
> Always use a cryptographically secure random value for the salt (`RandomNumberGenerator.GetBytes`).  
> Store salt and password separately and securely – never save passwords in plain text!

---

##  Background

This project was created as a standalone extension to [`sharper v2`](https://github.com/Julian-Rolfes/sharper), after requests from users for a simple, secure AES implementation for .NET.

---

##  License

This project is licensed under the [MIT License](./LICENSE).  
Free for private & commercial use – see the file for details.

---

##  Contribute & Feedback

Questions? Ideas?  
Just [open an issue](https://github.com/Julian-Rolfes/sharper-aes/issues) or send a pull request!

---

