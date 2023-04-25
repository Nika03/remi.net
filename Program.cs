using Discord;
using Discord.WebSocket;
using dotenv.net;

public class Program
{
	public static Task Main(string[] args) => new Program().MainAsync();

    private DiscordSocketClient _client = null!;
    //appended " = null!" to the end so the warning shuts the fuck up

	public async Task MainAsync()
	{
        DotEnv.Load();                                      //load environment variables set in ".env" file
        var envVars = DotEnv.Read();                        //read env vars and load them into envVars var

        _client = new DiscordSocketClient();
        _client.Log += Log;

        var token = envVars["TOKEN"];                       //simplification - sets "token" var value to "envVars" value thats associated with "TOKEN"

        await _client.LoginAsync(TokenType.Bot, token);     //starts the login
        await _client.StartAsync();

        // Block this task until the program is closed.
        await Task.Delay(-1);
	}

    private Task Log(LogMessage msg)
    {
	    Console.WriteLine(msg.ToString());
	    return Task.CompletedTask;
    }
}

