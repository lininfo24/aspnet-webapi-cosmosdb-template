using Newtonsoft.Json;
namespace Catalog.API.Models;

public class ProductPage
{
  [JsonProperty("id")]
  public string Id { get; set; }
  public string Title { get; set; }
  public string Description { get; set; }
  public string ImageUrl { get; set; }
  public string AdditionalInfo { get; set; }
  public DateTime PublishedDate { get; set; }
  public bool IsPublished { get; set; }
}