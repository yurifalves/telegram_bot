using System;
using System.Threading;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;
using Telegram.Bot.Polling;

public class Program {
  static async Task Main() {
    await MyBot.Run();
  }
}

class MyBot {
  private const string BotToken = "6906889561:AAHpmGcdXxPZOLbkEOLC67STCICwDxymkTs";
  private static readonly CancellationTokenSource Cts = new CancellationTokenSource();
  private static readonly TelegramBotClient Bot = new TelegramBotClient(BotToken, cancellationToken: MyBot.Cts.Token);

  public static async Task Run() {
    User me = await MyBot.Bot.GetMeAsync();
    
    MyBot.Bot.OnError += MyBot.OnError;
    MyBot.Bot.OnMessage += MyBot.OnMessage;
    MyBot.Bot.OnUpdate += MyBot.OnUpdate;

    Console.WriteLine($"@{me.Username} is running... Press Enter to terminate");
    Console.ReadLine();
    MyBot.Cts.Cancel(); // stop the bot
    MyBot.Cts.Dispose();
  }

  // method to handle errors in polling or in your OnMessage/OnUpdate code
  public static async Task OnError(Exception exception, HandleErrorSource source) {
    Console.WriteLine(exception);
  }

  // method that handle messages received by the bot
  public static async Task OnMessage(Message msg, UpdateType type) {
    if (msg.Text == "/start") await MyBot.Bot.SendTextMessageAsync(msg.Chat, "Welcome! Pick one direction", replyMarkup: new InlineKeyboardMarkup().AddButtons("Left", "Right"));
  }

  // method that handle other types of updates received by the bot
  public static async Task OnUpdate(Update update) {
    if (update is { CallbackQuery: { } query }) { // non-null CallbackQuery
      await MyBot.Bot.AnswerCallbackQueryAsync(query.Id, $"You picked {query.Data}");
      await MyBot.Bot.SendTextMessageAsync(query.Message!.Chat, $"User {query.From} clicked on {query.Data}");
    }
  }
}
