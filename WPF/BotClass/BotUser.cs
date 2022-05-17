using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Newtonsoft.Json;

namespace WPF.BotClass
{
    public class BotUser
    {
        [JsonProperty(Required = Required.Always)]
        public long ChatId { get; set; }

        [JsonProperty(Required = Required.AllowNull)]
        public string? FirstName { get; set; }

        [JsonProperty(Required = Required.AllowNull)]
        public string? LastName { get; set; }

        [JsonProperty(Required = Required.AllowNull)]
        public string? UserName { get; set; }

        [JsonProperty(Required = Required.Always)]
        public string LanguageCode { get; set; }

        [JsonProperty(Required = Required.Always)]
        public bool IsBot { get; set; }

        /// <summary>
        /// Все сообщения. Кортеж (это сообщение пользователя?, время сообщения, текст сообщения)
        /// </summary>
        [JsonProperty(Required = Required.AllowNull)]
        public List<(bool, DateTime, string?)> Messages { get; set; }

        /// <summary>
        /// Инициализация
        /// </summary>
        /// <param name="ChatId"></param>
        /// <param name="FirstName"></param>
        /// <param name="LastName"></param>
        /// <param name="UserName"></param>
        /// <param name="Type"></param>
        /// <param name="LanguageCode"></param>
        /// <param name="IsBot"></param>
        public BotUser(long ChatId, string? FirstName, string? LastName, string? UserName, string LanguageCode, bool IsBot)
        {
            this.ChatId = ChatId;
            this.FirstName = FirstName;
            this.LastName = LastName;
            this.UserName = UserName;
            this.LanguageCode = LanguageCode;
            this.IsBot = IsBot;
            Messages = new List<(bool, DateTime, string?)>();
        }

        /// <summary>
        /// метод добавления сообщения
        /// </summary>
        /// <param name="text">текст сообщения</param>
        /// <param name="dt">время сообщения</param>
        public void AddMessage(bool isUserMessage, DateTime dt, string? text) => Messages.Add((isUserMessage, dt, text));

        /// <summary>
        /// Метод сравнения двух пользователей
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public bool Equals(BotUser other) => other.ChatId == this.ChatId;

        public override string ToString()
        {
            string name = String.Empty;
            if (FirstName != null) name = FirstName;
            if (LastName != null) name = LastName;
            if (UserName != null) name = UserName;

            return $"{name} {ChatId}";
        }
    }
}
