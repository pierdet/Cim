namespace Cim.Lib.UI
{
    public interface IGui
    {
        void Write(string msg);
        void WriteError(string msg);
        void WriteLine(string msg);
        void WriteSuccess(string msg);
    }
}