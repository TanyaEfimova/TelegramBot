using System;
using Telegram.Bot;
using Telegram.Bot.Args;

namespace TelegramBot
{
    class Program
    {
        static ITelegramBotClient botClient;
        static void Main(string[] args)
        {
            botClient = new TelegramBotClient(BotCredentials.BotToken);

            // var me = botClient.GetMeAsync().Result;
            // Console.WriteLine("Привет! Меня зовут {0}.", me.FirstName);

            botClient.OnMessage += Bot_OnMessage;
            botClient.StartReceiving();

            Console.WriteLine("Нажмите любую кнопку для остановки");
            Console.ReadKey();

            botClient.StopReceiving();
        }

        static async void Bot_OnMessage(object sender, MessageEventArgs e)
        {
            if (e.Message.Text != null)
            {
                Console.WriteLine($"Получено сообщение в чате: {e.Message.Chat.Id}.");

                await botClient.SendTextMessageAsync(
                chatId: e.Message.Chat, text: "Вы написали:\n" + e.Message.Text);
            }
        }
    }
}