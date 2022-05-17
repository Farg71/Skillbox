using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MyLibrary.BotDictionary;

using Telegram.Bot.Types;

namespace Networking.BotsClass
{
    internal class Answers
    {
        public static Dictionary<string, string> AnswersDictionary { get; set; }

        public Answers(Message message)
        {
            AnswersDictionary = new Dictionary<string, string>();

            #region MyLibrary.BotDictionary

            BotAnswers botAnswers = new BotAnswers();

            if (message.From.FirstName == "Сергей") botAnswers = new BotAnswers("Сергей");
            if (message.From.FirstName == "Yuki") botAnswers = new BotAnswers("Dasha");
            if (message.From.FirstName == "Виктория") botAnswers = new BotAnswers("Vika");

            AnswersDictionary = BotAnswers.Answers;

            #endregion

            #region PrimitiveDictionary

            Dialog dialog = new Dialog();
            AnswersDictionary = dialog.Answers;

            #endregion

        }

        public string AnswersText(Message message)
        {
            string text = "";

            if (AnswersDictionary.ContainsKey(message.Text))
            {
                text = AnswersDictionary[message.Text];
            }
            else
            {
                text = $"{message.From.FirstName}, ты написал/а: {message.Text}";
            }

            return text;
        }
    }
}
