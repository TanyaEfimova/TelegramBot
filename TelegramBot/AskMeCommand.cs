namespace TelegramBot
{
    class AskMeCommand : AbstractCommand, IChatTextCommand
    {
        public AskMeCommand()
        {
            CommandText = "/askme";
        }
        public string ReturnText()
        {
            return "как дела";
        }
    }
}
