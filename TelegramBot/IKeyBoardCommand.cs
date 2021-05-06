using Telegram.Bot.Types.ReplyMarkups;

namespace TelegramBot
{
    interface IKeyBoardCommand
    {
        InlineKeyboardMarkup ReturnKeyBoard();

        void AddCallBack(long chatid);

        string InformationalMessage();
    }
}
