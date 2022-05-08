using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Telegram.Bot.Types;
using Telegram.Bot;

namespace Networking.BotsClass
{
    internal class Forex
    {
        /// <summary>
        /// Команда /forex
        /// </summary>
        public static bool IsForex {get; set;}

        /// <summary>
        /// Для запроса валютной пары
        /// </summary>
        public static bool IsCurrencyPair {get; set;}

        /// <summary>
        /// Словарь запросов в зависимости от валютной пары
        /// </summary>
        public static Dictionary<string, string> InstrumentsDictionary { get; set; }


        internal Forex()
        {
            IsForex = false;
            IsCurrencyPair = false;

            InstrumentsDictionary = new Dictionary<string, string>()
            {
                {"AUDJPY", InstrumentsAddress.AUDJPY },
                {"AUDUSD", InstrumentsAddress.AUDUSD },
                {"EURAUD", InstrumentsAddress.EURAUD },
                {"EURCHF", InstrumentsAddress.EURCHF },
                {"EURGBP", InstrumentsAddress.EURGBP },
                {"EURJPY", InstrumentsAddress.EURJPY },
                {"EURUSD", InstrumentsAddress.EURUSD },
                {"GBPCHF", InstrumentsAddress.GBPCHF },
                {"GBPJPY", InstrumentsAddress.GBPJPY },
                {"GBPUSD", InstrumentsAddress.GBPUSD },
                {"NZDUSD", InstrumentsAddress.NZDUSD },
                {"USDCAD", InstrumentsAddress.USDCAD },
                {"USDCHF", InstrumentsAddress.USDCHF },
                {"USDJPY", InstrumentsAddress.USDJPY }
            };
        }

        /// <summary>
        /// Запрос на ввод валютной пары
        /// </summary>
        /// <param name="botClient"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        internal static async Task<Message> ForexCommand(ITelegramBotClient botClient, Message message)
        {
            Forex.IsForex = true;

            string sentText = "Введите интересуемую валютную пару в формате 'EURUSD'";

            Message sentMessage = await Handlers.SentMessage(botClient, message, sentText);

            return sentMessage;
        }

        /// <summary>
        /// Заглушка: методы, подвязанные к валютным парам
        /// </summary>
        /// <param name="botClient"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        internal static async Task GetForexRequest(ITelegramBotClient botClient, Message message)
        {
            IsForex = false;            // В этом методе вывел данные о паре и обнулил флаг
            IsCurrencyPair = true;

            string text = "";

            if (InstrumentsDictionary.ContainsKey(message.Text)) text = InstrumentsDictionary[message.Text];    // вызов любого метода под инструмент

            await Handlers.SentMessage(botClient, message, text); 
        }


    }


    public struct InstrumentsAddress
    {
        public static string AUDJPY = "AUD_JPY";
        //public static string AUDNZD = "AUDNZD";
        public static string AUDUSD = "AUD_USD";
        //public static string CADCHF = "CADCHF";
        //public static string CHFJPY = "CHFJPY";
        public static string EURAUD = "EUR_AUD";
        //public static string EURCAD = "EURCAD";
        public static string EURCHF = "EUR_CHF";
        public static string EURGBP = "EUR_GBP";
        public static string EURJPY = "EUR_JPY";
        public static string EURUSD = "EUR_USD";
        public static string GBPCHF = "GBP_CHF";
        public static string GBPJPY = "GBP_JPY";
        public static string GBPUSD = "GBP_USD";
        public static string NZDUSD = "NZD_USD";
        public static string USDCAD = "USD_CAD";
        public static string USDCHF = "USD_CHF";
        public static string USDJPY = "USD_JPY";
        //public static string USDMXN = "USDMXN";
        //public static string USDSEK = "USDSEK";
        //public static string USDTRY = "USDTRY";
        //public static string USDZAR = "USDZAR";
        public static string ZARJPY = "ZAR_JPY";
        public static string XAUUSD = "XAU_USD";
        public static string XAGUSD = "XAG_USD";
    }

}
