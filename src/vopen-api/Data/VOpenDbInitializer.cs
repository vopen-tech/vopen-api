using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using vopen_api.Models;

namespace vopen_api.Data
{
    public static class VOpenDbInitializer
    {
        private static readonly string JAVIER_VILLEGAS_ID = Guid.NewGuid().ToString();
        private static readonly string MARIANO_VAZQUEZ_ID = "global-user1";
        private static readonly string FERNANDO_SONEGO_ID = Guid.NewGuid().ToString();
        private static readonly string VICTOR_SILVA_ID = Guid.NewGuid().ToString();

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

                var organizers = VOpenDbInitializer.CreateGlobalOrganizers(context);

                // Create sponsors
                var microsoft = new Sponsor
                {
                    Name = "Microsoft",
                    ImageUrl = "https://i.imgur.com/FWdDaGr.png",
                    Url = "https://www.microsoft.com"
                };
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
                var cobrosYa = new Sponsor
                {
                    Name = "CobrosYA",
                    ImageUrl = "https://i.imgur.com/M2mChJ5.png",
                    Url = "https://www.cobrosya.com/"
                };
                var uruIt = new Sponsor
                {
                    Name = "UruIT",
                    ImageUrl = "https://i.imgur.com/PNKsimP.png",
                    Url = "https://uruit.com/"
                };
                var uruguayXXI = new Sponsor
                {
                    Name = "UruguayXXI",
                    ImageUrl = "https://i.imgur.com/L4dAZKO.png",
                    Url = "https://www.uruguayxxi.gub.uy/"
                };
                var tcs = new Sponsor
                {
                    Name = "TCS",
                    ImageUrl = "https://i.imgur.com/rzNrslT.png",
                    Url = "https://www.tcs.com"
                };
                var smartTalent = new Sponsor
                {
                    Name = "SmartTalent",
                    ImageUrl = "https://i.imgur.com/TfIRhTX.png",
                    Url = "https://www.smarttalent.uy/"
                };
                var alianza = new Sponsor
                {
                    Name = "Alianza",
                    ImageUrl = "https://i.imgur.com/8bT4Zrt.png",
                    Url = "http://www.alianza.edu.uy/"
                };
                var practiaGlobal = new Sponsor
                {
                    Name = "Practia Global",
                    ImageUrl = "https://i.imgur.com/RMiN1j8.png",
                    Url = "http://www.practia.global"
                };
                var siderys = new Sponsor
                {
                    Name = "Siderys",
                    ImageUrl = "https://i.imgur.com/qL1C8lY.png",
                    Url = "http://www.siderys.com/"
                };
                var algeiba = new Sponsor
                {
                    Name = "Algeiba",
                    ImageUrl = "https://i.imgur.com/Ck8CwGs.png",
                    Url = "https://www.algeiba.com/"
                };
                var iTProve = new Sponsor
                {
                    Name = "iTProve",
                    ImageUrl = "https://i.imgur.com/nE9pcCY.png",
                    Url = "http://itprove.com.mx"
                };
                var softvision = new Sponsor
                {
                    Name = "Softvision",
                    ImageUrl = "https://i.imgur.com/vkvmrbA.jpg",
                    Url = "http://cognizantsoftvision.com"
                };
                var conosurtech = new Sponsor
                {
                    Name = "ConoSur Tech",
                    ImageUrl = "https://i.imgur.com/K3r2cDX.jpg",
                    Url = "https://www.facebook.com/ConoSurTech/"
                };

                var compartimoss = new Sponsor
                {
                    Name = "Compartimoss",
                    ImageUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn%3AANd9GcQIv0TjkapOCGS7enFYUJn8Afa0N7K83i990w&usqp=CAU",
                    Url = "http://www.compartimoss.com/"
                };
                var baufest = new Sponsor
                {
                    Name = "Baufest",
                    ImageUrl = "https://i.imgur.com/MnRLfw2.jpg",
                    Url = "http://www.baufest.com"
                };
                var hexacta = new Sponsor
                {
                    Name = "Hexacta",
                    ImageUrl = "https://i.imgur.com/KivtHyC.png",
                    Url = "https://www.hexacta.com/"
                };
                var distillery = new Sponsor
                {
                    Name = "Distillery",
                    ImageUrl = "https://i.imgur.com/H7HpSIr.jpg",
                    Url = "https://distillery.com/"
                };
                var southworks = new Sponsor
                {
                    Name = "Southworks",
                    ImageUrl = "https://i.imgur.com/29VaRrQ.jpg",
                    Url = "https://www.southworks.com/"
                };
                var mug = new Sponsor
                {
                    Name = "MUG",
                    ImageUrl = "https://i.imgur.com/ghNTejz.png",
                    Url = "http://www.mug-it.org.ar/"
                };

                context.Sponsors.Add(iTProve);
                context.Sponsors.Add(algeiba);
                context.Sponsors.Add(siderys);
                context.Sponsors.Add(microsoft);
                context.Sponsors.Add(kaizen);
                context.Sponsors.Add(endava);
                context.Sponsors.Add(wyeworks);
                context.Sponsors.Add(elObservador);
                context.Sponsors.Add(antel);
                context.Sponsors.Add(nareia);
                context.Sponsors.Add(cobrosYa);
                context.Sponsors.Add(uruIt);
                context.Sponsors.Add(uruguayXXI);
                context.Sponsors.Add(tcs);
                context.Sponsors.Add(smartTalent);
                context.Sponsors.Add(alianza);
                context.Sponsors.Add(practiaGlobal);
                context.Sponsors.Add(softvision);
                context.Sponsors.Add(conosurtech);
                context.Sponsors.Add(compartimoss);
                context.Sponsors.Add(baufest);
                context.Sponsors.Add(hexacta);
                context.Sponsors.Add(distillery);
                context.Sponsors.Add(southworks);
                context.Sponsors.Add(mug);

                var globalEdition2020Sponsors = new List<(Sponsor Sponsor, string Type)>
                {
                    (endava, "Gold"),
                    (softvision, "Gold"),
                    (iTProve, "Gold"),
                    (conosurtech, "Supporter"),
                    (compartimoss, "Supporter"),
                    (nareia, "Gold"),
                    (baufest, "Gold"),
                    (hexacta, "Gold"),
                    (distillery, "Supporter"),
                    (mug, "Supporter"),
                    (southworks, "Gold"),
                    (algeiba, "Gold"),
                    (kaizen, "Silver")
                };

                // Create global edition
                var globalEdition2020 = VOpenDbInitializer.CreateEdition2020(context, organizers, globalEdition2020Sponsors, vopenEvent);

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
                    Organizers = organizers.Where(c => c.Id.Contains("global-user")).Select(c => new EditionOrganizer { User = c }).ToList()
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

