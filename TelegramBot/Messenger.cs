using System.Collections.Generic;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types.ReplyMarkups;

namespace TelegramBot
{
    class Messenger
    {
        private ITelegramBotClient botClient;
        private CommandParser parser;

        public Messenger(ITelegramBotClient botClient)
        {
            this.botClient = botClient;
            parser = new CommandParser();

            RegisterCommands();
        }

        private void RegisterCommands()
        {
            parser.AddCommand(new SayHiCommand());
            parser.AddCommand(new AskMeCommand());
            parser.AddCommand(new PoemButtonCommand(botClient));
        }

        public string CreateTextMessage()
        {
            var text = "Not a command";

            return text;
        }


        public InlineKeyboardMarkup ReturnKeyBoard()
        {
            var buttonList = new List<InlineKeyboardButton>
            {
              new InlineKeyboardButton
              {
                 Text = "Пушкин",
                 CallbackData = "pushkin"
              },

              new InlineKeyboardButton
              {
                 Text = "Есенин",
                 CallbackData = "esenin"
              }
            };

            var keyboard = new InlineKeyboardMarkup(buttonList);

            return keyboard;
        }

        public async Task MakeAnswer(Conversation chat)
        {
            var lastmessage = chat.GetLastMessage();

            if (parser.IsMessageCommand(lastmessage))
            {
                await ExecCommand(chat, lastmessage);
            }
            else
            {
                var text = CreateTextMessage();

                await SendText(chat, text);
            }
        }

        public async Task ExecCommand(Conversation chat, string command)
        {
            if (parser.IsTextCommand(command))
            {
                var text = parser.GetMessageText(command);

                await SendText(chat, text);
            }

            if (parser.IsButtonCommand(command))
            {
                var keys = parser.GetKeyBoard(command);
                var text = parser.GetInformationalMessage(command);
                parser.AddCallback(command, chat.GetId());

                await SendTextWithKeyBoard(chat, text, keys);
            }
        }

        private async Task SendText(Conversation chat, string text)
        {
            await botClient.SendTextMessageAsync(
                  chatId: chat.GetId(),
                  text: text
                );
        }

        private async Task SendTextWithKeyBoard(Conversation chat, string text, InlineKeyboardMarkup keyboard)
        {
            await botClient.SendTextMessageAsync(
                  chatId: chat.GetId(),
                  text: text,
                  replyMarkup: keyboard
                );
        }
    }
}
