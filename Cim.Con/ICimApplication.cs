using System.Threading.Tasks;

namespace Cim.Con
{
    public interface ICimApplication
    {
        Task run(string[] args);
    }
}