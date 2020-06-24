namespace Cim.Lib.CommandHandler
{
    public interface ICommandHandler<TCommand>    // TODO: maybe add a baseclass for the command to add generic constraint "where TCommand : BaseCommand"
    {
        int RunCommand(TCommand opts);
    }
}
