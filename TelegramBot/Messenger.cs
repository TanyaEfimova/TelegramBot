using System.Collections.Generic;
using Telegram.Bot.Types.ReplyMarkups;

namespace TelegramBot
{
    class Messenger
    {
        public string CreateTextMessage(Conversation chat)
        {
            var text = "";

            switch (chat.GetLastMessage())
            {
                case "/saymehi":
                    text = "привет";
                    break;
                case "/askme":
                    text = "как дела";
                    break;
                default:
                    var delimiter = ",";
                    text = "История ваших сообщений: " + string.Join(delimiter, chat.GetTextMessages().ToArray());
                    break;
            }

            return text;
        }

        public string CreateTextMessage(Conversation chat, out InlineKeyboardMarkup keyboard)
        {
            var text = "";

            switch (chat.GetLastMessage())
            {
                case "/saymehi":
                    text = "привет";
                    keyboard = null;
                    break;
                case "/askme":
                    text = "как дела";
                    keyboard = null;
                    break;
                case "/poembuttons":
                    text = "Выберите поэта";
                    keyboard = ReturnKeyBoard();
                    break;
                default:
                    var delimiter = ",";
                    text = "История ваших сообщений: " + string.Join(delimiter, chat.GetTextMessages().ToArray());
                    keyboard = null;
                    break;
            }

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

    }
}
