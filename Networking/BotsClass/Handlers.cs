using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Telegram.Bot.Exceptions;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.InlineQueryResults;
using Telegram.Bot.Types.InputFiles;
using Telegram.Bot.Types.ReplyMarkups;
using Telegram.Bot.Types;
using Telegram.Bot;

using MyLibrary.BotDictionary;
using Newtonsoft.Json;
using File = System.IO.File;

namespace Networking.BotsClass
{
    public class Handlers
    {
        public static Task HandleErrorAsync(ITelegramBotClient botClient, Exception exception, CancellationToken cancellationToken)
        {
            var ErrorMessage = exception switch
            {
                ApiRequestException apiRequestException => $"Telegram API Error:\n[{apiRequestException.ErrorCode}]\n{apiRequestException.Message}",
                _ => exception.ToString()
            };

            Console.WriteLine(ErrorMessage);
            return Task.CompletedTask;
        }

        public static async Task HandleUpdateAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
        {
            var handler = update.Type switch
            {
                // UpdateType.Unknown:
                // UpdateType.ChannelPost:
                // UpdateType.EditedChannelPost:
                // UpdateType.ShippingQuery:
                // UpdateType.PreCheckoutQuery:
                // UpdateType.Poll:
                UpdateType.Message => BotOnMessageReceived(botClient, update!),
                UpdateType.EditedMessage => BotOnMessageReceived(botClient, update!),
                UpdateType.CallbackQuery => BotOnCallbackQueryReceived(botClient, update.CallbackQuery!),
                UpdateType.InlineQuery => BotOnInlineQueryReceived(botClient, update.InlineQuery!),
                UpdateType.ChosenInlineResult => BotOnChosenInlineResultReceived(botClient, update.ChosenInlineResult!),
                _ => UnknownUpdateHandlerAsync(botClient, update)
            };

            try
            {
                await handler;
            }
            catch (Exception exception)
            {
                await HandleErrorAsync(botClient, exception, cancellationToken);
            }
        }

