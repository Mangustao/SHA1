using System;
using System.Security.Cryptography;
using System.Text;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Введiть рядок для хешування:");
        string input = Console.ReadLine();

        string hashedValue = ComputeSha256Hash(input);
        Console.WriteLine($"Геш-значення: {hashedValue}");
    }

    static string ComputeSha256Hash(string rawData)
    {
        // Створення SHA256 об'єкта
        using (SHA256 sha256Hash = SHA256.Create())
        {
            // Обчислення хешу
            byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(rawData));

            // Перетворення байтів у шістнадцятковий формат
            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < bytes.Length; i++)
            {
                builder.Append(bytes[i].ToString("x2"));
            }
            return builder.ToString();
        }
    }
}
