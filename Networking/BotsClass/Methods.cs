using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using Telegram.Bot.Types;
using File = System.IO.File;

namespace Networking.BotsClass
{
    public static class Methods
    {
        public static void JsonFileWrite(User user)
        {
            string jsonUpdates = JsonConvert.SerializeObject(Handlers.UpdatesList);
            string jsonUser = JsonConvert.SerializeObject(user);

            JObject main = new JObject();

            JArray array = JArray.Parse(jsonUpdates);
            JObject us = JObject.Parse(jsonUser);

            main["user"] = us;
            main["updates"] = array;

            //Console.WriteLine(main.ToString());

            File.WriteAllText(PathToDirectory.FilesDir + "telegramBotLog.json", main.ToString());
        }

        public static void JsonFileRead()
        {
            string json = File.ReadAllText(PathToDirectory.FilesDir + "telegramBotLog.json");

            //string jsonUser = JObject.Parse(json)["user"].ToString();
            //user = JsonConvert.DeserializeObject<User>(jsonUser);

            string jsonUpdates = JObject.Parse(json)["updates"].ToString();
            Handlers.UpdatesList = JsonConvert.DeserializeObject<List<Update>>(jsonUpdates);

            //Console.WriteLine(user.Username);
            //foreach (var up in updates)
            //{
            //    Console.WriteLine(up.Message.Text);
            //}
        }

        /// <summary>
        /// Метод получения входящих обновлений с использованием long polling. Возвращается массив объектов Update.
        /// </summary>
        /// <param name="offset">
        /// Идентификатор первого возвращаемого обновления. Должен быть на единицу больше, чем самый высокий среди
        /// идентификаторов ранее полученных обновлений. По умолчанию возвращаются обновления, начиная с самого
        /// раннего неподтвержденного обновления.
        /// </param>
        /// <param name="limit">
        /// Ограничивает количество извлекаемых обновлений. Принимаются значения от 1 до 100. По умолчанию 100.
        /// </param>
        /// <param name="timeout">Тайм-аут в секундах для  long polling. По умолчанию 0, т.е. обычный short polling. 
        /// </param>
        /// <returns></returns>
        public static string GetUpdates(int offset, int limit = 100, int timeout = 0)
        {
            return $"getUpdates?offset={offset}&limit={limit}&timeout={timeout}";
        }

        public static string SendMessage(int chat_id, string text)
        {
            return $"sendMessage?chat_id={chat_id}&text={text}";
        }

        public static string SendMessage(string chat_id, string text)
        {
            return $"sendMessage?chat_id={chat_id}&text={text}";
        }

        #region Создать при необходимости следуюшие методы:
        public static string GetMe = "getMe";

        public static string ForwardMessage = "forwardMessage";

        public static string AnswerCallbackQuery = "answerCallbackQuery";

        public static string AnswerInlineQuery = "answerInlineQuery";

        public static string SendInvoice = "sendInvoice";

        public static string AnswerShippingQuery = "answerShippingQuery";

        public static string AnswerPreCheckoutQuery = "answerPreCheckoutQuery";

        public static string SetChatTitle = "setChatTitle";

        public static string SetChatDescription = "setChatDescription";

        public static string SetChatPermissions = "setChatPermissions";

        public static string SetChatAdministratorCustomTitle = "setChatAdministratorCustomTitle";

        public static string ExportChatInviteLink = "exportChatInviteLink";

        public static string CreateChatInviteLink = "createChatInviteLink";

        public static string EditChatInviteLink = "editChatInviteLink";

        public static string RevokeChatInviteLink = "revokeChatInviteLink";

        public static string ApproveChatJoinRequest = "approveChatJoinRequest";

        public static string DeclineChatJoinRequest = "declineChatJoinRequest";

        public static string PinChatMessage = "pinChatMessage";

        public static string GetChat = "getChat";

        public static string LeaveChat = "leaveChat";

        public static string GetUserProfilePhotos = "getUserProfilePhotos";

        public static string GetChatMember = "getChatMember";

        public static string GetChatAdministrators = "getChatAdministrators";

        public static string GetChatMembersCount = "getChatMembersCount";

        public static string SendChatAction = "sendChatAction";

        public static string GetFile = "getFile";

        public static string UnpinChatMessage = "unpinChatMessage";

        public static string SetChatPhoto = "setChatPhoto";

        public static string DeleteChatPhoto = "deleteChatPhoto";

        public static string KickChatMember = "kickChatMember";

        public static string UnbanChatMember = "unbanChatMember";

        public static string RestrictChatMember = "restrictChatMember";

        public static string PromoteChatMember = "promoteChatMember";

        public static string GetStickerSet = "getStickerSet";

        public static string SendPhoto = "sendPhoto";

        public static string SendVideo = "sendVideo";

        public static string SendAnimation = "sendAnimation";

        public static string SendAudio = "sendAudio";

        public static string SendVenue = "sendVenue";

        public static string SendVoice = "sendVoice";

        public static string SendVideoNote = "sendVideoNote";

        public static string SendDocument = "sendDocument";

        public static string SendContact = "sendContact";

        public static string EditMessageText = "editMessageText";

        public static string EditMessageMedia = "editMessageMedia";

        public static string EditMessageReplyMarkup = "editMessageReplyMarkup";

        public static string EditMessageCaption = "editMessageCaption";

        public static string DeleteMessage = "deleteMessage";

        public static string SendLocation = "sendLocation";

        public static string EditMessageLiveLocation = "editMessageLiveLocation";

        public static string StopMessageLiveLocation = "stopMessageLiveLocation";

        public static string SetChatStickerSet = "setChatStickerSet";

        public static string SendSticker = "sendSticker";

        public static string SendMediaGroup = "sendMediaGroup";

        public static string UploadStickerFile = "uploadStickerFile";

        public static string CreateNewStickerSet = "createNewStickerSet";

        public static string AddStickerToSet = "addStickerToSet";

        public static string SetStickerPositionInSet = "setStickerPositionInSet";

        public static string DeleteStickerFromSet = "deleteStickerFromSet";

        public static string SendGame = "sendGame";

        public static string SetGameScore = "setGameScore";

        public static string GetGameHighScores = "getGameHighScores";

        public static string SetWebhook = "setWebhook";

        public static string DeleteWebhook = "deleteWebhook";

        public static string GetWebhookInfo = "getWebhookInfo";

        public static string SendPoll = "sendPoll";

        public static string StopPoll = "stopPoll";

        public static string SetMyCommands = "setMyCommands";

        public static string GetMyCommands = "getMyCommands";

        public static string DeleteMyCommands = "deleteMyCommands";

        public static string SendDice = "sendDice";

        public static string CopyMessage = "copyMessage";

        public static string UnpinAllChatMessages = "unpinAllChatMessages";
        #endregion
    }

}
