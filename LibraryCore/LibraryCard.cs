using System;
using System.Text.Json.Serialization;

namespace LibraryCore
{
    public class LibraryCard
    {
        [JsonInclude] public Guid CardId { get; private set; } = Guid.NewGuid();
        [JsonInclude] public string StudentName { get; private set; }

        [JsonConstructor]
        public LibraryCard(Guid cardId, string studentName)
        {
            CardId = cardId;
            StudentName = studentName;
        }

        public LibraryCard(string studentName) => StudentName = studentName;

        public override string ToString() => $"{StudentName} (Card: {CardId})";
    }
}