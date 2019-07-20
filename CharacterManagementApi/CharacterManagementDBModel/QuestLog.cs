using System;
using System.Collections.Generic;

namespace CharacterManagementApi.CharacterManagementDBModel
{
    public partial class QuestLog
    {
        public int LogEntryId { get; set; }
        public DateTime EntryDate { get; set; }
        public string EntryText { get; set; }
    }
}
