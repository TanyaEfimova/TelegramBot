namespace TelegramBot
{
    class Messenger
    {
        public string CreateTextMessage(Conversation chat)
        {
            var text = "";

            if (chat.GetLastMessage() == "/saymehi")
            {
                text = "привет";
            }
            else
            {
                var delimiter = ",";
                text = "История ваших сообщений: " + string.Join(delimiter, chat.GetTextMessages().ToArray());
            }

            return text;
        }
    }
}
