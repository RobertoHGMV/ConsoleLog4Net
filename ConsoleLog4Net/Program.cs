using log4net;
using System;

namespace ConsoleLog4Net
{
    internal class Program
    {
        static void Main(string[] args)
        {
            log4net.Config.XmlConfigurator.Configure();

            var logTest = new LogTest();
            logTest.MyMethod();
            logTest.TestConsole();

            System.Console.WriteLine("Pressione uma tecla para fechar.");
            System.Console.ReadKey();
        }

        public class LogTest
        {
            ILog _logger;

            public LogTest()
            {
                _logger = LogManager.GetLogger(typeof(LogTest));
            }

            public void MyMethod()
            {
                _logger.Info($"MyMethod - 1 - Log: {DateTime.Now:HH:mm:ss:fff}");
            }

            public void TestConsole()
            {
                System.Console.WindowWidth = System.Console.LargestWindowWidth - 10;
                System.Console.WindowHeight = System.Console.LargestWindowHeight - 10;

                try
                {
                    if (_logger.IsDebugEnabled)
                        _logger.Debug("Debug ativo");

                    _logger.Info("Teste info!");
                    _logger.Debug("Teste debug!");
                    _logger.Warn("Teste warn!");
                    _logger.Error("Teste erro!");

                    throw new Exception("Erro gerado para teste!");
                }
                catch (Exception ex)
                {
                    if (_logger.IsFatalEnabled)
                        _logger.Fatal(ex);
                }
            }
        }
    }
}