        private static async Task BotOnMessageReceived(ITelegramBotClient botClient, Update update)
        {
            Program.updates.Add(update);

            Message message = update.Message!;

            Console.WriteLine($"Chat.Id: {message.Chat.Id} Receive message type: {message.Type}, from: {message.From.FirstName} " +
                $"{message.From.LastName}, text: {message.Text}\nMessageId {message.MessageId} ");

            if (Forex.IsForex) await Forex.GetForexRequest(botClient, message);

            if (message.Type == MessageType.Document)
            {
                //var document = message.Document;
                //Console.WriteLine($"{document.FileName} - {document.FileId} - {document.FileUniqueId}");

                await GetDocument(botClient, message);
            }

            if (message.Type == MessageType.Document) await GetDocument(botClient, message);

            if (message.Type != MessageType.Text) return;

            var action = message.Text!.Split(' ')[0] switch
            {
                "/inline" => SendInlineKeyboard(botClient, message),
                "/keyboard" => SendReplyKeyboard(botClient, message),
                "/remove" => RemoveKeyboard(botClient, message),
                //"/photo" => SendPhotoFile(botClient, message, PathToDirectory.PhotoDir + "tux.png"),
                "/photo" => SendPhotoFile(botClient, message, PathToDirectory.PhotoDir + "sticker-dali.webp"),
                "/request" => RequestContactAndLocation(botClient, message),
                "/help" => Help(botClient, message),
                "/start" => Start(botClient, message),
                "/forex" => Forex.ForexCommand(botClient, message),
                _ => TextOutput(botClient, message)
            };

            Message sentMessage = await action;
            //Console.WriteLine($"The message was sent with id: {sentMessage.MessageId}");

            // Отправляем встроенную клавиатуру
            // Можем обрабатывать ответы в обработчике BotOnCallbackQueryReceived
            static async Task<Message> SendInlineKeyboard(ITelegramBotClient botClient, Message message)
            {
                await botClient.SendChatActionAsync(message.Chat.Id, ChatAction.Typing);

                // Simulate longer running task
                await Task.Delay(500);

                InlineKeyboardMarkup inlineKeyboard = new(
                    new[]
                    {
                    // first row
                    new []
                    {
                        InlineKeyboardButton.WithCallbackData("1.1", "11"),
                        InlineKeyboardButton.WithCallbackData("1.2", "12"),
                    },
                    // second row
                    new []
                    {
                        InlineKeyboardButton.WithCallbackData("2.1", "21"),
                        InlineKeyboardButton.WithCallbackData("2.2", "22"),
                    },
                    });

                return await botClient.SendTextMessageAsync(chatId: message.Chat.Id,
                                                            text: "Choose",
                                                            replyMarkup: inlineKeyboard);
            }

            static async Task<Message> SendReplyKeyboard(ITelegramBotClient botClient, Message message)
            {
                ReplyKeyboardMarkup replyKeyboardMarkup = new(
                    new[]
                    {
                        new KeyboardButton[] { "1.1", "1.2" },
                        new KeyboardButton[] { "2.1", "2.2" },
                    })
                {
                    ResizeKeyboard = true
                };

                return await botClient.SendTextMessageAsync(chatId: message.Chat.Id,
                                                            text: "Choose",
                                                            replyMarkup: replyKeyboardMarkup);
            }

            static async Task<Message> RemoveKeyboard(ITelegramBotClient botClient, Message message)
            {
                return await botClient.SendTextMessageAsync(chatId: message.Chat.Id,
                                                            text: "Removing keyboard",
                                                            replyMarkup: new ReplyKeyboardRemove());
            }

            static async Task<Message> SendPhotoFile(ITelegramBotClient botClient, Message message, string filePath)
            {
                await botClient.SendChatActionAsync(message.Chat.Id, ChatAction.UploadPhoto);

                using FileStream fileStream = new(filePath, FileMode.Open, FileAccess.Read, FileShare.Read);
                var fileName = filePath.Split(Path.DirectorySeparatorChar).Last();

                return await botClient.SendPhotoAsync(chatId: message.Chat.Id,
                                                      photo: new InputOnlineFile(fileStream, fileName),
                                                      caption: fileName);
            }

            static async Task<Message> RequestContactAndLocation(ITelegramBotClient botClient, Message message)
            {
                ReplyKeyboardMarkup RequestReplyKeyboard = new(
                    new[]
                    {
                    KeyboardButton.WithRequestLocation("Location"),
                    KeyboardButton.WithRequestContact("Contact"),
                    });

                return await botClient.SendTextMessageAsync(chatId: message.Chat.Id,
                                                            text: "Who or Where are you?",
                                                            replyMarkup: RequestReplyKeyboard);
            }

            static async Task<Message> Start(ITelegramBotClient botClient, Message message)
            {
                const string usage = "Использование:\n" +
                                     "/start    - Описание комманд\n" +
                                     "/help     - Получение помощи\n" +
                                     "/inline   - Отправить встроенную клавиатуру\n" +
                                     "/keyboard - Отправить пользовательскую клавиатуру\n" +
                                     "/remove   - Удалить пользовательскую клавиатуру\n" +
                                     "/photo    - Отправить фото\n" +
                                     "/request  - Запросить местоположение или контакты\n" +
                                     "/forex    - Запрос финансовой информации\n";

                return await botClient.SendTextMessageAsync(chatId: message.Chat.Id,
                                                            text: usage,
                                                            replyMarkup: new ReplyKeyboardRemove());
            }

            static async Task<Message> TextOutput(ITelegramBotClient botClient, Message message)
            {
                if (!Forex.IsForex && !Forex.IsCurrencyPair)
                {
                    Answers answers = new Answers(message);

                    string text = answers.AnswersText(message);

                    return await botClient.SendTextMessageAsync(chatId: message.Chat.Id,
                                                                text: text,
                                                                replyMarkup: new ReplyKeyboardRemove());
                }
                else
                {
                    return message;
                }
            }

            static async Task<Message> GetDocument(ITelegramBotClient botClient, Message message)
            {
                var file = await botClient.GetFileAsync(message.Document.FileId);

                using (FileStream stream = new System.IO.FileStream(@"..\..\..\Files\Document\" + message.Document.FileName,
                    FileMode.OpenOrCreate))
                {
                    await botClient.GetInfoAndDownloadFileAsync(message.Document.FileId, stream);
                }

                Console.WriteLine($"{file.FileSize} - {file.FileId} - {file.FilePath} - {message.Document.FileName}");

                //await using (BinaryWriter writer = new BinaryWriter(
                //    System.IO.File.Open(@"..\..\..\Files\Photo\" + message.Document.FileName, FileMode.OpenOrCreate)))
                //{
                //    writer.Write(file);
                //}

                //await using(StreamWriter stream = new StreamWriter(@"..\..\..\Files\Photo\" + message.Document.FileName))
                //{
                //    stream. .WriteAsync()
                //}

                return await botClient.SendTextMessageAsync(chatId: message.Chat.Id,
                                                            text: $"Получил документ: {message.Document.FileName}",
                                                            replyMarkup: new ReplyKeyboardRemove());

            }

            static async Task<Message> Help(ITelegramBotClient botClient, Message message)
            {
                string text = "Здесь всё просто. Помогать не буду! :)))";

                return await botClient.SendTextMessageAsync(chatId: message.Chat.Id,
                                                            text: text,
                                                            replyMarkup: new ReplyKeyboardRemove());
            }
        }

