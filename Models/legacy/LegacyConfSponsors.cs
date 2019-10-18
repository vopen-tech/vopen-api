using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using vopen_api.Data;

namespace vopen_api.Models.legacy
{
  public class LegacyConfSponsorsDTO
  {
    public readonly string ImageBaseURL = "";
    public readonly string Info = "All images are .png";
    public ICollection<LegacyConfSponsorDTO> ConfSponsors { get; set; }
  }

  public class LegacyConfSponsorDTO
  {
    [JsonProperty("SponsorId")]
    public int SponsorId { get; set; }

    [JsonProperty("SponsorCategoryId")]
    public int SponsorCategoryId { get; set; }

    [JsonProperty("HasBooth")]
    public bool HasBooth { get; set; }

    [JsonProperty("Sponsor")]
    public LegacySponsorDTO Sponsor { get; set; }

    [JsonProperty("SponsorCategory")]
    public SponsorCategory SponsorCategory { get; set; }
  }

  public class LegacySponsorDTO
  {
    [JsonProperty("SponsorId")]
    public int SponsorId { get; set; }

    [JsonProperty("Name")]
    public string Name { get; set; }

    [JsonProperty("LogoFileName")]
    public string LogoFileName { get; set; }

    [JsonProperty("WebSite")]
    public string Website { get; set; }

    public LegacySponsorDTO(EditionSponsorDTO sponsor)
    {
      this.SponsorId = Int32.Parse(sponsor.Id);
      this.Name = sponsor.Name;
      this.LogoFileName = sponsor.ImageUrl;
      this.Website = sponsor.Url;
    }
  }

  public class SponsorCategory
  {
    [JsonProperty("SponsorCategoryId")]
    public int SponsorCategoryId { get; set; }

    [JsonProperty("Name")]
    public string Name { get; set; }

    [JsonProperty("HasBooth")]
    public bool HasBooth { get; set; }
  }

  public static class LegacyConfSponsorsUtils
  {
    public static LegacyConfSponsorsDTO ToLegacyConfSponsorsDTO(ICollection<EditionSponsorDTO> sponsors)
    {
      var legacyConfSponsorsDTO = new LegacyConfSponsorsDTO
      {
        ConfSponsors = sponsors.Select(
              sponsor => new LegacyConfSponsorDTO
              {
                SponsorId = Int32.Parse(sponsor.Id),
                Sponsor = new LegacySponsorDTO(sponsor),
                SponsorCategory = LegacyConfSponsorsUtils.GetSponsorCategory(sponsor),
                SponsorCategoryId = LegacyConfSponsorsUtils.GetSponsorCategory(sponsor).SponsorCategoryId,
                HasBooth = LegacyConfSponsorsUtils.GetSponsorCategory(sponsor).HasBooth,
              }
          ).ToList()
      };

      return legacyConfSponsorsDTO;
    }

    public static SponsorCategory GetSponsorCategory(EditionSponsorDTO sponsor)
    {
      var categoryId = sponsor.Type == Constants.SPONSOR_DIAMOND ? 6
          : sponsor.Type == Constants.SPONSOR_GOLD ? 4
              : sponsor.Type == Constants.SPONSOR_SILVER ? 2
                  : 1;

      var hasBooth = (
          sponsor.Type != Constants.SPONSOR_DIGITAL
          && sponsor.Name.ToLowerInvariant() != "nareia"
          && sponsor.Name.ToLowerInvariant() != "el observador"
      );

      return new SponsorCategory
      {
        SponsorCategoryId = categoryId,
        Name = sponsor.Type,
        HasBooth = hasBooth
      };
    }
  }
}
