using System;
using System.Collections.Generic;
using System.Net;
using System.Runtime.Serialization;

namespace Lincoln.Models
{
  [DataContract]
  public class Game
  {
    [DataMember(Name = "ID")]
    public int Id { get; set; }
    [DataMember(Name = "Name")]
    public string Name { get; set; }
    [DataMember(Name = "Slug")]
    public string Slug { get; set; }
    [DataMember(Name = "DateModified")]
    public DateTimeOffset DateModified { get; set; }
    [DataMember(Name = "Order")]
    public int Order { get; set; }
    [DataMember(Name = "SupportsAddons")]
    public bool SupportsAddons { get; set; }
    [DataMember(Name = "TwitchGameId")]
    public int TwitchGameId { get; set; }
    [DataMember(Name = "CategorySections")]
    public IEnumerable<CategorySection> CategorySections { get; set; }

    public string Icon
    {
      get
      {
        return $"https://clientupdate-v6.cursecdn.com/GameAssets/{this.Id}/Icon64.png";
      }
    }

    public string Boxart
    {
      get
      {
        return $"https://twitch-gds-boxart-aws.s3-us-west-2.amazonaws.com/{WebUtility.UrlEncode(this.Name)}.jpg";
      }
    }

    [DataContract]
    public class CategorySection
    {
      [DataMember(Name = "ID")]
      public int Id { get; set; }
      [DataMember(Name = "Name")]
      public string Name { get; set; }
    }
  }
}