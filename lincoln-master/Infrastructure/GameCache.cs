using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Runtime.Serialization;
using System.Threading.Tasks;
using Lincoln.Models;
using Newtonsoft.Json.Linq;

namespace Lincoln.Infrastructure
{
  public class GameCache
  {
    /* This Class needs help acquiring the data from the URL */
    const string GameURL = "https://clientupdate-v6.cursecdn.com/Feed/games/v10/games.json";
    public bool Initialized { get; set; } = false;
    public List<Game> Games { get; set; }

    public GameCache()
    {
    }

    public async Task Initialize()
    {
      HttpClient client = new HttpClient();
      try
      {
        var res = await client.GetStringAsync(GameURL);
        var db = JObject.Parse(res).ToObject<GameDBResponse>();

        //apologies for this YOLO code...
        var topHalf = db.Games.Where(x => x.Order != 0).OrderByDescending(g => g.Order).ThenBy(gg => gg.Name).ToList();
        var btmHalf = db.Games.Where(x => x.Order == 0).OrderBy(g => g.Name).OrderByDescending(gg => gg.SupportsAddons).ToList();
        Games = topHalf.Concat(btmHalf).ToList();

        Initialized = true;
      }
      catch (Exception ex)
      {
        
      }
      finally
      {
        client.Dispose();
      }

      await Task.CompletedTask;
      return;
    }
  }

  [DataContract]
  public class GameDBResponse
  {
    [DataMember(Name = "timestamp")]
    public long TimeStamp { get; set; }
    [DataMember(Name = "data")]
    public IEnumerable<Game> Games { get; set; }
  }
}