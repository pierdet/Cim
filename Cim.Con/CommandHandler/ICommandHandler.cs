using System.Threading.Tasks;

namespace Cim.Con.CommandHandler
{
    public interface ICommandHandler<TCommand>    // TODO: maybe add a baseclass for the command to add generic constraint "where TCommand : BaseCommand"
    {
        Task<int> RunCommand(TCommand opts);
    }
}
