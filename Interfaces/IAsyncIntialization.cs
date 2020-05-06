using System.Threading.Tasks;

namespace SaucyBot.Interfaces
{
    interface IAsyncIntialization
    {
        public Task<bool> Initialization
        {
            get;
        }
    }
}
