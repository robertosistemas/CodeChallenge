using AutoMapper;
using CodeChallenge.Domain.Models;
using CodeChallenge.WebApi;
using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;
using System;
using Xunit;

namespace CodeChallenge.IntegrationsTests.WebApi
{
    public class MapperTests : IntegrateTestBase<Startup>, IClassFixture<ApiWebApplicationFactory<Startup>>
    {
        public MapperTests(ApiWebApplicationFactory<Startup> factory) : base(factory)
        {

        }

        [Fact]
        public void User_Mapper_Special_One_Test()
        {
            // Arrange

            var userImport = new UserImportModel
            {
                Gender = "male",
                Name = new NameModel
                {
                    Title = "Mr",
                    First = "Roberto",
                    Last = "Silva"
                },
                Location = new LocationModel
                {
                    Street = "Rua Teste",
                    City = "Floripa",
                    State = "santa catarina",
                    Postcode = 12345789,
                    Coordinates = new CoordinatesModel
                    {
                        Latitude = "-46.361899",
                        Longitude = "-15.411580"
                    },
                    Timezone = new TimezoneModel
                    {
                        Offset = "-1:00",
                        Description = "Azores, Cape Verde Islands"
                    }
                },
                Email = "ione.dacosta@example.com",
                Dob = new DobModel
                {
                    Date = Convert.ToDateTime("1968-01-24T18:03:23Z"),
                    //Age = 50
                },
                Registered = new RegisteredModel
                {
                    Date = Convert.ToDateTime("2004-01-23T23:54:33Z"),
                    //Age = 14
                },
                Phone = "(01) 5415-5648",
                Cell = "(10) 8264-5550",
                Picture = new PictureModel
                {
                    Large = "https://randomuser.me/api/portraits/women/46.jpg",
                    Medium = "https://randomuser.me/api/portraits/med/women/46.jpg",
                    Thumbnail = "https://randomuser.me/api/portraits/thumb/women/46.jpg"
                }
            };

            //Act

            var mapper = Factory.Services.GetService<IMapper>();
            var user = mapper.Map<UserModel>(userImport);

            // Assert

            user.Id.Should().NotBeEmpty();
            user.Type.Should().Be("special");
            user.Gender.Should().Be("m");

            user.Birthday.Should().Be(Convert.ToDateTime("1968-01-24T18:03:23Z"));
            user.Registered.Should().Be(Convert.ToDateTime("2004-01-23T23:54:33Z"));

            user.TelephoneNumbers.Count.Should().Be(1);
            user.TelephoneNumbers[0].Should().Be("+550154155648");

            user.MobileNumbers.Count.Should().Be(1);
            user.MobileNumbers[0].Should().Be("+551082645550");

            user.Nationality.Should().Be("BR");
            user.Location.Region.Should().Be("sul");

        }

        [Fact]
        public void User_Mapper_Special_Two_Test()
        {
            // Arrange

            var userImport = new UserImportModel
            {
                Gender = "male",
                Name = new NameModel
                {
                    Title = "Mr",
                    First = "Roberto",
                    Last = "Silva"
                },
                Location = new LocationModel
                {
                    Street = "Rua Teste",
                    City = "Floripa",
                    State = "santa catarina",
                    Postcode = 12345789,
                    Coordinates = new CoordinatesModel
                    {
                        Latitude = "-52.997614",
                        Longitude = "-23.966413"
                    },
                    Timezone = new TimezoneModel
                    {
                        Offset = "-1:00",
                        Description = "Azores, Cape Verde Islands"
                    }
                },
                Email = "ione.dacosta@example.com",
                Dob = new DobModel
                {
                    Date = Convert.ToDateTime("1968-01-24T18:03:23Z"),
                    //Age = 50
                },
                Registered = new RegisteredModel
                {
                    Date = Convert.ToDateTime("2004-01-23T23:54:33Z"),
                    //Age = 14
                },
                Phone = "(01) 5415-5648",
                Cell = "(10) 8264-5550",
                Picture = new PictureModel
                {
                    Large = "https://randomuser.me/api/portraits/women/46.jpg",
                    Medium = "https://randomuser.me/api/portraits/med/women/46.jpg",
                    Thumbnail = "https://randomuser.me/api/portraits/thumb/women/46.jpg"
                }
            };

            //Act

            var mapper = Factory.Services.GetService<IMapper>();
            var user = mapper.Map<UserModel>(userImport);

            // Assert

            user.Id.Should().NotBeEmpty();
            user.Type.Should().Be("special");
            user.Gender.Should().Be("m");

            user.Birthday.Should().Be(Convert.ToDateTime("1968-01-24T18:03:23Z"));
            user.Registered.Should().Be(Convert.ToDateTime("2004-01-23T23:54:33Z"));

            user.TelephoneNumbers.Count.Should().Be(1);
            user.TelephoneNumbers[0].Should().Be("+550154155648");

            user.MobileNumbers.Count.Should().Be(1);
            user.MobileNumbers[0].Should().Be("+551082645550");

            user.Nationality.Should().Be("BR");
            user.Location.Region.Should().Be("sul");

        }