        /// <summary>
        /// Метод вывода сообщения в Телеграм
        /// </summary>
        /// <param name="botClient"></param>
        /// <param name="message"></param>
        /// <param name="sentText">Текст ответа Бота</param>
        /// <returns></returns>
        internal static async Task<Message> SentMessage(ITelegramBotClient botClient, Message message, string sentText)
        {
            return await botClient.SendTextMessageAsync(chatId: message.Chat.Id,
                                                        text: sentText,
                                                        replyMarkup: new ReplyKeyboardRemove());
        }

        // Обработка данных обратного вызова встроенной клавиатуры
        private static async Task BotOnCallbackQueryReceived(ITelegramBotClient botClient, CallbackQuery callbackQuery)
        {
            await botClient.AnswerCallbackQueryAsync(
                callbackQueryId: callbackQuery.Id,
                text: $"Received {callbackQuery.Data}");

            await botClient.SendTextMessageAsync(
                chatId: callbackQuery.Message.Chat.Id,
                text: $"Received {callbackQuery.Data}");
        }

        private static async Task BotOnInlineQueryReceived(ITelegramBotClient botClient, InlineQuery inlineQuery)
        {
            Console.WriteLine($"Received inline query from: {inlineQuery.From.Id}");

            InlineQueryResult[] results = {
            // displayed result
            new InlineQueryResultArticle(
                id: "3",
                title: "TgBots",
                inputMessageContent: new InputTextMessageContent(
                    "hello"
                )
            )
        };

            await botClient.AnswerInlineQueryAsync(inlineQueryId: inlineQuery.Id,
                                                   results: results,
                                                   isPersonal: true,
                                                   cacheTime: 0);
        }

        private static Task BotOnChosenInlineResultReceived(ITelegramBotClient botClient, ChosenInlineResult chosenInlineResult)
        {
            Console.WriteLine($"Received inline result: {chosenInlineResult.ResultId}");
            return Task.CompletedTask;
        }

        private static Task UnknownUpdateHandlerAsync(ITelegramBotClient botClient, Update update)
        {
            Console.WriteLine($"Unknown update type: {update.Type}");
            return Task.CompletedTask;
        }
    }
}
