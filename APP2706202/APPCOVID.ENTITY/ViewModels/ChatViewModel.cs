using System.Collections.Generic;

namespace APPCOVID.Entity.ViewModels
{
    public class ChatViewModel
    {
        public List<ConversatioMessage> ChatHistory { get; set; }
        public UserQueryModel UsrQueryModel { get; set; }

    }
}
