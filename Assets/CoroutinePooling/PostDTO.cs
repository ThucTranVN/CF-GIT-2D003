using Newtonsoft.Json;
using System;

[Serializable]
public class PostDTO
{
    [JsonProperty("userId")]
    public int UserId { get; set; }
    [JsonProperty("id")]
    public int Id { get; set; }
    [JsonProperty("title")]
    public string Title { get; set; }
    [JsonProperty("body")]
    public string Body { get; set; }

    public PostDTO()
    {
        UserId = 0;
        Id = 0;
        Title = string.Empty;
        Body = string.Empty;
    }
}
