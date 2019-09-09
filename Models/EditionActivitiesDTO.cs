using System;
using System.Collections.Generic;
using System.Linq;
using vopen_api.Data;

namespace vopen_api.Models
{
    public class EditionActivitiesDTO
    {
        public IEnumerable<EditionActivityDayDTO> Days;
    }

    public class EditionActivityDayDTO
    {
        public string Name;
        public IEnumerable<EditionActivityTrackDTO> Tracks;
    }

    public class EditionActivityTrackDTO
    {
        public string Name;
        public IEnumerable<EditionActivityDTO> Activities;
    }

    public class EditionActivityDTO
    {
        public string Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public ICollection<UserDTO> Presenters { get; set; }

        public string Type { get; set; }

        public string Day { get; set; }

        public string Track { get; set; }

        public string Date { get; set; }

        public string Duration { get; set; }

        public string Tags { get; set; }
    }

    public static class EditionActivityUtils
    {
        public static EditionActivitiesDTO ToEditionActivitiesDTO(ICollection<EditionActivity> editionActivies, string language)
        {
            var editionActivitiesDTO = new EditionActivitiesDTO
            {
                Days = new List<EditionActivityDayDTO>()
            };

            if (editionActivies == null)
            {
                return editionActivitiesDTO;
            }

            var activities = editionActivies.Select(editionActivity => EditionActivityUtils.ToEditionActivityDTO(editionActivity, language));

            editionActivitiesDTO.Days = activities
                .GroupBy(c => c.Day).OrderBy(c => c.Key)
                .Select(c => new EditionActivityDayDTO()
                {
                    Name = c.Key,
                    Tracks = c.GroupBy(item => item.Track).OrderBy(item => item.Key)
                        .Select(item => new EditionActivityTrackDTO
                        {
                            Name = item.Key,
                            Activities = item.OrderBy(activity => activity.Date)
                        })
                });

            return editionActivitiesDTO;
        }

        public static EditionActivityDTO ToEditionActivityDTO(EditionActivity editionActivity, string language)
        {
            var details = editionActivity.Details.FirstOrDefault(item => item.Language == language) ?? editionActivity.Details.First();
            return new EditionActivityDTO
            {
                Id = editionActivity.Id,
                Date = editionActivity.Date,
                Day = editionActivity.Day,
                Track = editionActivity.Track,
                Type = editionActivity.Type,
                Tags = editionActivity.Tags,
                Duration = editionActivity.Duration,
                Title = details.Title,
                Description = details.Description,
                Presenters = UserUtils.ToUsersDTO(editionActivity.Presenters, language),
            };
        }
    }
}
