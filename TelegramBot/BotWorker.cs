using Telegram.Bot;
using Telegram.Bot.Args;

namespace TelegramBot
{
    public class BotWorker
    {
        private ITelegramBotClient botClient;

        public void Inizalize()
        {
            botClient = new TelegramBotClient(BotCredentials.BotToken);
        }

        public void Start()
        {
            botClient.OnMessage += Bot_OnMessage;
            botClient.StartReceiving();
        }

        public void Stop()
        {
            botClient.StopReceiving();
        }

        private async void Bot_OnMessage(object sender, MessageEventArgs e)
        {
            if (e.Message.Text != null)
            {
                //Console.WriteLine($"Получено сообщение в чате: {e.Message.Chat.Id}.");

                await botClient.SendTextMessageAsync(
                chatId: e.Message.Chat,
                text: "Вы написали:\n" + e.Message.Text);
            }
        }
    }
}
