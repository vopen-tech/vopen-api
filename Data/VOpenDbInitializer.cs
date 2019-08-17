using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using vopen_api.Models;

namespace vopen_api.Data
{
    public static class VOpenDbInitializer
    {
        public static void Seed(DbContextOptions<VOpenDbContext> options)
        {
            using (var context = new VOpenDbContext(options))
            {
                context.Database.EnsureCreated();

                // Create vOpen event
                var vopenEvent = new Event()
                {
                    Id = "vopen",
                    Details = new EventDetail[]
                    {
                         new EventDetail { Language = Constants.LANGUAGES_SPANISH, Name = "vOpen", Description = "El ciclo de eventos de tecnología más importante en Latinoamérica" },
                         new EventDetail { Language = Constants.LANGUAGES_ENGLISH, Name = "vOpen", Description = "The most important technology-related cycle of events in Latin America" }
                    },
                };

                context.Events.Add(vopenEvent);

                // Create users
                var user1 = new User
                {
                    Country = Constants.COUNTRIES_ARGENTINA,
                    ImageUrl = "http://ar.netconf.global/Content/images/demo/organizers/marianovazquez.jpg",
                    Details = new UserDetail[]
                    {
                        new UserDetail { Name = "Mariano Vazquez", Description = "", Language = Constants.LANGUAGES_SPANISH }
                    },
                    SocialLinks = new UserSocialLink[]
                    {
                        new UserSocialLink { Type = Constants.SOCIAL_LINKEDIN, Url = "https://www.linkedin.com/in/nanovazquez/" },
                        new UserSocialLink { Type = Constants.SOCIAL_TWITTER, Url = "https://twitter.com/nanovazquez87" },
                    }
                };
                var user2 = new User
                {
                    Country = Constants.COUNTRIES_ARGENTINA,
                    ImageUrl = "http://ar.netconf.global/Content/images/demo/organizers/guillermobellmann.jpg",
                    Details = new UserDetail[]
                    {
                        new UserDetail { Name = "Guillermo Bellmann", Description = "", Language = Constants.LANGUAGES_SPANISH }
                    },
                    SocialLinks = new UserSocialLink[]
                    {
                        new UserSocialLink { Type = Constants.SOCIAL_LINKEDIN, Url = "https://ar.linkedin.com/in/gbellmann" },
                        new UserSocialLink { Type = Constants.SOCIAL_TWITTER, Url = "https://twitter.com/gjbellmann" },
                    }
                };
                var user3 = new User
                {
                    Country = Constants.COUNTRIES_ARGENTINA,
                    ImageUrl = "http://ar.netconf.global/Content/images/demo/organizers/pablodiloreto.jpg",
                    Details = new UserDetail[]
                    {
                        new UserDetail { Name = "Pablo Di Loreto", Description = "", Language = Constants.LANGUAGES_SPANISH }
                    },
                    SocialLinks = new UserSocialLink[]
                    {
                        new UserSocialLink { Type = Constants.SOCIAL_LINKEDIN, Url = "https://ar.linkedin.com/in/pablodiloreto" },
                        new UserSocialLink { Type = Constants.SOCIAL_TWITTER, Url = "https://twitter.com/pablodiloreto" },
                    }
                };
                var user4 = new User
                {
                    Country = Constants.COUNTRIES_URUGUAY,
                    ImageUrl = "http://uy.netconf.global/Content/images/demo/organizers/FabianImaz.jpg",
                    Details = new UserDetail[]
                    {
                        new UserDetail { Name = "Fabian Imaz", Description = "", Language = Constants.LANGUAGES_SPANISH }
                    },
                    SocialLinks = new UserSocialLink[]
                    {
                        new UserSocialLink { Type = Constants.SOCIAL_LINKEDIN, Url = "http://uy.linkedin.com/in/siderys" },
                        new UserSocialLink { Type = Constants.SOCIAL_TWITTER, Url = "https://twitter.com/fabianimaz" },
                    }
                };
                var user5 = new User
                {
                    Country = Constants.COUNTRIES_URUGUAY,
                    ImageUrl = "https://i.imgur.com/vXLIy95.jpg",
                    Details = new UserDetail[]
                    {
                        new UserDetail { Name = "Fabian Fernandez", Description = "", Language = Constants.LANGUAGES_SPANISH, }
                     },
                    SocialLinks = new UserSocialLink[]
                    {
                        new UserSocialLink { Type = Constants.SOCIAL_LINKEDIN, Url = "http://uy.linkedin.com/in/kzfabi" },
                        new UserSocialLink { Type = Constants.SOCIAL_TWITTER, Url = "https://twitter.com/kzfabi" },
                    }
                };

                ///// UY

                var user6 = new User
                {
                    Country = Constants.COUNTRIES_URUGUAY,
                    ImageUrl = "http://uy.netconf.global/Content/images/demo/organizers/FedericoBernasconi.jpg",
                    Details = new UserDetail[]
                    {
                        new UserDetail { Name = "Federico Bernasconi", Description = "", Language = Constants.LANGUAGES_SPANISH,  }
                    },
                    SocialLinks = new UserSocialLink[]
                    {
                        new UserSocialLink
                        {
                            Type = Constants.SOCIAL_LINKEDIN, Url = "https://www.linkedin.com/in/federico-bernasconi-48087b56/"
                        },
                    }
                };
                var user7 = new User
                {
                    Country = Constants.COUNTRIES_URUGUAY,
                    ImageUrl = "http://uy.netconf.global/Content/images/demo/organizers/BrianHardy.jpg",
                    Details = new UserDetail[]
                    {
                        new UserDetail { Name = "Brian Hardy", Description = "", Language = Constants.LANGUAGES_SPANISH,  }
                    },
                    SocialLinks = new UserSocialLink[]
                    {
                        new UserSocialLink { Type = Constants.SOCIAL_LINKEDIN, Url = "https://www.linkedin.com/in/brian-hardy-382a9484" },
                        new UserSocialLink { Type = Constants.SOCIAL_TWITTER, Url = "https://twitter.com/hardyr93" },
                    }
                };
                var user8 = new User
                {
                    Country = Constants.COUNTRIES_URUGUAY,
                    ImageUrl = "https://imgur.com/008xHsD.jpg",
                    Details = new UserDetail[]
                    {
                        new UserDetail { Name = "Pablo Marcano", Description = "", Language = Constants.LANGUAGES_SPANISH, }
                    },
                    SocialLinks = new UserSocialLink[]
                    {
                        new UserSocialLink { Type = Constants.SOCIAL_LINKEDIN, Url = "https://www.linkedin.com/in/pablo-m-1b2366124/" },
                    }
                };
                var user9 = new User
                {
                    Country = Constants.COUNTRIES_URUGUAY,
                    ImageUrl = "https://imgur.com/TpW7cPF.jpg",
                    Details = new UserDetail[]
                    {
                        new UserDetail { Name = "Victor Silva", Description = "", Language = Constants.LANGUAGES_SPANISH }
                    },
                    SocialLinks = new UserSocialLink[]
                    {
                        new UserSocialLink { Type = Constants.SOCIAL_LINKEDIN, Url = "https://www.linkedin.com/in/vmsilvamolina/" },
                    }
                };
                var user10 = new User
                {
                    Country = Constants.COUNTRIES_URUGUAY,
                    ImageUrl = "https://i.imgur.com/9jleLkK.jpg",
                    Details = new UserDetail[]
                    {
                        new UserDetail { Name = "Diego Bellora",  Description = "", Language = Constants.LANGUAGES_SPANISH }
                    },
                    SocialLinks = new UserSocialLink[]
                    {
                        new UserSocialLink { Type = Constants.SOCIAL_LINKEDIN, Url = "https://www.linkedin.com/in/diego-bellora-21175882/"}
                    }
                };
                var user23 = new User
                {
                    Country = Constants.COUNTRIES_URUGUAY,
                    ImageUrl = "https://i.imgur.com/g1l8I4s.jpg",
                    Details = new UserDetail[]
                    {
                        new UserDetail { Name = "Pablo Terevinto",  Description = "", Language = Constants.LANGUAGES_SPANISH }
                    },
                    SocialLinks = new UserSocialLink[]
                    {
                        new UserSocialLink { Type = Constants.SOCIAL_LINKEDIN, Url = "https://www.linkedin.com/in/pterevinto/"}
                    }
                };
                var user24 = new User
                {
                    Country = Constants.COUNTRIES_URUGUAY,
                    ImageUrl = "https://i.imgur.com/SO2Vnqj.jpg",
                    Details = new UserDetail[]
                    {
                        new UserDetail { Name = "Victoria Mato",  Description = "", Language = Constants.LANGUAGES_SPANISH }
                    },
                    SocialLinks = new UserSocialLink[]
                    {
                        new UserSocialLink { Type = Constants.SOCIAL_LINKEDIN, Url = "https://www.linkedin.com/in/Victoria-Mato"}
                    }
                };
                var user25 = new User
                {
                    Country = Constants.COUNTRIES_URUGUAY,
                    ImageUrl = "https://i.imgur.com/3p2UAdT.jpg",
                    Details = new UserDetail[]
                    {
                        new UserDetail { Name = "Martin Mato",  Description = "", Language = Constants.LANGUAGES_SPANISH }
                    },
                    SocialLinks = new UserSocialLink[]
                    {
                        new UserSocialLink { Type = Constants.SOCIAL_LINKEDIN, Url = "https://www.linkedin.com/in/martinmato/" },
                        new UserSocialLink { Type = Constants.SOCIAL_TWITTER, Url = " https://twitter.com/otamnitram" }
                    }
                };

                //// AR
                var user12 = new User
                {
                    Country = Constants.COUNTRIES_ARGENTINA,
                    ImageUrl = "http://ar.netconf.global/Content/images/demo/organizers/NahirIberra.jpg",
                    Details = new UserDetail[]
                    {
                        new UserDetail { Name = "Nahir Iberra", Description = "", Language = Constants.LANGUAGES_SPANISH }
                    },
                    SocialLinks = new UserSocialLink[]
                    {
                        new UserSocialLink { Type = Constants.SOCIAL_LINKEDIN, Url = "https://www.linkedin.com/in/niberra" },
                        new UserSocialLink { Type = Constants.SOCIAL_TWITTER, Url = "https://twitter.com/na_iberra" },
                    }
                };
                var user13 = new User
                {
                    Country = Constants.COUNTRIES_ARGENTINA,
                    ImageUrl = "http://ar.netconf.global/Content/images/demo/organizers/JorgeBramajo.jpg",
                    Details = new UserDetail[]
                    {
                        new UserDetail { Name = "Jorge Bramajo", Description = "", Language = Constants.LANGUAGES_SPANISH }
                    },
                    SocialLinks = new UserSocialLink[]
                    {
                        new UserSocialLink { Type = Constants.SOCIAL_LINKEDIN, Url = "https://www.linkedin.com/in/jobramajo" },
                        new UserSocialLink { Type = Constants.SOCIAL_TWITTER, Url = "https://twitter.com/jorbramajo" },
                    }
                };
                var user14 = new User
                {
                    Country = Constants.COUNTRIES_ARGENTINA,
                    ImageUrl = "http://ar.netconf.global/Content/images/demo/organizers/EstebanYanez.jpg",
                    Details = new UserDetail[]
                    {
                        new UserDetail { Name = "Esteban Yañez",  Description = "", Language = Constants.LANGUAGES_SPANISH  }
                    },
                    SocialLinks = new UserSocialLink[]
                    {
                        new UserSocialLink { Type = Constants.SOCIAL_LINKEDIN, Url = "https://www.linkedin.com/in/eyanez89" },
                        new UserSocialLink { Type = Constants.SOCIAL_TWITTER, Url = "https://twitter.com/Teban3010" },
                    }
                };
                var user15 = new User
                {
                    Country = Constants.COUNTRIES_ARGENTINA,
                    ImageUrl = "http://ar.netconf.global/Content/images/demo/organizers/SebastianPerez.jpg",
                    Details = new UserDetail[]
                    {
                        new UserDetail { Name = "Sebastián Pérez", Description = "", Language = Constants.LANGUAGES_SPANISH,  }
                    },
                    SocialLinks = new UserSocialLink[]
                    {
                        new UserSocialLink { Type = Constants.SOCIAL_LINKEDIN, Url = "https://www.linkedin.com/in/sebasti%C3%A1n-leonardo-p%C3%A9rez-68816599" },
                        new UserSocialLink { Type = Constants.SOCIAL_TWITTER, Url = "https://twitter.com/garudasla" },
                    }
                };

                // CL

                var user16 = new User
                {
                    Country = Constants.COUNTRIES_CHILE,
                    ImageUrl = "http://cl.netconf.global/Content/images/demo/organizers/SergioBorromei.jpg",
                    Details = new UserDetail[]
                    {
                        new UserDetail { Name = "Sergio Borromei", Description = "", Language = Constants.LANGUAGES_SPANISH,  }
                    },
                    SocialLinks = new UserSocialLink[]
                    {
                        new UserSocialLink { Type = Constants.SOCIAL_LINKEDIN, Url = "https://twitter.com/SergioBLagash" },
                        new UserSocialLink { Type = Constants.SOCIAL_TWITTER, Url = "https://www.linkedin.com/in/sergioborromei" },
                    }
                };

                // CO
                var user17 = new User
                {
                    Country = Constants.COUNTRIES_COLOMBIA,
                    ImageUrl = "https://i.imgur.com/Xtwd1U6.png",
                    Details = new UserDetail[]
                    {
                        new UserDetail { Name = "Mayra Badillo", Description = "", Language = Constants.LANGUAGES_SPANISH, }
                    },
                    SocialLinks = new UserSocialLink[]
                    {
                        new UserSocialLink { Type = Constants.SOCIAL_LINKEDIN, Url = "https://www.linkedin.com/in/mabvill" },
                        new UserSocialLink { Type = Constants.SOCIAL_TWITTER, Url = "https://twitter.com/mabvill" },
                    }
                };
                var user18 = new User
                {
                    Country = Constants.COUNTRIES_COLOMBIA,
                    ImageUrl = "https://i.imgur.com/DQevp7d.jpg",
                    Details = new UserDetail[]
                    {
                        new UserDetail { Name = "Andres Rojas", Description = "", Language = Constants.LANGUAGES_SPANISH,  }
                    },
                    SocialLinks = new UserSocialLink[] { }
                };
                var user19 = new User
                {
                    Country = Constants.COUNTRIES_COLOMBIA,
                    ImageUrl = "https://i.imgur.com/U4HO5Py.jpg",
                    Details = new UserDetail[]
                    {
                        new UserDetail { Name = "Rogger Rodriguez",Description = "", Language = Constants.LANGUAGES_SPANISH,  }
                    },
                    SocialLinks = new UserSocialLink[] { }
                };

                // PE

                var user20 = new User
                {
                    Country = Constants.COUNTRIES_PERU,
                    ImageUrl = "https://i.imgur.com/idbCxF9.jpg",
                    Details = new UserDetail[]
                    {
                        new UserDetail { Name = "Miguel Almeyda", Description = "", Language = Constants.LANGUAGES_SPANISH,  }
                    },
                    SocialLinks = new UserSocialLink[]
                    {
                        new UserSocialLink { Type = Constants.SOCIAL_LINKEDIN, Url = "https://www.linkedin.com/in/miguelalmeyda" },
                        new UserSocialLink { Type = Constants.SOCIAL_TWITTER, Url = "https://twitter.com/miguelalmeyda" },
                    }
                };
                var user21 = new User
                {
                    Country = Constants.COUNTRIES_PERU,
                    ImageUrl = "https://i.imgur.com/Hnp1yAr.png",
                    Details = new UserDetail[]
                    {
                        new UserDetail { Name = "Alberto De Rossi", Description = "", Language = Constants.LANGUAGES_SPANISH }
                    },
                    SocialLinks = new UserSocialLink[]
                    {
                        new UserSocialLink { Type = Constants.SOCIAL_LINKEDIN, Url = "https://www.linkedin.com/in/alberto-de-rossi-46814244/" },
                        new UserSocialLink { Type = Constants.SOCIAL_TWITTER, Url = "https://twitter.com/albertoderossi" },
                    }
                };
                var user22 = new User
                {
                    Country = Constants.COUNTRIES_PERU,
                    ImageUrl = "https://i.imgur.com/1NLCUGy.png",
                    Details = new UserDetail[]
                    {
                        new UserDetail { Name = "German Cayo", Description = "", Language = Constants.LANGUAGES_SPANISH }
                    },
                    SocialLinks = new UserSocialLink[] { },
                };

                context.Users.Add(user1);
                context.Users.Add(user2);
                context.Users.Add(user3);
                context.Users.Add(user4);
                context.Users.Add(user5);
                context.Users.Add(user6);
                context.Users.Add(user7);
                context.Users.Add(user8);
                context.Users.Add(user9);
                context.Users.Add(user10);
                context.Users.Add(user12);
                context.Users.Add(user13);
                context.Users.Add(user14);
                context.Users.Add(user15);
                context.Users.Add(user16);
                context.Users.Add(user17);
                context.Users.Add(user18);
                context.Users.Add(user19);
                context.Users.Add(user20);
                context.Users.Add(user21);
                context.Users.Add(user22);
                context.Users.Add(user23);
                context.Users.Add(user24);
                context.Users.Add(user25);

                // TODO: create sponsors

                // Create global edition
                var globalEdition = new Edition
                {
                    Id = "vopen-global-2019",
                    Event = vopenEvent,
                    Details = new EditionDetail[]
                    {
                       new EditionDetail { Language = Constants.LANGUAGES_SPANISH, Name = "vOpen Global 2019" },
                       new EditionDetail { Language = Constants.LANGUAGES_ENGLISH, Name = "vOpen Global 2019" }
                    },
                    Organizers = new List<EditionOrganizer>
                    {
                        new EditionOrganizer { User = user1 },
                        new EditionOrganizer { User = user2 },
                        new EditionOrganizer { User = user3 },
                        new EditionOrganizer { User = user4 },
                        new EditionOrganizer { User = user5 },
                    }
                };

                // Create UY Edition
                var uyBuyLinks = new List<TicketLink>()
                {
                    new TicketLink { Label = "PayPal", Url = "https://www.eventbrite.com/e/vopen-19-uruguay-tickets-64989745077" },
                    new TicketLink { Label = "CobrosYa", Url = "https://ks.uy/5c7FTJ2vnVytBeTm7" }
                };

                var camelCaseFormatter = new JsonSerializerSettings();
                camelCaseFormatter.ContractResolver = new CamelCasePropertyNamesContractResolver();
                var uyBuyLinksJson = JsonConvert.SerializeObject(uyBuyLinks);

                var uyEdition = new Edition
                {
                    Id = "vopen-uy-2019",
                    Event = vopenEvent,
                    Details = new EditionDetail[]
                    {
                       new EditionDetail { Language = Constants.LANGUAGES_SPANISH, Name = "vOpen UY 2019", Date = "21, 22 y 23 de Octubre" },
                       new EditionDetail { Language = Constants.LANGUAGES_ENGLISH, Name = "vOpen UY 2019", Date = "October 21st, 22nd and 23rd" }
                    },
                    LocationName = "Torre de las Telecomunicaciones, Antel",
                    LocationFullAddress = "Telecommunications Tower, 11800 Montevideo, Departamento de Montevideo, Uruguay",
                    EditionTickets = new List<EditionTicket>()
                    {
                        new EditionTicket { Id = "early-birds", Name = "Early birds", Price = "20USD", StartDate = "2019-08-19T16:00:00.000Z", EndDate = "2019-09-19T00:00:00.000Z", BuyLinks = uyBuyLinksJson },
                        new EditionTicket { Id = "night-owl", Name = "Night owl", Price = "40USD", StartDate = "2019-09-19T00:00:00.000Z", EndDate = "2019-10-01T00:00:00.000Z", BuyLinks = uyBuyLinksJson },
                        new EditionTicket { Id = "regular", Name = "Regular ticket", Price = "60USD", StartDate = "2019-10-01T00:00:00.000Z", EndDate = "2019-10-24T00:00:00.000Z", BuyLinks = uyBuyLinksJson },
                    },
                    Organizers = new List<EditionOrganizer>
                    {
                        new EditionOrganizer { User = user6 },
                        new EditionOrganizer { User = user7 },
                        new EditionOrganizer { User = user8 },
                        new EditionOrganizer { User = user9 },
                        new EditionOrganizer { User = user10 },
                        new EditionOrganizer { User = user11 },
                        new EditionOrganizer { User = user23 },
                        new EditionOrganizer { User = user24 },
                        new EditionOrganizer { User = user25 },
                    }
                };

                // Create AR Edition
                var arEdition = new Edition
                {
                    Id = "vopen-ar-2019",
                    Event = vopenEvent,
                    Details = new EditionDetail[]
                    {
                       new EditionDetail { Language = Constants.LANGUAGES_SPANISH, Name = "vOpen AR 2019", Date = "3, 4 y 5 de Octubre" },
                       new EditionDetail { Language = Constants.LANGUAGES_ENGLISH, Name = "vOpen AR 2019", Date = "October 3rd, 4th and 5th" }
                    },
                    LocationName = "Auditorio de la Casa del GCBA",
                    LocationFullAddress = "Uspallata 3160, Ciudad Autónoma de Buenos Aires, Argentina",
                    Organizers = new List<EditionOrganizer>
                    {
                        new EditionOrganizer { User = user12 },
                        new EditionOrganizer { User = user13 },
                        new EditionOrganizer { User = user14 },
                        new EditionOrganizer { User = user15 },
                    }
                };

                // Create CL Edition
                var clEdition = new Edition
                {
                    Id = "vopen-cl-2019",
                    Event = vopenEvent,
                    Details = new EditionDetail[]
                    {
                       new EditionDetail { Language = Constants.LANGUAGES_SPANISH, Name = "vOpen CL 2019" },
                       new EditionDetail { Language = Constants.LANGUAGES_ENGLISH, Name = "vOpen CL 2019" }
                    },
                    LocationName = "",
                    LocationFullAddress = "Santiago de Chile, Chile",
                    Organizers = new List<EditionOrganizer>
                    {
                        new EditionOrganizer { User = user16 },
                    }
                };

                // Create CO Edition
                var coEdition = new Edition
                {
                    Id = "vopen-co-2019",
                    Event = vopenEvent,
                    Details = new EditionDetail[]
                    {
                       new EditionDetail { Language = Constants.LANGUAGES_SPANISH, Name = "vOpen CO 2019" },
                       new EditionDetail { Language = Constants.LANGUAGES_ENGLISH, Name = "vOpen CO 2019" }
                    },
                    LocationName = "",
                    LocationFullAddress = "Bogotá, Colombia",
                    Organizers = new List<EditionOrganizer>
                    {
                        new EditionOrganizer { User = user17 },
                        new EditionOrganizer { User = user18 },
                        new EditionOrganizer { User = user19 },
                    }
                };

                // Create PE Edition
                var peEdition = new Edition
                {
                    Id = "vopen-pe-2019",
                    Event = vopenEvent,
                    Details = new EditionDetail[]
                    {
                       new EditionDetail { Language = Constants.LANGUAGES_SPANISH, Name = "vOpen PE 2019" },
                       new EditionDetail { Language = Constants.LANGUAGES_ENGLISH, Name = "vOpen PE 2019" }
                    },
                    LocationName = "",
                    LocationFullAddress = "Lima, Perú",
                    Organizers = new List<EditionOrganizer>
                    {
                        new EditionOrganizer { User = user20 },
                        new EditionOrganizer { User = user21 },
                        new EditionOrganizer { User = user22 },
                    }
                };

                context.Editions.Add(globalEdition);
                context.Editions.Add(arEdition);
                context.Editions.Add(uyEdition);
                context.Editions.Add(clEdition);
                context.Editions.Add(coEdition);
                context.Editions.Add(peEdition);

                context.SaveChanges();
            }
        }

        public static void Cleanup(DbContextOptions<VOpenDbContext> options)
        {
            using (var context = new VOpenDbContext(options))
            {
                context.Database.EnsureCreated();

                context.EditionsActivitiesScores.RemoveRange(context.EditionsActivitiesScores);
                context.EditionsActivitiesPresenters.RemoveRange(context.EditionsActivitiesPresenters);
                context.EditionsActivities.RemoveRange(context.EditionsActivities);
                context.EditionsOrganizers.RemoveRange(context.EditionsOrganizers);
                context.EditionsDetails.RemoveRange(context.EditionsDetails);
                context.EditionsSponsors.RemoveRange(context.EditionsSponsors);

                context.Sponsors.RemoveRange(context.Sponsors);
                context.UsersProposalsDetails.RemoveRange(context.UsersProposalsDetails);
                context.UsersDetails.RemoveRange(context.UsersDetails);
                context.Users.RemoveRange(context.Users);
                context.Editions.RemoveRange(context.Editions);
                context.Events.RemoveRange(context.Events);

                context.SaveChanges();
            }
        }
    }
}
