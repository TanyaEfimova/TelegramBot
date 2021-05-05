namespace TelegramBot
{
    class Messenger
    {
        public string CreateTextMessage(Conversation chat)
        {
            string delimiter = ",";
            var text = "Your history: " + string.Join(delimiter, chat.GetTextMessages().ToArray());
            return text;
        }
    }
}
