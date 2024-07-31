using System;
using System.Threading.Tasks;
using Telegram.Bot;

public class Program {
  static async Task Main() {
    await MyBot.Teste();
  }
}

class MyBot {
  public static async Task Teste() {
    const string botToken = "6906889561:AAHpmGcdXxPZOLbkEOLC67STCICwDxymkTs";
    TelegramBotClient bot = new TelegramBotClient(botToken);
    Telegram.Bot.Types.User me = await bot.GetMeAsync();
    Console.WriteLine($"Hello, World! I am user {me.Id} and my name is {me.FirstName}.");
  }
}
