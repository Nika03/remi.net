using Discord;
using Discord.Interactions;

    public abstract class InteractionModuleBase : InteractionModuleBase<IInteractionContext>, IInteractionModuleBase
    {
        [SlashCommand("echo", "Echo an input")]
        async Task Echo(string input)
        {
            await RespondAsync(input);
        }
    }