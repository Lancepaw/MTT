//-----------------------------------------------------------------------
// <copyright file="JsonSeeker.cs" company="No Company">
//     Company copyright tag.
// </copyright>
//-----------------------------------------------------------------------

namespace TestService
{
    using System;
    using System.Collections.Generic;
    using System.Configuration;
    using System.IO;
    using System.Linq;
    using System.Timers;
    using Newtonsoft.Json.Linq;
    using testWCF;

    /// <summary>
    /// Класс, отвечающий за все действия с файлами.
    /// </summary>
    public class JsonSeeker
    {
        /// <summary>
        /// Инициализация таймера.
        /// </summary>
        private Timer timer;

        /// <summary>
        /// Настройка и запуск таймера.
        /// </summary>
        public void Start()
        {
            this.timer = new Timer(2000);
            this.timer.Elapsed += this.Seeker;
            this.timer.Start();
        }

        /// <summary>
        /// Остановка таймера.
        /// </summary>
        public void Stop()
        {
            this.timer.Stop();
        }

        /// <summary>
        /// Проверка отобранных .txt на соответствие заданной структуре json.
        /// </summary>
        /// <param name="array">Массив адресов .txt файлов.</param>
        /// <returns>Массив адресов .txt файлов с соответствующей требованиям структурой.</returns>
        public string[] JsonDetector(string[] array)
        {
            Logger.InitLogger();
            string[] result = array;
            string[] tokens = new[] { "Number", "Summ", "Discount", "Articles" };
            List<string> falseCheques = new List<string>();

            foreach (var item in array)
            {
                try
                {
                    var subject = File.ReadAllText(item);
                    var jo = JObject.Parse(subject);

                    foreach (var token in tokens)
                    {
                        jo.SelectToken(token,true);
                    }
                }
                catch
                {
                    string destination = ConfigurationManager.AppSettings.Get("Garbadge");
                    string name = item.Substring(item.LastIndexOf(@"\") + 1);
                    File.Move(item, $"{destination}{name}");
                    Logger.Log.Info($"Файл {name} не является чеком и перемещён в папку Garbadge");
                    falseCheques.Add(item);
                }
            }

            result.Except(falseCheques);
            return result;
        }

        /// <summary>
        /// Формирование данных для передачи в WCF.
        /// </summary>
        /// <param name="item">Адрес .txt файла</param>
        /// <returns>Объект класса Cheque WCF службы.</returns>
        public testWCF.Cheque CreateOutput(string item)
        {
            var subject = File.ReadAllText(item);
            var jo = JObject.Parse(subject);
            testWCF.Cheque result = new testWCF.Cheque();
            result.Number = jo.SelectToken("Number").ToString();
            result.Summ = decimal.Parse(jo.SelectToken("Summ").ToString());
            result.Discount = decimal.Parse(jo.SelectToken("Discount").ToString());
            result.Articles = this.TokenToList(jo.SelectToken("Articles")).ToArray();

            return result;
        }

        /// <summary>
        /// Преобразование токена Articles в массив.
        /// </summary>
        /// <param name="t">Объект JToken.</param>
        /// <returns>Массив артиклей.</returns>
        public List<string> TokenToList(JToken t)
        {
            List<string> result = new List<string>();
            var s = t.ToString();
            int j = s.Count(x => x == ',' + 1);
            for (var i = 0; i <= j; i++)
            {
                if (i < j)
                {
                    string elem = s.Substring(0, s.IndexOf(',') - 2);
                    result.Add(elem);
                    s = s.Substring(s.IndexOf(',') + 2);
                }
                else
                {
                    result.Add(s);
                }
            }

            return result;
        }
        
        /// <summary>
        /// Основной метод службы.
        /// </summary>
        /// <param name="source">Source</param>
        /// <param name="e">Timer.Elapsed.</param>
        private void Seeker(object source, ElapsedEventArgs e)
        {
            //// Инициализируем логгер.
            Logger.InitLogger();
            //// Создаём объект службы WCF.
            TestWCFServiceClient client = new TestWCFServiceClient("Basic");
            //// Получаем путь к папке с файлами из конфига.
            var currentPath = ConfigurationManager.AppSettings.Get("Folder");
            //// Отбор всех .txt. 
            string[] probablyCheques = Directory.GetFiles(currentPath, "*.txt");
            //// Отбор всех не .txt.
            string[] absolutelyNotCheques = Directory.GetFiles(currentPath);
            absolutelyNotCheques.Except(probablyCheques);
            //// Проверка отобранных .txt на соответствие заданной структуре json.
            string[] absolutelyCheques = this.JsonDetector(probablyCheques);
            
            //// Обработка корректных файлов и их перенос в соответствующую папку.
            foreach (var item in absolutelyCheques)
            {
                string name = item.Substring(item.LastIndexOf(@"\") + 1);
                Logger.Log.Info($"Файл {name} обрабатывается ");
                testWCF.Cheque output = this.CreateOutput(item);
                string destination = ConfigurationManager.AppSettings.Get("Completed");
                client.InsertCheques(output);
                File.Move(item, $"{destination}{name}");
                Logger.Log.Info($"Файл {name} точно является чеком");
                client.Close();
            }

            //// Обработка некорректных файлов и их перенос в соответствующую папку.
            foreach (var item in absolutelyNotCheques)
            {
                string destination = ConfigurationManager.AppSettings.Get("Garbadge");
                string name = item.Substring(item.LastIndexOf(@"\") + 1);
                File.Move(item, $"{destination}{name}");
                Logger.Log.Info($"Файл {name} не является чеком и перемещён в папку Garbadge");
            }
        }
    }
}