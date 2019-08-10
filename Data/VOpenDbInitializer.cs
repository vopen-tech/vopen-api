using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

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
                        new UserSocialLink { Type = "linkedin", Url = "https://www.linkedin.com/in/nanovazquez/" },
                        new UserSocialLink { Type = "twitter", Url = "https://twitter.com/nanovazquez87" },
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
                        new UserSocialLink { Type = "linkedin", Url = "https://ar.linkedin.com/in/gbellmann" },
                        new UserSocialLink { Type = "twitter", Url = "https://twitter.com/gjbellmann" },
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
                        new UserSocialLink { Type = "linkedin", Url = "https://ar.linkedin.com/in/pablodiloreto" },
                        new UserSocialLink { Type = "twitter", Url = "https://twitter.com/pablodiloreto" },
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
                        new UserSocialLink { Type = "linkedin", Url = "http://uy.linkedin.com/in/siderys" },
                        new UserSocialLink { Type = "twitter", Url = "https://twitter.com/fabianimaz" },
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
                        new UserSocialLink { Type = "linkedin", Url = "http://uy.linkedin.com/in/kzfabi" },
                        new UserSocialLink { Type = "twitter", Url = "https://twitter.com/kzfabi" },
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
                        new UserSocialLink { Type = "linkedin", Url = "https://www.linkedin.com/in/federico-bernasconi-48087b56/" },
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
                        new UserSocialLink { Type = "linkedin", Url = "https://www.linkedin.com/in/brian-hardy-382a9484/" },
                        new UserSocialLink { Type = "twitter", Url = "https://twitter.com/hardyr93" },
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
                    SocialLinks = new UserSocialLink[] { }
                };
                var user9 = new User
                {
                    Country = Constants.COUNTRIES_URUGUAY,
                    ImageUrl = "https://imgur.com/TpW7cPF.jpg",
                    Details = new UserDetail[]
                    {
                        new UserDetail { Name = "Victor Silva", Description = "", Language = Constants.LANGUAGES_SPANISH }
                    },
                    SocialLinks = new UserSocialLink[] { }
                };
                var user10 = new User
                {
                    Country = Constants.COUNTRIES_URUGUAY,
                    ImageUrl = "https://i.imgur.com/NKOIFQK.jpg",
                    Details = new UserDetail[]
                    {
                        new UserDetail { Name = "Fernanda Canepa", Description = "", Language = Constants.LANGUAGES_SPANISH }
                    },
                    SocialLinks = new UserSocialLink[] { }
                };
                var user11 = new User
                {
                    Country = Constants.COUNTRIES_URUGUAY,
                    ImageUrl = "https://i.imgur.com/9jleLkK.jpg",
                    Details = new UserDetail[]
                    {
                        new UserDetail { Name = "Diego Bellora",  Description = "", Language = Constants.LANGUAGES_SPANISH }
                    },
                    SocialLinks = new UserSocialLink[] { }
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
                        new UserSocialLink { Type = "linkedin", Url = "https://www.linkedin.com/in/niberra" },
                        new UserSocialLink { Type = "twitter", Url = "https://twitter.com/na_iberra" },
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
                        new UserSocialLink { Type = "linkedin", Url = "https://www.linkedin.com/in/jobramajo" },
                        new UserSocialLink { Type = "twitter", Url = "https://twitter.com/jorbramajo" },
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
                        new UserSocialLink { Type = "linkedin", Url = "https://www.linkedin.com/in/eyanez89" },
                        new UserSocialLink { Type = "twitter", Url = "https://twitter.com/Teban3010" },
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
                        new UserSocialLink { Type = "linkedin", Url = "https://www.linkedin.com/in/sebasti%C3%A1n-leonardo-p%C3%A9rez-68816599" },
                        new UserSocialLink { Type = "twitter", Url = "https://twitter.com/garudasla" },
                    }
                };

                // CH

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
                        new UserSocialLink { Type = "linkedin", Url = "https://twitter.com/SergioBLagash" },
                        new UserSocialLink { Type = "twitter", Url = "https://www.linkedin.com/in/sergioborromei" },
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
                        new UserSocialLink { Type = "linkedin", Url = "https://www.linkedin.com/in/mabvill" },
                        new UserSocialLink { Type = "twitter", Url = "https://twitter.com/mabvill" },
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
                        new UserSocialLink { Type = "linkedin", Url = "https://www.linkedin.com/in/miguelalmeyda" },
                        new UserSocialLink { Type = "twitter", Url = "https://twitter.com/miguelalmeyda" },
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
                        new UserSocialLink { Type = "linkedin", Url = "https://www.linkedin.com/in/alberto-de-rossi-46814244/" },
                        new UserSocialLink { Type = "twitter", Url = "https://twitter.com/albertoderossi" },
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
                context.Users.Add(user11);
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


                // Create locations
                var argLocation = new Location
                {
                    Details = new LocationDetail[]
                     {
                         new LocationDetail { Language = "es-AR", Name = "Auditorio de la Casa del GCBA", FullAddress = "Uspallata 3160, C1437JCL CABA", Country = "Argentina" },
                         new LocationDetail { Language = "en-US", Name = "Auditorio de la Casa del GCBA", FullAddress = "Uspallata 3160, C1437JCL CABA", Country = "Argentina" }
                     }
                };

                context.Locations.Add(argLocation);

                // TODO: create sponsors

                // Create AR Edition

                // Create UY Edition

                // Create CHI Edition

                // Create CO Edition

                // Create PE Edition

                context.SaveChanges();
            }
        }

        public static void Cleanup(DbContextOptions<VOpenDbContext> options)
        {
            using (var context = new VOpenDbContext(options))
            {
                context.Database.EnsureCreated();

                context.Events.RemoveRange(context.Events);
                context.Locations.RemoveRange(context.Locations);
                context.Sponsors.RemoveRange(context.Sponsors);
                context.Users.RemoveRange(context.Users);

                context.SaveChanges();
            }
        }
    }
}
