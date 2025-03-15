using Cysharp.Threading.Tasks;
using Newtonsoft.Json;
using UnityEngine;
using UnityEngine.Networking;

namespace Game.Scripts.App
{
    public class BackpackClient : IBackpackClient
    {
        private const string ContentType = "application/json";
        private const string Authorization = "Authorization";
        private const string Bearer = "Bearer";

        private readonly string _uri;
        private readonly string _token;

        public BackpackClient(string uri, string token)
        {
            _uri = uri;
            _token = $"{Bearer} {token}";
        }

        public async UniTask<bool> SendItemStatus(int id, string action)
        {
            string json = JsonConvert.SerializeObject(new ItemData { Id = id, Action = action });

            UnityWebRequest request = UnityWebRequest.Post(_uri, json, ContentType);
            request.SetRequestHeader(Authorization, _token);

            try
            {
                await request.SendWebRequest();
            }
            catch
            {
                return false;
            }

            Debug.Log(request.downloadHandler.text);

            return request.result == UnityWebRequest.Result.Success;
        }
    }
}