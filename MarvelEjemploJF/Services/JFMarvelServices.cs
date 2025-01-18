using RestSharp;
using System.Security.Cryptography;
using System.Text;
using Newtonsoft.Json;
using MarvelEjemploJF.Models;

namespace MarvelEjemploJF.Services;

public class JFMarvelServices
{
    private const string BaseUrl = "https://gateway.marvel.com/v1/public";
    private readonly string _publicKey = "7fdb49313f0931fdd615bc7d8a09b675";
    private readonly string _privateKey = "8f3e9e7e9afc016ede6f52a1fa0abf6cd6826781";

    public async Task<List<JFMarvelCharacterc>> GetCharactersAsync()
    {
        var timeStamp = DateTime.UtcNow.Ticks.ToString();
        var hash = CreateHash(timeStamp, _privateKey, _publicKey);

        var client = new RestClient(BaseUrl);
        var request = new RestRequest("characters", Method.Get);
        request.AddQueryParameter("ts", timeStamp);
        request.AddQueryParameter("apikey", _publicKey);
        request.AddQueryParameter("hash", hash);

        var response = await client.ExecuteAsync(request);
        if (response.IsSuccessful)
        {
            var data = JsonConvert.DeserializeObject<MarvelApiResponse>(response.Content);
            return data.Data.Results;
        }

        return new List<JFMarvelCharacterc>();
    }

    private string CreateHash(string timeStamp, string privateKey, string publicKey)
    {
        var input = $"{timeStamp}{privateKey}{publicKey}";
        using var md5 = MD5.Create();
        var hashBytes = md5.ComputeHash(Encoding.UTF8.GetBytes(input));
        return BitConverter.ToString(hashBytes).Replace("-", "").ToLowerInvariant();
    }
}

