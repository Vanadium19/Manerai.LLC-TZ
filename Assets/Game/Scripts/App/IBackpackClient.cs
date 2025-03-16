using Cysharp.Threading.Tasks;

namespace Game.Scripts.App
{
    public interface IBackpackClient
    {
        public UniTask<bool> SendItemStatus(int id, string action);
    }
}