using System.Threading.Tasks;

namespace SaucyBot.Shared
{
    interface IAsyncIntialization
    {
        public Task<bool> Initialization
        {
            get;
        }
    }
}
