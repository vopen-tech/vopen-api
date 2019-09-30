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

                // Global

                var user1 = new User
                {
                    Country = Constants.COUNTRIES_ARGENTINA,
                    ImageUrl = "https://i.imgur.com/14aAfJW.jpg",
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
                    ImageUrl = "https://i.imgur.com/4JpB16z.jpg",
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
                    ImageUrl = "https://i.imgur.com/iY5beT7.jpg",
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
                    ImageUrl = "https://i.imgur.com/KrNBexb.jpg",
                    Details = new UserDetail[]
                    {
                        new UserDetail { Name = "Fabian Imaz", Description = "", Language = Constants.LANGUAGES_SPANISH }
                    },
                    SocialLinks = new UserSocialLink[]
                    {
                        new UserSocialLink { Type = Constants.SOCIAL_LINKEDIN, Url = "https://uy.linkedin.com/in/siderys" },
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
                        new UserSocialLink { Type = Constants.SOCIAL_LINKEDIN, Url = "https://uy.linkedin.com/in/kzfabi" },
                        new UserSocialLink { Type = Constants.SOCIAL_TWITTER, Url = "https://twitter.com/kzfabi" },
                    }
                };

                // UY

                var user6 = new User
                {
                    Country = Constants.COUNTRIES_URUGUAY,
                    ImageUrl = "https://i.imgur.com/vSPaUor.jpg",
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
                    ImageUrl = "https://i.imgur.com/7WclQJ9.jpg",
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

                // AR

                var user12 = new User
                {
                    Country = Constants.COUNTRIES_ARGENTINA,
                    ImageUrl = "https://i.imgur.com/xxhanh1.jpg",
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
                    ImageUrl = "https://i.imgur.com/WTWvZct.jpg",
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
                    ImageUrl = "https://i.imgur.com/FB2hl5h.jpg",
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
                    ImageUrl = "https://i.imgur.com/4F8teHs.jpg",
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
                    ImageUrl = "https://i.imgur.com/lVxUCBx.jpg",
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
                    ImageUrl = "https://i.imgur.com/h1wbE8H.png",
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

                // Create sponsors
                var kaizen = new Sponsor
                {
                    Name = "Kaizen Softworks",
                    ImageUrl = "https://i.imgur.com/njfCNqo.png",
                    Url = "http://kzsoftworks.com"
                };
                var endava = new Sponsor
                {
                    Name = "Endava",
                    ImageUrl = "https://i.imgur.com/U7PZHiu.png",
                    Url = "https://www.endava.com/"
                };
                var wyeworks = new Sponsor
                {
                    Name = "WyeWorks",
                    ImageUrl = "https://i.imgur.com/iGiYWG9.png",
                    Url = "https://www.wyeworks.com"
                };
                var elObservador = new Sponsor
                {
                    Name = "El Observador",
                    ImageUrl = "https://i.imgur.com/R48lvSw.png",
                    Url = "https://elobservador.com.uy"
                };
                var antel = new Sponsor
                {
                    Name = "Antel",
                    ImageUrl = "https://i.imgur.com/T6vHq3x.png",
                    Url = "https://www.antel.com.uy/"
                };
                var nareia = new Sponsor
                {
                    Name = "Nareia",
                    ImageUrl = "https://i.imgur.com/qwHigPt.png",
                    Url = "https://nareia.com.uy/"
                };

                context.Sponsors.Add(kaizen);
                context.Sponsors.Add(endava);
                context.Sponsors.Add(wyeworks);
                context.Sponsors.Add(elObservador);

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

                // UY Speakers
                var uySpeaker1 = new User
                {
                    Country = Constants.COUNTRIES_UNITED_STATES,
                    ImageUrl = "https://media.licdn.com/dms/image/C4E03AQEHm9QpksQ63w/profile-displayphoto-shrink_200_200/0?e=1572480000&v=beta&t=Tz-_ZmHuWY99rdA3bIJ8ybHsuTfj6oO_vtBjt4bSjpc",
                    Details = new UserDetail[]
                    {
                        new UserDetail { Name = "Guada Casuso", Description = "", JobTitle = "Lead PM", Company = "Microsoft", Language = Constants.LANGUAGES_SPANISH }
                    },
                    SocialLinks = new UserSocialLink[]
                    {
                        new UserSocialLink { Type = Constants.SOCIAL_LINKEDIN, Url = "https://www.linkedin.com/in/guada-casuso/" },
                        new UserSocialLink { Type = Constants.SOCIAL_TWITTER, Url = "https://twitter.com/guadacasuso" },
                    }
                };
                var uySpeaker2 = new User
                {
                    Country = Constants.COUNTRIES_ARGENTINA,
                    ImageUrl = "https://media.licdn.com/dms/image/C4E03AQH-7vC7lgttOw/profile-displayphoto-shrink_200_200/0?e=1572480000&v=beta&t=1XjAiK51c-w-kdXkNADDeawi-igJHEFqjjASx_VN3M4",
                    Details = new UserDetail[]
                    {
                        new UserDetail { Name = "Enrique Dutra", Description = "", JobTitle = "Socio Gerente", Company = "Punto Net Soluciones SRL", Language = Constants.LANGUAGES_SPANISH }
                    },
                    SocialLinks = new UserSocialLink[]
                    {
                        new UserSocialLink { Type = Constants.SOCIAL_LINKEDIN, Url = "https://www.linkedin.com/in/enriquedutra/" },
                        new UserSocialLink { Type = Constants.SOCIAL_TWITTER, Url = "https://twitter.com/egdutra" },
                    }
                };
                var uySpeaker3 = new User
                {
                    Country = Constants.COUNTRIES_UNITED_KINGDOM,
                    ImageUrl = "https://meteatamel.files.wordpress.com/2019/03/meteatamel-2019.jpeg",
                    Details = new UserDetail[]
                    {
                        new UserDetail { Name = "Mete Atamel", Description = "", JobTitle = "Senior Developer Advocate", Company = "Google", Language = Constants.LANGUAGES_SPANISH }
                    },
                    SocialLinks = new UserSocialLink[]
                    {
                        new UserSocialLink { Type = Constants.SOCIAL_LINKEDIN, Url = "https://www.linkedin.com/in/meteatamel" },
                        new UserSocialLink { Type = Constants.SOCIAL_TWITTER, Url = "https://twitter.com/meteatamel" },
                    }
                };
                var uySpeaker4 = new User
                {
                    Country = Constants.COUNTRIES_ARGENTINA,
                    ImageUrl = "https://media.licdn.com/dms/image/C4E03AQGqrFkjImrUbg/profile-displayphoto-shrink_200_200/0?e=1572480000&v=beta&t=9hZMihfvDIeiEZ839Xw__kGAD-2Uq700vXpWb3LUCk4",
                    Details = new UserDetail[]
                    {
                        new UserDetail { Name = "Javier Villegas", Description = "", JobTitle = "DBA Manager", Company = "Mediterranean Shipping Co.", Language = Constants.LANGUAGES_SPANISH }
                    },
                    SocialLinks = new UserSocialLink[]
                    {
                        new UserSocialLink { Type = Constants.SOCIAL_LINKEDIN, Url = "https://www.linkedin.com/in/javiervillegas" },
                        new UserSocialLink { Type = Constants.SOCIAL_TWITTER, Url = "https://twitter.com/javier_vill" },
                    }
                };
                var uySpeaker5 = new User
                {
                    Country = Constants.COUNTRIES_URUGUAY,
                    ImageUrl = "https://i.imgur.com/EThBZCw.jpg",
                    Details = new UserDetail[]
                    {
                        new UserDetail { Name = "Felipe Schneider", Description = "", JobTitle = "DBA Admin", Company = "Pyxis", Language = Constants.LANGUAGES_SPANISH }
                    },
                    SocialLinks = new UserSocialLink[]
                    {
                        new UserSocialLink { Type = Constants.SOCIAL_LINKEDIN, Url = "https://www.linkedin.com/in/felipe-schneider-03066921/" },
                        new UserSocialLink { Type = Constants.SOCIAL_TWITTER, Url = "https://twitter.com/Felipes88" },
                    }
                };
                var uySpeaker6 = new User
                {
                    Country = Constants.COUNTRIES_URUGUAY,
                    ImageUrl = "https://i.imgur.com/nTCQW4O.jpg",
                    Details = new UserDetail[]
                    {
                        new UserDetail { Name = "Santiago Pastorino", Description = "", JobTitle = "Fundador", Company = "WyeWorks", Language = Constants.LANGUAGES_SPANISH }
                    },
                    SocialLinks = new UserSocialLink[]
                    {
                        new UserSocialLink { Type = Constants.SOCIAL_LINKEDIN, Url = "https://uy.linkedin.com/in/santiagopastorino" },
                        new UserSocialLink { Type = Constants.SOCIAL_TWITTER, Url = "https://twitter.com/spastorino" },
                    }
                };
                var uySpeaker7 = new User
                {
                    Country = Constants.COUNTRIES_BRAZIL,
                    ImageUrl = "https://media.licdn.com/dms/image/C4E03AQGPcSiPZ4SEpw/profile-displayphoto-shrink_200_200/0?e=1570060800&v=beta&t=DAyy4VlxpkUT4A_zafFmXNXGQzqphsu-XVnXTthZ31M",
                    Details = new UserDetail[]
                    {
                        new UserDetail { Name = "Alexandre Brandão Lustosa", Description = "", JobTitle = "IT Director", Company = "Stone Payments", Language = Constants.LANGUAGES_SPANISH }
                    },
                    SocialLinks = new UserSocialLink[]
                    {
                        new UserSocialLink { Type = Constants.SOCIAL_LINKEDIN, Url = "https://www.linkedin.com/in/abrandaol/" },
                        new UserSocialLink { Type = Constants.SOCIAL_TWITTER, Url = "https://twitter.com/abrandaolustosa" },
                    }
                };
                var uySpeaker9 = new User
                {
                    Country = Constants.COUNTRIES_BRAZIL,
                    ImageUrl = "https://media.licdn.com/dms/image/C4E03AQFEySIvDgebsA/profile-displayphoto-shrink_200_200/0?e=1572480000&v=beta&t=_qxu87Ovo7WkFz5_BUmasXk9rmmiR8_lfnYr6r7VSR8",
                    Details = new UserDetail[]
                    {
                        new UserDetail { Name = "Rodrigo Crespi", Description = "", JobTitle = "CTO", Company = "CrespiDB Ltda", Language = Constants.LANGUAGES_SPANISH }
                    },
                    SocialLinks = new UserSocialLink[]
                    {
                        new UserSocialLink { Type = Constants.SOCIAL_LINKEDIN, Url = "https://www.linkedin.com/in/rodrigocrespi/" },
                        new UserSocialLink { Type = Constants.SOCIAL_TWITTER, Url = "https://twitter.com/SQLCrespi" },
                    }
                };
                var uySpeaker10 = new User
                {
                    Country = Constants.COUNTRIES_PERU,
                    ImageUrl = "https://secure.meetupstatic.com/photos/member/7/1/0/c/highres_266188940.jpeg",
                    Details = new UserDetail[]
                    {
                        new UserDetail { Name = "Nicolas Nakasone", Description = "", JobTitle = "Technical Leader", Company = "Arkanosoft", Language = Constants.LANGUAGES_SPANISH }
                    },
                    SocialLinks = new UserSocialLink[]
                    {
                        new UserSocialLink { Type = Constants.SOCIAL_LINKEDIN, Url = "https://www.linkedin.com/in/nicolas-nakasone/" },
                        new UserSocialLink { Type = Constants.SOCIAL_TWITTER, Url = "https://twitter.com/nicolasnakasone" },
                    }
                };
                var uySpeaker11 = new User
                {
                    Country = Constants.COUNTRIES_URUGUAY,
                    ImageUrl = "https://i.imgur.com/dUdbx4k.jpg",
                    Details = new UserDetail[]
                    {
                        new UserDetail { Name = "Victoria Perez", Description = "", JobTitle = "Dev con foco en UX", Company = "Pyxis", Language = Constants.LANGUAGES_SPANISH }
                    },
                    SocialLinks = new UserSocialLink[]
                    {
                        new UserSocialLink { Type = Constants.SOCIAL_LINKEDIN, Url = "https://www.linkedin.com/in/perezmvictoria/ " },
                        new UserSocialLink { Type = Constants.SOCIAL_TWITTER, Url = "https://twitter.com/perezmvictoria" },
                    }
                };
                var uySpeaker12 = new User
                {
                    Country = Constants.COUNTRIES_VENEZUELA,
                    ImageUrl = "https://i.imgur.com/hgdXyLu.jpg",
                    Details = new UserDetail[]
                    {
                        new UserDetail { Name = "Josmell Chavarri", Description = "", JobTitle = "Especialista en Seguridad", Company = "GuayoyoLabs", Language = Constants.LANGUAGES_SPANISH }
                    },
                    SocialLinks = new UserSocialLink[]
                    {
                        new UserSocialLink { Type = Constants.SOCIAL_LINKEDIN, Url = "https://www.linkedin.com/in/josmellchavarri/ " },
                        new UserSocialLink { Type = Constants.SOCIAL_TWITTER, Url = "https://twitter.com/j0sm3ll" },
                    }
                };

                context.Users.Add(uySpeaker1);
                context.Users.Add(uySpeaker2);
                context.Users.Add(uySpeaker3);
                context.Users.Add(uySpeaker4);
                context.Users.Add(uySpeaker5);
                context.Users.Add(uySpeaker6);
                context.Users.Add(uySpeaker7);
                context.Users.Add(uySpeaker9);
                context.Users.Add(uySpeaker10);
                context.Users.Add(uySpeaker11);
                context.Users.Add(uySpeaker12);

                ///

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
                        new EditionTicket { Name = "Early birds", Price = "20USD", StartDate = "2019-08-19T16:00:00.000Z", EndDate = "2019-09-19T00:00:00.000Z", BuyLinks = uyBuyLinksJson },
                        new EditionTicket { Name = "Night owl", Price = "40USD", StartDate = "2019-09-19T00:00:00.000Z", EndDate = "2019-10-01T00:00:00.000Z", BuyLinks = uyBuyLinksJson },
                        new EditionTicket { Name = "General ticket", Price = "60USD", StartDate = "2019-10-01T00:00:00.000Z", EndDate = "2019-10-24T00:00:00.000Z", BuyLinks = uyBuyLinksJson },
                    },
                    Organizers = new List<EditionOrganizer>
                    {
                        new EditionOrganizer { User = user6 },
                        new EditionOrganizer { User = user7 },
                        new EditionOrganizer { User = user8 },
                        new EditionOrganizer { User = user9 },
                        new EditionOrganizer { User = user10 },
                        new EditionOrganizer { User = user23 },
                        new EditionOrganizer { User = user24 },
                        new EditionOrganizer { User = user25 },
                    },
                    Sponsors = new List<EditionSponsor>()
                    {
                        // use a number for the ID because it is needed for the app mobile (will be removed later on)
                        new EditionSponsor { Id = "1", Sponsor = kaizen, Type = Constants.SPONSOR_GOLD },
                        new EditionSponsor { Id = "2", Sponsor = endava, Type = Constants.SPONSOR_GOLD },
                        new EditionSponsor { Id = "3", Sponsor = antel, Type = Constants.SPONSOR_GOLD },
                        new EditionSponsor { Id = "4", Sponsor = nareia, Type = Constants.SPONSOR_GOLD },
                        new EditionSponsor { Id = "5", Sponsor = wyeworks, Type = Constants.SPONSOR_SILVER },
                        new EditionSponsor { Id = "6", Sponsor = elObservador, Type = Constants.SPONSOR_SILVER },
                    },
                    Activities = new List<EditionActivity>
                    {
                        new EditionActivity {
                            Users = new List<EditionActivityUser> { new EditionActivityUser { User = uySpeaker2 } },
                            Type = Constants.ACTIVITY_TALK, Day = "Day 1", Track ="Track 1", Duration = "00:30:00", Date = "2019-08-19T09:00:00.000Z", Tags = "tag1, tag2, tag3", Level = "100", Scores = new List<EditionActivityScore>(),
                            Details = new List<EditionActivityDetail>()
                            {
                                new EditionActivityDetail() { Language = Constants.LANGUAGES_SPANISH, Title = "Day 1 - Track 1 - Talk 1" }
                            }
                        },
                        new EditionActivity
                        {
                            Users = new List<EditionActivityUser> { new EditionActivityUser { User = uySpeaker2 } },
                            Type = Constants.ACTIVITY_TALK, Day = "Day 1", Track ="Track 1", Duration = "00:30:00", Date = "2019-08-19T09:30:00.000Z", Tags = "tag1, tag2", Level = "100", Scores = new List<EditionActivityScore>(),
                            Details = new List<EditionActivityDetail>()
                            {
                                new EditionActivityDetail() { Language = Constants.LANGUAGES_SPANISH, Title = "Day 1 - Track 1 - Talk 2" }
                            }
                        },
                        new EditionActivity
                        {
                            Users = new List<EditionActivityUser> { new EditionActivityUser { User = uySpeaker3 } },
                            Type = Constants.ACTIVITY_TALK, Day = "Day 1", Track ="Track 1", Duration = "00:30:00", Date = "2019-08-19T10:00:00.000Z", Tags = "tag1, tag2, tag3, tag4, tag5", Level = "100", Scores = new List<EditionActivityScore>(),
                            Details = new List<EditionActivityDetail>()
                            {
                                new EditionActivityDetail() { Language = Constants.LANGUAGES_SPANISH, Title = "Day 1 - Track 1 - Talk 3" }
                            }
                        },
                        new EditionActivity
                        {
                            Users = new List<EditionActivityUser> { new EditionActivityUser { User = uySpeaker4 } },
                            Type = Constants.ACTIVITY_TALK, Day = "Day 1", Track ="Track 2", Duration = "00:30:00", Date = "2019-08-19T09:00:00.000Z", Tags = "tag1, tag2", Level = "100", Scores = new List<EditionActivityScore>(),
                            Details = new List<EditionActivityDetail>()
                            {
                                new EditionActivityDetail() { Language = Constants.LANGUAGES_SPANISH, Title = "Day 1 - Track 2 - Talk 1" }
                            }
                        },
                        new EditionActivity
                        {
                            Users = new List<EditionActivityUser> { new EditionActivityUser { User = uySpeaker5 } },
                            Type = Constants.ACTIVITY_TALK, Day = "Day 1", Track ="Track 2", Duration = "00:30:00", Date = "2019-08-19T09:30:00.000Z", Tags = "tag1", Level = "100", Scores = new List<EditionActivityScore>(),
                            Details = new List<EditionActivityDetail>()
                            {
                                new EditionActivityDetail() { Language = Constants.LANGUAGES_SPANISH, Title = "Day 1 - Track 2 - Talk 2" }
                            }
                        },
                        new EditionActivity
                        {
                            Users = new List<EditionActivityUser> { new EditionActivityUser { User = uySpeaker6 } },
                            Type = Constants.ACTIVITY_TALK, Day = "Day 1", Track ="Track 2", Duration = "00:30:00", Date = "2019-08-19T10:00:00.000Z", Tags = "tag1, tag2, tag3", Level = "100", Scores = new List<EditionActivityScore>(),
                            Details = new List<EditionActivityDetail>()
                            {
                                new EditionActivityDetail() { Language = Constants.LANGUAGES_SPANISH, Title = "Day 1 - Track 2 - Talk 3" }
                            }
                        },
                        new EditionActivity
                        {
                            Users = new List<EditionActivityUser> { new EditionActivityUser { User = uySpeaker7 } },
                            Type = Constants.ACTIVITY_TALK, Day = "Day 2", Track ="Track 1", Duration = "00:30:00", Date = "2019-08-20T09:00:00.000Z", Tags = "tag1, tag2", Level = "100", Scores = new List<EditionActivityScore>(),
                            Details = new List<EditionActivityDetail>()
                            {
                                new EditionActivityDetail() { Language = Constants.LANGUAGES_SPANISH, Title = "Day 2 - Track 1 - Talk 1" }
                            }
                        },
                        new EditionActivity
                        {
                            Users = new List<EditionActivityUser> { new EditionActivityUser { User = uySpeaker7 } },
                            Type = Constants.ACTIVITY_TALK, Day = "Day 2", Track ="Track 1", Duration = "00:30:00", Date = "2019-08-20T09:30:00.000Z", Tags = "tag1", Level = "100", Scores = new List<EditionActivityScore>(),
                            Details = new List<EditionActivityDetail>()
                            {
                                new EditionActivityDetail() { Language = Constants.LANGUAGES_SPANISH, Title = "Day 2 - Track 1 - Talk 2" }
                            }
                        },
                        new EditionActivity
                        {
                            Users = new List<EditionActivityUser> { new EditionActivityUser { User = uySpeaker9 } },
                            Type = Constants.ACTIVITY_TALK, Day = "Day 2", Track ="Track 1", Duration = "00:30:00", Date = "2019-08-20T10:00:00.000Z", Tags = "tag1, tag2", Level = "100", Scores = new List<EditionActivityScore>(),
                            Details = new List<EditionActivityDetail>()
                            {
                                new EditionActivityDetail() { Language = Constants.LANGUAGES_SPANISH, Title = "Day 2 - Track 1 - Talk 3" }
                            }
                        },
                        new EditionActivity
                        {
                            Users = new List<EditionActivityUser> { new EditionActivityUser { User = uySpeaker10 } },
                            Type = Constants.ACTIVITY_TALK, Day = "Day 2", Track ="Track 2", Duration = "00:30:00", Date = "2019-08-20T09:00:00.000Z", Tags = "tag1, tag2, tag3", Level = "100", Scores = new List<EditionActivityScore>(),
                            Details = new List<EditionActivityDetail>()
                            {
                                new EditionActivityDetail() { Language = Constants.LANGUAGES_SPANISH, Title = "Day 2 - Track 2 - Talk 1" }
                            }
                        },
                        new EditionActivity
                        {
                            Users = new List<EditionActivityUser> { new EditionActivityUser { User = uySpeaker11 }, new EditionActivityUser { User = uySpeaker12 } },
                            Type = Constants.ACTIVITY_TALK, Day = "Day 2", Track ="Track 2", Duration = "00:30:00", Date = "2019-08-20T09:30:00.000Z", Tags = "tag1, tag2, tag3, tag4, tag5", Level = "100", Scores = new List<EditionActivityScore>(),
                            Details = new List<EditionActivityDetail>()
                            {
                                new EditionActivityDetail() { Language = Constants.LANGUAGES_SPANISH, Title = "Day 2 - Track 2 - Talk 2" }
                            }
                        },
                    }
                };

                // Create AR Edition

                // Speakers
                var arSpeaker1 = new User
                {
                    Country = Constants.COUNTRIES_ARGENTINA,
                    ImageUrl = "https://i.imgur.com/cD0SXUl.jpg",
                    Details = new UserDetail[]
                    {
                        new UserDetail { Name = "María Alejandra Mazzini", Description = "", JobTitle = "Co-Fundadora", Company = "Algeiba", Language = Constants.LANGUAGES_SPANISH }
                    },
                    SocialLinks = new UserSocialLink[]
                    {
                        new UserSocialLink { Type = Constants.SOCIAL_LINKEDIN, Url = "https://www.linkedin.com/in/malejandramazzini/" },
                    }
                };
                var arSpeaker2 = new User
                {
                    Country = Constants.COUNTRIES_ARGENTINA,
                    ImageUrl = "https://i.imgur.com/m5W4jCV.jpg",
                    Details = new UserDetail[]
                    {
                        new UserDetail { Name = "Juan Francisco Escudero", Description = "", JobTitle = "Eng. Manager", Company = "Medallia", Language = Constants.LANGUAGES_SPANISH }
                    },
                    SocialLinks = new UserSocialLink[]
                    {
                        new UserSocialLink { Type = Constants.SOCIAL_LINKEDIN, Url = "https://www.linkedin.com/in/juan-francisco-escudero" },
                    }
                };
                var arSpeaker3 = new User
                {
                    Country = Constants.COUNTRIES_ARGENTINA,
                    ImageUrl = "https://i.imgur.com/XQD0EcR.jpg",
                    Details = new UserDetail[]
                    {
                        new UserDetail { Name = "Jonathan Erlich", Description = "", JobTitle = "Senior Engineer", Company = "Medallia", Language = Constants.LANGUAGES_SPANISH }
                    },
                    SocialLinks = new UserSocialLink[]
                    {
                        new UserSocialLink { Type = Constants.SOCIAL_LINKEDIN, Url = "https://www.linkedin.com/in/jonathan-erlich-4948ba7/" },
                    }
                };
                var arSpeaker4 = new User
                {
                    Country = Constants.COUNTRIES_UNITED_STATES,
                    ImageUrl = "https://i.imgur.com/URg9dmD.jpg",
                    Details = new UserDetail[]
                    {
                        new UserDetail { Name = "Jonas Stawski", Description = "", JobTitle = "CTO", Company = "FishAngler", Language = Constants.LANGUAGES_SPANISH }
                    },
                    SocialLinks = new UserSocialLink[]
                    {
                        new UserSocialLink { Type = Constants.SOCIAL_LINKEDIN, Url = "https://www.linkedin.com/in/jonasstawski/" },
                        new UserSocialLink { Type = Constants.SOCIAL_TWITTER, Url = "https://twitter.com/jstawski" },
                    }
                };
                var arSpeaker5 = new User
                {
                    Country = Constants.COUNTRIES_ARGENTINA,
                    ImageUrl = "https://i.imgur.com/wcYR2J5.jpg",
                    Details = new UserDetail[]
                    {
                        new UserDetail { Name = "Fernando Sonego", Description = "", JobTitle = "Arquitecto de Soluciones", Company = "Algeiba", Language = Constants.LANGUAGES_SPANISH }
                    },
                    SocialLinks = new UserSocialLink[]
                    {
                        new UserSocialLink { Type = Constants.SOCIAL_LINKEDIN, Url = "https://www.linkedin.com/in/fernando-sonego-a7378231/" },
                        new UserSocialLink { Type = Constants.SOCIAL_TWITTER, Url = "https://twitter.com/FernandoSonego" },
                    }
                };
                var arSpeaker6 = new User
                {
                    Country = Constants.COUNTRIES_ARGENTINA,
                    ImageUrl = "https://i.imgur.com/yGLqySK.png",
                    Details = new UserDetail[]
                    {
                        new UserDetail { Name = "Ivana Tilca", Description = "", JobTitle = "Quality Manager", Company = "3XM Group", Language = Constants.LANGUAGES_SPANISH }
                    },
                    SocialLinks = new UserSocialLink[]
                    {
                        new UserSocialLink { Type = Constants.SOCIAL_LINKEDIN, Url = "https://www.linkedin.com/in/ivanatilca/" },
                        new UserSocialLink { Type = Constants.SOCIAL_TWITTER, Url = "https://twitter.com/ivanatilca" },
                    }
                };
                var arSpeaker7 = new User
                {
                    Country = Constants.COUNTRIES_ARGENTINA,
                    ImageUrl = "https://i.imgur.com/oAOvSFW.jpg",
                    Details = new UserDetail[]
                    {
                        new UserDetail { Name = "Angel J Lopez", Description = "", JobTitle = "Software Developer", Company = "IOVLabs", Language = Constants.LANGUAGES_SPANISH }
                    },
                    SocialLinks = new UserSocialLink[]
                    {
                        new UserSocialLink { Type = Constants.SOCIAL_LINKEDIN, Url = "https://www.linkedin.com/in/ajlopez/" },
                        new UserSocialLink { Type = Constants.SOCIAL_TWITTER, Url = "https://twitter.com/ajlopez" },
                    }
                };
                var arSpeaker8 = new User
                {
                    Country = Constants.COUNTRIES_ARGENTINA,
                    ImageUrl = "https://i.imgur.com/TwCIpww.jpg",
                    Details = new UserDetail[]
                    {
                        new UserDetail { Name = "Enzo Cano", Description = "", JobTitle = "Lead Software Engineer", Company = "Southworks", Language = Constants.LANGUAGES_SPANISH }
                    },
                    SocialLinks = new UserSocialLink[]
                    {
                        new UserSocialLink { Type = Constants.SOCIAL_LINKEDIN, Url = "https://www.linkedin.com/in/enzojfcano" },
                        new UserSocialLink { Type = Constants.SOCIAL_TWITTER, Url = "https://twitter.com/enz_cano" },
                    }
                };

                context.Users.Add(arSpeaker1);
                context.Users.Add(arSpeaker2);
                context.Users.Add(arSpeaker3);
                context.Users.Add(arSpeaker4);
                context.Users.Add(arSpeaker5);
                context.Users.Add(arSpeaker6);
                context.Users.Add(arSpeaker7);
                context.Users.Add(arSpeaker8);

                var aryBuyLinks = new List<TicketLink>()
                {
                    new TicketLink { Url = "https://vopen-ar-2019.eventbrite.com" },
                };
                var arBuyLinksJson = JsonConvert.SerializeObject(aryBuyLinks);

                var arEdition = new Edition
                {
                    Id = "vopen-ar-2019",
                    Event = vopenEvent,
                    Details = new EditionDetail[]
                    {
                       new EditionDetail { Language = Constants.LANGUAGES_SPANISH, Name = "vOpen AR 2019", Date = "5 de Octubre" },
                       new EditionDetail { Language = Constants.LANGUAGES_ENGLISH, Name = "vOpen AR 2019", Date = "October 5th" }
                    },
                    LocationName = "Microsoft Argentina",
                    LocationFullAddress = "Bouchard 710, Ciudad Autónoma de Buenos Aires, Argentina",
                    Organizers = new List<EditionOrganizer>
                    {
                        new EditionOrganizer { User = user12 },
                        new EditionOrganizer { User = user13 },
                        new EditionOrganizer { User = user14 },
                        new EditionOrganizer { User = user15 },
                    },
                    EditionTickets = new List<EditionTicket>()
                    {
                        new EditionTicket { Name = "General ticket", Price = "Free", StartDate = "2019-09-01T00:00:00.000Z", EndDate = "2019-10-07T00:00:00.000Z", BuyLinks = arBuyLinksJson },
                    },
                    Activities = new List<EditionActivity>
                    {
                        new EditionActivity { Type = Constants.ACTIVITY_ACCREDITATION_BREAKFAST, Day = "Day 1", Track = "Track 1", Duration = "00:30:00", Date = "2019-10-05T08:30:00.000-0300", Details = new List<EditionActivityDetail>() {  new EditionActivityDetail() { Language = Constants.LANGUAGES_SPANISH, Title = "Acreditación y desayuno" } } },
                        new EditionActivity { Type = Constants.ACTIVITY_OPENING, Day = "Day 1", Track = "Track 1", Duration = "00:30:00", Date = "2019-10-05T09:00:00.000-0300", Details = new List<EditionActivityDetail>() {  new EditionActivityDetail() { Language = Constants.LANGUAGES_SPANISH, Title = "Apertura" } } },
                        new EditionActivity
                        {
                            Type = Constants.ACTIVITY_KEYNOTE, Day = "Day 1", Track = "Track 1", Duration = "00:45:00", Date = "2019-10-05T09:30:00.000-0300", Level = "100", Tags = "startups, knowledge",
                            Users = new List<EditionActivityUser> { new EditionActivityUser { User = arSpeaker1 } },
                            Details = new List<EditionActivityDetail>()
                            {
                                new EditionActivityDetail() { Language = Constants.LANGUAGES_SPANISH, Title = "El gap entre tecnología, adopción y talento en las organizaciones: ¿estás preparado para diferenciarte?", Description = "La velocidad de cambio de la tecnología es mucho mayor a la velocidad de adopción que tienen las empresas. Y aquellas empresas que inician una transformación tecnológica se enfrentan con el desafío de contar con los colaboradores que sepan cómo abordarla. Existe un GAP entre tecnología disponible, tecnología adoptada y talento. La escasez de talento analítico y de habilidades de desaprendizaje y aprendizaje continuo representan un gran desafío y una buena oportunidad para diferenciarte del resto. Hoy el saber importa y vale, pero la capacidad de repensarse a uno mismo y la disposición para aprender sobre nuevos temas, son las competencias estratégicas esenciales para el presente y futuro próximo. En esta charla repasaremos algunos conceptos clave y consejos que te ayudarán a liberar todo tu potencial. ¿Estás preparado?" }
                            }
                        },
                        new EditionActivity
                        {
                            Type = Constants.ACTIVITY_TALK, Day = "Day 1", Track = "Track 1", Duration = "00:45:00", Date = "2019-10-05T10:15:00.000-0300", Level = "300", Tags = "APIs, cloud, backend",
                            Users = new List<EditionActivityUser> { new EditionActivityUser { User = arSpeaker2 }, new EditionActivityUser { User = arSpeaker3 } },
                            Details = new List<EditionActivityDetail>()
                            {
                                new EditionActivityDetail() { Language = Constants.LANGUAGES_SPANISH, Title = "Un camino pragmatico a la simplificacion de infraestructura de APIs", Description = "Kong, nginx, WSO2, AWS API Manager, todo muy lindo, es fácil poner un API GW. Queremos mostrar cómo hacemos en Medallia para brindar soporte para APIs muy heterogéneas que tienen desde 3 requests por día, hasta high-performance APIs de millones de requests por minuto." }
                            }
                        },
                        new EditionActivity { Type = Constants.ACTIVITY_COFFEE_BREAK, Day = "Day 1", Track = "Track 1", Duration = "00:30:00", Date = "2019-10-05T11:00:00.000-0300", Details = new List<EditionActivityDetail>() {  new EditionActivityDetail() { Language = Constants.LANGUAGES_SPANISH, Title = "Coffee break" } } },
                        new EditionActivity
                        {
                            Type = Constants.ACTIVITY_TALK, Day = "Day 1", Track = "Track 1", Duration = "00:45:00", Date = "2019-10-05T11:30:00.000-0300", Level = "100", Tags = "storage, Azure, cloud",
                            Users = new List<EditionActivityUser> { new EditionActivityUser { User = arSpeaker4 } },
                            Details = new List<EditionActivityDetail>()
                            {
                                new EditionActivityDetail() { Language = Constants.LANGUAGES_SPANISH, Title = "Eligiendo el servicio correcto de data storage en Azure", Description = "Azure, la nube de Microsoft, esta compuesta de cientos de servicios y productos de los cuales 19 están relacionados al almacenamiento de datos. En esta charla hablaremos de estos servicios, sus pros y cons, como elegir uno adecuado para cada problema y cómo son usados en FishAngler.com." }
                            }
                        },
                        new EditionActivity
                        {
                            Type = Constants.ACTIVITY_TALK, Day = "Day 1", Track = "Track 1", Duration = "00:45:00", Date = "2019-10-05T12:15:00.000-0300", Level = "100", Tags = "cloud, Azure, AWS",
                            Users = new List<EditionActivityUser> { new EditionActivityUser { User = arSpeaker5 } },
                            Details = new List<EditionActivityDetail>()
                            {
                                new EditionActivityDetail() { Language = Constants.LANGUAGES_SPANISH, Title = "Azure vs AWS: Guía de Servicios en la Nube", Description = "La elección de un proveedor de servicios en la nube es una gran decisión. Entender cuales se adaptan mejor a tus requerimientos te permitirán ahorrar costos significativos. En esta charla vas a conocer y entender varios de los servicios que ofrecen Microsoft y Amazon, sus similitudes y diferencias." }
                            }
                        },
                        new EditionActivity { Type = Constants.ACTIVITY_LUNCH, Day = "Day 1", Track = "Track 1", Duration = "00:60:00", Date = "2019-10-05T13:00:00.000-0300", Details = new List<EditionActivityDetail>() {  new EditionActivityDetail() { Language = Constants.LANGUAGES_SPANISH, Title = "Almuerzo" } } },
                        new EditionActivity
                        {
                            Type = Constants.ACTIVITY_TALK, Day = "Day 1", Track = "Track 1", Duration = "00:45:00", Date = "2019-10-05T14:00:00.000-0300", Level = "200", Tags = "AI, Azure, Kinect",
                            Users = new List<EditionActivityUser> { new EditionActivityUser { User = arSpeaker6 } },
                            Details = new List<EditionActivityDetail>()
                            {
                                new EditionActivityDetail() { Language = Constants.LANGUAGES_ENGLISH, Title = "Azure Kinect + AI development “Third era of computing”", Description = "AI is predicted to be the third era of computing. Now it´s also becoming cloud-based which means that even the most sophisticated techniques become available to everybody. The key is, using the Azure Kinect to provide data, then use it to train machine-learning systems, feed image- and text-recognition services, perform speech recognition, and so on. Let me show you how this can be accomplished." }
                            }
                        },
                        new EditionActivity
                        {
                            Type = Constants.ACTIVITY_TALK, Day = "Day 1", Track = "Track 1", Duration = "00:45:00", Date = "2019-10-05T14:45:00.000-0300", Level = "200", Tags = "AI, Deep Learning, Go",
                            Users = new List<EditionActivityUser> { new EditionActivityUser { User = arSpeaker7 } },
                            Details = new List<EditionActivityDetail>()
                            {
                                new EditionActivityDetail() { Language = Constants.LANGUAGES_ENGLISH, Title = "Deep Learning y el Juego del Go", Description = "Descripción del juego del Go y cómo una implementación de Deep Learning con Reinforcement Learning llegó a derrotar al mejor jugador humano." }
                            }
                        },
                        new EditionActivity { Type = Constants.ACTIVITY_COFFEE_BREAK, Day = "Day 1", Track = "Track 1", Duration = "00:30:00", Date = "2019-10-05T15:30:00.000-0300", Details = new List<EditionActivityDetail>() {  new EditionActivityDetail() { Language = Constants.LANGUAGES_SPANISH, Title = "Coffee break" } } },
                         new EditionActivity
                        {
                            Type = Constants.ACTIVITY_TALK, Day = "Day 1", Track = "Track 1", Duration = "00:45:00", Date = "2019-10-05T16:00:00.000-0300", Level = "200", Tags = "Serverless, Azure, Bots",
                            Users = new List<EditionActivityUser> { new EditionActivityUser { User = arSpeaker8 } },
                            Details = new List<EditionActivityDetail>()
                            {
                                new EditionActivityDetail() { Language = Constants.LANGUAGES_ENGLISH, Title = "Bots + Azure Functions", Description = "Como conectar BotFramework v4 con Azure Functions y crear bots serverless." }
                            }
                        },
                        new EditionActivity
                        {
                            Type = Constants.ACTIVITY_TALK, Day = "Day 1", Track = "Track 1", Duration = "00:45:00", Date = "2019-10-05T16:45:00.000-0300", Level = "200", Tags = "DB, COntainers, Docker, Kubernetes",
                            Users = new List<EditionActivityUser> { new EditionActivityUser { User = uySpeaker4 } },
                            Details = new List<EditionActivityDetail>()
                            {
                                new EditionActivityDetail() { Language = Constants.LANGUAGES_ENGLISH, Title = "Corriendo Bases de Datos relacionales en Containers", Description = "Veremos como corres diferentes tipos de motores de base de datos en Docker y Kubernetes." }
                            }
                        },
                        new EditionActivity { Type = Constants.ACTIVITY_CLOSURE, Day = "Day 1", Track = "Track 1", Duration = "00:45:00", Date = "2019-10-05T17:30:00.000-0300", Details = new List<EditionActivityDetail>() {  new EditionActivityDetail() { Language = Constants.LANGUAGES_SPANISH, Title = "Cierre" } } },
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

                var coBuyLinks = new List<TicketLink>()
                {
                    new TicketLink { Url = "https://vopen-co-2020.eventbrite.com" },
                };
                var coBuyLinksJson = JsonConvert.SerializeObject(aryBuyLinks);

                var coEdition = new Edition
                {
                    Id = "vopen-co-2020",
                    Event = vopenEvent,
                    Details = new EditionDetail[]
                    {
                       new EditionDetail { Language = Constants.LANGUAGES_SPANISH, Name = "vOpen CO 2020", Date = "26 27 y 28 de Marzo de 2020" },
                       new EditionDetail { Language = Constants.LANGUAGES_ENGLISH, Name = "vOpen CO 2020", Date = "March 26th, 27th and 28th, 2020" }
                    },
                    LocationName = "Bogotá, Colombia",
                    LocationFullAddress = "Bogotá, Colombia",
                    EditionTickets =
                    {
                        new EditionTicket { Name = "Early birds", Price = "$120.000", StartDate = "2019-10-01T00:00:00.000-0500", EndDate = "2019-12-14T00:00:00.000-0500", BuyLinks = coBuyLinksJson },
                        new EditionTicket { Name = "Night owl", Price = "$210.000", StartDate = "2019-12-14T00:00:00.000-0500", EndDate = "2020-02-09T00:00:00.000-0500", BuyLinks = coBuyLinksJson },
                        new EditionTicket { Name = "General ticket", Price = "$297.900", StartDate = "2020-02-09T00:00:00.000-0500", EndDate = "2020-03-29T00:00:00.000-0500", BuyLinks = coBuyLinksJson },
                    },
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
                context.EditionsActivitiesUsers.RemoveRange(context.EditionsActivitiesUsers);
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
