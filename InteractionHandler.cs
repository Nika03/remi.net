using Discord;
using Discord.Interactions;
using Discord.WebSocket;
using System.Reflection;

public class InteractionHandler
{
    private readonly DiscordSocketClient _client = null!;
    private readonly InteractionService _commands = null!;
    private readonly IServiceProvider _services = null!;

    public InteractionHandler(DiscordSocketClient client, InteractionService commands, IServiceProvider services)
    {
        _client = client;
        _commands = commands;
        _services = services;
    }

    public async Task InitializeAsync()
    {
        await _commands.AddModulesAsync(Assembly.GetEntryAssembly(), _services);

        _client.IntegrationCreated += HandleInteraction;

    }

    private async Task HandleInteraction(SocketInteraction arg)
    {
        try
        {
            var ctx = new SocketInteractionContext(_client, arg);
            await _commands.ExecuteCommandAsync(ctx, _services);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.ToString());
        }
    }
}