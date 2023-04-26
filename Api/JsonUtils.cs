
using Newtonsoft.Json;
using RestAPI.DTO;

namespace RestAPI
{
    public static class JsonUtils
    {
        public static UsersDTO GetUserFromJson(string filePath)
        {
            string json = File.ReadAllText(filePath);
            return JsonConvert.DeserializeObject<UsersDTO>(json);
        }
        
    }
}