        [Fact]
        public void User_Mapper_Normal_Test()
        {
            // Arrange

            var userImport = new UserImportModel
            {
                Gender = "male",
                Name = new NameModel
                {
                    Title = "Mr",
                    First = "Roberto",
                    Last = "Silva"
                },
                Location = new LocationModel
                {
                    Street = "Rua Teste",
                    City = "Floripa",
                    State = "santa catarina",
                    Postcode = 12345789,
                    Coordinates = new CoordinatesModel
                    {
                        Latitude = "-54.777426",
                        Longitude = "-34.016466"
                    },
                    Timezone = new TimezoneModel
                    {
                        Offset = "-1:00",
                        Description = "Azores, Cape Verde Islands"
                    }
                },
                Email = "ione.dacosta@example.com",
                Dob = new DobModel
                {
                    Date = Convert.ToDateTime("1968-01-24T18:03:23Z"),
                    //Age = 50
                },
                Registered = new RegisteredModel
                {
                    Date = Convert.ToDateTime("2004-01-23T23:54:33Z"),
                    //Age = 14
                },
                Phone = "(01) 5415-5648",
                Cell = "(10) 8264-5550",
                Picture = new PictureModel
                {
                    Large = "https://randomuser.me/api/portraits/women/46.jpg",
                    Medium = "https://randomuser.me/api/portraits/med/women/46.jpg",
                    Thumbnail = "https://randomuser.me/api/portraits/thumb/women/46.jpg"
                }
            };

            //Act

            var mapper = Factory.Services.GetService<IMapper>();
            var user = mapper.Map<UserModel>(userImport);

            // Assert

            user.Id.Should().NotBeEmpty();
            user.Type.Should().Be("normal");
            user.Gender.Should().Be("m");

            user.Birthday.Should().Be(Convert.ToDateTime("1968-01-24T18:03:23Z"));
            user.Registered.Should().Be(Convert.ToDateTime("2004-01-23T23:54:33Z"));

            user.TelephoneNumbers.Count.Should().Be(1);
            user.TelephoneNumbers[0].Should().Be("+550154155648");

            user.MobileNumbers.Count.Should().Be(1);
            user.MobileNumbers[0].Should().Be("+551082645550");

            user.Nationality.Should().Be("BR");
            user.Location.Region.Should().Be("sul");

        }

        [Fact]
        public void User_Mapper_Laborious_Test()
        {
            // Arrange

            var userImport = new UserImportModel
            {
                Gender = "male",
                Name = new NameModel
                {
                    Title = "Mr",
                    First = "Roberto",
                    Last = "Silva"
                },
                Location = new LocationModel
                {
                    Street = "Rua Teste",
                    City = "Floripa",
                    State = "santa catarina",
                    Postcode = 12345789,
                    Coordinates = new CoordinatesModel
                    {
                        Latitude = "-76.3253",
                        Longitude = "137.9437"
                    },
                    Timezone = new TimezoneModel
                    {
                        Offset = "-1:00",
                        Description = "Azores, Cape Verde Islands"
                    }
                },
                Email = "ione.dacosta@example.com",
                Dob = new DobModel
                {
                    Date = Convert.ToDateTime("1968-01-24T18:03:23Z"),
                    //Age = 50
                },
                Registered = new RegisteredModel
                {
                    Date = Convert.ToDateTime("2004-01-23T23:54:33Z"),
                    //Age = 14
                },
                Phone = "(01) 5415-5648",
                Cell = "(10) 8264-5550",
                Picture = new PictureModel
                {
                    Large = "https://randomuser.me/api/portraits/women/46.jpg",
                    Medium = "https://randomuser.me/api/portraits/med/women/46.jpg",
                    Thumbnail = "https://randomuser.me/api/portraits/thumb/women/46.jpg"
                }
            };

            //Act

            var mapper = Factory.Services.GetService<IMapper>();
            var user = mapper.Map<UserModel>(userImport);

            // Assert

            user.Id.Should().NotBeEmpty();
            user.Type.Should().Be("laborious");
            user.Gender.Should().Be("m");

            user.Birthday.Should().Be(Convert.ToDateTime("1968-01-24T18:03:23Z"));
            user.Registered.Should().Be(Convert.ToDateTime("2004-01-23T23:54:33Z"));

            user.TelephoneNumbers.Count.Should().Be(1);
            user.TelephoneNumbers[0].Should().Be("+550154155648");

            user.MobileNumbers.Count.Should().Be(1);
            user.MobileNumbers[0].Should().Be("+551082645550");

            user.Nationality.Should().Be("BR");
            user.Location.Region.Should().Be("sul");

        }

    }
}
