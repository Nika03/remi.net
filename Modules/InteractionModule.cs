using Discord;
using Discord.Interactions;

public class InteractionModule : InteractionModuleBase<SocketInteractionContext>
{
    [SlashCommand("ping", "Check for a response from Remi")]
        public async Task HandlePingCommand()
        {
            await RespondAsync("Pong!");
        }
}