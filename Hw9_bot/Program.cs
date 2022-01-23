using Microsoft.Win32.SafeHandles;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using Telegram.Bot;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.InputFiles;
using Telegram.Bot.Types.ReplyMarkups;

namespace Hw9_bot
{
    class Program
    {
        private static TelegramBotClient bot;
        private static string token = File.ReadAllText("token.txt");
        private static string fPath = "files";
        private static List<string> filesName;

        private static ReplyKeyboardMarkup rkm = new ReplyKeyboardMarkup();
        private static List<KeyboardButton[]> rows = new List<KeyboardButton[]>();
        private static List<KeyboardButton> cols = new List<KeyboardButton>();

        static void Main(string[] args)
        {
            CreateDir();

            bot = new TelegramBotClient(token);
            bot.OnMessage += MessageListener;
            bot.StartReceiving();

            Console.ReadLine();
        }

        private static void MessageListener(object sender, Telegram.Bot.Args.MessageEventArgs e)
        {
            Console.WriteLine($"{DateTime.Now.ToLongTimeString()}: user: {e.Message.Chat.FirstName}, " +
                              $"chat: {e.Message.Chat.Id}, message: {e.Message.Text}, type {e.Message.Type.ToString()}");
            GetFileName();
            string messageText = "";
            switch (e.Message.Type)
            {
                case MessageType.Document:

                    Console.WriteLine(e.Message.Document.FileId);
                    Console.WriteLine(e.Message.Document.FileName);
                    Console.WriteLine(e.Message.Document.FileSize);

                    Download(e.Message.Document.FileId, e.Message.Document.FileName);

                    break;
                case MessageType.Photo:
                    foreach (var pic in e.Message.Photo)
                    {
                        Console.WriteLine($"File id: {pic.FileId}");
                        Console.WriteLine($"File size: {pic.FileSize}");
                        Console.WriteLine($"Width: {pic.Width}");
                        Console.WriteLine($"Height: {pic.Height}\n");
                    }

                    Download(e.Message.Photo[2].FileId, $"{e.Message.Photo[2].FileId}.jpg");
                    break;

            }

            if (e.Message.Text == null) return;

            if (e.Message.Text == "/start")
            {
                messageText = $"{e.Message.Chat.FirstName} это твоя удаленная папка в ноутбуке" +
                    "\nвсе твои данные будут сохранены" +
                    "\nДля просмотра доступных файлов введи /load";
            }
            else if (e.Message.Text == "/load")
            {
                messageText = GetDir();
            }
            else if (File.Exists(fPath + e.Message.Text))
            {
                Upload(e.Message.Text, e.Message.Chat.Id);

            }

            bot.SendTextMessageAsync(e.Message.Chat.Id,
            $"{messageText}"
            );
        }

       private static async void Upload(string file, long userID)
        {
            using (FileStream stream = File.Open(fPath + file, FileMode.Open))
            {
                InputOnlineFile iof = new InputOnlineFile(stream);
                iof.FileName = file;
                var send = await bot.SendDocumentAsync(userID, iof, "Вот то что вы просили!");
            }
        }

        private static async void Download(string fileId, string filePath)
        {
            var file = await bot.GetFileAsync(fileId);
            using (FileStream fs = new FileStream($"{fPath}/{filePath}", FileMode.Create))
            {
                await bot.DownloadFileAsync(file.FilePath, fs);
            }
        }

        private static void GetFileName()
        {
            if (Directory.Exists(fPath))
            {
                filesName = Directory.GetFiles(fPath).ToList();

                for (int i = 0; i < filesName.Count; i++)
                {
                    filesName[i] = filesName[i].Remove(0, 6);
                    if (filesName.Where(x => x == filesName[i]).Count() > 1)
                    {
                        filesName.Remove(filesName[i]);
                    }
                }
            }
        }

       private static string GetDir()
        {
            DirectoryInfo directoryInfo = new DirectoryInfo(fPath);
            StringBuilder text = new StringBuilder();

            foreach (var item in directoryInfo.GetFiles())
            {
                text.Append($"\n{item.Name}  размер файла {item.Length}.");
            }

            return text.ToString();
        }

        private static void CreateDir()
        {
            DirectoryInfo dirInfo = new DirectoryInfo(fPath);
            if (!dirInfo.Exists)
            {
                dirInfo.Create();
            }
        }
    }
}