                // Create UY Edition
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
                new EditionTicket { Name = "Early birds", Price = "20USD", StartDate = "2019-08-19T16:00:00.000-03:00", EndDate = "2019-09-19T00:00:00.000-03:00", BuyLinks = uyBuyLinksJson },
                new EditionTicket { Name = "Night owl", Price = "40USD", StartDate = "2019-09-19T00:00:00.000-03:00", EndDate = "2019-10-24T00:00:00.000-03:00", BuyLinks = uyBuyLinksJson },
                // new EditionTicket { Name = "General ticket", Price = "60USD", StartDate = "2019-10-01T00:00:00.000Z", EndDate = "2019-10-24T00:00:00.000Z", BuyLinks = uyBuyLinksJson },
            },
                    Organizers = organizers.Where(c => !c.Id.Contains("global-user") && c.Country == Constants.COUNTRIES_URUGUAY).Select(c => new EditionOrganizer { User = c }).ToList(),
                    Sponsors = new List<EditionSponsor>()
            {
                // use a number for the ID because it is needed for the app mobile (will be removed later on)
                new EditionSponsor { Id = "1", Sponsor = microsoft, Type = Constants.SPONSOR_DIAMOND },
                new EditionSponsor { Id = "2", Sponsor = kaizen, Type = Constants.SPONSOR_GOLD },
                new EditionSponsor { Id = "3", Sponsor = endava, Type = Constants.SPONSOR_GOLD },
                new EditionSponsor { Id = "4", Sponsor = smartTalent, Type = Constants.SPONSOR_GOLD },
                new EditionSponsor { Id = "5", Sponsor = uruIt, Type = Constants.SPONSOR_GOLD },
                new EditionSponsor { Id = "6", Sponsor = antel, Type = Constants.SPONSOR_GOLD },
                new EditionSponsor { Id = "7", Sponsor = uruguayXXI, Type = Constants.SPONSOR_GOLD },
                new EditionSponsor { Id = "8", Sponsor = nareia, Type = Constants.SPONSOR_GOLD },
                new EditionSponsor { Id = "9", Sponsor = alianza, Type = Constants.SPONSOR_GOLD },
                new EditionSponsor { Id = "10", Sponsor = wyeworks, Type = Constants.SPONSOR_SILVER },
                new EditionSponsor { Id = "11", Sponsor = tcs, Type = Constants.SPONSOR_SILVER },
                new EditionSponsor { Id = "12", Sponsor = practiaGlobal, Type = Constants.SPONSOR_SILVER },
                new EditionSponsor { Id = "13", Sponsor = elObservador, Type = Constants.SPONSOR_SILVER },
                new EditionSponsor { Id = "14", Sponsor = cobrosYa, Type = Constants.SPONSOR_SILVER },
            },
                    Activities = VOpenDbInitializer.GetUyEditionActivities(context),
                };

                // Create CL Edition
                var clEdition = new Edition
                {
                    Id = "vopen-cl-2019",
                    Event = vopenEvent,
                    Details = new EditionDetail[]
                    {
                new EditionDetail { Language = Constants.LANGUAGES_SPANISH, Name = "vOpen CL 2020", Date = "14, 15 y 16 de Mayo"  },
                new EditionDetail { Language = Constants.LANGUAGES_ENGLISH, Name = "vOpen CL 2020", Date = "May 14th, 15th and 16th" }
                    },
                    LocationName = "Duoc UC: Sede Alonso de Ovalle",
                    LocationFullAddress = "Duoc UC: Sede Alonso de Ovalle, Santiago de Chile, Chile",
                    Organizers = organizers.Where(c => !c.Id.Contains("global-user") && c.Country == Constants.COUNTRIES_CHILE).Select(c => new EditionOrganizer { User = c }).ToList(),
                };

                // Create MX Edition
                var mxBuyLinks = new List<TicketLink>()
        {
            new TicketLink { Url = "https://vopen-mx-2020.eventbrite.com" },
        };
                var mxBuyLinksJson = JsonConvert.SerializeObject(mxBuyLinks);

                var mxEdition = new Edition
                {
                    Id = "vopen-mx-2019",
                    Event = vopenEvent,
                    Details = new EditionDetail[]
                    {
                new EditionDetail { Language = Constants.LANGUAGES_SPANISH, Name = "vOpen MX 2020", Date = "26, 27 y 28 de Marzo"  },
                new EditionDetail { Language = Constants.LANGUAGES_ENGLISH, Name = "vOpen MX 2020", Date = "March 26th, 27th and 28th" }
                    },
                    LocationName = "Tecnológico Nacional de México Campus Tlahuac",
                    LocationFullAddress = "Av Estanislao Ramírez Ruiz 301, Ciudad de México, Mexico",
                    Organizers = organizers.Where(c => !c.Id.Contains("global-user") && c.Country == Constants.COUNTRIES_MEXICO).Select(c => new EditionOrganizer { User = c }).ToList(),
                    Sponsors = new List<EditionSponsor>()
            {
                // use a number for the ID because it is needed for the app mobile (will be removed later on)
                new EditionSponsor { Id = "15", Sponsor = microsoft, Type = Constants.SPONSOR_DIAMOND },
                new EditionSponsor { Id = "19", Sponsor = iTProve, Type = Constants.SPONSOR_GOLD },
                new EditionSponsor { Id = "16", Sponsor = kaizen, Type = Constants.SPONSOR_DIGITAL },
                new EditionSponsor { Id = "17", Sponsor = siderys, Type = Constants.SPONSOR_DIGITAL },
                new EditionSponsor { Id = "18", Sponsor = algeiba, Type = Constants.SPONSOR_DIGITAL }
            },
                    EditionTickets = new List<EditionTicket>()
             {
                new EditionTicket { Name = "General ticket", Price = "Free", StartDate = "2020-03-01T00:00:00.000Z", EndDate = "2020-03-29T00:00:00.000Z", BuyLinks = mxBuyLinksJson },
             },
                };

                // Create AR Edition
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
                    Organizers = organizers.Where(c => !c.Id.Contains("global-user") && c.Country == Constants.COUNTRIES_ARGENTINA).Select(c => new EditionOrganizer { User = c }).ToList(),
                    EditionTickets = new List<EditionTicket>()
            {
                new EditionTicket { Name = "General ticket", Price = "Free", StartDate = "2019-09-01T00:00:00.000Z", EndDate = "2019-10-07T00:00:00.000Z", BuyLinks = arBuyLinksJson },
            },
                    Activities = VOpenDbInitializer.GetArEditionActivities(context),
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
                new EditionDetail { Language = Constants.LANGUAGES_SPANISH, Name = "vOpen CO 2020", Date = "Próximamente" },
                new EditionDetail { Language = Constants.LANGUAGES_ENGLISH, Name = "vOpen CO 2020", Date = "Soon" }
                    },
                    LocationName = "Bogotá, Colombia",
                    LocationFullAddress = "Bogotá, Colombia",
                    EditionTickets =
            {
                // new EditionTicket { Name = "Early birds", Price = "$120.000", StartDate = "2019-10-01T00:00:00.000-0500", EndDate = "2019-12-14T00:00:00.000-0500", BuyLinks = coBuyLinksJson },
                // new EditionTicket { Name = "Night owl", Price = "$210.000", StartDate = "2019-12-14T00:00:00.000-0500", EndDate = "2020-02-09T00:00:00.000-0500", BuyLinks = coBuyLinksJson },
                // new EditionTicket { Name = "General ticket", Price = "$297.900", StartDate = "2020-02-09T00:00:00.000-0500", EndDate = "2020-03-29T00:00:00.000-0500", BuyLinks = coBuyLinksJson },
            },
                    Organizers = organizers.Where(c => !c.Id.Contains("global-user") && c.Country == Constants.COUNTRIES_COLOMBIA).Select(c => new EditionOrganizer { User = c }).ToList(),
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
                    Organizers = organizers.Where(c => !c.Id.Contains("global-user") && c.Country == Constants.COUNTRIES_PERU).Select(c => new EditionOrganizer { User = c }).ToList(),
                };

                context.Editions.Add(globalEdition2020);
                context.Editions.Add(globalEdition);

                context.Editions.Add(clEdition);
                context.Editions.Add(mxEdition);

                context.Editions.Add(arEdition);
                context.Editions.Add(uyEdition);
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

        public static ICollection<User> CreateGlobalOrganizers(VOpenDbContext context)
        {
            var user1 = new User
            {
                Id = MARIANO_VAZQUEZ_ID,
                Country = Constants.COUNTRIES_ARGENTINA,
                ImageUrl = "https://i.imgur.com/14aAfJW.jpg",
                Details = new UserDetail[]
               {
            new UserDetail { Name = "Mariano Vazquez", Description = "", JobTitle = "Principal Software Engineer", Company = "MuleSoft", Language = Constants.LANGUAGES_SPANISH }
               },
                SocialLinks = new UserSocialLink[]
               {
            new UserSocialLink { Type = Constants.SOCIAL_LINKEDIN, Url = "https://www.linkedin.com/in/nanovazquez/" },
            new UserSocialLink { Type = Constants.SOCIAL_TWITTER, Url = "https://twitter.com/nanovazquez87" },
               }
            };
            var user3 = new User
            {
                Id = "global-user2",
                Country = Constants.COUNTRIES_ARGENTINA,
                ImageUrl = "https://i.imgur.com/iY5beT7.jpg",
                Details = new UserDetail[]
                {
              new UserDetail { Name = "Pablo Di Loreto", Description = "", JobTitle = "Service Manager", Company = "Algeiba", Language = Constants.LANGUAGES_SPANISH }
                },
                SocialLinks = new UserSocialLink[]
                {
              new UserSocialLink { Type = Constants.SOCIAL_LINKEDIN, Url = "https://ar.linkedin.com/in/pablodiloreto" },
              new UserSocialLink { Type = Constants.SOCIAL_TWITTER, Url = "https://twitter.com/pablodiloreto" },
                }
            };
            var user4 = new User
            {
                Id = "global-user3",
                Country = Constants.COUNTRIES_URUGUAY,
                ImageUrl = "https://i.imgur.com/KrNBexb.jpg",
                Details = new UserDetail[]
                {
                new UserDetail { Name = "Fabian Imaz", Description = "", JobTitle = "CEO", Company = "Siderys", Language = Constants.LANGUAGES_SPANISH }
                },
                SocialLinks = new UserSocialLink[]
                {
              new UserSocialLink { Type = Constants.SOCIAL_LINKEDIN, Url = "https://uy.linkedin.com/in/siderys" },
              new UserSocialLink { Type = Constants.SOCIAL_TWITTER, Url = "https://twitter.com/fabianimaz" },
                }
            };
            var user5 = new User
            {
                Id = "global-user4",
                Country = Constants.COUNTRIES_URUGUAY,
                ImageUrl = "https://i.imgur.com/vXLIy95.jpg",
                Details = new UserDetail[]
                {
                new UserDetail { Name = "Fabian Fernandez", Description = "", JobTitle = "VP Global Markets", Company = "Cuti", Language = Constants.LANGUAGES_SPANISH, }
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
                Id = VICTOR_SILVA_ID,
                Country = Constants.COUNTRIES_URUGUAY,
                ImageUrl = "https://imgur.com/TpW7cPF.jpg",
                Details = new UserDetail[]
                {
              new UserDetail { Name = "Victor Silva", Description = "", JobTitle = "DevOps and Cloud Architect", Company = "Pyxis", Language = Constants.LANGUAGES_SPANISH }
                },
                SocialLinks = new UserSocialLink[]
                {
              new UserSocialLink { Type = Constants.SOCIAL_LINKEDIN, Url = "https://www.linkedin.com/in/vmsilvamolina/" },
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
                ImageUrl = "https://i.imgur.com/JtRrcur.jpg",
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
                ImageUrl = "https://i.imgur.com/gCXf8rh.png",
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

            var user2 = new User
            {
                Country = Constants.COUNTRIES_ARGENTINA,
                ImageUrl = "https://i.imgur.com/4JpB16z.jpg",
                Details = new UserDetail[] { new UserDetail { Name = "Guillermo Bellmann", Description = "", Language = Constants.LANGUAGES_SPANISH } },
                SocialLinks = new UserSocialLink[]
               {
            new UserSocialLink { Type = Constants.SOCIAL_LINKEDIN, Url = "https://ar.linkedin.com/in/gbellmann" },
            new UserSocialLink { Type = Constants.SOCIAL_TWITTER, Url = "https://twitter.com/gjbellmann" },
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
              new UserSocialLink { Type = Constants.SOCIAL_LINKEDIN, Url = "https://www.linkedin.com/in/sergioborromei" },
              new UserSocialLink { Type = Constants.SOCIAL_TWITTER, Url = "https://twitter.com/SergioBLagash" },
          }
            };
            var user26 = new User
            {
                Country = Constants.COUNTRIES_CHILE,
                ImageUrl = "https://i.imgur.com/RNU3DyU.jpg",
                Details = new UserDetail[]
                {
              new UserDetail { Name = "Mario Valderrama", Description = "", Language = Constants.LANGUAGES_SPANISH,  }
                },
                SocialLinks = new UserSocialLink[]
                {
              new UserSocialLink { Type = Constants.SOCIAL_LINKEDIN, Url = "https://www.linkedin.com/in/mario-valderrama-silva-a8253b46/" },
              new UserSocialLink { Type = Constants.SOCIAL_TWITTER, Url = "https://twitter.com/MarioChep" },
                }
            };
            var user27 = new User
            {
                Country = Constants.COUNTRIES_CHILE,
                ImageUrl = "https://i.imgur.com/zn3VgQD.png",
                Details = new UserDetail[]
                {
              new UserDetail { Name = "Christian Kus", Description = "", Language = Constants.LANGUAGES_SPANISH,  }
                },
                SocialLinks = new UserSocialLink[]
                {
              new UserSocialLink { Type = Constants.SOCIAL_LINKEDIN, Url = "https://www.linkedin.com/in/christiankus/" },
              new UserSocialLink { Type = Constants.SOCIAL_TWITTER, Url = "https://twitter.com/christiankus" },
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

            // MX
            var user30 = new User
            {
                Country = Constants.COUNTRIES_MEXICO,
                ImageUrl = "https://i.imgur.com/4OmATPO.jpg",
                Details = new UserDetail[]
                 {
                new UserDetail { Name = "Christian Romano", Description = "", JobTitle = "Gerente de Infraestructura y Operaciones de TI", Company = "Universidad Latinoamericana", Language = Constants.LANGUAGES_SPANISH }
                 },
                SocialLinks = new UserSocialLink[]
                 {
                new UserSocialLink { Type = Constants.SOCIAL_LINKEDIN, Url = "https://www.linkedin.com/in/christianromanomvp/" },
                new UserSocialLink { Type = Constants.SOCIAL_TWITTER, Url = "https://twitter.com/shionfox" },
                 }
            };
            var user31 = new User
            {
                Country = Constants.COUNTRIES_MEXICO,
                ImageUrl = "https://i.imgur.com/i3wzW1v.jpg?1",
                Details = new UserDetail[]
                {
                new UserDetail { Name = "Fátima Jaydith Blancas Velázquez", Description = "", JobTitle = "CEO", Company = "iTProve Corporation", Language = Constants.LANGUAGES_SPANISH }
                },
                SocialLinks = new UserSocialLink[]
                {
                new UserSocialLink { Type = Constants.SOCIAL_LINKEDIN, Url = "https://www.linkedin.com/in/fatimablancasv/" },
                new UserSocialLink { Type = Constants.SOCIAL_TWITTER, Url = "https://twitter.com/JaydithBV" },
                }
            };
            var user32 = new User
            {
                Country = Constants.COUNTRIES_MEXICO,
                ImageUrl = "https://i.imgur.com/UY8abAH.jpg",
                Details = new UserDetail[]
                {
                new UserDetail { Name = "Roberto Correa", Description = "", JobTitle = "Gerente de Infraestructura", Company = "Comisión Nacional de Cultura Física y Deporte", Language = Constants.LANGUAGES_SPANISH }
                },
                SocialLinks = new UserSocialLink[]
                {
                new UserSocialLink { Type = Constants.SOCIAL_LINKEDIN, Url = "https://www.linkedin.com/in/roberto-correa-mart%C3%ADnez-450b8016/" },
                new UserSocialLink { Type = Constants.SOCIAL_TWITTER, Url = "https://twitter.com/Roberto_Correa_" },
                }
            };
            var user33 = new User
            {
                Country = Constants.COUNTRIES_MEXICO,
                ImageUrl = "https://i.imgur.com/jnOvbjH.jpg",
                Details = new UserDetail[]
                {
                new UserDetail { Name = "Julio César Leyva", Description = "", JobTitle = "Director de Operaciones", Company = "iTProve Corporation", Language = Constants.LANGUAGES_SPANISH }
                },
                SocialLinks = new UserSocialLink[]
                {
                new UserSocialLink { Type = Constants.SOCIAL_LINKEDIN, Url = "https://www.linkedin.com/in/julioleyva/" },
                new UserSocialLink { Type = Constants.SOCIAL_TWITTER, Url = "https://twitter.com/kexdat" },
                }
            };
            var user34 = new User
            {
                Country = Constants.COUNTRIES_MEXICO,
                ImageUrl = "https://i.imgur.com/iEG62Yn.jpg",
                Details = new UserDetail[]
                {
                new UserDetail { Name = "Rodolfo Castro", Description = "", JobTitle = "MS UC Consultant", Company = "Poly", Language = Constants.LANGUAGES_SPANISH }
                },
                SocialLinks = new UserSocialLink[]
                {
                new UserSocialLink { Type = Constants.SOCIAL_LINKEDIN, Url = "https://www.linkedin.com/in/rodolfomvp/" },
                new UserSocialLink { Type = Constants.SOCIAL_TWITTER, Url = "https://twitter.com/ucblogmx" },
                }
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
            context.Users.Add(user26);
            context.Users.Add(user27);
            context.Users.Add(user30);
            context.Users.Add(user31);
            context.Users.Add(user32);
            context.Users.Add(user33);
            context.Users.Add(user34);

            return new List<User>
        {
            user1, user2, user3, user4, user5, user6, user7, user8, user9, user12,
            user13, user14, user15, user16, user17, user18, user19, user20, user21,
            user22, user23, user24, user25, user26, user27, user30, user31, user32, user33, user34
        };
        }

        public static ICollection<User> CreateGlobalOrganizers2020(VOpenDbContext context)
        {
            var user1 = new User
            {
                Id = "global-user-2020-1",
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
            var user2 = new User
            {
                Id = "global-user-2020-2",
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
            var user3 = new User
            {
                Id = "global-user-2020-3",
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
            var user4 = new User
            {
                Id = "global-user-2020-4",
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
            var user5 = new User
            {
                Id = "global-user-2020-5",
                Country = Constants.COUNTRIES_ARGENTINA,
                ImageUrl = "https://i.imgur.com/gCXf8rh.png",
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
            var user6 = new User
            {
                Id = "global-user-2020-6",
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
            var user7 = new User
            {
                Id = "global-user-2020-7",
                Country = Constants.COUNTRIES_ARGENTINA,
                ImageUrl = "https://avatars2.githubusercontent.com/u/49730737?s=460&u=357f7b9e604eb0144002001ec24f9b25fac81d72&v=4",
                Details = new UserDetail[]
              {
          new UserDetail { Name = "Facundo La Rocca", Description = "", Language = Constants.LANGUAGES_SPANISH,  }
              },
                SocialLinks = new UserSocialLink[]
              {
          new UserSocialLink { Type = Constants.SOCIAL_LINKEDIN, Url = "https://www.linkedin.com/in/facundo-la-rocca/" },
          new UserSocialLink { Type = Constants.SOCIAL_TWITTER, Url = "https://twitter.com/TheRockFacu" },
              }
            };
            var user8 = new User
            {
                Id = "global-user-2020-8",
                Country = Constants.COUNTRIES_CHILE,
                ImageUrl = "https://i.imgur.com/RNU3DyU.jpg",
                Details = new UserDetail[]
                {
              new UserDetail { Name = "Mario Valderrama", Description = "", Language = Constants.LANGUAGES_SPANISH,  }
                },
                SocialLinks = new UserSocialLink[]
                {
              new UserSocialLink { Type = Constants.SOCIAL_LINKEDIN, Url = "https://www.linkedin.com/in/mario-valderrama-silva-a8253b46/" },
              new UserSocialLink { Type = Constants.SOCIAL_TWITTER, Url = "https://twitter.com/MarioChep" },
                }
            };
            var user9 = new User
            {
                Id = "global-user-2020-9",
                Country = Constants.COUNTRIES_CHILE,
                ImageUrl = "https://i.imgur.com/zn3VgQD.png",
                Details = new UserDetail[]
                {
              new UserDetail { Name = "Christian Kus", Description = "", Language = Constants.LANGUAGES_SPANISH,  }
                },
                SocialLinks = new UserSocialLink[]
                {
              new UserSocialLink { Type = Constants.SOCIAL_LINKEDIN, Url = "https://www.linkedin.com/in/christiankus/" },
              new UserSocialLink { Type = Constants.SOCIAL_TWITTER, Url = "https://twitter.com/christiankus" },
                }
            };
            var user10 = new User
            {
                Id = "global-user-2020-10",
                Country = Constants.COUNTRIES_MEXICO,
                ImageUrl = "https://i.imgur.com/4OmATPO.jpg",
                Details = new UserDetail[]
                 {
                new UserDetail { Name = "Christian Romano", Description = "", JobTitle = "Gerente de Infraestructura y Operaciones de TI", Company = "Universidad Latinoamericana", Language = Constants.LANGUAGES_SPANISH }
                 },
                SocialLinks = new UserSocialLink[]
                 {
                new UserSocialLink { Type = Constants.SOCIAL_LINKEDIN, Url = "https://www.linkedin.com/in/christianromanomvp/" },
                new UserSocialLink { Type = Constants.SOCIAL_TWITTER, Url = "https://twitter.com/shionfox" },
                 }
            };
            var user11 = new User
            {
                Id = "global-user-2020-11",
                Country = Constants.COUNTRIES_MEXICO,
                ImageUrl = "https://i.imgur.com/i3wzW1v.jpg?1",
                Details = new UserDetail[]
                {
                new UserDetail { Name = "Fátima Jaydith Blancas Velázquez", Description = "", JobTitle = "CEO", Company = "iTProve Corporation", Language = Constants.LANGUAGES_SPANISH }
                },
                SocialLinks = new UserSocialLink[]
                {
                new UserSocialLink { Type = Constants.SOCIAL_LINKEDIN, Url = "https://www.linkedin.com/in/fatimablancasv/" },
                new UserSocialLink { Type = Constants.SOCIAL_TWITTER, Url = "https://twitter.com/JaydithBV" },
                }
            };
            var user12 = new User
            {
                Id = "global-user-2020-12",
                Country = Constants.COUNTRIES_MEXICO,
                ImageUrl = "https://i.imgur.com/jnOvbjH.jpg",
                Details = new UserDetail[]
                {
                new UserDetail { Name = "Julio César Leyva", Description = "", JobTitle = "Director de Operaciones", Company = "iTProve Corporation", Language = Constants.LANGUAGES_SPANISH }
                },
                SocialLinks = new UserSocialLink[]
                {
                new UserSocialLink { Type = Constants.SOCIAL_LINKEDIN, Url = "https://www.linkedin.com/in/julioleyva/" },
                new UserSocialLink { Type = Constants.SOCIAL_TWITTER, Url = "https://twitter.com/kexdat" },
                }
            };
            var user13 = new User
            {
                Id = "global-user-2020-13",
                Country = Constants.COUNTRIES_MEXICO,
                ImageUrl = "https://i.imgur.com/iEG62Yn.jpg",
                Details = new UserDetail[]
                {
                new UserDetail { Name = "Rodolfo Castro", Description = "", JobTitle = "MS UC Consultant", Company = "Poly", Language = Constants.LANGUAGES_SPANISH }
                },
                SocialLinks = new UserSocialLink[]
                {
                new UserSocialLink { Type = Constants.SOCIAL_LINKEDIN, Url = "https://www.linkedin.com/in/rodolfomvp/" },
                new UserSocialLink { Type = Constants.SOCIAL_TWITTER, Url = "https://twitter.com/ucblogmx" },
                }
            };
            var user14 = new User
            {
                Id = "global-user-2020-14",
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

            return new List<User>
      {
        user1, user2, user3, user4, user5, user6,
        user7, user8, user9, user10, user11, user12,
        user13, user14
      };
        }

        public static ICollection<EditionActivity> GetArEditionActivities(VOpenDbContext context)
        {
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
            var arSpeaker5 = context.Users.Find(FERNANDO_SONEGO_ID);
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

            var uySpeaker4 = context.Users.Find(JAVIER_VILLEGAS_ID);

            return new List<EditionActivity>
      {
        new EditionActivity { Type = Constants.ACTIVITY_ACCREDITATION_BREAKFAST, Day = "Day 1", Track = "Track 1", Duration = "00:30:00", Date = "2019-10-05T08:30:00.000-03:00", Details = new List<EditionActivityDetail>() {  new EditionActivityDetail() { Language = Constants.LANGUAGES_SPANISH, Title = "Acreditación y desayuno" } } },
        new EditionActivity { Type = Constants.ACTIVITY_OPENING, Day = "Day 1", Track = "Track 1", Duration = "00:30:00", Date = "2019-10-05T09:00:00.000-03:00", Details = new List<EditionActivityDetail>() {  new EditionActivityDetail() { Language = Constants.LANGUAGES_SPANISH, Title = "Apertura" } } },
        new EditionActivity
        {
            Type = Constants.ACTIVITY_KEYNOTE, Day = "Day 1", Track = "Track 1", Duration = "00:45:00", Date = "2019-10-05T09:30:00.000-03:00", Level = "100", Tags = "startups, knowledge",
            Users = new List<EditionActivityUser> { new EditionActivityUser { User = arSpeaker1 } },
            Details = new List<EditionActivityDetail>()
            {
                new EditionActivityDetail() { Language = Constants.LANGUAGES_SPANISH, Title = "El gap entre tecnología, adopción y talento en las organizaciones: ¿estás preparado para diferenciarte?", Description = "La velocidad de cambio de la tecnología es mucho mayor a la velocidad de adopción que tienen las empresas. Y aquellas empresas que inician una transformación tecnológica se enfrentan con el desafío de contar con los colaboradores que sepan cómo abordarla. Existe un GAP entre tecnología disponible, tecnología adoptada y talento. La escasez de talento analítico y de habilidades de desaprendizaje y aprendizaje continuo representan un gran desafío y una buena oportunidad para diferenciarte del resto. Hoy el saber importa y vale, pero la capacidad de repensarse a uno mismo y la disposición para aprender sobre nuevos temas, son las competencias estratégicas esenciales para el presente y futuro próximo. En esta charla repasaremos algunos conceptos clave y consejos que te ayudarán a liberar todo tu potencial. ¿Estás preparado?" }
            }
        },
        new EditionActivity
        {
            Type = Constants.ACTIVITY_TALK, Day = "Day 1", Track = "Track 1", Duration = "00:45:00", Date = "2019-10-05T10:15:00.000-03:00", Level = "300", Tags = "APIs, cloud, backend",
            Users = new List<EditionActivityUser> { new EditionActivityUser { User = arSpeaker2 }, new EditionActivityUser { User = arSpeaker3 } },
            Details = new List<EditionActivityDetail>()
            {
                new EditionActivityDetail() { Language = Constants.LANGUAGES_SPANISH, Title = "Un camino pragmatico a la simplificacion de infraestructura de APIs", Description = "Kong, nginx, WSO2, AWS API Manager, todo muy lindo, es fácil poner un API GW. Queremos mostrar cómo hacemos en Medallia para brindar soporte para APIs muy heterogéneas que tienen desde 3 requests por día, hasta high-performance APIs de millones de requests por minuto." }
            }
        },
        new EditionActivity { Type = Constants.ACTIVITY_COFFEE_BREAK, Day = "Day 1", Track = "Track 1", Duration = "00:30:00", Date = "2019-10-05T11:00:00.000-03:00", Details = new List<EditionActivityDetail>() {  new EditionActivityDetail() { Language = Constants.LANGUAGES_SPANISH, Title = "Coffee break" } } },
        new EditionActivity
        {
            Type = Constants.ACTIVITY_TALK, Day = "Day 1", Track = "Track 1", Duration = "00:45:00", Date = "2019-10-05T11:30:00.000-03:00", Level = "100", Tags = "storage, Azure, cloud",
            Users = new List<EditionActivityUser> { new EditionActivityUser { User = arSpeaker4 } },
            Details = new List<EditionActivityDetail>()
            {
                new EditionActivityDetail() { Language = Constants.LANGUAGES_SPANISH, Title = "Eligiendo el servicio correcto de data storage en Azure", Description = "Azure, la nube de Microsoft, esta compuesta de cientos de servicios y productos de los cuales 19 están relacionados al almacenamiento de datos. En esta charla hablaremos de estos servicios, sus pros y cons, como elegir uno adecuado para cada problema y cómo son usados en FishAngler.com." }
            }
        },
        new EditionActivity
        {
            Type = Constants.ACTIVITY_TALK, Day = "Day 1", Track = "Track 1", Duration = "00:45:00", Date = "2019-10-05T12:15:00.000-03:00", Level = "100", Tags = "cloud, Azure, AWS",
            Users = new List<EditionActivityUser> { new EditionActivityUser { User = arSpeaker5 } },
            Details = new List<EditionActivityDetail>()
            {
                new EditionActivityDetail() { Language = Constants.LANGUAGES_SPANISH, Title = "Azure vs AWS: Guía de Servicios en la Nube", Description = "La elección de un proveedor de servicios en la nube es una gran decisión. Entender cuales se adaptan mejor a tus requerimientos te permitirán ahorrar costos significativos. En esta charla vas a conocer y entender varios de los servicios que ofrecen Microsoft y Amazon, sus similitudes y diferencias." }
            }
        },
        new EditionActivity { Type = Constants.ACTIVITY_LUNCH, Day = "Day 1", Track = "Track 1", Duration = "01:00:00", Date = "2019-10-05T13:00:00.000-03:00", Details = new List<EditionActivityDetail>() {  new EditionActivityDetail() { Language = Constants.LANGUAGES_SPANISH, Title = "Almuerzo" } } },
        new EditionActivity
        {
            Type = Constants.ACTIVITY_TALK, Day = "Day 1", Track = "Track 1", Duration = "00:45:00", Date = "2019-10-05T14:00:00.000-03:00", Level = "200", Tags = "AI, Azure, Kinect",
            Users = new List<EditionActivityUser> { new EditionActivityUser { User = arSpeaker6 } },
            Details = new List<EditionActivityDetail>()
            {
                new EditionActivityDetail() { Language = Constants.LANGUAGES_ENGLISH, Title = "Azure Kinect + AI development “Third era of computing”", Description = "AI is predicted to be the third era of computing. Now it´s also becoming cloud-based which means that even the most sophisticated techniques become available to everybody. The key is, using the Azure Kinect to provide data, then use it to train machine-learning systems, feed image- and text-recognition services, perform speech recognition, and so on. Let me show you how this can be accomplished." }
            }
        },
        new EditionActivity
        {
            Type = Constants.ACTIVITY_TALK, Day = "Day 1", Track = "Track 1", Duration = "00:45:00", Date = "2019-10-05T14:45:00.000-03:00", Level = "200", Tags = "AI, Deep Learning, Go",
            Users = new List<EditionActivityUser> { new EditionActivityUser { User = arSpeaker7 } },
            Details = new List<EditionActivityDetail>()
            {
                new EditionActivityDetail() { Language = Constants.LANGUAGES_ENGLISH, Title = "Deep Learning y el Juego del Go", Description = "Descripción del juego del Go y cómo una implementación de Deep Learning con Reinforcement Learning llegó a derrotar al mejor jugador humano." }
            }
        },
        new EditionActivity { Type = Constants.ACTIVITY_COFFEE_BREAK, Day = "Day 1", Track = "Track 1", Duration = "00:30:00", Date = "2019-10-05T15:30:00.000-03:00", Details = new List<EditionActivityDetail>() {  new EditionActivityDetail() { Language = Constants.LANGUAGES_SPANISH, Title = "Coffee break" } } },
            new EditionActivity
        {
            Type = Constants.ACTIVITY_TALK, Day = "Day 1", Track = "Track 1", Duration = "00:45:00", Date = "2019-10-05T16:00:00.000-03:00", Level = "200", Tags = "Serverless, Azure, Bots",
            Users = new List<EditionActivityUser> { new EditionActivityUser { User = arSpeaker8 } },
            Details = new List<EditionActivityDetail>()
            {
                new EditionActivityDetail() { Language = Constants.LANGUAGES_ENGLISH, Title = "Bots + Azure Functions", Description = "Como conectar BotFramework v4 con Azure Functions y crear bots serverless." }
            }
        },
        new EditionActivity
        {
            Type = Constants.ACTIVITY_TALK, Day = "Day 1", Track = "Track 1", Duration = "00:45:00", Date = "2019-10-05T16:45:00.000-03:00", Level = "200", Tags = "DB, COntainers, Docker, Kubernetes",
            Users = new List<EditionActivityUser> { new EditionActivityUser { User = uySpeaker4 } },
            Details = new List<EditionActivityDetail>()
            {
                new EditionActivityDetail() { Language = Constants.LANGUAGES_ENGLISH, Title = "Corriendo Bases de Datos relacionales en Containers", Description = "Veremos como corres diferentes tipos de motores de base de datos en Docker y Kubernetes." }
            }
        },
        new EditionActivity { Type = Constants.ACTIVITY_CLOSURE, Day = "Day 1", Track = "Track 1", Duration = "00:45:00", Date = "2019-10-05T17:30:00.000-03:00", Details = new List<EditionActivityDetail>() {  new EditionActivityDetail() { Language = Constants.LANGUAGES_SPANISH, Title = "Cierre" } } },
      };
        }

        public static ICollection<EditionActivity> GetUyEditionActivities(VOpenDbContext context)
        {
            var uySpeaker1 = new User
            {
                Country = Constants.COUNTRIES_URUGUAY,
                ImageUrl = "https://pbs.twimg.com/profile_images/540333239387557888/BezHW_ii_400x400.jpeg",
                Details = new UserDetail[]
                {
              new UserDetail { Name = "Gastón Milano", Description = "", JobTitle = "CTO", Company = "GeneXus", Language = Constants.LANGUAGES_SPANISH }
                },
                SocialLinks = new UserSocialLink[]
                {
              new UserSocialLink { Type = Constants.SOCIAL_LINKEDIN, Url = "https://www.linkedin.com/in/gastonmilano" },
              new UserSocialLink { Type = Constants.SOCIAL_TWITTER, Url = "https://twitter.com/GMilano" },
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
                Id = JAVIER_VILLEGAS_ID,
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
                ImageUrl = "https://i.imgur.com/1epkuZZ.jpg",
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

            var uySpeaker8 = new User
            {
                Country = Constants.COUNTRIES_CUBA,
                ImageUrl = "https://media.licdn.com/dms/image/C4E03AQHfoMQZOieQNQ/profile-displayphoto-shrink_800_800/0?e=1575504000&v=beta&t=bCcx9zY3xXZFKcVYVnrYTW8guvU3l71pWkymykhuw0c",
                Details = new UserDetail[]
                {
              new UserDetail { Name = "Lisandra Armas Águila", Description = "", JobTitle = "Senior QA Engineer", Company = "Abstracta", Language = Constants.LANGUAGES_SPANISH }
                },
                SocialLinks = new UserSocialLink[]
                {
              new UserSocialLink { Type = Constants.SOCIAL_LINKEDIN, Url = "https://www.linkedin.com/in/lisandra-armas-aguila/" },
              new UserSocialLink { Type = Constants.SOCIAL_TWITTER, Url = "https://twitter.com/lisyarmas" },
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
                Country = Constants.COUNTRIES_ARGENTINA,
                ImageUrl = "https://i.imgur.com/sQNWlwN.jpg",
                Details = new UserDetail[]
                {
              new UserDetail { Name = "Sebastián Perez", Description = "", JobTitle = "Ethereum Instructor", Company = "Blockchain Academy Chile", Language = Constants.LANGUAGES_SPANISH }
                },
                SocialLinks = new UserSocialLink[]
                {
              new UserSocialLink { Type = Constants.SOCIAL_LINKEDIN, Url = "https://www.linkedin.com/in/sebaleoperez/" },
              new UserSocialLink { Type = Constants.SOCIAL_TWITTER, Url = "https://twitter.com/sebaleoperez" },
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
            var uySpeaker13 = new User
            {
                Country = Constants.COUNTRIES_UNITED_STATES,
                ImageUrl = "https://media.licdn.com/dms/image/C4E03AQE1QonvgdIp5A/profile-displayphoto-shrink_800_800/0?e=1574294400&v=beta&t=0y8T5at1V6Hnte5Nbz1aS1cYqOiLet9R5tTG05z03Jg",
                Details = new UserDetail[]
                {
              new UserDetail { Name = "Jd Marymee", Description = "", JobTitle = "Architect", Company = "Microsoft", Language = Constants.LANGUAGES_SPANISH }
                },
                SocialLinks = new UserSocialLink[]
                {
              new UserSocialLink { Type = Constants.SOCIAL_LINKEDIN, Url = "https://www.linkedin.com/in/jmarymee/ " }
                }
            };
            var uySpeaker14 = new User
            {
                Country = Constants.COUNTRIES_BRAZIL,
                ImageUrl = "https://aboutme.imgix.net/background/users/g/l/a/glauter_1542132760_393.jpg",
                Details = new UserDetail[]
                {
              new UserDetail { Name = "Glauter Jannuzzi", Description = "", JobTitle = "CPM", Company = "Microsoft", Language = Constants.LANGUAGES_SPANISH }
                },
                SocialLinks = new UserSocialLink[]
                {
              new UserSocialLink { Type = Constants.SOCIAL_LINKEDIN, Url = "https://www.linkedin.com/in/jannuzzi/ " },
              new UserSocialLink { Type = Constants.SOCIAL_TWITTER, Url = "https://twitter.com/glauterj" },
                }
            };
            var uySpeaker15 = new User
            {
                Country = Constants.COUNTRIES_URUGUAY,
                ImageUrl = "https://media.licdn.com/dms/image/C4E03AQHQTmJRVUp8CA/profile-displayphoto-shrink_800_800/0?e=1574899200&v=beta&t=9DULpuODChZJqDcLLlz9cJwmKD81Lc9a8izWvJmsmeQ",
                Details = new UserDetail[]
                {
              new UserDetail { Name = "Sebastián Gómez", Description = "", JobTitle = "Sr. Software Engineer", Company = "GeneXus", Language = Constants.LANGUAGES_SPANISH }
                },
                SocialLinks = new UserSocialLink[]
                {
              new UserSocialLink { Type = Constants.SOCIAL_LINKEDIN, Url = "https://www.linkedin.com/in/sebagomez/ " },
              new UserSocialLink { Type = Constants.SOCIAL_TWITTER, Url = "https://twitter.com/sebagomez" },
                }
            };
            var uySpeaker16 = new User
            {
                Country = Constants.COUNTRIES_URUGUAY,
                ImageUrl = "https://elixirconf.com/2019/images/speakers/jorge-bejar.jpg",
                Details = new UserDetail[]
                {
              new UserDetail { Name = "Jorge Bejar", Description = "", JobTitle = "CTO", Company = "WyeWorks", Language = Constants.LANGUAGES_SPANISH }
                },
                SocialLinks = new UserSocialLink[]
                {
              new UserSocialLink { Type = Constants.SOCIAL_LINKEDIN, Url = "https://www.linkedin.com/in/jorge-bejar/ " },
              new UserSocialLink { Type = Constants.SOCIAL_TWITTER, Url = "https://twitter.com/jmbejar" },
                }
            };
            var uySpeaker17 = new User
            {
                Country = Constants.COUNTRIES_VENEZUELA,
                ImageUrl = "https://i.imgur.com/b16oH4A.jpg",
                Details = new UserDetail[]
                {
              new UserDetail { Name = "Roygar Briceño", Description = "", JobTitle = "Cloud Solution Architect", Company = "Arkano", Language = Constants.LANGUAGES_SPANISH }
                },
                SocialLinks = new UserSocialLink[]
                {
              new UserSocialLink { Type = Constants.SOCIAL_LINKEDIN, Url = "https://www.linkedin.com/in/roygarbriceno/ " },
              new UserSocialLink { Type = Constants.SOCIAL_TWITTER, Url = "https://twitter.com/roygarbriceno" },
                }
            };
            var uySpeaker18 = new User
            {
                Country = Constants.COUNTRIES_BRAZIL,
                ImageUrl = "https://media.licdn.com/dms/image/C4D03AQF9rOyx-QYLZw/profile-displayphoto-shrink_800_800/0?e=1574294400&v=beta&t=syPlaKRmb7rXPyrD-DyBufZMxAYTxdrYIjIjyEvd2TQ",
                Details = new UserDetail[]
                {
              new UserDetail { Name = "Viviane Martins Ferreira", Description = "", JobTitle = "Security And Analytics Consultant", Company = "IBM", Language = Constants.LANGUAGES_SPANISH }
                },
                SocialLinks = new UserSocialLink[]
                {
              new UserSocialLink { Type = Constants.SOCIAL_LINKEDIN, Url = "https://www.linkedin.com/in/vivianemartinsoficial/ " },
              new UserSocialLink { Type = Constants.SOCIAL_TWITTER, Url = "https://twitter.com/vbanaveia" },
                }
            };
            var uySpeaker19 = new User
            {
                Country = Constants.COUNTRIES_BRAZIL,
                // ImageUrl = "https://i.imgur.com/vu2PtZl.png",
                ImageUrl = "https://i.imgur.com/SHyfZmK.png",
                Details = new UserDetail[]
                {
              new UserDetail { Name = "Erick Wendel", Description = "", JobTitle = "Lead Software Architect", Company = "Beetech Global", Language = Constants.LANGUAGES_SPANISH }
                },
                SocialLinks = new UserSocialLink[]
                {
              new UserSocialLink { Type = Constants.SOCIAL_LINKEDIN, Url = "https://www.linkedin.com/in/erickwendel/ " },
              new UserSocialLink { Type = Constants.SOCIAL_TWITTER, Url = "https://twitter.com/erickwendel_" },
                }
            };
            var uySpeaker20 = new User
            {
                Country = Constants.COUNTRIES_BRAZIL,
                ImageUrl = "https://www.sqlsaturday.com/images/speakers/7040-8624a3c6.jpg",
                Details = new UserDetail[]
                {
              new UserDetail { Name = "Luis Nascimento Serra", Description = "", JobTitle = "Socio Proprietario", Company = "Excelência Soluções Empresariais", Language = Constants.LANGUAGES_SPANISH }
                },
                SocialLinks = new UserSocialLink[]
                {
              new UserSocialLink { Type = Constants.SOCIAL_LINKEDIN, Url = "https://www.linkedin.com/in/luisgnserra/ " }
                }
            };
            var uySpeaker21 = new User
            {
                Country = Constants.COUNTRIES_ARGENTINA,
                ImageUrl = "https://media.licdn.com/dms/image/C4E03AQF8DtVxG_clOw/profile-displayphoto-shrink_200_200/0?e=1572480000&v=beta&t=nX8jQDQKtbfXq1AZB3fjkaBb2omeI3thi6zNneJxZbM",
                Details = new UserDetail[]
                {
              new UserDetail { Name = "Esteban Mellado", Description = "", JobTitle = "Developer", Company = "Algeiba", Language = Constants.LANGUAGES_SPANISH }
                },
                SocialLinks = new UserSocialLink[]
                {
              new UserSocialLink { Type = Constants.SOCIAL_LINKEDIN, Url = "https://www.linkedin.com/in/esteban-mellado-30179315a/ " },
              new UserSocialLink { Type = Constants.SOCIAL_TWITTER, Url = "https://twitter.com/m_esteban90" },
                }
            };
            var uySpeaker22 = new User
            {
                Country = Constants.COUNTRIES_ARGENTINA,
                ImageUrl = "http://www.hardkoded.com/img/avatar-icon.png",
                Details = new UserDetail[]
                {
              new UserDetail { Name = "Dario Kondratiuk", Description = "", JobTitle = "Tech Lead", Company = "MultiTracks.com", Language = Constants.LANGUAGES_SPANISH }
                },
                SocialLinks = new UserSocialLink[]
                {
              new UserSocialLink { Type = Constants.SOCIAL_LINKEDIN, Url = "https://www.linkedin.com/in/darío-kondratiuk/ " },
              new UserSocialLink { Type = Constants.SOCIAL_TWITTER, Url = "https://twitter.com/hardkoded" },
                }
            };
            var uySpeaker23 = new User
            {
                Country = Constants.COUNTRIES_URUGUAY,
                ImageUrl = "https://i.imgur.com/i6xy8fD.jpg",
                Details = new UserDetail[]
                {
              new UserDetail { Name = "Sebastián Passaro", Description = "", JobTitle = "FullStack developer", Company = "Urudata Software", Language = Constants.LANGUAGES_SPANISH }
                },
                SocialLinks = new UserSocialLink[]
                {
              new UserSocialLink { Type = Constants.SOCIAL_LINKEDIN, Url = "https://www.linkedin.com/in/sebastian-passaro-50057342/ " },
              new UserSocialLink { Type = Constants.SOCIAL_TWITTER, Url = "https://twitter.com/spassarop" },
                }
            };
            var uySpeaker24 = new User
            {
                Country = Constants.COUNTRIES_URUGUAY,
                ImageUrl = "https://i.imgur.com/yEHZCpg.jpg",
                Details = new UserDetail[]
                {
              new UserDetail { Name = "Guillermo Skrilec", Description = "", JobTitle = "CEO", Company = "QAlified", Language = Constants.LANGUAGES_SPANISH }
                },
                SocialLinks = new UserSocialLink[]
                {
              new UserSocialLink { Type = Constants.SOCIAL_LINKEDIN, Url = "https://www.linkedin.com/in/gskrilec/ " },
              new UserSocialLink { Type = Constants.SOCIAL_TWITTER, Url = "https://twitter.com/gskrilec" },
                }
            };
            var uySpeaker25 = new User
            {
                Country = Constants.COUNTRIES_ARGENTINA,
                ImageUrl = "https://pbs.twimg.com/profile_images/819924951419518976/BQOmtetK_400x400.jpg",
                Details = new UserDetail[]
                {
              new UserDetail { Name = "Sebastian Gambolati", Description = "", JobTitle = "FullStack developer", Company = "MelonTech", Language = Constants.LANGUAGES_SPANISH }
                },
                SocialLinks = new UserSocialLink[]
                {
              new UserSocialLink { Type = Constants.SOCIAL_LINKEDIN, Url = "https://www.linkedin.com/in/sgambolati/ " },
              new UserSocialLink { Type = Constants.SOCIAL_TWITTER, Url = "https://twitter.com/sggambolati" },
                }
            };
            var uySpeaker26 = new User
            {
                Id = FERNANDO_SONEGO_ID,
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
            var uySpeaker27 = new User
            {
                Country = Constants.COUNTRIES_URUGUAY,
                ImageUrl = "https://i.imgur.com/2xm6Dwu.jpg",
                Details = new UserDetail[]
                {
              new UserDetail { Name = "Noelia Lencina", Description = "", JobTitle = "Software Developer", Company = "WyeWorks", Language = Constants.LANGUAGES_SPANISH }
                },
                SocialLinks = new UserSocialLink[]
                {
              new UserSocialLink { Type = Constants.SOCIAL_LINKEDIN, Url = "https://www.linkedin.com/in/noelia-lencina-alfonso-ab3472130/" },
                }
            };
            var uySpeaker28 = new User
            {
                Country = Constants.COUNTRIES_URUGUAY,
                ImageUrl = "https://i.imgur.com/y2tVHDd.jpg",
                Details = new UserDetail[]
                {
              new UserDetail { Name = "Nicolás Ferraro", Description = "", JobTitle = "Software Developer", Company = "WyeWorks", Language = Constants.LANGUAGES_SPANISH }
                },
                SocialLinks = new UserSocialLink[] { }
            };
            var uySpeaker29 = new User
            {
                Country = Constants.COUNTRIES_URUGUAY,
                ImageUrl = "https://i.imgur.com/Si1Ru7F.jpg",
                Details = new UserDetail[]
                {
              new UserDetail { Name = "Tomás Facal", Description = "", JobTitle = "Full Stack Developer", Company = "IBM", Language = Constants.LANGUAGES_SPANISH }
                },
                SocialLinks = new UserSocialLink[]
                {
              new UserSocialLink { Type = Constants.SOCIAL_LINKEDIN, Url = "https://www.linkedin.com/in/tomas-facal-0945a6193/" },
                }
            };
            var uySpeaker30 = new User
            {
                Country = Constants.COUNTRIES_ARGENTINA,
                ImageUrl = "https://i.imgur.com/TFhYd9Y.jpg",
                Details = new UserDetail[]
                {
              new UserDetail { Name = "Jonathan Smirnoff", Description = "", JobTitle = "Blockchain Developer", Company = "IOV Labs", Language = Constants.LANGUAGES_SPANISH }
                },
                SocialLinks = new UserSocialLink[]
                {
              new UserSocialLink { Type = Constants.SOCIAL_LINKEDIN, Url = "https://www.linkedin.com/in/jonathan-smirnoff-85272210" },
              new UserSocialLink { Type = Constants.SOCIAL_TWITTER, Url = "https://twitter.com/jonysmirnoff" }
                }
            };
            var uySpeaker31 = new User
            {
                Country = Constants.COUNTRIES_URUGUAY,
                ImageUrl = "https://i.imgur.com/tGNdqfg.jpg",
                Details = new UserDetail[]
                {
              new UserDetail { Name = "Sebastián Vergara", Description = "", JobTitle = "CTO at IBM Uruguay/Paraguay", Company = "IBM", Language = Constants.LANGUAGES_SPANISH }
                },
                SocialLinks = new UserSocialLink[]
                {
              new UserSocialLink { Type = Constants.SOCIAL_LINKEDIN, Url = "https://www.linkedin.com/in/sebastian-vergara/" }
                }
            };
            var uySpeaker32 = new User
            {
                Country = Constants.COUNTRIES_URUGUAY,
                ImageUrl = "https://i.imgur.com/fcfOzjA.jpg",
                Details = new UserDetail[]
                {
              new UserDetail { Name = "Jose Panizza", Description = "", JobTitle = "Full Stack Developer", Company = "IBM", Language = Constants.LANGUAGES_SPANISH }
                },
                SocialLinks = new UserSocialLink[]
                {
              new UserSocialLink { Type = Constants.SOCIAL_LINKEDIN, Url = "https://www.linkedin.com/in/jose-ignacio-panizza/" }
                }
            };
            var uySpeaker33 = new User
            {
                Country = Constants.COUNTRIES_CUBA,
                ImageUrl = "https://i.imgur.com/S747dlQ.jpg",
                Details = new UserDetail[]
                {
              new UserDetail { Name = "Yoelvis Mulen", Description = "", JobTitle = "Senior Full Stack Engineer", Company = "Modus Create, Inc", Language = Constants.LANGUAGES_SPANISH }
                },
                SocialLinks = new UserSocialLink[]
                {
              new UserSocialLink { Type = Constants.SOCIAL_LINKEDIN, Url = "https://www.linkedin.com/in/yoelvismulen/" },
              new UserSocialLink { Type = Constants.SOCIAL_TWITTER, Url = "https://twitter.com/ymulenll" }
                }
            };
            var uySpeaker34 = new User
            {
                Country = Constants.COUNTRIES_URUGUAY,
                ImageUrl = "https://i.imgur.com/OIvEWKx.jpg",
                Details = new UserDetail[]
                {
              new UserDetail { Name = "Abel Quintana", Description = "", JobTitle = "Software Developer Engineer in Test", Company = "TravelGenio", Language = Constants.LANGUAGES_SPANISH }
                },
                SocialLinks = new UserSocialLink[]
                {
              new UserSocialLink { Type = Constants.SOCIAL_LINKEDIN, Url = "https://www.linkedin.com/in/abel-quintana-lopez-371a31b9/" },
              new UserSocialLink { Type = Constants.SOCIAL_TWITTER, Url = "https://twitter.com/beloquintana" }
                }
            };
            var uySpeaker35 = new User
            {
                Country = Constants.COUNTRIES_URUGUAY,
                ImageUrl = "https://i.imgur.com/trm2Av1.png",
                Details = new UserDetail[]
                {
              new UserDetail { Name = "Alfredo Quintana Lopez", Description = "", JobTitle = "Tech Lead", Company = "TravelGenio", Language = Constants.LANGUAGES_SPANISH }
                },
                SocialLinks = new UserSocialLink[]
                {
              new UserSocialLink { Type = Constants.SOCIAL_LINKEDIN, Url = "https://www.linkedin.com/in/alfredo-quintana-l%C3%B3pez-b46a3095/" },
              new UserSocialLink { Type = Constants.SOCIAL_TWITTER, Url = "https://twitter.com/alfreql" }
                }
            };

            context.Users.Add(uySpeaker1);
            context.Users.Add(uySpeaker2);
            context.Users.Add(uySpeaker3);
            context.Users.Add(uySpeaker4);
            context.Users.Add(uySpeaker5);
            context.Users.Add(uySpeaker6);
            context.Users.Add(uySpeaker7);
            context.Users.Add(uySpeaker8);
            context.Users.Add(uySpeaker9);
            context.Users.Add(uySpeaker10);
            context.Users.Add(uySpeaker11);
            context.Users.Add(uySpeaker12);
            context.Users.Add(uySpeaker13);
            context.Users.Add(uySpeaker14);
            context.Users.Add(uySpeaker15);
            context.Users.Add(uySpeaker16);
            context.Users.Add(uySpeaker17);
            context.Users.Add(uySpeaker18);
            context.Users.Add(uySpeaker19);
            context.Users.Add(uySpeaker20);
            context.Users.Add(uySpeaker21);
            context.Users.Add(uySpeaker22);
            context.Users.Add(uySpeaker23);
            context.Users.Add(uySpeaker24);
            context.Users.Add(uySpeaker25);
            context.Users.Add(uySpeaker26);
            context.Users.Add(uySpeaker27);
            context.Users.Add(uySpeaker28);
            context.Users.Add(uySpeaker29);
            context.Users.Add(uySpeaker30);
            context.Users.Add(uySpeaker31);
            context.Users.Add(uySpeaker32);
            context.Users.Add(uySpeaker33);
            context.Users.Add(uySpeaker34);
            context.Users.Add(uySpeaker35);

            return new List<EditionActivity>
        {
            // Dia 1, track 1

            new EditionActivity { Type = Constants.ACTIVITY_ACCREDITATION_BREAKFAST, Day = "Day 1", Track = "Track 1", Duration = "01:00:00", Date = "2019-10-21T08:30:00.000-03:00", Details = new List<EditionActivityDetail>() {  new EditionActivityDetail() { Language = Constants.LANGUAGES_SPANISH, Title = "Acreditación y desayuno" } } },
            new EditionActivity { Type = Constants.ACTIVITY_OPENING, Day = "Day 1", Track = "Track 1", Duration = "00:15:00", Date = "2019-10-21T09:30:00.000-03:00", Details = new List<EditionActivityDetail>() {  new EditionActivityDetail() { Language = Constants.LANGUAGES_SPANISH, Title = "Apertura" } } },
            new EditionActivity
            {
                Type = Constants.ACTIVITY_KEYNOTE, Day = "Day 1", Track = "Track 1", Duration = "00:35:00", Date = "2019-10-21T09:45:00.000-03:00", Level = "", Tags = "",
                Users = new List<EditionActivityUser> { },
                Details = new List<EditionActivityDetail>()
                {
                    new EditionActivityDetail() { Language = Constants.LANGUAGES_SPANISH, Title = "Keynote", Description = "TBD" }
                }
            },
            new EditionActivity
            {
                Type = Constants.ACTIVITY_TALK, Day = "Day 1", Track = "Track 1", Duration = "00:45:00", Date = "2019-10-21T10:20:00.000-03:00", Level = "200", Tags = "Elixir, Phoenix",
                Users = new List<EditionActivityUser> { new EditionActivityUser { User = uySpeaker16 } },
                Details = new List<EditionActivityDetail>()
                {
                    new EditionActivityDetail() { Language = Constants.LANGUAGES_SPANISH, Title = "Desarrollo web funcional con Elixir y Phoenix", Description = "La idea de esta charla es contar nuestra experiencia haciendo desarrollo web con Elixir, y el framework Phoenix en particular, que viene siendo muy satisfactoria. Acostumbrados a tener muchas tecnologías que permiten hacer aplicaciones web dentro del paradigma de la orientación a objetos, nos parece interesante mostrar cómo Phoenix modela este problema pero usando un enfoque puramente funcional, explicando la arquitectura del framework, las cualidades de Elixir en las que se apoya, y mostrando código concreto que sirva de ejemplo para quienes no conozcan estas tecnologías." }
                }
            },
            new EditionActivity { Type = Constants.ACTIVITY_COFFEE_BREAK, Day = "Day 1", Track = "Track 1", Duration = "00:20:00", Date = "2019-10-21T11:05:00.000-03:00", Details = new List<EditionActivityDetail>() {  new EditionActivityDetail() { Language = Constants.LANGUAGES_SPANISH, Title = "Coffee break" } } },
            new EditionActivity
            {
                Type = Constants.ACTIVITY_TALK, Day = "Day 1", Track = "Track 1", Duration = "00:45:00", Date = "2019-10-21T11:25:00.000-03:00", Level = "300", Tags = ".NET Core, Akka.Net",
                Users = new List<EditionActivityUser> { new EditionActivityUser { User = uySpeaker7 } },
                Details = new List<EditionActivityDetail>()
                {
                    new EditionActivityDetail() { Language = Constants.LANGUAGES_SPANISH, Title = "Distribute Systems with Akka.Net and .Net Core", Description = "Building distributed applications with concurrent processing scenarios easily and simply ensuring high performance and fault tolerance. Remoting, Clustering, Deployment and Grid Processing concepts will be explored." }
                }
            },
            new EditionActivity
            {
                Type = Constants.ACTIVITY_TALK, Day = "Day 1", Track = "Track 1", Duration = "00:45:00", Date = "2019-10-21T12:15:00.000-03:00", Level = "100", Tags = "UX, mobile",
                Users = new List<EditionActivityUser> { new EditionActivityUser { User = uySpeaker8 } },
                Details = new List<EditionActivityDetail>()
                {
                    new EditionActivityDetail() { Language = Constants.LANGUAGES_SPANISH, Title = "Make Your App Friendly to 1 Billion More Users", Description = "Today, mobile devices serve are an extension of the human body, giving us more computing power in the palm of our hands or our back pockets than the computer had that landed NASA astronauts on the moon! As a society, we are growing reliant on this technology that is already an integral part of our lives. Currently, there are more than 1.2 billion websites on the internet, Google Play has over 3.8 million mobile applications and the App Store has over 2 million applications, but how many apps and sites are accessible to people with disabilities? When a company launches an application on the market, it should consider accessibility as an important factor because there are more than one billion people living worldwide with some form of disability, who should be considered when making design decisions. It is essential that, from our role as developers, we not only take into consideration the functionality, performance, security, etc. but that we are advocates for designing and developing accessible applications, using the proper tools to evaluate the accessibility of a product. I invite you to this talk where we will be examining how we can quickly detect accessibility problems from the design and development stage, comparing examples of good and bad practices that will allow us to easily distinguish accessibility errors. With these tips and tools, we can ensure that our applications are accessible and achieve a barrier-free technological landscape." }
                }
            },
            new EditionActivity { Type = Constants.ACTIVITY_LUNCH, Day = "Day 1", Track = "Track 1", Duration = "01:00:00", Date = "2019-10-21T13:00:00.000-03:00", Details = new List<EditionActivityDetail>() {  new EditionActivityDetail() { Language = Constants.LANGUAGES_SPANISH, Title = "Almuerzo" } } },
            new EditionActivity
            {
                Type = Constants.ACTIVITY_TALK, Day = "Day 1", Track = "Track 1", Duration = "00:45:00", Date = "2019-10-21T14:00:00.000-03:00", Level = "200", Tags = "API, backend, OpenAPI",
                Users = new List<EditionActivityUser> { new EditionActivityUser { User = context.Users.Find(MARIANO_VAZQUEZ_ID) } },
                Details = new List<EditionActivityDetail>()
                {
                    new EditionActivityDetail() { Language = Constants.LANGUAGES_SPANISH, Title = "Design-first APIs with OpenAPI spec", Description = "Ready to learn new stuff? If you are modeling APIs using Google docs, this talk IS FOR YOU. You’ll learn how to design your APIs from scratch with OAS/Swagger, and all the bonuses you could get for free without adding a single line of code: a mocking service, auto-generated code & docs, API testing, and so on." }
                }
            },
            new EditionActivity
            {
                Type = Constants.ACTIVITY_TALK, Day = "Day 1", Track = "Track 1", Duration = "00:45:00", Date = "2019-10-21T14:50:00.000-03:00", Level = "200", Tags = "AR, Azure",
                Users = new List<EditionActivityUser> { new EditionActivityUser { User = uySpeaker17 } },
                Details = new List<EditionActivityDetail>()
                {
                    new EditionActivityDetail() { Language = Constants.LANGUAGES_SPANISH, Title = "Creando experiencias de realidad aumentada persistentes y multiusuario", Description = "Las experiencias de realidad aumentada ya no tienen por qué limitarse a un único usuario en su dispositivo. La tecnología actual nos permite hoy crear nuevas experiencias que son persistentes y multiusuario, donde no es necesario seleccionar y posicionar objetos constantemente, basta con enfocar un área determinada con un dispositivo móvil. Veamos los conceptos básicos de AR, como podemos utilizar los servicios de Azure, los SDK de cada plataforma ArCore (Android) y ArKit (iOS) y crear este tipo de experiencias para dispositivos móviles. Augmented reality experiences no longer must be limited to a single user in his/her device. Current technology allows us today to create new persistent and multiuser experiences where there’s no need to select and place objects constantly, it's enough to focus a certain area with a mobile device. Let’s see basic AR concept, how to use Azure services, each platform SDK, ArCore (Android) and ArKit (iOS) and create this type of experiences for mobile devices." }
                }
            },
            new EditionActivity { Type = Constants.ACTIVITY_COFFEE_BREAK, Day = "Day 1", Track = "Track 1", Duration = "00:20:00", Date = "2019-10-21T15:35:00.000-03:00", Details = new List<EditionActivityDetail>() {  new EditionActivityDetail() { Language = Constants.LANGUAGES_SPANISH, Title = "Coffee break" } } },
            new EditionActivity
            {
                Type = Constants.ACTIVITY_TALK, Day = "Day 1", Track = "Track 1", Duration = "00:45:00", Date = "2019-10-21T15:55:00.000-03:00", Level = "100", Tags = "Seguridad, UX",
                Users = new List<EditionActivityUser> { new EditionActivityUser { User = uySpeaker11 }, new EditionActivityUser { User = uySpeaker12 } },
                Details = new List<EditionActivityDetail>()
                {
                    new EditionActivityDetail() { Language = Constants.LANGUAGES_SPANISH, Title = "¿Podemos hacer que la seguridad sea usable? ", Description = "Para confiar en un sistema, lo mínimo que esperamos, es que nuestros datos personales sean utilizados de forma segura. Pero también esperamos que este sistema sea agradable, y fácil de usar. ¿Ahora, qué pasa cuando estas medidas de seguridad, tan necesarias para garantizar la confianza, complican la vida del usuario?. ¿Será que la seguridad se pone encontra de la usabilidad? o ¿es que la usabilidad simplifica en exceso las cosas, pasando por alto las recomendaciones de seguridad?. Uno de los factores más importantes a la hora de analizar la seguridad de una aplicación, es el impacto que puede tener un comportamiento de usuario no esperado. Por otro lado el desarrollo de experiencia de usuario trabaja con el comportamiento de los usuarios para crear sistemas usables. ¿Por qué entonces no consideramos en el diseño de experiencia de usuario a la seguridad, en lugar de sumarla previo a salida a producción?. Te invitamos a revisar con nosotros, estos dos conceptos que a primera vista parecen tan opuestos y que no solo cuentan con un origen común sino también con un fin muy alineado." }
                }
            },
            new EditionActivity
            {
                Type = Constants.ACTIVITY_TALK, Day = "Day 1", Track = "Track 1", Duration = "00:45:00", Date = "2019-10-21T16:45:00.000-03:00", Level = "100", Tags = "AI, AR",
                Users = new List<EditionActivityUser> { new EditionActivityUser { User = uySpeaker14 } },
                Details = new List<EditionActivityDetail>()
                {
                    new EditionActivityDetail() { Language = Constants.LANGUAGES_SPANISH, Title = "Change the world with AI and How to become a Microsoft MVP", Description = "Talk about Microsoft MVP Program as well as how Augmented Reality and AI can change the world, not only to developers and ITpros but for startup makers and entrepreneurs." }
                }
            },
            new EditionActivity
            {
                Type = Constants.ACTIVITY_TALK, Day = "Day 1", Track = "Track 1", Duration = "00:45:00", Date = "2019-10-21T17:35:00.000-03:00", Level = "200", Tags = "API, backend, MicroServices",
                Users = new List<EditionActivityUser> { new EditionActivityUser { User = uySpeaker15 } },
                Details = new List<EditionActivityDetail>()
                {
                    new EditionActivityDetail() { Language = Constants.LANGUAGES_SPANISH, Title = "Don't go to Microservices!", Description = "Microservices has become a huge buzzword, but is it for everyone? I will show why it is not for everyone... and most probably, not for you." }
                }
            },
            new EditionActivity { Type = Constants.ACTIVITY_CLOSURE, Day = "Day 1", Track = "Track 1", Duration = "00:40:00", Date = "2019-10-21T18:20:00.000-03:00", Details = new List<EditionActivityDetail>() {  new EditionActivityDetail() { Language = Constants.LANGUAGES_SPANISH, Title = "Cierre" } } },

            // Dia 1, track 2

            new EditionActivity { Type = Constants.ACTIVITY_ACCREDITATION_BREAKFAST, Day = "Day 1", Track = "Track 2", Duration = "01:00:00", Date = "2019-10-21T08:30:00.000-03:00", Details = new List<EditionActivityDetail>() {  new EditionActivityDetail() { Language = Constants.LANGUAGES_SPANISH, Title = "Acreditación y desayuno" } } },
            new EditionActivity { Type = Constants.ACTIVITY_OPENING, Day = "Day 1", Track = "Track 2", Duration = "00:15:00", Date = "2019-10-21T09:30:00.000-03:00", Details = new List<EditionActivityDetail>() {  new EditionActivityDetail() { Language = Constants.LANGUAGES_SPANISH, Title = "Apertura" } } },
            new EditionActivity
            {
                Type = Constants.ACTIVITY_TALK, Day = "Day 1", Track = "Track 2", Duration = "00:45:00", Date = "2019-10-21T10:20:00.000-03:00", Tags = "AI, Machine learning",
                Users = new List<EditionActivityUser> { new EditionActivityUser { User = uySpeaker23 } },
                Details = new List<EditionActivityDetail>()
                {
                    new EditionActivityDetail() { Language = Constants.LANGUAGES_SPANISH, Title = "Cómo crear aplicaciones inteligentes con ML.NET", Description = "ML.NET es el framework open source de Microsoft, construido para desarrolladores, que permite crear o expandir soluciones que incluyan una componente de machine learning, disponible para Windows, Linux y macOS. Se verán conceptos básicos de machine learning para luego poder adentrarse en lo que es posible construir utilizando la API de ML.NET." }
                }
            },
            new EditionActivity { Type = Constants.ACTIVITY_COFFEE_BREAK, Day = "Day 1", Track = "Track 2", Duration = "00:20:00", Date = "2019-10-21T11:05:00.000-03:00", Details = new List<EditionActivityDetail>() {  new EditionActivityDetail() { Language = Constants.LANGUAGES_SPANISH, Title = "Coffee break" } } },
            new EditionActivity
            {
                Type = Constants.ACTIVITY_TALK, Day = "Day 1", Track = "Track 2", Duration = "00:45:00", Date = "2019-10-21T11:25:00.000-03:00", Level = "200", Tags = "SQL, Async",
                Users = new List<EditionActivityUser> { new EditionActivityUser { User = uySpeaker5 } },
                Details = new List<EditionActivityDetail>()
                {
                    new EditionActivityDetail() { Language = Constants.LANGUAGES_SPANISH, Title = "Cómo construir una aplicación ASYNC con SQL Server", Description = "La idea es repasar un poco la caracteristica de message broker que viene con SQL Server. La idea es crear una pequeña aplicación que funcione de forma ASYNC para mostrar las principales caracteristicas del servicio y como podemos empezar a usarlo sistema de mensajeria de nuestra aplicación." }
                }
            },
            new EditionActivity
            {
                Type = Constants.ACTIVITY_TALK, Day = "Day 1", Track = "Track 2", Duration = "00:45:00", Date = "2019-10-21T12:15:00.000-03:00", Level = "200", Tags = "DB, Containers",
                Users = new List<EditionActivityUser> { new EditionActivityUser { User = uySpeaker4 } },
                Details = new List<EditionActivityDetail>()
                {
                    new EditionActivityDetail() { Language = Constants.LANGUAGES_SPANISH, Title = "Corriendo Bases de Datos relacionales en Containers", Description = "Veremos como corres diferentes tipos de motores de base de datos en Docker y Kubernetes." }
                }
            },
            new EditionActivity { Type = Constants.ACTIVITY_LUNCH, Day = "Day 1", Track = "Track 2", Duration = "01:00:00", Date = "2019-10-21T13:00:00.000-03:00", Details = new List<EditionActivityDetail>() {  new EditionActivityDetail() { Language = Constants.LANGUAGES_SPANISH, Title = "Almuerzo" } } },
            new EditionActivity
            {
                Type = Constants.ACTIVITY_TALK, Day = "Day 1", Track = "Track 2", Duration = "00:45:00", Date = "2019-10-21T14:00:00.000-03:00", Level = "200", Tags = "QA, automation",
                Users = new List<EditionActivityUser> { new EditionActivityUser { User = uySpeaker34 }, new EditionActivityUser { User = uySpeaker35 } },
                Details = new List<EditionActivityDetail>()
                {
                    new EditionActivityDetail() { Language = Constants.LANGUAGES_SPANISH, Title = "Automatizar sin morir en el intento", Description = "Cuando desarrollamos software en ambientes ágiles, la automatización de pruebas es un pilar fundamental para lograr releases más rápidos y confiables. Pero, ¿quien se encarga de automatizar las pruebas en un equipo de desarrollo de software?, ¿los testers?, ¿stakeholders?, ¿desarrolladores?, ¿analistas?. En realidad la automatización de pruebas es una actividad de todo el equipo, donde la colaboración es imprescindible. Sin embargo, ¿cómo podemos colaborar diferentes roles con diferentes skills en una actividad técnica como es automatizar pruebas? En esta charla veremos como con el uso de algunas herramientas de automatización para .Net podemos hacer que los scripts automatizados sean comprensible tanto por roles técnicos y no técnicos. Donde clientes, testers y desarrolladores puedan crear, editar y ejecutar con facilidad los tests automatizados y de esta manera fomentar una cultura más colaborativa en nuestros equipos." }
                }
            },
            new EditionActivity
            {
                Type = Constants.ACTIVITY_TALK, Day = "Day 1", Track = "Track 2", Duration = "00:45:00", Date = "2019-10-21T14:50:00.000-03:00", Level = "100", Tags = "Smart Contracts, blockchain",
                Users = new List<EditionActivityUser> { new EditionActivityUser { User = uySpeaker10 } },
                Details = new List<EditionActivityDetail>()
                {
                    new EditionActivityDetail() { Language = Constants.LANGUAGES_SPANISH, Title = "Smart Coding with Smart Contracts", Description = "Sintaxis, arquitectura, buenas prácticas y todo lo que hay que tener en cuenta para crear tu aplicación descentralizada utilizando contratos inteligentes escritos en Solidity." }
                }
            },
            new EditionActivity { Type = Constants.ACTIVITY_COFFEE_BREAK, Day = "Day 1", Track = "Track 2", Duration = "00:20:00", Date = "2019-10-21T15:35:00.000-03:00", Details = new List<EditionActivityDetail>() {  new EditionActivityDetail() { Language = Constants.LANGUAGES_SPANISH, Title = "Coffee break" } } },
            new EditionActivity
            {
                Type = Constants.ACTIVITY_TALK, Day = "Day 1", Track = "Track 2", Duration = "00:45:00", Date = "2019-10-21T15:55:00.000-03:00", Level = "200", Tags = "API, backend, GraphQL, REST",
                Users = new List<EditionActivityUser> { new EditionActivityUser { User = uySpeaker33 } },
                Details = new List<EditionActivityDetail>()
                {
                    new EditionActivityDetail() { Language = Constants.LANGUAGES_SPANISH, Title = "Conoce GraphQL, es hora de jubilar las API REST", Description = "En los últimos años GraphQL está ganando una gran popularidad y grandes empresas han migrado sus APIs a esa tecnología, durante esta charla veremos el porqué de esa popularidad, las ventajas y características que nos ofrece GraphQL así como los problemas que viene a resolver. Todo mediante ejemplos." }
                }
            },

            // Dia 2, track 1

            new EditionActivity { Type = Constants.ACTIVITY_ACCREDITATION_BREAKFAST, Day = "Day 2", Track = "Track 1", Duration = "01:00:00", Date = "2019-10-22T08:30:00.000-03:00", Details = new List<EditionActivityDetail>() {  new EditionActivityDetail() { Language = Constants.LANGUAGES_SPANISH, Title = "Acreditación y desayuno" } } },
            new EditionActivity { Type = Constants.ACTIVITY_OPENING, Day = "Day 2", Track = "Track 1", Duration = "00:15:00", Date = "2019-10-22T09:30:00.000-03:00", Details = new List<EditionActivityDetail>() {  new EditionActivityDetail() { Language = Constants.LANGUAGES_SPANISH, Title = "Apertura" } } },
            new EditionActivity
            {
                Type = Constants.ACTIVITY_KEYNOTE, Day = "Day 2", Track = "Track 1", Duration = "00:35:00", Date = "2019-10-22T09:45:00.000-03:00", Level = "100", Tags = "keynote",
                Users = new List<EditionActivityUser> { new EditionActivityUser { User = uySpeaker31 } },
                Details = new List<EditionActivityDetail>()
                {
                    new EditionActivityDetail() { Language = Constants.LANGUAGES_SPANISH, Title = "Keynote: Caminos Estratégicos", Description = "Actualmente todas las organizaciones están llevando sus aplicaciones a la nube (pública, privada, híbrida), están haciendo uso de analítica avanzada de datos, inteligencia artificial o capacidades cognitivas, se están fortaleciendo en aspectos de seguridad y están buscando nuevas formas de innovar. En esta charla, se presentará una arquitectura de referencia a alto nivel que incluye todos estos caminos estratégicos y como el por qué de la adquisición de Red Hat por parte de IBM." }
                }
            },
            new EditionActivity
            {
                Type = Constants.ACTIVITY_TALK, Day = "Day 2", Track = "Track 1", Duration = "00:45:00", Date = "2019-10-22T10:20:00.000-03:00", Level = "200", Tags = "Serverless, Knative, Cloud Run",
                Users = new List<EditionActivityUser> { new EditionActivityUser { User = uySpeaker3 } },
                Details = new List<EditionActivityDetail>()
                {
                    new EditionActivityDetail() { Language = Constants.LANGUAGES_SPANISH, Title = "Serverless Containers with Knative and Cloud Run", Description = "When you build a serverless app, you either tie yourself to a cloud provider, or you end up building your own serverless stack. Knative provides a better choice. Open-source Knative extends Kubernetes to provide a set of middleware components for container-based serverless apps that can run anywhere. In this talk, we’ll explore Knative components (serving, eventing, build) and also take a look at its managed cousin Cloud Run on Google Cloud." }
                }
            },
            new EditionActivity { Type = Constants.ACTIVITY_COFFEE_BREAK, Day = "Day 2", Track = "Track 1", Duration = "00:20:00", Date = "2019-10-22T11:05:00.000-03:00", Details = new List<EditionActivityDetail>() {  new EditionActivityDetail() { Language = Constants.LANGUAGES_SPANISH, Title = "Coffee break" } } },
            new EditionActivity
            {
                Type = Constants.ACTIVITY_TALK, Day = "Day 2", Track = "Track 1", Duration = "00:45:00", Date = "2019-10-22T11:25:00.000-03:00", Level = "200", Tags = "IoT, Hacking",
                Users = new List<EditionActivityUser> { new EditionActivityUser { User = uySpeaker2 } },
                Details = new List<EditionActivityDetail>()
                {
                    new EditionActivityDetail() { Language = Constants.LANGUAGES_SPANISH, Title = "Hacking applications that use IoT", Description = "Functionality is prioritized and not security and there is a massive deployment of IoT devices. It is shown why security aspects should be taken into account." }
                }
            },
            new EditionActivity
            {
                Type = Constants.ACTIVITY_TALK, Day = "Day 2", Track = "Track 1", Duration = "00:45:00", Date = "2019-10-22T12:15:00.000-03:00", Level = "100", Tags = "Data processing",
                Users = new List<EditionActivityUser> { new EditionActivityUser { User = uySpeaker1 } },
                Details = new List<EditionActivityDetail>()
                {
                    new EditionActivityDetail() { Language = Constants.LANGUAGES_SPANISH, Title = "Stream Processing", Description = "Los datos cada vez más se convierten en el petróleo de este siglo. Los mecanismos tradicionales de captura de datos y su procesamiento ya no alcanzan. Que soluciones y que problemas nuevos traen los motores y frameworks de procesamiento de Streams." }
                }
            },
            new EditionActivity { Type = Constants.ACTIVITY_LUNCH, Day = "Day 2", Track = "Track 1", Duration = "01:00:00", Date = "2019-10-22T13:00:00.000-03:00", Details = new List<EditionActivityDetail>() {  new EditionActivityDetail() { Language = Constants.LANGUAGES_SPANISH, Title = "Almuerzo" } } },
            new EditionActivity
            {
                Type = Constants.ACTIVITY_TALK, Day = "Day 2", Track = "Track 1", Duration = "00:45:00", Date = "2019-10-22T14:00:00.000-03:00", Level = "100", Tags = "Rust",
                Users = new List<EditionActivityUser> { new EditionActivityUser { User = uySpeaker6 } },
                Details = new List<EditionActivityDetail>()
                {
                    new EditionActivityDetail() { Language = Constants.LANGUAGES_SPANISH, Title = "Why People Love Rust?", Description = "Rust es un 'nuevo' lenguaje de programación de sistemas creado por Mozilla. Considerado por grandes compañías como Mozilla, Google, Facebook, Amazon, Twitter y Microsoft entre otras grandes empresas. Promete la performance de C/C++ con las garantías de seguridad en el manejo de memoria que nos da un lenguaje garbage collected. En esta charla vamos a ver por qué los desarrolladores aman Rust (lenguaje más amado por la comunidad de desarrolladores en 2016, 2017, 2018 y 2019) y por qué es una excelente opción a considerar a la hora de hacer desarrollo de sistemas." }
                }
            },
            new EditionActivity
            {
                Type = Constants.ACTIVITY_TALK, Day = "Day 2", Track = "Track 1", Duration = "00:45:00", Date = "2019-10-22T14:50:00.000-03:00", Level = "200", Tags = "SQL",
                Users = new List<EditionActivityUser> { new EditionActivityUser { User = uySpeaker9 } },
                Details = new List<EditionActivityDetail>()
                {
                    new EditionActivityDetail() { Language = Constants.LANGUAGES_SPANISH, Title = "Query Tuning Techniques Every SQL Server Programmer Should Know", Description = "Querying databases is easy when you're in development, but do you know the impact of your queries in the future? In this session learn techniques that all developers should learn to create better objects of SQL Server databases with performance, security and elegance." }
                }
            },
            new EditionActivity { Type = Constants.ACTIVITY_COFFEE_BREAK, Day = "Day 2", Track = "Track 1", Duration = "00:20:00", Date = "2019-10-22T15:35:00.000-03:00", Details = new List<EditionActivityDetail>() {  new EditionActivityDetail() { Language = Constants.LANGUAGES_SPANISH, Title = "Coffee break" } } },
            new EditionActivity
            {
                Type = Constants.ACTIVITY_TALK, Day = "Day 2", Track = "Track 1", Duration = "00:45:00", Date = "2019-10-22T15:55:00.000-03:00", Level = "100", Tags = "Javascript, Azure, IoT",
                Users = new List<EditionActivityUser> { new EditionActivityUser { User = uySpeaker19 } },
                Details = new List<EditionActivityDetail>()
                {
                    new EditionActivityDetail() { Language = Constants.LANGUAGES_SPANISH, Title = "Javascript, Azure Cognitive Services and RaspberryPI - Using Javascript to recognise people!", Description = "Technologies have been increasing our power to develop new applications without a big knowledge of previous concepts. Today developers could create their own Machine Learning applications, strong and complex algorithms without knowing what is happening behind the scenes thought APIs. This talk will explore the benefits of Cognitive services by showing a real application. They will learn how is the most common challenges that we face when we need to depend on third-party APIs and low-cost devices. We will take a look at the following topics: OpenCV, challenges and concepts to recognize people, drawbacks to create a real application, demos to compare Azure FaceAPIs and OpenCV, how Azure face API helped us to be more productive, how to use text to speech after recognizing someone." }
                }
            },
            new EditionActivity
            {
                Type = Constants.ACTIVITY_TALK, Day = "Day 2", Track = "Track 1", Duration = "00:45:00", Date = "2019-10-22T16:45:00.000-03:00", Level = "100", Tags = "PowerBI",
                Users = new List<EditionActivityUser> { new EditionActivityUser { User = uySpeaker20 } },
                Details = new List<EditionActivityDetail>()
                {
                    new EditionActivityDetail() { Language = Constants.LANGUAGES_SPANISH, Title = "A importância do Storytelling no Power BI", Description = "Nessa palestra, demonstrarei técnicas de Storytelling para visualização de dados com o Power BI. Desde melhores práticas de elaboração, até utilização de técnicas de ferramentas do Power BI." }
                }
            },
            new EditionActivity
            {
                Type = Constants.ACTIVITY_TALK, Day = "Day 2", Track = "Track 1", Duration = "00:45:00", Date = "2019-10-22T17:35:00.000-03:00", Level = "100", Tags = "Azure, AWS, cloud computing",
                Users = new List<EditionActivityUser> { new EditionActivityUser { User = uySpeaker21 } },
                Details = new List<EditionActivityDetail>()
                {
                    new EditionActivityDetail() { Language = Constants.LANGUAGES_SPANISH, Title = "Azure vs AWS: Guía de Servicios en la Nube", Description = "La elección de un proveedor de servicios en la nube es una gran decisión. Entender cuales se adaptan mejor a tus requerimientos te permitirán ahorrar costos significativos. En esta charla vas a conocer y entender varios de los servicios que ofrecen Microsoft y Amazon, sus similitudes y diferencias." }
                }
            },
            new EditionActivity { Type = Constants.ACTIVITY_CLOSURE, Day = "Day 2", Track = "Track 1", Duration = "00:30:00", Date = "2019-10-22T18:20:00.000-03:00", Details = new List<EditionActivityDetail>() {  new EditionActivityDetail() { Language = Constants.LANGUAGES_SPANISH, Title = "Cierre" } } },
            new EditionActivity { Type = Constants.ACTIVITY_AFTER_PARTY, Day = "Day 2", Track = "Track 1", Duration = "02:00:00", Date = "2019-10-22T18:50:00.000-03:00", Details = new List<EditionActivityDetail>() {  new EditionActivityDetail() { Language = Constants.LANGUAGES_SPANISH, Title = "After party" } } },

            // Dia 2 - Track 2
            new EditionActivity { Type = Constants.ACTIVITY_ACCREDITATION_BREAKFAST, Day = "Day 2", Track = "Track 2", Duration = "01:00:00", Date = "2019-10-22T08:30:00.000-03:00", Details = new List<EditionActivityDetail>() {  new EditionActivityDetail() { Language = Constants.LANGUAGES_SPANISH, Title = "Acreditación y desayuno" } } },
            new EditionActivity { Type = Constants.ACTIVITY_OPENING, Day = "Day 2", Track = "Track 2", Duration = "00:15:00", Date = "2019-10-22T09:30:00.000-03:00", Details = new List<EditionActivityDetail>() {  new EditionActivityDetail() { Language = Constants.LANGUAGES_SPANISH, Title = "Apertura" } } },
            new EditionActivity
            {
                Type = Constants.ACTIVITY_TALK, Day = "Day 2", Track = "Track 2", Duration = "00:45:00", Date = "2019-10-22T10:20:00.000-03:00", Level = "100", Tags = "Comunidad, responsabilidad social",
                Users = new List<EditionActivityUser> { new EditionActivityUser { User = uySpeaker22 } },
                Details = new List<EditionActivityDetail>()
                {
                    new EditionActivityDetail() { Language = Constants.LANGUAGES_SPANISH, Title = "Hoy te convertís en un héroe", Description = "Vos también podes ser parte de la comunidad, vos tenes algo que te hace único, vos tenes algo para dar. Esta charla es sobre comunidad, como un simple dev como yo (y posiblemente como vos) puede hacer la diferencia en la comunidad. Quiero compartir mi viaje, desde ser un “consumidor” de la comunidad a participar en Stack Overflow, tener mi propio blog y un proyecto open source con más de 100.000 descargas." }
                }
            },
            new EditionActivity { Type = Constants.ACTIVITY_COFFEE_BREAK, Day = "Day 2", Track = "Track 2", Duration = "00:20:00", Date = "2019-10-22T11:05:00.000-03:00", Details = new List<EditionActivityDetail>() {  new EditionActivityDetail() { Language = Constants.LANGUAGES_SPANISH, Title = "Coffee break" } } },
            new EditionActivity
            {
                Type = Constants.ACTIVITY_TALK, Day = "Day 2", Track = "Track 2", Duration = "00:45:00", Date = "2019-10-22T11:25:00.000-03:00", Level = "100", Tags = "Security, Privacy",
                Users = new List<EditionActivityUser> { new EditionActivityUser { User = uySpeaker18 } },
                Details = new List<EditionActivityDetail>()
                {
                    new EditionActivityDetail() { Language = Constants.LANGUAGES_SPANISH, Title = "Are you really protected?", Description = "Talk about privacy and our social behavior." }
                }
            },
            new EditionActivity
            {
                Type = Constants.ACTIVITY_TALK, Day = "Day 2", Track = "Track 2", Duration = "00:45:00", Date = "2019-10-22T12:15:00.000-03:00", Level = "100", Tags = "AI, testing",
                Users = new List<EditionActivityUser> { new EditionActivityUser { User = uySpeaker24 } },
                Details = new List<EditionActivityDetail>()
                {
                    new EditionActivityDetail() { Language = Constants.LANGUAGES_SPANISH, Title = "Impacto de la Inteligencia Artificial en el Testing", Description = "La inteligencia artificial ha impactado en la manera que construimos software. En esta ocasión compartiremos como lo está haciendo en el testing de software. El avance de la tecnología ha cambiado la forma en que se prueban las aplicaciones que utilizan inteligencia artificial. Incluso, la inteligencia artificial está siendo adoptada hoy en día para probar aplicaciones." }
                }
            },
            new EditionActivity { Type = Constants.ACTIVITY_LUNCH, Day = "Day 2", Track = "Track 2", Duration = "01:00:00", Date = "2019-10-22T13:00:00.000-03:00", Details = new List<EditionActivityDetail>() {  new EditionActivityDetail() { Language = Constants.LANGUAGES_SPANISH, Title = "Almuerzo" } } },
            new EditionActivity
            {
                Type = Constants.ACTIVITY_TALK, Day = "Day 2", Track = "Track 2", Duration = "00:45:00", Date = "2019-10-22T14:00:00.000-03:00", Level = "100", Tags = "Bots, AI, Azure",
                Users = new List<EditionActivityUser> { new EditionActivityUser { User = uySpeaker25 } },
                Details = new List<EditionActivityDetail>()
                {
                    new EditionActivityDetail() { Language = Constants.LANGUAGES_SPANISH, Title = "Haciendo un bot más inteligente", Description = "Pasamos desde una presentación de las características sobresalientes de Microsoft Bot Framework a la presentación de un caso de un bot usando servicios de Microsoft Azure para mejorar la interacción con el usuario, mediante reconocimiento de frases, e imágenes." }
                }
            },
            new EditionActivity
            {
                Type = Constants.ACTIVITY_TALK, Day = "Day 2", Track = "Track 2", Duration = "00:45:00", Date = "2019-10-22T14:50:00.000-03:00", Level = "100", Tags = "DevOps, OpenShift",
                Users = new List<EditionActivityUser> { new EditionActivityUser { User = uySpeaker32 } },
                Details = new List<EditionActivityDetail>()
                {
                    new EditionActivityDetail() { Language = Constants.LANGUAGES_SPANISH, Title = "DevOps con OpenShift Container Platform", Description = "En esta demostración se hará un recorrido por la consola web para conocer conceptos y beneficios que OpenShift brinda como plataforma de contenedores. Se mostrará el concepto de integración continua (CI) a través de una demo de source to image (S2I) y de despliegue continuo (CD) utilizando pipelines. También se contrastarán algunas de las ventajas de utilizar OpenShift por sobre un cluster de Kubernetes. Por último y pensando en los administradores de la plataforma, se demostrarán algunas de las herramientas integradas a OpenShift para el monitoreo de un cluster." }
                }
            },
            new EditionActivity { Type = Constants.ACTIVITY_COFFEE_BREAK, Day = "Day 2", Track = "Track 2", Duration = "00:20:00", Date = "2019-10-23T15:35:00.000-03:00", Details = new List<EditionActivityDetail>() {  new EditionActivityDetail() { Language = Constants.LANGUAGES_SPANISH, Title = "Coffee break" } } },
            new EditionActivity
            {
                Type = Constants.ACTIVITY_TALK, Day = "Day 2", Track = "Track 2", Duration = "00:45:00", Date = "2019-10-23T15:55:00.000-03:00", Level = "200", Tags = "web apps, arquitectura",
                Users = new List<EditionActivityUser> { new EditionActivityUser { User = uySpeaker26 } },
                Details = new List<EditionActivityDetail>()
                {
                    new EditionActivityDetail() { Language = Constants.LANGUAGES_SPANISH, Title = "Construye tu aplicación Multi-Tenant", Description = "¿Que es un software multitenant? Es un principio de arquitectura de software donde sola instancia de la aplicación puede alojar múltiples clientes u organizaciones . Este es un ambiente muy común en aplicaciones de tipo SaaS (Software as a Services) en la nube. En esta charla veremos diferentes estrategias de cómo diseñar y construir una aplicación multitenant, como particionar datos, configuraciones y requerimientos para clientes. Si tiene un producto el cual quieras convertir a SaaS y cobrar por una suscripción, esta es tu charla." }
                }
            },
            new EditionActivity
            {
                Type = Constants.ACTIVITY_TALK, Day = "Day 2", Track = "Track 2", Duration = "00:45:00", Date = "2019-10-23T16:45:00.000-03:00", Level = "200", Tags = "Security, OWASP",
                Users = new List<EditionActivityUser> { new EditionActivityUser { User = uySpeaker2 } },
                Details = new List<EditionActivityDetail>()
                {
                    new EditionActivityDetail() { Language = Constants.LANGUAGES_SPANISH, Title = "Secure design of applications for mobile devices", Description = "Train developers how to develop mobile applications, enable them to evaluate their own applications using Open-source tools and using OWASP methodology." }
                }
            },

            // Dia 3, track 1

            new EditionActivity
            {
                Type = Constants.ACTIVITY_TALK, Day = "Day 3", Track = "Track 1", Duration = "01:00:00", Date = "2019-10-23T17:00:00.000-03:00", Level = "100", Tags = "CQRS, C#",
                Users = new List<EditionActivityUser> { new EditionActivityUser { User = uySpeaker26 } },
                Details = new List<EditionActivityDetail>()
                {
                    new EditionActivityDetail() { Language = Constants.LANGUAGES_SPANISH, Title = "El misterioso CQRS", Description = "El patron CQRS siempre ha sido rodeado de una gran cantidad de misterios, confusiones y errores conceptuales. En este workshop tocaremos varias inquietudes y preguntas sobre la implementación de este patrón. Veremos, qué es exactamente CQRS, qué principios lo fundamentan, que beneficios brinda en nuestros proyectos. Por último, veremos una implementación detallada, paso a paso, de es patrón en un proyecto muy cercano al mundo real. El objetivo final es la comprensión fundamental del patrón CQRS y cómo llevarlo adelante en nuestros proyecto de software. Lo veremos en práctica de la mano de C#." }
                }
            },
            new EditionActivity { Type = Constants.ACTIVITY_COFFEE_BREAK, Day = "Day 3", Track = "Track 1", Duration = "00:30:00", Date = "2019-10-23T19:00:00.000-03:00", Details = new List<EditionActivityDetail>() {  new EditionActivityDetail() { Language = Constants.LANGUAGES_SPANISH, Title = "Coffee break" } } },
            new EditionActivity
            {
                Type = Constants.ACTIVITY_TALK, Day = "Day 3", Track = "Track 1", Duration = "01:00:00", Date = "2019-10-23T19:30:00.000-03:00", Level = "100", Tags = "IBM, IBM Watson",
                Users = new List<EditionActivityUser> { new EditionActivityUser { User = uySpeaker29 } },
                Details = new List<EditionActivityDetail>()
                {
                    new EditionActivityDetail() { Language = Constants.LANGUAGES_SPANISH, Title = "Asistentes Virtuales Inteligentes usando Watson Assistant", Description = "Hoy en dia los asistentes virtuales son la novedad del mundo tecnológico que nos rodea. En este Hands-On vas a poder crear tu propio Asistente Virtual utilizando el servicio que se encuentra en IBM Cloud: 'WATSON ASSISTANT'. Se estarán explicando los conceptos básicos para crear asistentes que sean capaces de solucionar nuestros problemas de una manera mas humanizada y además, como escalar estos asistentes permitiendo un mejor funcionamiento con el paso del tiempo." }
                }
            },

            // Dia 3, track 2

            new EditionActivity
            {
                Type = Constants.ACTIVITY_TALK, Day = "Day 3", Track = "Track 2", Duration = "01:00:00", Date = "2019-10-23T17:00:00.000-03:00", Level = "100", Tags = "Bitcoin, Smart Contracts",
                Users = new List<EditionActivityUser> { new EditionActivityUser { User = uySpeaker30 } },
                Details = new List<EditionActivityDetail>()
                {
                    new EditionActivityDetail() { Language = Constants.LANGUAGES_SPANISH, Title = "Introduction to Smart Contract powered by RSK", Description = "Se hará una introducción a bitcoin, smart contracts y RSK. Luego se utilizará truffle para interactuar con contratos inteligentes en RSK." }
                }
            },
            new EditionActivity { Type = Constants.ACTIVITY_COFFEE_BREAK, Day = "Day 3", Track = "Track 2", Duration = "00:30:00", Date = "2019-10-23T19:00:00.000-03:00", Details = new List<EditionActivityDetail>() {  new EditionActivityDetail() { Language = Constants.LANGUAGES_SPANISH, Title = "Coffee break" } } },
            new EditionActivity
            {
                Type = Constants.ACTIVITY_TALK, Day = "Day 3", Track = "Track 2", Duration = "01:00:00", Date = "2019-10-23T19:30:00.000-03:00", Level = "200", Tags = "Elixir, Phoenix",
                Users = new List<EditionActivityUser> { new EditionActivityUser { User = uySpeaker16 }, new EditionActivityUser { User = uySpeaker27 }, new EditionActivityUser { User = uySpeaker28 }  },
                Details = new List<EditionActivityDetail>()
                {
                    new EditionActivityDetail() { Language = Constants.LANGUAGES_SPANISH, Title = "Desarrollo web funcional con Elixir", Description = "En este workshop descubriremos una nueva forma de hacer desarrollo web de la mano de Phoenix (https://phoenixframework.org/). Combinando la potencia de la ErlangVM, la facilidad de uso de Elixir y las virtudes de la programación funcional, crearemos una aplicación completa en pocos pasos." }
                }
            },

            // Dia 3, track 3

            new EditionActivity
            {
                Type = Constants.ACTIVITY_TALK, Day = "Day 3", Track = "Track 3", Duration = "01:00:00", Date = "2019-10-23T17:00:00.000-03:00", Level = "", Tags = "",
                Users = new List<EditionActivityUser> {  },
                Details = new List<EditionActivityDetail>()
                {
                    new EditionActivityDetail() { Language = Constants.LANGUAGES_SPANISH, Title = "TBC", Description = "" }
                }
            },
            new EditionActivity { Type = Constants.ACTIVITY_COFFEE_BREAK, Day = "Day 3", Track = "Track 3", Duration = "00:30:00", Date = "2019-10-23T19:00:00.000-03:00", Details = new List<EditionActivityDetail>() {  new EditionActivityDetail() { Language = Constants.LANGUAGES_SPANISH, Title = "Coffee break" } } },
            new EditionActivity
            {
                Type = Constants.ACTIVITY_TALK, Day = "Day 3", Track = "Track 3", Duration = "01:00:00", Date = "2019-10-23T19:30:00.000-03:00", Level = "100", Tags = "Azure, Kubernetes, Azure CLI",
                Users = new List<EditionActivityUser> { new EditionActivityUser { User = context.Users.Find(VICTOR_SILVA_ID) } },
                Details = new List<EditionActivityDetail>()
                {
                    new EditionActivityDetail() { Language = Constants.LANGUAGES_SPANISH, Title = "Consolidating containerized apps with Azure Kubernetes Service", Description = "Kubernetes unlocks advanced features like A/B testing, Blue/Green deployments, canary builds, and dead-simple rollbacks. This workshop demonstrates taking your containerized application and deploying it to Azure Kubernetes Service (AKS) using tools like Helm and Azure CLI." }
                }
            },
        };
        }

        private static Edition CreateEdition2020(VOpenDbContext context, ICollection<User> organizers, ICollection<(Sponsor Sponsor, string Type)> sponsors, Event vopenEvent)
        {
            var organizers2020 = VOpenDbInitializer.CreateGlobalOrganizers2020(context);

            // Create global edition
            var globalEdition2020 = new Edition
            {
                Id = "vopen-global-2020",
                Event = vopenEvent,
                Details = new EditionDetail[]
                {
                new EditionDetail { Date = "Octubre 3", Language = Constants.LANGUAGES_SPANISH, Name = "vOpen Global 2020" },
                new EditionDetail { Date = "October 3rd", Language = Constants.LANGUAGES_ENGLISH, Name = "vOpen Global 2020" }
          },
                Organizers = organizers2020
          .Concat(organizers.Where(c => c.Id.Contains("global-user")))
          .Select(c => new EditionOrganizer { User = c })
          .ToList(),
                Sponsors = sponsors.Select((s, i) =>
                  new EditionSponsor
                  {
                      Id = (i + 20).ToString(),
                      Sponsor = s.Sponsor,
                      Type = s.Type
                  }).ToList()
            };

            context.Editions.Add(globalEdition2020);

            var activities2020 = VOpenDbInitializer.CreateActivitiesGlobal2020(context, globalEdition2020);

            globalEdition2020.Activities = activities2020;

            return globalEdition2020;
        }

        private static ICollection<EditionActivity> CreateActivitiesGlobal2020(VOpenDbContext context, Edition edition)
        {
            var speaker1 = new User
            {
                Country = Constants.COUNTRIES_UNITED_KINGDOM,
                Details = new UserDetail[]
              {
          new UserDetail
          {
            Name = "Mete Atamel",
            Language = Constants.LANGUAGES_ENGLISH,
            Company = "Google",
            JobTitle = "Senior Developer Advocate",
          }
              },
                SocialLinks = new UserSocialLink[]
              {
            new UserSocialLink { Type = Constants.SOCIAL_LINKEDIN, Url = "https://www.linkedin.com/in/meteatamel" },
            new UserSocialLink { Type = Constants.SOCIAL_TWITTER, Url = "https://twitter.com/meteatamel" },
              },
                ImageUrl = "https://pbs.twimg.com/profile_images/1103216597232222209/YyYjS3qI_400x400.jpg"
            };

            var speaker2 = new User
            {
                Country = Constants.COUNTRIES_NEW_ZELAND,
                Details = new UserDetail[]
              {
          new UserDetail
          {
            Name = "Matias Iacono",
            Language = Constants.LANGUAGES_SPANISH,
            Company = "Cucumber",
            JobTitle = "Software Engineer"
          }
              },
                SocialLinks = new UserSocialLink[]
              {
            new UserSocialLink { Type = Constants.SOCIAL_LINKEDIN, Url = "https://www.linkedin.com/in/matiasiacono" },
            new UserSocialLink { Type = Constants.SOCIAL_TWITTER, Url = "https://twitter.com/matiasiacono" },
              },
                ImageUrl = "https://pbs.twimg.com/profile_images/1295527863920103425/pU5RK8xb_400x400.jpg"
            };

            var speaker3 = new User
            {
                Country = Constants.COUNTRIES_URUGUAY,
                Details = new UserDetail[]
              {
          new UserDetail
          {
            Name = "Martín Loskin",
            Language = Constants.LANGUAGES_SPANISH,
            Company = "Jigso Labs",
            JobTitle = "UX Expert"
          }
              },
                SocialLinks = new UserSocialLink[]
              {
            new UserSocialLink { Type = Constants.SOCIAL_LINKEDIN, Url = "https://www.linkedin.com/in/martinloskin/" },
            new UserSocialLink { Type = Constants.SOCIAL_TWITTER, Url = "https://twitter.com/loskinoficial" },
              },
                ImageUrl = "https://pbs.twimg.com/profile_images/936434480197328896/RHWRUO47_400x400.jpg"
            };

            var speaker4 = new User
            {
                Country = Constants.COUNTRIES_UNITED_STATES,
                Details = new UserDetail[]
              {
          new UserDetail
          {
            Name = "Guy Royse",
            Language = Constants.LANGUAGES_ENGLISH,
            Company = "Redis Labs",
            JobTitle = "Developer Advocate"
          }
              },
                SocialLinks = new UserSocialLink[]
              {
            new UserSocialLink { Type = Constants.SOCIAL_LINKEDIN, Url = "https://www.linkedin.com/in/groyse/" },
            new UserSocialLink { Type = Constants.SOCIAL_TWITTER, Url = "https://twitter.com/guyroyse" },
              },
                ImageUrl = "https://media-exp1.licdn.com/dms/image/C4E03AQEUx0DEbKQ21g/profile-displayphoto-shrink_800_800/0?e=1605744000&v=beta&t=PxaCEeJICyuBBCPwK5_rdJ5_BzxOxk22BUm-i4BNTMo"
            };

            var speaker5 = new User
            {
                Country = Constants.COUNTRIES_CHILE,
                Details = new UserDetail[]
              {
          new UserDetail
          {
            Name = "Néstor Campos",
            Language = Constants.LANGUAGES_SPANISH,
            Company = "EY",
            JobTitle = "Senior Architect"
          }
              },
                SocialLinks = new UserSocialLink[]
              {
            new UserSocialLink { Type = Constants.SOCIAL_LINKEDIN, Url = "https://www.linkedin.com/in/nescampos/" },
            new UserSocialLink { Type = Constants.SOCIAL_TWITTER, Url = "https://twitter.com/nes_campos" },
              },
                ImageUrl = "https://pbs.twimg.com/profile_images/1187838729274220545/ARPXYyft_400x400.jpg"
            };

            var speaker6 = new User
            {
                Country = Constants.COUNTRIES_NORWAY,
                Details = new UserDetail[]
              {
          new UserDetail
          {
            Name = "Håkan Silfvernagel",
            Language = Constants.LANGUAGES_ENGLISH,
            Company = "Miles AS",
            JobTitle = "Manager AI and Big Data"
          }
              },
                SocialLinks = new UserSocialLink[]
              {
            new UserSocialLink { Type = Constants.SOCIAL_LINKEDIN, Url = "https://www.linkedin.com/in/hakansilfvernagel" },
            new UserSocialLink { Type = Constants.SOCIAL_TWITTER, Url = "https://twitter.com/agrevlis" },
              },
                ImageUrl = "https://pbs.twimg.com/profile_images/1009177368320249856/c5MRhLYi_400x400.jpg"
            };

            var speaker7 = new User
            {
                Country = Constants.COUNTRIES_COSTA_RICA,
                Details = new UserDetail[]
              {
          new UserDetail
          {
            Name = "Ivonne Chaves Ríos",
            Language = Constants.LANGUAGES_SPANISH,
            Company = "Microsoft",
            JobTitle = "Cloud Solution Architect - Data & AI"
          }
              },
                SocialLinks = new UserSocialLink[]
              {
            new UserSocialLink { Type = Constants.SOCIAL_LINKEDIN, Url = "https://www.linkedin.com/in/shirivo" },
            new UserSocialLink { Type = Constants.SOCIAL_TWITTER, Url = "https://twitter.com/shirivo" },
              },
                ImageUrl = "https://pbs.twimg.com/profile_images/1300605958423482369/VSVF8-1O_400x400.jpg"
            };

            var speaker8 = new User
            {
                Country = Constants.COUNTRIES_ARGENTINA,
                Details = new UserDetail[]
              {
          new UserDetail
          {
            Name = "Joel Alejandro Villarreal Bertoldi",
            Language = Constants.LANGUAGES_SPANISH,
            Company = "CoDeAr/Mercado Libre",
            JobTitle = "Co-Founder/Tech Lead"
          }
              },
                SocialLinks = new UserSocialLink[]
              {
            new UserSocialLink { Type = Constants.SOCIAL_LINKEDIN, Url = "https://www.linkedin.com/in/joelvillarrealbertoldi" },
            new UserSocialLink { Type = Constants.SOCIAL_TWITTER, Url = "https://twitter.com/joelalejandro" },
              },
                ImageUrl = "https://pbs.twimg.com/profile_images/1274885769019228161/U538bRxk_400x400.jpg"
            };

            var speaker9 = new User
            {
                Country = Constants.COUNTRIES_ARGENTINA,
                Details = new UserDetail[]
              {
          new UserDetail
          {
            Name = "Vanesa Cillo",
            Language = Constants.LANGUAGES_SPANISH,
            Company = "Mulesoft",
            JobTitle = "Director of Engineering"
          }
              },
                SocialLinks = new UserSocialLink[]
              {
            new UserSocialLink { Type = Constants.SOCIAL_LINKEDIN, Url = "https://www.linkedin.com/in/vanesacillo/" }
              },
                ImageUrl = "https://media-exp1.licdn.com/dms/image/C5103AQGV3Wiv6VuuSw/profile-displayphoto-shrink_800_800/0?e=1605744000&v=beta&t=6EaJYhsE1SQO004VcWaZ_eTBX_TtdrjkPz5Hh0T1tw0"
            };

            var speaker10 = new User
            {
                Country = Constants.COUNTRIES_GERMANY,
                Details = new UserDetail[]
              {
          new UserDetail
          {
            Name = "Nikita Malyschkin",
            Language = Constants.LANGUAGES_ENGLISH,
            Company = "INFORM GmbH",
            JobTitle = "Software Architect"
          }
              },
                SocialLinks = new UserSocialLink[]
              {
            new UserSocialLink { Type = Constants.SOCIAL_LINKEDIN, Url = "https://www.linkedin.com/in/nikita-malyschkin-152aa9190/" },
            new UserSocialLink { Type = Constants.SOCIAL_TWITTER, Url = "https://twitter.com/nmalyschkin" }
              },
                ImageUrl = "https://media-exp1.licdn.com/dms/image/C5603AQEW36Nu5IS8dA/profile-displayphoto-shrink_800_800/0?e=1605744000&v=beta&t=rEZ2vdcGhJEetKXmJuI7bC18H5wB-QN5TX47iblVDiM"
            };

            var speaker11 = new User
            {
                Country = Constants.COUNTRIES_MEXICO,
                Details = new UserDetail[]
              {
          new UserDetail
          {
            Name = "Yosele Angulo",
            Language = Constants.LANGUAGES_SPANISH,
            Company = "Distillery",
            JobTitle = "Country Manager"
          }
              },
                SocialLinks = new UserSocialLink[]
              {
            new UserSocialLink { Type = Constants.SOCIAL_LINKEDIN, Url = "https://www.linkedin.com/in/yoseleanguloorozco-4ba96851" }
              },
                ImageUrl = "https://media-exp1.licdn.com/dms/image/C4E03AQE6cOQkUVfmEw/profile-displayphoto-shrink_800_800/0?e=1605744000&v=beta&t=dpxyK7wkhWfhyqCc5F9LusazdPyQytRgKHGb3DH-DjE"
            };

            var speaker12 = new User
            {
                Country = Constants.COUNTRIES_UNITED_STATES,
                Details = new UserDetail[]
              {
          new UserDetail
          {
            Name = "Tammy Guns",
            Language = Constants.LANGUAGES_ENGLISH,
            Company = "CanCorp LLC",
            JobTitle = "CEO"
          }
              },
                SocialLinks = new UserSocialLink[]
              {
            new UserSocialLink { Type = Constants.SOCIAL_LINKEDIN, Url = "https://www.linkedin.com/in/tammylynnguns/" },
            new UserSocialLink { Type = Constants.SOCIAL_TWITTER, Url = "https://twitter.com/GunsTammy" }
              },
                ImageUrl = "https://pbs.twimg.com/profile_images/638201182490521600/4nVw6f-E_400x400.jpg"
            };

            var speaker13 = new User
            {
                Country = Constants.COUNTRIES_UNITED_STATES,
                Details = new UserDetail[]
              {
          new UserDetail
          {
            Name = "Christopher Salem",
            Language = Constants.LANGUAGES_ENGLISH,
            Company = "CRS Group Holdings, LLC",
            JobTitle = "CEO - Executive Coach"
          }
              },
                SocialLinks = new UserSocialLink[]
              {
            new UserSocialLink { Type = Constants.SOCIAL_LINKEDIN, Url = "https://www.linkedin.com/in/christophersalem" },
            new UserSocialLink { Type = Constants.SOCIAL_TWITTER, Url = "https://twitter.com/whealthteam" }
              },
                ImageUrl = "https://pbs.twimg.com/profile_images/891814181565079552/U5z6TK7o_400x400.jpg"
            };

            var speaker14 = new User
            {
                Country = Constants.COUNTRIES_PERU,
                Details = new UserDetail[]
              {
          new UserDetail
          {
            Name = "Alberto De Rossi",
            Language = Constants.LANGUAGES_SPANISH,
            Company = "dbLearner",
            JobTitle = "Consultor Data Platform"
          }
              },
                SocialLinks = new UserSocialLink[]
              {
            new UserSocialLink { Type = Constants.SOCIAL_LINKEDIN, Url = "https://www.linkedin.com/in/alberto-de-rossi-46814244/" },
            new UserSocialLink { Type = Constants.SOCIAL_TWITTER, Url = "https://twitter.com/albertoderossi" }
              },
                ImageUrl = "https://pbs.twimg.com/profile_images/1260309752774569984/bvuG0Tl0_400x400.jpg"
            };

            var speaker15 = new User
            {
                Country = Constants.COUNTRIES_ARGENTINA,
                Details = new UserDetail[]
              {
          new UserDetail
          {
            Name = "Ivana Tilca",
            Language = Constants.LANGUAGES_SPANISH,
            Company = "3XM Group",
            JobTitle = "Quality Manager/Microsoft MVP AI"
          }
              },
                SocialLinks = new UserSocialLink[]
              {
            new UserSocialLink { Type = Constants.SOCIAL_LINKEDIN, Url = "https://www.linkedin.com/in/ivanatilca/" },
            new UserSocialLink { Type = Constants.SOCIAL_TWITTER, Url = "https://twitter.com/ivanatilca" }
              },
                ImageUrl = "https://pbs.twimg.com/profile_images/1296925134100533248/5-6Dj05n_400x400.jpg"
            };

            var speaker16 = new User
            {
                Country = Constants.COUNTRIES_UNITED_STATES,
                Details = new UserDetail[]
              {
          new UserDetail
          {
            Name = "Dan Seidman",
            Language = Constants.LANGUAGES_ENGLISH,
            Company = "Read Emotions",
            JobTitle = "Managing Director"
          }
              },
                SocialLinks = new UserSocialLink[]
              {
            new UserSocialLink { Type = Constants.SOCIAL_LINKEDIN, Url = "https://www.linkedin.com/in/salesautopsy/" },
            new UserSocialLink { Type = Constants.SOCIAL_TWITTER, Url = "https://twitter.com/ReadEmotions" }
              },
                ImageUrl = "https://pbs.twimg.com/profile_images/1093164073867505664/l8hDKWor_400x400.jpg"
            };

            var speaker17 = new User
            {
                Country = Constants.COUNTRIES_ARGENTINA,
                Details = new UserDetail[]
              {
          new UserDetail
          {
            Name = "Christopher Louis Chancé",
            Language = Constants.LANGUAGES_SPANISH,
            Company = "DataXype",
            JobTitle = "CEO"
          }
              },
                SocialLinks = new UserSocialLink[]
              {
            new UserSocialLink { Type = Constants.SOCIAL_LINKEDIN, Url = "https://www.linkedin.com/in/chrischance67/" },
            new UserSocialLink { Type = Constants.SOCIAL_TWITTER, Url = "https://twitter.com/chrischance67" }
              },
                ImageUrl = "https://pbs.twimg.com/profile_images/1305056761578127360/Ec7pOCsK_400x400.jpg"
            };

            var vOpenUser = new User
            {
                Country = Constants.COUNTRIES_ARGENTINA,
                Details = new UserDetail[]
              {
              new UserDetail
              {
                Name = "vOpen Team",
                Language = Constants.LANGUAGES_SPANISH
              }
              },
                ImageUrl = "https://pbs.twimg.com/profile_images/1153603294281064448/_0X-eqH1_400x400.jpg"
            };

            context.Users.Add(speaker1);
            context.Users.Add(speaker2);
            context.Users.Add(speaker3);
            context.Users.Add(speaker4);
            context.Users.Add(speaker5);
            context.Users.Add(speaker6);
            context.Users.Add(speaker7);
            context.Users.Add(speaker8);
            context.Users.Add(speaker9);
            context.Users.Add(speaker10);
            context.Users.Add(speaker11);
            context.Users.Add(speaker12);
            context.Users.Add(speaker13);
            context.Users.Add(speaker14);
            context.Users.Add(speaker15);
            context.Users.Add(speaker16);
            context.Users.Add(speaker17);
            context.Users.Add(vOpenUser);

            var aperturaTech = new EditionActivity
            {
                Day = "Day 1",
                Duration = "00:30",
                Edition = edition,
                Level = "100",
                Track = "Techie",
                Date = "2020-10-03T09:00:00.000-05:00",
                Type = "Opening",
                Details = new List<EditionActivityDetail>
        {
          new EditionActivityDetail
          {
            Language = "es-AR",
            Title = "Keynote"
          }
        },
                Users = new List<EditionActivityUser> { new EditionActivityUser { User = vOpenUser } }
            };

            var talkTech1 = new EditionActivity
            {
                Day = "Day 1",
                Duration = "00:45",
                Edition = edition,
                Level = "100",
                Track = "Techie",
                Date = "2020-10-03T09:30:00.000-05:00",
                Type = "Talk",
                Tags = "Google Cloud",
                Details = new List<EditionActivityDetail>
        {
          new EditionActivityDetail
          {
            Language = "en-US",
            Title = "An app modernization story with Cloud Run",
          }
        },
                Users = new List<EditionActivityUser> { new EditionActivityUser { User = speaker1 } }
            };

            var talkTech2 = new EditionActivity
            {
                Day = "Day 1",
                Duration = "00:45",
                Edition = edition,
                Level = "100",
                Track = "Techie",
                Date = "2020-10-03T10:15:00.000-05:00",
                Type = "Talk",
                Tags = "Testing, TDD",
                Details = new List<EditionActivityDetail>
        {
          new EditionActivityDetail
          {
            Language = "es-AR",
            Title = "Los tests unitarios son necesarios? Y porqué TDD?",
          }
        },
                Users = new List<EditionActivityUser> { new EditionActivityUser { User = speaker2 } }
            };

            var lightningTalk1 = new EditionActivity
            {
                Day = "Day 1",
                Duration = "00:15",
                Edition = edition,
                Level = "100",
                Track = "Techie",
                Date = "2020-10-03T11:00:00.000-05:00",
                Type = "LightningTalk",
                Details = new List<EditionActivityDetail>
        {
          new EditionActivityDetail
          {
            Language = "es-AR",
            Title = "Lightning Talk"
          }
        },
                Users = new List<EditionActivityUser> { new EditionActivityUser { User = vOpenUser } }
            };

            var talkTech3 = new EditionActivity
            {
                Day = "Day 1",
                Duration = "00:45",
                Edition = edition,
                Level = "100",
                Track = "Techie",
                Date = "2020-10-03T11:15:00.000-05:00",
                Type = "Talk",
                Tags = "General",
                Details = new List<EditionActivityDetail>
        {
          new EditionActivityDetail
          {
            Language = "es-AR",
            Title = "Cuídalos: de la idea hasta la salida a producción",
          }
        },
                Users = new List<EditionActivityUser> { new EditionActivityUser { User = speaker17 } }
            };

            var talkTech4 = new EditionActivity
            {
                Day = "Day 1",
                Duration = "00:45",
                Edition = edition,
                Level = "100",
                Track = "Techie",
                Date = "2020-10-03T12:00:00.000-05:00",
                Type = "Talk",
                Tags = "UX",
                Details = new List<EditionActivityDetail>
        {
          new EditionActivityDetail
          {
            Language = "es-AR",
            Title = "¿Y el usuario? Consejos prácticos de UX",
          }
        },
                Users = new List<EditionActivityUser> { new EditionActivityUser { User = speaker3 } }
            };

            var break1 = new EditionActivity
            {
                Day = "Day 1",
                Duration = "00:15",
                Edition = edition,
                Level = "100",
                Track = "Techie",
                Date = "2020-10-03T12:45:00.000-05:00",
                Type = "Break",
                Details = new List<EditionActivityDetail>
        {
          new EditionActivityDetail
          {
            Language = "es-AR",
            Title = "Juego"
          }
        },
                Users = new List<EditionActivityUser> { new EditionActivityUser { User = vOpenUser } }
            };

            var talkTech5 = new EditionActivity
            {
                Day = "Day 1",
                Duration = "00:45",
                Edition = edition,
                Level = "100",
                Track = "Techie",
                Date = "2020-10-03T13:00:00.000-05:00",
                Type = "Talk",
                Tags = "Graph DB",
                Details = new List<EditionActivityDetail>
        {
          new EditionActivityDetail
          {
            Language = "en-US",
            Title = "Dungeons, Dragons, and Graph Databases",
          }
        },
                Users = new List<EditionActivityUser> { new EditionActivityUser { User = speaker4 } }
            };

            var talkTech6 = new EditionActivity
            {
                Day = "Day 1",
                Duration = "00:45",
                Edition = edition,
                Level = "100",
                Track = "Techie",
                Date = "2020-10-03T13:45:00.000-05:00",
                Type = "Talk",
                Tags = "AI, Alibaba CLoud",
                Details = new List<EditionActivityDetail>
        {
          new EditionActivityDetail
          {
            Language = "es-AR",
            Title = "Inteligencia artificial aplicada con Alibaba Cloud",
          }
        },
                Users = new List<EditionActivityUser> { new EditionActivityUser { User = speaker5 } }
            };

            var break2 = new EditionActivity
            {
                Day = "Day 1",
                Duration = "00:15",
                Edition = edition,
                Level = "100",
                Track = "Techie",
                Date = "2020-10-03T14:30:00.000-05:00",
                Type = "Break",
                Details = new List<EditionActivityDetail>
        {
          new EditionActivityDetail
          {
            Language = "es-AR",
            Title = "Juego"
          }
        },
                Users = new List<EditionActivityUser> { new EditionActivityUser { User = vOpenUser } }
            };

            var talkTech7 = new EditionActivity
            {
                Day = "Day 1",
                Duration = "00:45",
                Edition = edition,
                Level = "100",
                Track = "Techie",
                Date = "2020-10-03T14:45:00.000-05:00",
                Type = "Talk",
                Tags = "Machine Learning, JS",
                Details = new List<EditionActivityDetail>
        {
          new EditionActivityDetail
          {
            Language = "es-AR",
            Title = "Machine learning in the browser using TensorFlow.js",
          }
        },
                Users = new List<EditionActivityUser> { new EditionActivityUser { User = speaker6 } }
            };

            var talkTech8 = new EditionActivity
            {
                Day = "Day 1",
                Duration = "00:45",
                Edition = edition,
                Level = "100",
                Track = "Techie",
                Date = "2020-10-03T15:30:00.000-05:00",
                Type = "Talk",
                Tags = "Azure, AI, Cognitive Services",
                Details = new List<EditionActivityDetail>
        {
          new EditionActivityDetail
          {
            Language = "es-AR",
            Title = "Servicios cognitivos aplicados en el día a día",
          }
        },
                Users = new List<EditionActivityUser> { new EditionActivityUser { User = speaker7 } }
            };

            var lightningTalk2 = new EditionActivity
            {
                Day = "Day 1",
                Duration = "00:15",
                Edition = edition,
                Level = "100",
                Track = "Techie",
                Date = "2020-10-03T16:15:00.000-05:00",
                Type = "LightningTalk",
                Details = new List<EditionActivityDetail>
        {
          new EditionActivityDetail
          {
            Language = "es-AR",
            Title = "Lightning Talk"
          }
        },
                Users = new List<EditionActivityUser> { new EditionActivityUser { User = vOpenUser } }
            };

            var talkTech9 = new EditionActivity
            {
                Day = "Day 1",
                Duration = "01:00",
                Edition = edition,
                Level = "100",
                Track = "Techie",
                Date = "2020-10-03T16:30:00.000-05:00",
                Type = "Talk",
                Tags = "ReactJS, JS, FE",
                Details = new List<EditionActivityDetail>
        {
          new EditionActivityDetail
          {
            Language = "es-AR",
            Title = "useReact('better'): El hook de las buenas prácticas",
          }
        },
                Users = new List<EditionActivityUser> { new EditionActivityUser { User = speaker8 } }
            };

            var cierreTech = new EditionActivity
            {
                Day = "Day 1",
                Duration = "00:30",
                Edition = edition,
                Level = "100",
                Track = "Techie",
                Date = "2020-10-03T17:30:00.000-05:00",
                Type = "Closing",
                Details = new List<EditionActivityDetail>
        {
          new EditionActivityDetail
          {
            Language = "es-AR",
            Title = "Cierre"
          }
        },
                Users = new List<EditionActivityUser> { new EditionActivityUser { User = vOpenUser } }
            };

            var aperturaBusiness = new EditionActivity
            {
                Day = "Day 1",
                Duration = "00:45",
                Edition = edition,
                Level = "100",
                Track = "Business",
                Date = "2020-10-03T09:00:00.000-05:00",
                Type = "Opening",
                Details = new List<EditionActivityDetail>
        {
          new EditionActivityDetail
          {
            Language = "es-AR",
            Title = "Keynote"
          }
        },
                Users = new List<EditionActivityUser> { new EditionActivityUser { User = vOpenUser } }
            };

            var talkBusiness1 = new EditionActivity
            {
                Day = "Day 1",
                Duration = "00:45",
                Edition = edition,
                Level = "100",
                Track = "Business",
                Date = "2020-10-03T09:30:00.000-05:00",
                Type = "Talk",
                Tags = "Innovation",
                Details = new List<EditionActivityDetail>
        {
          new EditionActivityDetail
          {
            Language = "es-AR",
            Title = "Emprender e innovar en una corporación como plan de carrera",
          }
        },
                Users = new List<EditionActivityUser> { new EditionActivityUser { User = speaker9 } }
            };

            var talkBusiness2 = new EditionActivity
            {
                Day = "Day 1",
                Duration = "00:45",
                Edition = edition,
                Level = "100",
                Track = "Business",
                Date = "2020-10-03T10:15:00.000-05:00",
                Type = "Talk",
                Tags = "Soft Skills",
                Details = new List<EditionActivityDetail>
        {
          new EditionActivityDetail
          {
            Language = "en-US",
            Title = "Develop yourself, not software",
          }
        },
                Users = new List<EditionActivityUser> { new EditionActivityUser { User = speaker10 } }
            };

            var lightningTalk3 = new EditionActivity
            {
                Day = "Day 1",
                Duration = "00:15",
                Edition = edition,
                Level = "100",
                Track = "Business",
                Date = "2020-10-03T11:00:00.000-05:00",
                Type = "LightningTalk",
                Details = new List<EditionActivityDetail>
        {
          new EditionActivityDetail
          {
            Language = "es-AR",
            Title = "Lightning Talk"
          }
        },
                Users = new List<EditionActivityUser> { new EditionActivityUser { User = vOpenUser } }
            };

            var talkBusiness3 = new EditionActivity
            {
                Day = "Day 1",
                Duration = "00:45",
                Edition = edition,
                Level = "100",
                Track = "Business",
                Date = "2020-10-03T11:15:00.000-05:00",
                Type = "Talk",
                Tags = "Management",
                Details = new List<EditionActivityDetail>
        {
          new EditionActivityDetail
          {
            Language = "es-AR",
            Title = "El principio de la 'P' para administrar una empresa remota",
          }
        },
                Users = new List<EditionActivityUser> { new EditionActivityUser { User = speaker11 } }
            };

            var talkBusiness4 = new EditionActivity
            {
                Day = "Day 1",
                Duration = "00:45",
                Edition = edition,
                Level = "100",
                Track = "Business",
                Date = "2020-10-03T12:00:00.000-05:00",
                Type = "Talk",
                Tags = "Soft Skills",
                Details = new List<EditionActivityDetail>
        {
          new EditionActivityDetail
          {
            Language = "en-US",
            Title = "Is the FEAR of Change Causing Your System to Crash?",
          }
        },
                Users = new List<EditionActivityUser> { new EditionActivityUser { User = speaker12 } }
            };

            var break3 = new EditionActivity
            {
                Day = "Day 1",
                Duration = "00:15",
                Edition = edition,
                Level = "100",
                Track = "Business",
                Date = "2020-10-03T12:45:00.000-05:00",
                Type = "Break",
                Details = new List<EditionActivityDetail>
        {
          new EditionActivityDetail
          {
            Language = "es-AR",
            Title = "Juego"
          }
        },
                Users = new List<EditionActivityUser> { new EditionActivityUser { User = vOpenUser } }
            };

            var talkBusiness5 = new EditionActivity
            {
                Day = "Day 1",
                Duration = "00:45",
                Edition = edition,
                Level = "100",
                Track = "Business",
                Date = "2020-10-03T13:00:00.000-05:00",
                Type = "Talk",
                Details = new List<EditionActivityDetail>
        {
          new EditionActivityDetail
          {
            Language = "es-AR",
            Title = "Panel: Mujeres en Tecnologia",
          }
        }
            };

            var talkBusiness6 = new EditionActivity
            {
                Day = "Day 1",
                Duration = "00:45",
                Edition = edition,
                Level = "100",
                Track = "Business",
                Date = "2020-10-03T13:45:00.000-05:00",
                Type = "Talk",
                Tags = "Innovation",
                Details = new List<EditionActivityDetail>
        {
          new EditionActivityDetail
          {
            Language = "en-US",
            Title = "Fostering Innovation in the New Workplace",
          }
        },
                Users = new List<EditionActivityUser> { new EditionActivityUser { User = speaker13 } }
            };

            var break4 = new EditionActivity
            {
                Day = "Day 1",
                Duration = "00:15",
                Edition = edition,
                Level = "100",
                Track = "Business",
                Date = "2020-10-03T14:30:00.000-05:00",
                Type = "Break",
                Details = new List<EditionActivityDetail>
        {
          new EditionActivityDetail
          {
            Language = "es-AR",
            Title = "Juego"
          }
        },
                Users = new List<EditionActivityUser> { new EditionActivityUser { User = vOpenUser } }
            };

            var talkBusiness7 = new EditionActivity
            {
                Day = "Day 1",
                Duration = "00:45",
                Edition = edition,
                Level = "100",
                Track = "Business",
                Date = "2020-10-03T14:45:00.000-05:00",
                Type = "Talk",
                Tags = "Power BI",
                Details = new List<EditionActivityDetail>
        {
          new EditionActivityDetail
          {
            Language = "es-AR",
            Title = "Lineaje de datos: conceptos y gestión con Power BI",
          }
        },
                Users = new List<EditionActivityUser> { new EditionActivityUser { User = speaker14 } }
            };

            var talkBusiness8 = new EditionActivity
            {
                Day = "Day 1",
                Duration = "00:45",
                Edition = edition,
                Level = "100",
                Track = "Business",
                Date = "2020-10-03T15:30:00.000-05:00",
                Type = "Talk",
                Tags = "AI",
                Details = new List<EditionActivityDetail>
        {
          new EditionActivityDetail
          {
            Language = "en-US",
            Title = "Using pre-built AI to solve business challenges",
          }
        },
                Users = new List<EditionActivityUser> { new EditionActivityUser { User = speaker15 } }
            };

            var lightningTalk4 = new EditionActivity
            {
                Day = "Day 1",
                Duration = "00:15",
                Edition = edition,
                Level = "100",
                Track = "Business",
                Date = "2020-10-03T16:15:00.000-05:00",
                Type = "LightningTalk",
                Details = new List<EditionActivityDetail>
        {
          new EditionActivityDetail
          {
            Language = "es-AR",
            Title = "Lightning Talk"
          }
        },
                Users = new List<EditionActivityUser> { new EditionActivityUser { User = vOpenUser } }
            };

            var talkBusiness9 = new EditionActivity
            {
                Day = "Day 1",
                Duration = "01:00",
                Edition = edition,
                Level = "100",
                Track = "Business",
                Date = "2020-10-03T16:30:00.000-05:00",
                Type = "Talk",
                Tags = "Soft Skills",
                Details = new List<EditionActivityDetail>
        {
          new EditionActivityDetail
          {
            Language = "en-US",
            Title = "Read (Hidden) Emotions - gain access to information you've never had - knowing what others feel",
          }
        },
                Users = new List<EditionActivityUser> { new EditionActivityUser { User = speaker16 } }
            };

            var cierreBusiness = new EditionActivity
            {
                Day = "Day 1",
                Duration = "00:30",
                Edition = edition,
                Level = "100",
                Track = "Business",
                Date = "2020-10-03T17:30:00.000-05:00",
                Type = "Closing",
                Details = new List<EditionActivityDetail>
        {
          new EditionActivityDetail
          {
            Language = "es-AR",
            Title = "Cierre"
          }
        },
                Users = new List<EditionActivityUser> { new EditionActivityUser { User = vOpenUser } }
            };

            context.EditionsActivities.Add(aperturaTech);
            context.EditionsActivities.Add(talkTech1);
            context.EditionsActivities.Add(talkTech2);
            context.EditionsActivities.Add(lightningTalk1);
            context.EditionsActivities.Add(talkTech3);
            context.EditionsActivities.Add(talkTech4);
            context.EditionsActivities.Add(break1);
            context.EditionsActivities.Add(talkTech5);
            context.EditionsActivities.Add(talkTech6);
            context.EditionsActivities.Add(break2);
            context.EditionsActivities.Add(talkTech7);
            context.EditionsActivities.Add(talkTech8);
            context.EditionsActivities.Add(lightningTalk2);
            context.EditionsActivities.Add(talkTech9);
            context.EditionsActivities.Add(cierreTech);

            context.EditionsActivities.Add(aperturaBusiness);
            context.EditionsActivities.Add(talkBusiness1);
            context.EditionsActivities.Add(talkBusiness2);
            context.EditionsActivities.Add(lightningTalk3);
            context.EditionsActivities.Add(talkBusiness3);
            context.EditionsActivities.Add(talkBusiness4);
            context.EditionsActivities.Add(break3);
            context.EditionsActivities.Add(talkBusiness5);
            context.EditionsActivities.Add(talkBusiness6);
            context.EditionsActivities.Add(break4);
            context.EditionsActivities.Add(talkBusiness7);
            context.EditionsActivities.Add(talkBusiness8);
            context.EditionsActivities.Add(lightningTalk4);
            context.EditionsActivities.Add(talkBusiness9);
            context.EditionsActivities.Add(cierreBusiness);

            return new List<EditionActivity>
      {
        aperturaTech, talkTech1, talkTech2, lightningTalk1, talkTech3, talkTech4, break1, talkTech5, talkTech6, break2, talkTech7, talkTech8, lightningTalk2, talkTech9, cierreTech,
        aperturaBusiness, talkBusiness1, talkBusiness2, lightningTalk3, talkBusiness3, talkBusiness4, break3, talkBusiness5, talkBusiness6, break4, talkBusiness7, talkBusiness8, lightningTalk4, talkBusiness9, cierreBusiness
      };
        }
    }
}
