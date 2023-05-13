using Discord;
using Discord.WebSocket;
using Discord.Interactions;
using Discord.Commands;
using dotenv.net;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

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

        var _interactionService = new InteractionService(_client.Rest);

        //Gifs.Almic();

        using IHost host = Host.CreateDefaultBuilder()
            .ConfigureServices((_, services) => 
            services
            
            .AddSingleton(x => new DiscordSocketClient(new DiscordSocketConfig
            {
                GatewayIntents = Discord.GatewayIntents.AllUnprivileged,
                AlwaysDownloadUsers = true,
            }))
            .AddSingleton(x => new InteractionService(x.GetRequiredService<DiscordSocketClient>()))
            .AddSingleton<InteractionHandler>()
            .AddSingleton(x => new CommandService())
            )
            .Build();
        
        
        await RunAsync(host);
	}

    public async Task RunAsync(IHost host)
    {
        using IServiceScope serviceScope = host.Services.CreateScope();
        IServiceProvider provider = serviceScope.ServiceProvider;

        var _client = provider.GetRequiredService<DiscordSocketClient>();
        var sCommands = provider.GetRequiredService<InteractionService>();
        await provider.GetRequiredService<InteractionHandler>().InitializeAsync();

        // Logs subscriptions
        _client.Log += async (LogMessage msg) => { Console.WriteLine(msg.Message); };
        sCommands.Log += async (LogMessage msg) => { Console.WriteLine(msg.Message); };

        _client.Ready += async () => 
        { 
            Console.WriteLine("Hot and Ready, boys!"); 
            await sCommands.RegisterCommandsGloballyAsync();
        };

        

        // Block this task until the program is closed.
        await Task.Delay(-1);
    }

    private Task Log(LogMessage msg)
    {
	    Console.WriteLine(msg.ToString());
	    return Task.CompletedTask;
    }
}

