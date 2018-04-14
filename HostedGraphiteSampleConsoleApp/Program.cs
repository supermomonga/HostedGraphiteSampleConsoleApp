using System;
using System.IO;
using System.Threading.Tasks;

namespace HostedGraphiteSampleConsoleApp
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Setting setting;
            using (StreamReader r = new StreamReader("Config.json"))
            {
                string json = r.ReadToEnd();
                setting = Setting.FromJson(json);
            }
            var client = new Client(setting);
            while (true)
            {
                try
                {
                    var t = client.SendSpreadToGraphiteAsync();

                    // 最低限ApiAccessInterval設定値の秒数待ちつつ、APIアクセスなども待つ
                    await Task.Delay(setting.ApiAccessInterval);
                    await t;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    Console.WriteLine(e.StackTrace);
                }
            }
        }

    }
}
