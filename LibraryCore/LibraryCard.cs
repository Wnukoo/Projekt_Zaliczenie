using System;
using System.Security.Cryptography;
using System.Text.Json.Serialization;

namespace LibraryCore
{
    // Klasa reprezentująca kartę biblioteczną przypisaną do studenta/użytkownika.
    public class LibraryCard
    {
        [JsonInclude] public string StudentName { get; private set; }
        [JsonInclude] public string CardId { get; private set; }

        private static readonly char[] _alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789".ToCharArray();

        private static string GenerateCardId()
        {
            Span<byte> buf = stackalloc byte[4];
            RandomNumberGenerator.Fill(buf); 

            var chars = new char[4]; 
            for (int i = 0; i < 4; i++)

                chars[i] = _alphabet[buf[i] % _alphabet.Length];

            return new string(chars);
        }

        [JsonConstructor]
        public LibraryCard(string cardId, string studentName)
        {
            CardId = cardId;
            StudentName = studentName;
        }

        public LibraryCard(string studentName)
        {
            CardId = GenerateCardId();
            StudentName = studentName;
        }

        public override string ToString() => $"{StudentName} (Card: {CardId})";
    }
}
