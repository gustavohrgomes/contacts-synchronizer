using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using WireMock.RequestBuilders;
using WireMock.ResponseBuilders;
using WireMock.Server;

namespace Contacts.Synchronizer.Tests.Integration;
public class MockApiServer : IDisposable
{
    private WireMockServer _server = WireMockServer.Start();

    public string Url => _server.Url!;

    public void Start()
    {
        _server = WireMockServer.Start();
    }

    public void GetContacts()
    {
        _server
            .Given(Request.Create()
                .WithPath("/api/v1/contacts")
                .UsingGet())
            .RespondWith(Response.Create()
                .WithBody(GetContactsResponse())
                .WithHeader("Content-Type", "application/json", "charset=utf-8")
                .WithStatusCode(HttpStatusCode.OK));
    }

    public void CreateList()
    {
        _server
            .Given(Request.Create()
                .WithPath("/lists")
                .UsingPost())
            .RespondWith(Response.Create()
                .WithBody(CreateListResponse())
                .WithHeader("Content-Type", "application/json", "charset=utf-8")
                .WithHeader("Content-Length", "1121")
                .WithStatusCode(HttpStatusCode.OK));
    }

    public void AddMembersToList()
    {
        _server
            .Given(Request.Create()
                .WithPath($"/lists/f23f740fd9")
                .UsingPost())
            .RespondWith(Response.Create()
                .WithBody(AddMembersToListResponse())
                .WithHeader("Content-Type", "application/json", "charset=utf-8")
                .WithHeader("Content-Length", "3966")
                .WithStatusCode(HttpStatusCode.OK));
    }

    private static string GetContactsResponse()
    {
        return """
            [
                {
                    "createdAt": "2022-02-18T16:32:23.057Z",
                    "firstName": "Michelle pfifer",
                    "lastName": "Gaylord",
                    "email": "Kirk.Fritsch198@hotmail.com",
                    "avatar": "https://cdn.fakercloud.com/avatars/dshster_128.jpg",
                    "id": "115"
                },
                {
                    "createdAt": "2022-02-18T18:09:28.068Z",
                    "firstName": "Deborah",
                    "lastName": "Schinner",
                    "email": "Corbin.Abshire206@gmail.com",
                    "avatar": "https://cdn.fakercloud.com/avatars/spacewood__128.jpg",
                    "id": "116"
                },
                {
                    "createdAt": "2022-02-18T16:41:12.035Z",
                    "firstName": "Jessika",
                    "lastName": "Auer",
                    "email": "Dillon132@hotmail.com",
                    "avatar": "https://cdn.fakercloud.com/avatars/xalionmalik_128.jpg",
                    "id": "117"
                },
                {
                    "createdAt": "2022-02-18T15:13:59.635Z",
                    "firstName": "Geo",
                    "lastName": "Schmitt",
                    "email": "Cierra_Walsh261@gmail.com",
                    "avatar": "https://cdn.fakercloud.com/avatars/sircalebgrove_128.jpg",
                    "id": "118"
                },
                {
                    "createdAt": "2022-02-18T13:40:05.955Z",
                    "firstName": "Floyd",
                    "lastName": "Gerlach",
                    "email": "Adalberto397@outlook.com",
                    "avatar": "https://cdn.fakercloud.com/avatars/dreizle_128.jpg",
                    "id": "119"
                },
                {
                    "createdAt": "2022-02-18T08:17:35.041Z",
                    "firstName": "Hoyt",
                    "lastName": "Grady",
                    "email": "Elvie.Hagenes72@outlook.com",
                    "avatar": "https://cdn.fakercloud.com/avatars/anaami_128.jpg",
                    "id": "120"
                },
                {
                    "createdAt": "2022-02-18T01:36:33.505Z",
                    "firstName": "Royce",
                    "lastName": "Kunze",
                    "email": "Dallin_Powlowski55@hotmail.com",
                    "avatar": "https://cdn.fakercloud.com/avatars/ruehldesign_128.jpg",
                    "id": "121"
                },
                {
                    "createdAt": "2022-02-18T14:41:41.858Z",
                    "firstName": "Eileen",
                    "lastName": "Schowalter",
                    "email": "Jameson683@icloud.com",
                    "avatar": "https://cdn.fakercloud.com/avatars/brenmurrell_128.jpg",
                    "id": "122"
                },
                {
                    "createdAt": "2022-02-18T15:02:25.539Z",
                    "firstName": "Leonie",
                    "lastName": "Strosin",
                    "email": "Raheem.DAmore821@icloud.com",
                    "avatar": "https://cdn.fakercloud.com/avatars/mhaligowski_128.jpg",
                    "id": "123"
                },
                {
                    "createdAt": "2022-02-18T01:22:48.341Z",
                    "firstName": "Noemie",
                    "lastName": "Gleichner",
                    "email": "Cristina187@yahoo.com",
                    "avatar": "https://cdn.fakercloud.com/avatars/moscoz_128.jpg",
                    "id": "124"
                },
                {
                    "createdAt": "2022-02-18T15:56:23.326Z",
                    "firstName": "Kaleb",
                    "lastName": "Robel",
                    "email": "Leonel.Sipes6@yahoo.com",
                    "avatar": "https://cdn.fakercloud.com/avatars/lepinski_128.jpg",
                    "id": "125"
                },
                {
                    "createdAt": "2022-02-18T04:53:58.106Z",
                    "firstName": "Harold",
                    "lastName": "Mann",
                    "email": "Alexys_Aufderhar147@yahoo.com",
                    "avatar": "https://cdn.fakercloud.com/avatars/AlbertoCococi_128.jpg",
                    "id": "126"
                },
                {
                    "createdAt": "2022-02-18T16:26:20.492Z",
                    "firstName": "Danyka",
                    "lastName": "Witting",
                    "email": "Jamil381@hotmail.com",
                    "avatar": "https://cdn.fakercloud.com/avatars/rude_128.jpg",
                    "id": "127"
                },
                {
                    "createdAt": "2022-02-18T04:13:01.747Z",
                    "firstName": "Alvena",
                    "lastName": "Marks",
                    "email": "Trace.Johnston128@yahoo.com",
                    "avatar": "https://cdn.fakercloud.com/avatars/itskawsar_128.jpg",
                    "id": "128"
                },
                {
                    "createdAt": "2022-02-18T04:09:47.743Z",
                    "firstName": "Christopher",
                    "lastName": "Marquardt",
                    "email": "Felipe238@icloud.com",
                    "avatar": "https://cdn.fakercloud.com/avatars/kurtinc_128.jpg",
                    "id": "129"
                },
                {
                    "createdAt": "2022-02-18T20:05:15.394Z",
                    "firstName": "Tod",
                    "lastName": "Stehr",
                    "email": "Reginald_Bechtelar980@gmail.com",
                    "avatar": "https://cdn.fakercloud.com/avatars/elliotnolten_128.jpg",
                    "id": "130"
                },
                {
                    "createdAt": "2022-02-18T17:00:53.930Z",
                    "firstName": "Delphia",
                    "lastName": "Huels",
                    "email": "Myrtis343@icloud.com",
                    "avatar": "https://cdn.fakercloud.com/avatars/jayphen_128.jpg",
                    "id": "131"
                },
                {
                    "createdAt": "2022-02-18T00:34:59.582Z",
                    "firstName": "Nels",
                    "lastName": "Brakus",
                    "email": "Rebeka_Thompson200@gmail.com",
                    "avatar": "https://cdn.fakercloud.com/avatars/davidmerrique_128.jpg",
                    "id": "132"
                },
                {
                    "createdAt": "2022-02-18T03:47:26.577Z",
                    "firstName": "Bethel",
                    "lastName": "Rau",
                    "email": "Benedict_Kunze311@icloud.com",
                    "avatar": "https://cdn.fakercloud.com/avatars/janpalounek_128.jpg",
                    "id": "133"
                },
                {
                    "createdAt": "2022-02-18T16:56:51.886Z",
                    "firstName": "Charley",
                    "lastName": "Hermann",
                    "email": "Jennie.Kessler436@hotmail.com",
                    "avatar": "https://cdn.fakercloud.com/avatars/0therplanet_128.jpg",
                    "id": "134"
                },
                {
                    "createdAt": "2022-02-18T05:17:55.961Z",
                    "firstName": "Cole",
                    "lastName": "Zieme",
                    "email": "Terrance379@outlook.com",
                    "avatar": "https://cdn.fakercloud.com/avatars/madshensel_128.jpg",
                    "id": "135"
                },
                {
                    "createdAt": "2022-02-18T09:21:05.918Z",
                    "firstName": "Lee",
                    "lastName": "Runolfsson",
                    "email": "Jackie571@icloud.com",
                    "avatar": "https://cdn.fakercloud.com/avatars/deviljho__128.jpg",
                    "id": "136"
                },
                {
                    "createdAt": "2022-02-18T18:50:12.509Z",
                    "firstName": "Zander",
                    "lastName": "Greenholt",
                    "email": "Austin244@hotmail.com",
                    "avatar": "https://cdn.fakercloud.com/avatars/jm_denis_128.jpg",
                    "id": "137"
                },
                {
                    "createdAt": "2022-02-18T11:09:33.659Z",
                    "firstName": "Rene",
                    "lastName": "Nienow",
                    "email": "Michael_Dach29@hotmail.com",
                    "avatar": "https://cdn.fakercloud.com/avatars/jacobbennett_128.jpg",
                    "id": "138"
                }
            ]
            """;
    }

    private static string CreateListResponse()
    {
        return """
            {
                "id": "f23f740fd9",
                "web_id": 652558,
                "name": "Integration Test Meetup",
                "contact": {
                    "company": "Mailchimp",
                    "address1": "405 N Angier Ave NE",
                    "address2": "",
                    "city": "Atlanta",
                    "state": "GA",
                    "zip": "30308",
                    "country": "US",
                    "phone": ""
                },
                "permission_reminder": "permission_reminder",
                "use_archive_bar": true,
                "campaign_defaults": {
                    "from_name": "Gettin' Together",
                    "from_email": "boporow427@chosenx.com",
                    "subject": "Bash Developers Meetup",
                    "language": "EN_US"
                },
                "notify_on_subscribe": "",
                "notify_on_unsubscribe": "",
                "date_created": "2024-12-23T15:54:14+00:00",
                "list_rating": 0,
                "email_type_option": true,
                "subscribe_url_short": "http://eepurl.com/i6MAII",
                "subscribe_url_long": "https://gmail.us14.list-manage.com/subscribe?u=09acb8734a786c7a42d44331a&id=f23f740fd9",
                "beamer_address": "us14-0e77eeeade-e1e48858aa@inbound.mailchimp.com",
                "visibility": "prv",
                "double_optin": false,
                "has_welcome": false,
                "marketing_permissions": false,
                "modules": [],
                "stats": {
                    "member_count": 0,
                    "unsubscribe_count": 0,
                    "cleaned_count": 0,
                    "member_count_since_send": 0,
                    "unsubscribe_count_since_send": 0,
                    "cleaned_count_since_send": 0,
                    "campaign_count": 0,
                    "campaign_last_sent": "",
                    "merge_field_count": 4,
                    "avg_sub_rate": 0,
                    "avg_unsub_rate": 0,
                    "target_sub_rate": 0,
                    "open_rate": 0,
                    "click_rate": 0,
                    "last_sub_date": "",
                    "last_unsub_date": ""
                },
                "_links": [
                    {
                        "rel": "self",
                        "href": "https://us14.api.mailchimp.com/3.0/lists/f23f740fd9",
                        "method": "GET",
                        "targetSchema": "https://us14.api.mailchimp.com/schema/3.0/Definitions/Lists/Response.json"
                    },
                    {
                        "rel": "parent",
                        "href": "https://us14.api.mailchimp.com/3.0/lists",
                        "method": "GET",
                        "targetSchema": "https://us14.api.mailchimp.com/schema/3.0/Definitions/Lists/CollectionResponse.json",
                        "schema": "https://us14.api.mailchimp.com/schema/3.0/Paths/Lists/Collection.json"
                    },
                    {
                        "rel": "update",
                        "href": "https://us14.api.mailchimp.com/3.0/lists/f23f740fd9",
                        "method": "PATCH",
                        "targetSchema": "https://us14.api.mailchimp.com/schema/3.0/Definitions/Lists/Response.json",
                        "schema": "https://us14.api.mailchimp.com/schema/3.0/Definitions/Lists/PATCH.json"
                    },
                    {
                        "rel": "batch-sub-unsub-members",
                        "href": "https://us14.api.mailchimp.com/3.0/lists/f23f740fd9",
                        "method": "POST",
                        "targetSchema": "https://us14.api.mailchimp.com/schema/3.0/Definitions/Lists/BatchPOST-Response.json",
                        "schema": "https://us14.api.mailchimp.com/schema/3.0/Definitions/Lists/BatchPOST.json"
                    },
                    {
                        "rel": "delete",
                        "href": "https://us14.api.mailchimp.com/3.0/lists/f23f740fd9",
                        "method": "DELETE"
                    },
                    {
                        "rel": "abuse-reports",
                        "href": "https://us14.api.mailchimp.com/3.0/lists/f23f740fd9/abuse-reports",
                        "method": "GET",
                        "targetSchema": "https://us14.api.mailchimp.com/schema/3.0/Definitions/Lists/Abuse/CollectionResponse.json",
                        "schema": "https://us14.api.mailchimp.com/schema/3.0/Paths/Lists/Abuse/Collection.json"
                    },
                    {
                        "rel": "activity",
                        "href": "https://us14.api.mailchimp.com/3.0/lists/f23f740fd9/activity",
                        "method": "GET",
                        "targetSchema": "https://us14.api.mailchimp.com/schema/3.0/Definitions/Lists/Activity/Response.json"
                    },
                    {
                        "rel": "clients",
                        "href": "https://us14.api.mailchimp.com/3.0/lists/f23f740fd9/clients",
                        "method": "GET",
                        "targetSchema": "https://us14.api.mailchimp.com/schema/3.0/Definitions/Lists/Clients/Response.json"
                    },
                    {
                        "rel": "growth-history",
                        "href": "https://us14.api.mailchimp.com/3.0/lists/f23f740fd9/growth-history",
                        "method": "GET",
                        "targetSchema": "https://us14.api.mailchimp.com/schema/3.0/Definitions/Lists/Growth/CollectionResponse.json",
                        "schema": "https://us14.api.mailchimp.com/schema/3.0/Paths/Lists/Growth/Collection.json"
                    },
                    {
                        "rel": "interest-categories",
                        "href": "https://us14.api.mailchimp.com/3.0/lists/f23f740fd9/interest-categories",
                        "method": "GET",
                        "targetSchema": "https://us14.api.mailchimp.com/schema/3.0/Definitions/Lists/InterestCategories/CollectionResponse.json",
                        "schema": "https://us14.api.mailchimp.com/schema/3.0/Paths/Lists/InterestCategories/Collection.json"
                    },
                    {
                        "rel": "members",
                        "href": "https://us14.api.mailchimp.com/3.0/lists/f23f740fd9/members",
                        "method": "GET",
                        "targetSchema": "https://us14.api.mailchimp.com/schema/3.0/Definitions/Lists/Members/CollectionResponse.json",
                        "schema": "https://us14.api.mailchimp.com/schema/3.0/Paths/Lists/Members/Collection.json"
                    },
                    {
                        "rel": "merge-fields",
                        "href": "https://us14.api.mailchimp.com/3.0/lists/f23f740fd9/merge-fields",
                        "method": "GET",
                        "targetSchema": "https://us14.api.mailchimp.com/schema/3.0/Definitions/Lists/MergeFields/CollectionResponse.json",
                        "schema": "https://us14.api.mailchimp.com/schema/3.0/Paths/Lists/MergeFields/Collection.json"
                    },
                    {
                        "rel": "segments",
                        "href": "https://us14.api.mailchimp.com/3.0/lists/f23f740fd9/segments",
                        "method": "GET",
                        "targetSchema": "https://us14.api.mailchimp.com/schema/3.0/Definitions/Lists/Segments/CollectionResponse.json",
                        "schema": "https://us14.api.mailchimp.com/schema/3.0/Paths/Lists/Segments/Collection.json"
                    },
                    {
                        "rel": "webhooks",
                        "href": "https://us14.api.mailchimp.com/3.0/lists/f23f740fd9/webhooks",
                        "method": "GET",
                        "targetSchema": "https://us14.api.mailchimp.com/schema/3.0/Definitions/Lists/Webhooks/CollectionResponse.json",
                        "schema": "https://us14.api.mailchimp.com/schema/3.0/Paths/Lists/Webhooks/Collection.json"
                    },
                    {
                        "rel": "signup-forms",
                        "href": "https://us14.api.mailchimp.com/3.0/lists/f23f740fd9/signup-forms",
                        "method": "GET",
                        "targetSchema": "https://us14.api.mailchimp.com/schema/3.0/Definitions/Lists/SignupForms/CollectionResponse.json",
                        "schema": "https://us14.api.mailchimp.com/schema/3.0/Paths/Lists/SignupForms/Collection.json"
                    },
                    {
                        "rel": "locations",
                        "href": "https://us14.api.mailchimp.com/3.0/lists/f23f740fd9/locations",
                        "method": "GET",
                        "targetSchema": "https://us14.api.mailchimp.com/schema/3.0/Definitions/Lists/Locations/CollectionResponse.json",
                        "schema": "https://us14.api.mailchimp.com/schema/3.0/Paths/Lists/Locations/Collection.json"
                    }
                ]
            }
            """;
    }

    private static string AddMembersToListResponse()
    {
        return """
            {
                "new_members": [
                    {
                        "id": "5528c04f554b51169e5f1a4364d83f9e",
                        "contact_id": "5c06b5696f93b705beb6b68c6a2beb5b",
                        "email_address": "Kirk.Fritsch198@hotmail.com",
                        "unique_email_id": "2ce86e265a",
                        "email_type": "html",
                        "status": "subscribed",
                        "merge_fields": {
                            "FNAME": "",
                            "LNAME": "",
                            "ADDRESS": "",
                            "PHONE": ""
                        },
                        "stats": {
                            "avg_open_rate": 0,
                            "avg_click_rate": 0
                        },
                        "ip_signup": "",
                        "timestamp_signup": "",
                        "ip_opt": "170.244.255.167",
                        "timestamp_opt": "2024-12-23T16:21:57+00:00",
                        "member_rating": 2,
                        "last_changed": "2024-12-23T16:21:57+00:00",
                        "language": "",
                        "vip": false,
                        "email_client": "",
                        "location": {
                            "latitude": 0,
                            "longitude": 0,
                            "gmtoff": 0,
                            "dstoff": 0,
                            "country_code": "",
                            "timezone": ""
                        },
                        "tags_count": 0,
                        "tags": [],
                        "list_id": "b090e8dbda",
                        "_links": [
                            {
                                "rel": "self",
                                "href": "https://us14.api.mailchimp.com/3.0/lists/b090e8dbda/members/5528c04f554b51169e5f1a4364d83f9e",
                                "method": "GET",
                                "targetSchema": "https://us14.api.mailchimp.com/schema/3.0/Definitions/Lists/Members/Response.json"
                            },
                            {
                                "rel": "parent",
                                "href": "https://us14.api.mailchimp.com/3.0/lists/b090e8dbda/members",
                                "method": "GET",
                                "targetSchema": "https://us14.api.mailchimp.com/schema/3.0/Definitions/Lists/Members/CollectionResponse.json",
                                "schema": "https://us14.api.mailchimp.com/schema/3.0/Paths/Lists/Members/Collection.json"
                            },
                            {
                                "rel": "update",
                                "href": "https://us14.api.mailchimp.com/3.0/lists/b090e8dbda/members/5528c04f554b51169e5f1a4364d83f9e",
                                "method": "PATCH",
                                "targetSchema": "https://us14.api.mailchimp.com/schema/3.0/Definitions/Lists/Members/Response.json",
                                "schema": "https://us14.api.mailchimp.com/schema/3.0/Definitions/Lists/Members/PATCH.json"
                            },
                            {
                                "rel": "upsert",
                                "href": "https://us14.api.mailchimp.com/3.0/lists/b090e8dbda/members/5528c04f554b51169e5f1a4364d83f9e",
                                "method": "PUT",
                                "targetSchema": "https://us14.api.mailchimp.com/schema/3.0/Definitions/Lists/Members/Response.json",
                                "schema": "https://us14.api.mailchimp.com/schema/3.0/Definitions/Lists/Members/PUT.json"
                            },
                            {
                                "rel": "delete",
                                "href": "https://us14.api.mailchimp.com/3.0/lists/b090e8dbda/members/5528c04f554b51169e5f1a4364d83f9e",
                                "method": "DELETE"
                            },
                            {
                                "rel": "activity",
                                "href": "https://us14.api.mailchimp.com/3.0/lists/b090e8dbda/members/5528c04f554b51169e5f1a4364d83f9e/activity",
                                "method": "GET",
                                "targetSchema": "https://us14.api.mailchimp.com/schema/3.0/Definitions/Lists/Members/Activity/Response.json"
                            },
                            {
                                "rel": "goals",
                                "href": "https://us14.api.mailchimp.com/3.0/lists/b090e8dbda/members/5528c04f554b51169e5f1a4364d83f9e/goals",
                                "method": "GET",
                                "targetSchema": "https://us14.api.mailchimp.com/schema/3.0/Definitions/Lists/Members/Goals/Response.json"
                            },
                            {
                                "rel": "notes",
                                "href": "https://us14.api.mailchimp.com/3.0/lists/b090e8dbda/members/5528c04f554b51169e5f1a4364d83f9e/notes",
                                "method": "GET",
                                "targetSchema": "https://us14.api.mailchimp.com/schema/3.0/Definitions/Lists/Members/Notes/CollectionResponse.json"
                            },
                            {
                                "rel": "events",
                                "href": "https://us14.api.mailchimp.com/3.0/lists/b090e8dbda/members/5528c04f554b51169e5f1a4364d83f9e/events",
                                "method": "POST",
                                "targetSchema": "https://us14.api.mailchimp.com/schema/3.0/Definitions/Lists/Members/Events/POST.json"
                            },
                            {
                                "rel": "delete_permanent",
                                "href": "https://us14.api.mailchimp.com/3.0/lists/b090e8dbda/members/5528c04f554b51169e5f1a4364d83f9e/actions/delete-permanent",
                                "method": "POST"
                            }
                        ]
                    },
                    {
                        "id": "9823db572a82ce96b811236d90e9dad2",
                        "contact_id": "ceaf0b85ff17d8725f3343c5d9cda11c",
                        "email_address": "Corbin.Abshire206@gmail.com",
                        "unique_email_id": "56e4b9fe4c",
                        "email_type": "html",
                        "status": "subscribed",
                        "merge_fields": {
                            "FNAME": "",
                            "LNAME": "",
                            "ADDRESS": "",
                            "PHONE": ""
                        },
                        "stats": {
                            "avg_open_rate": 0,
                            "avg_click_rate": 0
                        },
                        "ip_signup": "",
                        "timestamp_signup": "",
                        "ip_opt": "170.244.255.167",
                        "timestamp_opt": "2024-12-23T16:21:57+00:00",
                        "member_rating": 2,
                        "last_changed": "2024-12-23T16:21:57+00:00",
                        "language": "",
                        "vip": false,
                        "email_client": "",
                        "location": {
                            "latitude": 0,
                            "longitude": 0,
                            "gmtoff": 0,
                            "dstoff": 0,
                            "country_code": "",
                            "timezone": ""
                        },
                        "tags_count": 0,
                        "tags": [],
                        "list_id": "b090e8dbda",
                        "_links": [
                            {
                                "rel": "self",
                                "href": "https://us14.api.mailchimp.com/3.0/lists/b090e8dbda/members/9823db572a82ce96b811236d90e9dad2",
                                "method": "GET",
                                "targetSchema": "https://us14.api.mailchimp.com/schema/3.0/Definitions/Lists/Members/Response.json"
                            },
                            {
                                "rel": "parent",
                                "href": "https://us14.api.mailchimp.com/3.0/lists/b090e8dbda/members",
                                "method": "GET",
                                "targetSchema": "https://us14.api.mailchimp.com/schema/3.0/Definitions/Lists/Members/CollectionResponse.json",
                                "schema": "https://us14.api.mailchimp.com/schema/3.0/Paths/Lists/Members/Collection.json"
                            },
                            {
                                "rel": "update",
                                "href": "https://us14.api.mailchimp.com/3.0/lists/b090e8dbda/members/9823db572a82ce96b811236d90e9dad2",
                                "method": "PATCH",
                                "targetSchema": "https://us14.api.mailchimp.com/schema/3.0/Definitions/Lists/Members/Response.json",
                                "schema": "https://us14.api.mailchimp.com/schema/3.0/Definitions/Lists/Members/PATCH.json"
                            },
                            {
                                "rel": "upsert",
                                "href": "https://us14.api.mailchimp.com/3.0/lists/b090e8dbda/members/9823db572a82ce96b811236d90e9dad2",
                                "method": "PUT",
                                "targetSchema": "https://us14.api.mailchimp.com/schema/3.0/Definitions/Lists/Members/Response.json",
                                "schema": "https://us14.api.mailchimp.com/schema/3.0/Definitions/Lists/Members/PUT.json"
                            },
                            {
                                "rel": "delete",
                                "href": "https://us14.api.mailchimp.com/3.0/lists/b090e8dbda/members/9823db572a82ce96b811236d90e9dad2",
                                "method": "DELETE"
                            },
                            {
                                "rel": "activity",
                                "href": "https://us14.api.mailchimp.com/3.0/lists/b090e8dbda/members/9823db572a82ce96b811236d90e9dad2/activity",
                                "method": "GET",
                                "targetSchema": "https://us14.api.mailchimp.com/schema/3.0/Definitions/Lists/Members/Activity/Response.json"
                            },
                            {
                                "rel": "goals",
                                "href": "https://us14.api.mailchimp.com/3.0/lists/b090e8dbda/members/9823db572a82ce96b811236d90e9dad2/goals",
                                "method": "GET",
                                "targetSchema": "https://us14.api.mailchimp.com/schema/3.0/Definitions/Lists/Members/Goals/Response.json"
                            },
                            {
                                "rel": "notes",
                                "href": "https://us14.api.mailchimp.com/3.0/lists/b090e8dbda/members/9823db572a82ce96b811236d90e9dad2/notes",
                                "method": "GET",
                                "targetSchema": "https://us14.api.mailchimp.com/schema/3.0/Definitions/Lists/Members/Notes/CollectionResponse.json"
                            },
                            {
                                "rel": "events",
                                "href": "https://us14.api.mailchimp.com/3.0/lists/b090e8dbda/members/9823db572a82ce96b811236d90e9dad2/events",
                                "method": "POST",
                                "targetSchema": "https://us14.api.mailchimp.com/schema/3.0/Definitions/Lists/Members/Events/POST.json"
                            },
                            {
                                "rel": "delete_permanent",
                                "href": "https://us14.api.mailchimp.com/3.0/lists/b090e8dbda/members/9823db572a82ce96b811236d90e9dad2/actions/delete-permanent",
                                "method": "POST"
                            }
                        ]
                    },
                    {
                        "id": "ed5e6ed52d9770f8c23c837c4df05e62",
                        "contact_id": "9d7ea3fd7ad9b9b4f7727ecee5a4c452",
                        "email_address": "Dillon132@hotmail.com",
                        "unique_email_id": "84afa9886b",
                        "email_type": "html",
                        "status": "subscribed",
                        "merge_fields": {
                            "FNAME": "",
                            "LNAME": "",
                            "ADDRESS": "",
                            "PHONE": ""
                        },
                        "stats": {
                            "avg_open_rate": 0,
                            "avg_click_rate": 0
                        },
                        "ip_signup": "",
                        "timestamp_signup": "",
                        "ip_opt": "170.244.255.167",
                        "timestamp_opt": "2024-12-23T16:21:57+00:00",
                        "member_rating": 2,
                        "last_changed": "2024-12-23T16:21:58+00:00",
                        "language": "",
                        "vip": false,
                        "email_client": "",
                        "location": {
                            "latitude": 0,
                            "longitude": 0,
                            "gmtoff": 0,
                            "dstoff": 0,
                            "country_code": "",
                            "timezone": ""
                        },
                        "tags_count": 0,
                        "tags": [],
                        "list_id": "b090e8dbda",
                        "_links": [
                            {
                                "rel": "self",
                                "href": "https://us14.api.mailchimp.com/3.0/lists/b090e8dbda/members/ed5e6ed52d9770f8c23c837c4df05e62",
                                "method": "GET",
                                "targetSchema": "https://us14.api.mailchimp.com/schema/3.0/Definitions/Lists/Members/Response.json"
                            },
                            {
                                "rel": "parent",
                                "href": "https://us14.api.mailchimp.com/3.0/lists/b090e8dbda/members",
                                "method": "GET",
                                "targetSchema": "https://us14.api.mailchimp.com/schema/3.0/Definitions/Lists/Members/CollectionResponse.json",
                                "schema": "https://us14.api.mailchimp.com/schema/3.0/Paths/Lists/Members/Collection.json"
                            },
                            {
                                "rel": "update",
                                "href": "https://us14.api.mailchimp.com/3.0/lists/b090e8dbda/members/ed5e6ed52d9770f8c23c837c4df05e62",
                                "method": "PATCH",
                                "targetSchema": "https://us14.api.mailchimp.com/schema/3.0/Definitions/Lists/Members/Response.json",
                                "schema": "https://us14.api.mailchimp.com/schema/3.0/Definitions/Lists/Members/PATCH.json"
                            },
                            {
                                "rel": "upsert",
                                "href": "https://us14.api.mailchimp.com/3.0/lists/b090e8dbda/members/ed5e6ed52d9770f8c23c837c4df05e62",
                                "method": "PUT",
                                "targetSchema": "https://us14.api.mailchimp.com/schema/3.0/Definitions/Lists/Members/Response.json",
                                "schema": "https://us14.api.mailchimp.com/schema/3.0/Definitions/Lists/Members/PUT.json"
                            },
                            {
                                "rel": "delete",
                                "href": "https://us14.api.mailchimp.com/3.0/lists/b090e8dbda/members/ed5e6ed52d9770f8c23c837c4df05e62",
                                "method": "DELETE"
                            },
                            {
                                "rel": "activity",
                                "href": "https://us14.api.mailchimp.com/3.0/lists/b090e8dbda/members/ed5e6ed52d9770f8c23c837c4df05e62/activity",
                                "method": "GET",
                                "targetSchema": "https://us14.api.mailchimp.com/schema/3.0/Definitions/Lists/Members/Activity/Response.json"
                            },
                            {
                                "rel": "goals",
                                "href": "https://us14.api.mailchimp.com/3.0/lists/b090e8dbda/members/ed5e6ed52d9770f8c23c837c4df05e62/goals",
                                "method": "GET",
                                "targetSchema": "https://us14.api.mailchimp.com/schema/3.0/Definitions/Lists/Members/Goals/Response.json"
                            },
                            {
                                "rel": "notes",
                                "href": "https://us14.api.mailchimp.com/3.0/lists/b090e8dbda/members/ed5e6ed52d9770f8c23c837c4df05e62/notes",
                                "method": "GET",
                                "targetSchema": "https://us14.api.mailchimp.com/schema/3.0/Definitions/Lists/Members/Notes/CollectionResponse.json"
                            },
                            {
                                "rel": "events",
                                "href": "https://us14.api.mailchimp.com/3.0/lists/b090e8dbda/members/ed5e6ed52d9770f8c23c837c4df05e62/events",
                                "method": "POST",
                                "targetSchema": "https://us14.api.mailchimp.com/schema/3.0/Definitions/Lists/Members/Events/POST.json"
                            },
                            {
                                "rel": "delete_permanent",
                                "href": "https://us14.api.mailchimp.com/3.0/lists/b090e8dbda/members/ed5e6ed52d9770f8c23c837c4df05e62/actions/delete-permanent",
                                "method": "POST"
                            }
                        ]
                    },
                    {
                        "id": "2afd09b0537418930ed343f650ebd40d",
                        "contact_id": "12d538e05974386ae2bed7295df9e121",
                        "email_address": "Cierra_Walsh261@gmail.com",
                        "unique_email_id": "329d4b28d4",
                        "email_type": "html",
                        "status": "subscribed",
                        "merge_fields": {
                            "FNAME": "",
                            "LNAME": "",
                            "ADDRESS": "",
                            "PHONE": ""
                        },
                        "stats": {
                            "avg_open_rate": 0,
                            "avg_click_rate": 0
                        },
                        "ip_signup": "",
                        "timestamp_signup": "",
                        "ip_opt": "170.244.255.167",
                        "timestamp_opt": "2024-12-23T16:21:58+00:00",
                        "member_rating": 2,
                        "last_changed": "2024-12-23T16:21:58+00:00",
                        "language": "",
                        "vip": false,
                        "email_client": "",
                        "location": {
                            "latitude": 0,
                            "longitude": 0,
                            "gmtoff": 0,
                            "dstoff": 0,
                            "country_code": "",
                            "timezone": ""
                        },
                        "tags_count": 0,
                        "tags": [],
                        "list_id": "b090e8dbda",
                        "_links": [
                            {
                                "rel": "self",
                                "href": "https://us14.api.mailchimp.com/3.0/lists/b090e8dbda/members/2afd09b0537418930ed343f650ebd40d",
                                "method": "GET",
                                "targetSchema": "https://us14.api.mailchimp.com/schema/3.0/Definitions/Lists/Members/Response.json"
                            },
                            {
                                "rel": "parent",
                                "href": "https://us14.api.mailchimp.com/3.0/lists/b090e8dbda/members",
                                "method": "GET",
                                "targetSchema": "https://us14.api.mailchimp.com/schema/3.0/Definitions/Lists/Members/CollectionResponse.json",
                                "schema": "https://us14.api.mailchimp.com/schema/3.0/Paths/Lists/Members/Collection.json"
                            },
                            {
                                "rel": "update",
                                "href": "https://us14.api.mailchimp.com/3.0/lists/b090e8dbda/members/2afd09b0537418930ed343f650ebd40d",
                                "method": "PATCH",
                                "targetSchema": "https://us14.api.mailchimp.com/schema/3.0/Definitions/Lists/Members/Response.json",
                                "schema": "https://us14.api.mailchimp.com/schema/3.0/Definitions/Lists/Members/PATCH.json"
                            },
                            {
                                "rel": "upsert",
                                "href": "https://us14.api.mailchimp.com/3.0/lists/b090e8dbda/members/2afd09b0537418930ed343f650ebd40d",
                                "method": "PUT",
                                "targetSchema": "https://us14.api.mailchimp.com/schema/3.0/Definitions/Lists/Members/Response.json",
                                "schema": "https://us14.api.mailchimp.com/schema/3.0/Definitions/Lists/Members/PUT.json"
                            },
                            {
                                "rel": "delete",
                                "href": "https://us14.api.mailchimp.com/3.0/lists/b090e8dbda/members/2afd09b0537418930ed343f650ebd40d",
                                "method": "DELETE"
                            },
                            {
                                "rel": "activity",
                                "href": "https://us14.api.mailchimp.com/3.0/lists/b090e8dbda/members/2afd09b0537418930ed343f650ebd40d/activity",
                                "method": "GET",
                                "targetSchema": "https://us14.api.mailchimp.com/schema/3.0/Definitions/Lists/Members/Activity/Response.json"
                            },
                            {
                                "rel": "goals",
                                "href": "https://us14.api.mailchimp.com/3.0/lists/b090e8dbda/members/2afd09b0537418930ed343f650ebd40d/goals",
                                "method": "GET",
                                "targetSchema": "https://us14.api.mailchimp.com/schema/3.0/Definitions/Lists/Members/Goals/Response.json"
                            },
                            {
                                "rel": "notes",
                                "href": "https://us14.api.mailchimp.com/3.0/lists/b090e8dbda/members/2afd09b0537418930ed343f650ebd40d/notes",
                                "method": "GET",
                                "targetSchema": "https://us14.api.mailchimp.com/schema/3.0/Definitions/Lists/Members/Notes/CollectionResponse.json"
                            },
                            {
                                "rel": "events",
                                "href": "https://us14.api.mailchimp.com/3.0/lists/b090e8dbda/members/2afd09b0537418930ed343f650ebd40d/events",
                                "method": "POST",
                                "targetSchema": "https://us14.api.mailchimp.com/schema/3.0/Definitions/Lists/Members/Events/POST.json"
                            },
                            {
                                "rel": "delete_permanent",
                                "href": "https://us14.api.mailchimp.com/3.0/lists/b090e8dbda/members/2afd09b0537418930ed343f650ebd40d/actions/delete-permanent",
                                "method": "POST"
                            }
                        ]
                    },
                    {
                        "id": "9f3d7ffa5106470e97c2c1b1b05cb134",
                        "contact_id": "0ffd82596b9b56db64db8a9d66c225a3",
                        "email_address": "Adalberto397@outlook.com",
                        "unique_email_id": "be1b6f68f1",
                        "email_type": "html",
                        "status": "subscribed",
                        "merge_fields": {
                            "FNAME": "",
                            "LNAME": "",
                            "ADDRESS": "",
                            "PHONE": ""
                        },
                        "stats": {
                            "avg_open_rate": 0,
                            "avg_click_rate": 0
                        },
                        "ip_signup": "",
                        "timestamp_signup": "",
                        "ip_opt": "170.244.255.167",
                        "timestamp_opt": "2024-12-23T16:21:58+00:00",
                        "member_rating": 2,
                        "last_changed": "2024-12-23T16:21:58+00:00",
                        "language": "",
                        "vip": false,
                        "email_client": "",
                        "location": {
                            "latitude": 0,
                            "longitude": 0,
                            "gmtoff": 0,
                            "dstoff": 0,
                            "country_code": "",
                            "timezone": ""
                        },
                        "tags_count": 0,
                        "tags": [],
                        "list_id": "b090e8dbda",
                        "_links": [
                            {
                                "rel": "self",
                                "href": "https://us14.api.mailchimp.com/3.0/lists/b090e8dbda/members/9f3d7ffa5106470e97c2c1b1b05cb134",
                                "method": "GET",
                                "targetSchema": "https://us14.api.mailchimp.com/schema/3.0/Definitions/Lists/Members/Response.json"
                            },
                            {
                                "rel": "parent",
                                "href": "https://us14.api.mailchimp.com/3.0/lists/b090e8dbda/members",
                                "method": "GET",
                                "targetSchema": "https://us14.api.mailchimp.com/schema/3.0/Definitions/Lists/Members/CollectionResponse.json",
                                "schema": "https://us14.api.mailchimp.com/schema/3.0/Paths/Lists/Members/Collection.json"
                            },
                            {
                                "rel": "update",
                                "href": "https://us14.api.mailchimp.com/3.0/lists/b090e8dbda/members/9f3d7ffa5106470e97c2c1b1b05cb134",
                                "method": "PATCH",
                                "targetSchema": "https://us14.api.mailchimp.com/schema/3.0/Definitions/Lists/Members/Response.json",
                                "schema": "https://us14.api.mailchimp.com/schema/3.0/Definitions/Lists/Members/PATCH.json"
                            },
                            {
                                "rel": "upsert",
                                "href": "https://us14.api.mailchimp.com/3.0/lists/b090e8dbda/members/9f3d7ffa5106470e97c2c1b1b05cb134",
                                "method": "PUT",
                                "targetSchema": "https://us14.api.mailchimp.com/schema/3.0/Definitions/Lists/Members/Response.json",
                                "schema": "https://us14.api.mailchimp.com/schema/3.0/Definitions/Lists/Members/PUT.json"
                            },
                            {
                                "rel": "delete",
                                "href": "https://us14.api.mailchimp.com/3.0/lists/b090e8dbda/members/9f3d7ffa5106470e97c2c1b1b05cb134",
                                "method": "DELETE"
                            },
                            {
                                "rel": "activity",
                                "href": "https://us14.api.mailchimp.com/3.0/lists/b090e8dbda/members/9f3d7ffa5106470e97c2c1b1b05cb134/activity",
                                "method": "GET",
                                "targetSchema": "https://us14.api.mailchimp.com/schema/3.0/Definitions/Lists/Members/Activity/Response.json"
                            },
                            {
                                "rel": "goals",
                                "href": "https://us14.api.mailchimp.com/3.0/lists/b090e8dbda/members/9f3d7ffa5106470e97c2c1b1b05cb134/goals",
                                "method": "GET",
                                "targetSchema": "https://us14.api.mailchimp.com/schema/3.0/Definitions/Lists/Members/Goals/Response.json"
                            },
                            {
                                "rel": "notes",
                                "href": "https://us14.api.mailchimp.com/3.0/lists/b090e8dbda/members/9f3d7ffa5106470e97c2c1b1b05cb134/notes",
                                "method": "GET",
                                "targetSchema": "https://us14.api.mailchimp.com/schema/3.0/Definitions/Lists/Members/Notes/CollectionResponse.json"
                            },
                            {
                                "rel": "events",
                                "href": "https://us14.api.mailchimp.com/3.0/lists/b090e8dbda/members/9f3d7ffa5106470e97c2c1b1b05cb134/events",
                                "method": "POST",
                                "targetSchema": "https://us14.api.mailchimp.com/schema/3.0/Definitions/Lists/Members/Events/POST.json"
                            },
                            {
                                "rel": "delete_permanent",
                                "href": "https://us14.api.mailchimp.com/3.0/lists/b090e8dbda/members/9f3d7ffa5106470e97c2c1b1b05cb134/actions/delete-permanent",
                                "method": "POST"
                            }
                        ]
                    },
                    {
                        "id": "61debf47ee48f951de87daf709eb531a",
                        "contact_id": "55764a80ded3410015c0de23b08bd5df",
                        "email_address": "Elvie.Hagenes72@outlook.com",
                        "unique_email_id": "c6c5f1eb80",
                        "email_type": "html",
                        "status": "subscribed",
                        "merge_fields": {
                            "FNAME": "",
                            "LNAME": "",
                            "ADDRESS": "",
                            "PHONE": ""
                        },
                        "stats": {
                            "avg_open_rate": 0,
                            "avg_click_rate": 0
                        },
                        "ip_signup": "",
                        "timestamp_signup": "",
                        "ip_opt": "170.244.255.167",
                        "timestamp_opt": "2024-12-23T16:21:58+00:00",
                        "member_rating": 2,
                        "last_changed": "2024-12-23T16:21:58+00:00",
                        "language": "",
                        "vip": false,
                        "email_client": "",
                        "location": {
                            "latitude": 0,
                            "longitude": 0,
                            "gmtoff": 0,
                            "dstoff": 0,
                            "country_code": "",
                            "timezone": ""
                        },
                        "tags_count": 0,
                        "tags": [],
                        "list_id": "b090e8dbda",
                        "_links": [
                            {
                                "rel": "self",
                                "href": "https://us14.api.mailchimp.com/3.0/lists/b090e8dbda/members/61debf47ee48f951de87daf709eb531a",
                                "method": "GET",
                                "targetSchema": "https://us14.api.mailchimp.com/schema/3.0/Definitions/Lists/Members/Response.json"
                            },
                            {
                                "rel": "parent",
                                "href": "https://us14.api.mailchimp.com/3.0/lists/b090e8dbda/members",
                                "method": "GET",
                                "targetSchema": "https://us14.api.mailchimp.com/schema/3.0/Definitions/Lists/Members/CollectionResponse.json",
                                "schema": "https://us14.api.mailchimp.com/schema/3.0/Paths/Lists/Members/Collection.json"
                            },
                            {
                                "rel": "update",
                                "href": "https://us14.api.mailchimp.com/3.0/lists/b090e8dbda/members/61debf47ee48f951de87daf709eb531a",
                                "method": "PATCH",
                                "targetSchema": "https://us14.api.mailchimp.com/schema/3.0/Definitions/Lists/Members/Response.json",
                                "schema": "https://us14.api.mailchimp.com/schema/3.0/Definitions/Lists/Members/PATCH.json"
                            },
                            {
                                "rel": "upsert",
                                "href": "https://us14.api.mailchimp.com/3.0/lists/b090e8dbda/members/61debf47ee48f951de87daf709eb531a",
                                "method": "PUT",
                                "targetSchema": "https://us14.api.mailchimp.com/schema/3.0/Definitions/Lists/Members/Response.json",
                                "schema": "https://us14.api.mailchimp.com/schema/3.0/Definitions/Lists/Members/PUT.json"
                            },
                            {
                                "rel": "delete",
                                "href": "https://us14.api.mailchimp.com/3.0/lists/b090e8dbda/members/61debf47ee48f951de87daf709eb531a",
                                "method": "DELETE"
                            },
                            {
                                "rel": "activity",
                                "href": "https://us14.api.mailchimp.com/3.0/lists/b090e8dbda/members/61debf47ee48f951de87daf709eb531a/activity",
                                "method": "GET",
                                "targetSchema": "https://us14.api.mailchimp.com/schema/3.0/Definitions/Lists/Members/Activity/Response.json"
                            },
                            {
                                "rel": "goals",
                                "href": "https://us14.api.mailchimp.com/3.0/lists/b090e8dbda/members/61debf47ee48f951de87daf709eb531a/goals",
                                "method": "GET",
                                "targetSchema": "https://us14.api.mailchimp.com/schema/3.0/Definitions/Lists/Members/Goals/Response.json"
                            },
                            {
                                "rel": "notes",
                                "href": "https://us14.api.mailchimp.com/3.0/lists/b090e8dbda/members/61debf47ee48f951de87daf709eb531a/notes",
                                "method": "GET",
                                "targetSchema": "https://us14.api.mailchimp.com/schema/3.0/Definitions/Lists/Members/Notes/CollectionResponse.json"
                            },
                            {
                                "rel": "events",
                                "href": "https://us14.api.mailchimp.com/3.0/lists/b090e8dbda/members/61debf47ee48f951de87daf709eb531a/events",
                                "method": "POST",
                                "targetSchema": "https://us14.api.mailchimp.com/schema/3.0/Definitions/Lists/Members/Events/POST.json"
                            },
                            {
                                "rel": "delete_permanent",
                                "href": "https://us14.api.mailchimp.com/3.0/lists/b090e8dbda/members/61debf47ee48f951de87daf709eb531a/actions/delete-permanent",
                                "method": "POST"
                            }
                        ]
                    },
                    {
                        "id": "29593e0a036a016d858d304497072279",
                        "contact_id": "3dd2df50ab51c777afb237255ee3afbe",
                        "email_address": "Dallin_Powlowski55@hotmail.com",
                        "unique_email_id": "fca673a4b9",
                        "email_type": "html",
                        "status": "subscribed",
                        "merge_fields": {
                            "FNAME": "",
                            "LNAME": "",
                            "ADDRESS": "",
                            "PHONE": ""
                        },
                        "stats": {
                            "avg_open_rate": 0,
                            "avg_click_rate": 0
                        },
                        "ip_signup": "",
                        "timestamp_signup": "",
                        "ip_opt": "170.244.255.167",
                        "timestamp_opt": "2024-12-23T16:21:58+00:00",
                        "member_rating": 2,
                        "last_changed": "2024-12-23T16:21:58+00:00",
                        "language": "",
                        "vip": false,
                        "email_client": "",
                        "location": {
                            "latitude": 0,
                            "longitude": 0,
                            "gmtoff": 0,
                            "dstoff": 0,
                            "country_code": "",
                            "timezone": ""
                        },
                        "tags_count": 0,
                        "tags": [],
                        "list_id": "b090e8dbda",
                        "_links": [
                            {
                                "rel": "self",
                                "href": "https://us14.api.mailchimp.com/3.0/lists/b090e8dbda/members/29593e0a036a016d858d304497072279",
                                "method": "GET",
                                "targetSchema": "https://us14.api.mailchimp.com/schema/3.0/Definitions/Lists/Members/Response.json"
                            },
                            {
                                "rel": "parent",
                                "href": "https://us14.api.mailchimp.com/3.0/lists/b090e8dbda/members",
                                "method": "GET",
                                "targetSchema": "https://us14.api.mailchimp.com/schema/3.0/Definitions/Lists/Members/CollectionResponse.json",
                                "schema": "https://us14.api.mailchimp.com/schema/3.0/Paths/Lists/Members/Collection.json"
                            },
                            {
                                "rel": "update",
                                "href": "https://us14.api.mailchimp.com/3.0/lists/b090e8dbda/members/29593e0a036a016d858d304497072279",
                                "method": "PATCH",
                                "targetSchema": "https://us14.api.mailchimp.com/schema/3.0/Definitions/Lists/Members/Response.json",
                                "schema": "https://us14.api.mailchimp.com/schema/3.0/Definitions/Lists/Members/PATCH.json"
                            },
                            {
                                "rel": "upsert",
                                "href": "https://us14.api.mailchimp.com/3.0/lists/b090e8dbda/members/29593e0a036a016d858d304497072279",
                                "method": "PUT",
                                "targetSchema": "https://us14.api.mailchimp.com/schema/3.0/Definitions/Lists/Members/Response.json",
                                "schema": "https://us14.api.mailchimp.com/schema/3.0/Definitions/Lists/Members/PUT.json"
                            },
                            {
                                "rel": "delete",
                                "href": "https://us14.api.mailchimp.com/3.0/lists/b090e8dbda/members/29593e0a036a016d858d304497072279",
                                "method": "DELETE"
                            },
                            {
                                "rel": "activity",
                                "href": "https://us14.api.mailchimp.com/3.0/lists/b090e8dbda/members/29593e0a036a016d858d304497072279/activity",
                                "method": "GET",
                                "targetSchema": "https://us14.api.mailchimp.com/schema/3.0/Definitions/Lists/Members/Activity/Response.json"
                            },
                            {
                                "rel": "goals",
                                "href": "https://us14.api.mailchimp.com/3.0/lists/b090e8dbda/members/29593e0a036a016d858d304497072279/goals",
                                "method": "GET",
                                "targetSchema": "https://us14.api.mailchimp.com/schema/3.0/Definitions/Lists/Members/Goals/Response.json"
                            },
                            {
                                "rel": "notes",
                                "href": "https://us14.api.mailchimp.com/3.0/lists/b090e8dbda/members/29593e0a036a016d858d304497072279/notes",
                                "method": "GET",
                                "targetSchema": "https://us14.api.mailchimp.com/schema/3.0/Definitions/Lists/Members/Notes/CollectionResponse.json"
                            },
                            {
                                "rel": "events",
                                "href": "https://us14.api.mailchimp.com/3.0/lists/b090e8dbda/members/29593e0a036a016d858d304497072279/events",
                                "method": "POST",
                                "targetSchema": "https://us14.api.mailchimp.com/schema/3.0/Definitions/Lists/Members/Events/POST.json"
                            },
                            {
                                "rel": "delete_permanent",
                                "href": "https://us14.api.mailchimp.com/3.0/lists/b090e8dbda/members/29593e0a036a016d858d304497072279/actions/delete-permanent",
                                "method": "POST"
                            }
                        ]
                    },
                    {
                        "id": "aca9b34e8a60a31aefaf54427d3563c7",
                        "contact_id": "ddd9e2ddb7feeec376f9fbd8938c1836",
                        "email_address": "Jameson683@icloud.com",
                        "unique_email_id": "afb5c95fb2",
                        "email_type": "html",
                        "status": "subscribed",
                        "merge_fields": {
                            "FNAME": "",
                            "LNAME": "",
                            "ADDRESS": "",
                            "PHONE": ""
                        },
                        "stats": {
                            "avg_open_rate": 0,
                            "avg_click_rate": 0
                        },
                        "ip_signup": "",
                        "timestamp_signup": "",
                        "ip_opt": "170.244.255.167",
                        "timestamp_opt": "2024-12-23T16:21:58+00:00",
                        "member_rating": 2,
                        "last_changed": "2024-12-23T16:21:58+00:00",
                        "language": "",
                        "vip": false,
                        "email_client": "",
                        "location": {
                            "latitude": 0,
                            "longitude": 0,
                            "gmtoff": 0,
                            "dstoff": 0,
                            "country_code": "",
                            "timezone": ""
                        },
                        "tags_count": 0,
                        "tags": [],
                        "list_id": "b090e8dbda",
                        "_links": [
                            {
                                "rel": "self",
                                "href": "https://us14.api.mailchimp.com/3.0/lists/b090e8dbda/members/aca9b34e8a60a31aefaf54427d3563c7",
                                "method": "GET",
                                "targetSchema": "https://us14.api.mailchimp.com/schema/3.0/Definitions/Lists/Members/Response.json"
                            },
                            {
                                "rel": "parent",
                                "href": "https://us14.api.mailchimp.com/3.0/lists/b090e8dbda/members",
                                "method": "GET",
                                "targetSchema": "https://us14.api.mailchimp.com/schema/3.0/Definitions/Lists/Members/CollectionResponse.json",
                                "schema": "https://us14.api.mailchimp.com/schema/3.0/Paths/Lists/Members/Collection.json"
                            },
                            {
                                "rel": "update",
                                "href": "https://us14.api.mailchimp.com/3.0/lists/b090e8dbda/members/aca9b34e8a60a31aefaf54427d3563c7",
                                "method": "PATCH",
                                "targetSchema": "https://us14.api.mailchimp.com/schema/3.0/Definitions/Lists/Members/Response.json",
                                "schema": "https://us14.api.mailchimp.com/schema/3.0/Definitions/Lists/Members/PATCH.json"
                            },
                            {
                                "rel": "upsert",
                                "href": "https://us14.api.mailchimp.com/3.0/lists/b090e8dbda/members/aca9b34e8a60a31aefaf54427d3563c7",
                                "method": "PUT",
                                "targetSchema": "https://us14.api.mailchimp.com/schema/3.0/Definitions/Lists/Members/Response.json",
                                "schema": "https://us14.api.mailchimp.com/schema/3.0/Definitions/Lists/Members/PUT.json"
                            },
                            {
                                "rel": "delete",
                                "href": "https://us14.api.mailchimp.com/3.0/lists/b090e8dbda/members/aca9b34e8a60a31aefaf54427d3563c7",
                                "method": "DELETE"
                            },
                            {
                                "rel": "activity",
                                "href": "https://us14.api.mailchimp.com/3.0/lists/b090e8dbda/members/aca9b34e8a60a31aefaf54427d3563c7/activity",
                                "method": "GET",
                                "targetSchema": "https://us14.api.mailchimp.com/schema/3.0/Definitions/Lists/Members/Activity/Response.json"
                            },
                            {
                                "rel": "goals",
                                "href": "https://us14.api.mailchimp.com/3.0/lists/b090e8dbda/members/aca9b34e8a60a31aefaf54427d3563c7/goals",
                                "method": "GET",
                                "targetSchema": "https://us14.api.mailchimp.com/schema/3.0/Definitions/Lists/Members/Goals/Response.json"
                            },
                            {
                                "rel": "notes",
                                "href": "https://us14.api.mailchimp.com/3.0/lists/b090e8dbda/members/aca9b34e8a60a31aefaf54427d3563c7/notes",
                                "method": "GET",
                                "targetSchema": "https://us14.api.mailchimp.com/schema/3.0/Definitions/Lists/Members/Notes/CollectionResponse.json"
                            },
                            {
                                "rel": "events",
                                "href": "https://us14.api.mailchimp.com/3.0/lists/b090e8dbda/members/aca9b34e8a60a31aefaf54427d3563c7/events",
                                "method": "POST",
                                "targetSchema": "https://us14.api.mailchimp.com/schema/3.0/Definitions/Lists/Members/Events/POST.json"
                            },
                            {
                                "rel": "delete_permanent",
                                "href": "https://us14.api.mailchimp.com/3.0/lists/b090e8dbda/members/aca9b34e8a60a31aefaf54427d3563c7/actions/delete-permanent",
                                "method": "POST"
                            }
                        ]
                    },
                    {
                        "id": "746f6cf9f8152834f1b8891314e2cafd",
                        "contact_id": "a0369c27c091bc5ceb44a246dc4e755f",
                        "email_address": "Raheem.DAmore821@icloud.com",
                        "unique_email_id": "fdd4f5a452",
                        "email_type": "html",
                        "status": "subscribed",
                        "merge_fields": {
                            "FNAME": "",
                            "LNAME": "",
                            "ADDRESS": "",
                            "PHONE": ""
                        },
                        "stats": {
                            "avg_open_rate": 0,
                            "avg_click_rate": 0
                        },
                        "ip_signup": "",
                        "timestamp_signup": "",
                        "ip_opt": "170.244.255.167",
                        "timestamp_opt": "2024-12-23T16:21:58+00:00",
                        "member_rating": 2,
                        "last_changed": "2024-12-23T16:21:58+00:00",
                        "language": "",
                        "vip": false,
                        "email_client": "",
                        "location": {
                            "latitude": 0,
                            "longitude": 0,
                            "gmtoff": 0,
                            "dstoff": 0,
                            "country_code": "",
                            "timezone": ""
                        },
                        "tags_count": 0,
                        "tags": [],
                        "list_id": "b090e8dbda",
                        "_links": [
                            {
                                "rel": "self",
                                "href": "https://us14.api.mailchimp.com/3.0/lists/b090e8dbda/members/746f6cf9f8152834f1b8891314e2cafd",
                                "method": "GET",
                                "targetSchema": "https://us14.api.mailchimp.com/schema/3.0/Definitions/Lists/Members/Response.json"
                            },
                            {
                                "rel": "parent",
                                "href": "https://us14.api.mailchimp.com/3.0/lists/b090e8dbda/members",
                                "method": "GET",
                                "targetSchema": "https://us14.api.mailchimp.com/schema/3.0/Definitions/Lists/Members/CollectionResponse.json",
                                "schema": "https://us14.api.mailchimp.com/schema/3.0/Paths/Lists/Members/Collection.json"
                            },
                            {
                                "rel": "update",
                                "href": "https://us14.api.mailchimp.com/3.0/lists/b090e8dbda/members/746f6cf9f8152834f1b8891314e2cafd",
                                "method": "PATCH",
                                "targetSchema": "https://us14.api.mailchimp.com/schema/3.0/Definitions/Lists/Members/Response.json",
                                "schema": "https://us14.api.mailchimp.com/schema/3.0/Definitions/Lists/Members/PATCH.json"
                            },
                            {
                                "rel": "upsert",
                                "href": "https://us14.api.mailchimp.com/3.0/lists/b090e8dbda/members/746f6cf9f8152834f1b8891314e2cafd",
                                "method": "PUT",
                                "targetSchema": "https://us14.api.mailchimp.com/schema/3.0/Definitions/Lists/Members/Response.json",
                                "schema": "https://us14.api.mailchimp.com/schema/3.0/Definitions/Lists/Members/PUT.json"
                            },
                            {
                                "rel": "delete",
                                "href": "https://us14.api.mailchimp.com/3.0/lists/b090e8dbda/members/746f6cf9f8152834f1b8891314e2cafd",
                                "method": "DELETE"
                            },
                            {
                                "rel": "activity",
                                "href": "https://us14.api.mailchimp.com/3.0/lists/b090e8dbda/members/746f6cf9f8152834f1b8891314e2cafd/activity",
                                "method": "GET",
                                "targetSchema": "https://us14.api.mailchimp.com/schema/3.0/Definitions/Lists/Members/Activity/Response.json"
                            },
                            {
                                "rel": "goals",
                                "href": "https://us14.api.mailchimp.com/3.0/lists/b090e8dbda/members/746f6cf9f8152834f1b8891314e2cafd/goals",
                                "method": "GET",
                                "targetSchema": "https://us14.api.mailchimp.com/schema/3.0/Definitions/Lists/Members/Goals/Response.json"
                            },
                            {
                                "rel": "notes",
                                "href": "https://us14.api.mailchimp.com/3.0/lists/b090e8dbda/members/746f6cf9f8152834f1b8891314e2cafd/notes",
                                "method": "GET",
                                "targetSchema": "https://us14.api.mailchimp.com/schema/3.0/Definitions/Lists/Members/Notes/CollectionResponse.json"
                            },
                            {
                                "rel": "events",
                                "href": "https://us14.api.mailchimp.com/3.0/lists/b090e8dbda/members/746f6cf9f8152834f1b8891314e2cafd/events",
                                "method": "POST",
                                "targetSchema": "https://us14.api.mailchimp.com/schema/3.0/Definitions/Lists/Members/Events/POST.json"
                            },
                            {
                                "rel": "delete_permanent",
                                "href": "https://us14.api.mailchimp.com/3.0/lists/b090e8dbda/members/746f6cf9f8152834f1b8891314e2cafd/actions/delete-permanent",
                                "method": "POST"
                            }
                        ]
                    },
                    {
                        "id": "0e1d64b5a51568d14b1355f2d9403999",
                        "contact_id": "d497153d1bb384c101ce70ffecf73c34",
                        "email_address": "Cristina187@yahoo.com",
                        "unique_email_id": "d3b7865585",
                        "email_type": "html",
                        "status": "subscribed",
                        "merge_fields": {
                            "FNAME": "",
                            "LNAME": "",
                            "ADDRESS": "",
                            "PHONE": ""
                        },
                        "stats": {
                            "avg_open_rate": 0,
                            "avg_click_rate": 0
                        },
                        "ip_signup": "",
                        "timestamp_signup": "",
                        "ip_opt": "170.244.255.167",
                        "timestamp_opt": "2024-12-23T16:21:58+00:00",
                        "member_rating": 2,
                        "last_changed": "2024-12-23T16:21:58+00:00",
                        "language": "",
                        "vip": false,
                        "email_client": "",
                        "location": {
                            "latitude": 0,
                            "longitude": 0,
                            "gmtoff": 0,
                            "dstoff": 0,
                            "country_code": "",
                            "timezone": ""
                        },
                        "tags_count": 0,
                        "tags": [],
                        "list_id": "b090e8dbda",
                        "_links": [
                            {
                                "rel": "self",
                                "href": "https://us14.api.mailchimp.com/3.0/lists/b090e8dbda/members/0e1d64b5a51568d14b1355f2d9403999",
                                "method": "GET",
                                "targetSchema": "https://us14.api.mailchimp.com/schema/3.0/Definitions/Lists/Members/Response.json"
                            },
                            {
                                "rel": "parent",
                                "href": "https://us14.api.mailchimp.com/3.0/lists/b090e8dbda/members",
                                "method": "GET",
                                "targetSchema": "https://us14.api.mailchimp.com/schema/3.0/Definitions/Lists/Members/CollectionResponse.json",
                                "schema": "https://us14.api.mailchimp.com/schema/3.0/Paths/Lists/Members/Collection.json"
                            },
                            {
                                "rel": "update",
                                "href": "https://us14.api.mailchimp.com/3.0/lists/b090e8dbda/members/0e1d64b5a51568d14b1355f2d9403999",
                                "method": "PATCH",
                                "targetSchema": "https://us14.api.mailchimp.com/schema/3.0/Definitions/Lists/Members/Response.json",
                                "schema": "https://us14.api.mailchimp.com/schema/3.0/Definitions/Lists/Members/PATCH.json"
                            },
                            {
                                "rel": "upsert",
                                "href": "https://us14.api.mailchimp.com/3.0/lists/b090e8dbda/members/0e1d64b5a51568d14b1355f2d9403999",
                                "method": "PUT",
                                "targetSchema": "https://us14.api.mailchimp.com/schema/3.0/Definitions/Lists/Members/Response.json",
                                "schema": "https://us14.api.mailchimp.com/schema/3.0/Definitions/Lists/Members/PUT.json"
                            },
                            {
                                "rel": "delete",
                                "href": "https://us14.api.mailchimp.com/3.0/lists/b090e8dbda/members/0e1d64b5a51568d14b1355f2d9403999",
                                "method": "DELETE"
                            },
                            {
                                "rel": "activity",
                                "href": "https://us14.api.mailchimp.com/3.0/lists/b090e8dbda/members/0e1d64b5a51568d14b1355f2d9403999/activity",
                                "method": "GET",
                                "targetSchema": "https://us14.api.mailchimp.com/schema/3.0/Definitions/Lists/Members/Activity/Response.json"
                            },
                            {
                                "rel": "goals",
                                "href": "https://us14.api.mailchimp.com/3.0/lists/b090e8dbda/members/0e1d64b5a51568d14b1355f2d9403999/goals",
                                "method": "GET",
                                "targetSchema": "https://us14.api.mailchimp.com/schema/3.0/Definitions/Lists/Members/Goals/Response.json"
                            },
                            {
                                "rel": "notes",
                                "href": "https://us14.api.mailchimp.com/3.0/lists/b090e8dbda/members/0e1d64b5a51568d14b1355f2d9403999/notes",
                                "method": "GET",
                                "targetSchema": "https://us14.api.mailchimp.com/schema/3.0/Definitions/Lists/Members/Notes/CollectionResponse.json"
                            },
                            {
                                "rel": "events",
                                "href": "https://us14.api.mailchimp.com/3.0/lists/b090e8dbda/members/0e1d64b5a51568d14b1355f2d9403999/events",
                                "method": "POST",
                                "targetSchema": "https://us14.api.mailchimp.com/schema/3.0/Definitions/Lists/Members/Events/POST.json"
                            },
                            {
                                "rel": "delete_permanent",
                                "href": "https://us14.api.mailchimp.com/3.0/lists/b090e8dbda/members/0e1d64b5a51568d14b1355f2d9403999/actions/delete-permanent",
                                "method": "POST"
                            }
                        ]
                    },
                    {
                        "id": "3de48cb715674a6bcaea8a4ea9a6d4b3",
                        "contact_id": "a1c8d0e7ff8dd201d2f4d3322bc0f647",
                        "email_address": "Leonel.Sipes6@yahoo.com",
                        "unique_email_id": "b3d229ee75",
                        "email_type": "html",
                        "status": "subscribed",
                        "merge_fields": {
                            "FNAME": "",
                            "LNAME": "",
                            "ADDRESS": "",
                            "PHONE": ""
                        },
                        "stats": {
                            "avg_open_rate": 0,
                            "avg_click_rate": 0
                        },
                        "ip_signup": "",
                        "timestamp_signup": "",
                        "ip_opt": "170.244.255.167",
                        "timestamp_opt": "2024-12-23T16:21:58+00:00",
                        "member_rating": 2,
                        "last_changed": "2024-12-23T16:21:58+00:00",
                        "language": "",
                        "vip": false,
                        "email_client": "",
                        "location": {
                            "latitude": 0,
                            "longitude": 0,
                            "gmtoff": 0,
                            "dstoff": 0,
                            "country_code": "",
                            "timezone": ""
                        },
                        "tags_count": 0,
                        "tags": [],
                        "list_id": "b090e8dbda",
                        "_links": [
                            {
                                "rel": "self",
                                "href": "https://us14.api.mailchimp.com/3.0/lists/b090e8dbda/members/3de48cb715674a6bcaea8a4ea9a6d4b3",
                                "method": "GET",
                                "targetSchema": "https://us14.api.mailchimp.com/schema/3.0/Definitions/Lists/Members/Response.json"
                            },
                            {
                                "rel": "parent",
                                "href": "https://us14.api.mailchimp.com/3.0/lists/b090e8dbda/members",
                                "method": "GET",
                                "targetSchema": "https://us14.api.mailchimp.com/schema/3.0/Definitions/Lists/Members/CollectionResponse.json",
                                "schema": "https://us14.api.mailchimp.com/schema/3.0/Paths/Lists/Members/Collection.json"
                            },
                            {
                                "rel": "update",
                                "href": "https://us14.api.mailchimp.com/3.0/lists/b090e8dbda/members/3de48cb715674a6bcaea8a4ea9a6d4b3",
                                "method": "PATCH",
                                "targetSchema": "https://us14.api.mailchimp.com/schema/3.0/Definitions/Lists/Members/Response.json",
                                "schema": "https://us14.api.mailchimp.com/schema/3.0/Definitions/Lists/Members/PATCH.json"
                            },
                            {
                                "rel": "upsert",
                                "href": "https://us14.api.mailchimp.com/3.0/lists/b090e8dbda/members/3de48cb715674a6bcaea8a4ea9a6d4b3",
                                "method": "PUT",
                                "targetSchema": "https://us14.api.mailchimp.com/schema/3.0/Definitions/Lists/Members/Response.json",
                                "schema": "https://us14.api.mailchimp.com/schema/3.0/Definitions/Lists/Members/PUT.json"
                            },
                            {
                                "rel": "delete",
                                "href": "https://us14.api.mailchimp.com/3.0/lists/b090e8dbda/members/3de48cb715674a6bcaea8a4ea9a6d4b3",
                                "method": "DELETE"
                            },
                            {
                                "rel": "activity",
                                "href": "https://us14.api.mailchimp.com/3.0/lists/b090e8dbda/members/3de48cb715674a6bcaea8a4ea9a6d4b3/activity",
                                "method": "GET",
                                "targetSchema": "https://us14.api.mailchimp.com/schema/3.0/Definitions/Lists/Members/Activity/Response.json"
                            },
                            {
                                "rel": "goals",
                                "href": "https://us14.api.mailchimp.com/3.0/lists/b090e8dbda/members/3de48cb715674a6bcaea8a4ea9a6d4b3/goals",
                                "method": "GET",
                                "targetSchema": "https://us14.api.mailchimp.com/schema/3.0/Definitions/Lists/Members/Goals/Response.json"
                            },
                            {
                                "rel": "notes",
                                "href": "https://us14.api.mailchimp.com/3.0/lists/b090e8dbda/members/3de48cb715674a6bcaea8a4ea9a6d4b3/notes",
                                "method": "GET",
                                "targetSchema": "https://us14.api.mailchimp.com/schema/3.0/Definitions/Lists/Members/Notes/CollectionResponse.json"
                            },
                            {
                                "rel": "events",
                                "href": "https://us14.api.mailchimp.com/3.0/lists/b090e8dbda/members/3de48cb715674a6bcaea8a4ea9a6d4b3/events",
                                "method": "POST",
                                "targetSchema": "https://us14.api.mailchimp.com/schema/3.0/Definitions/Lists/Members/Events/POST.json"
                            },
                            {
                                "rel": "delete_permanent",
                                "href": "https://us14.api.mailchimp.com/3.0/lists/b090e8dbda/members/3de48cb715674a6bcaea8a4ea9a6d4b3/actions/delete-permanent",
                                "method": "POST"
                            }
                        ]
                    },
                    {
                        "id": "c526bf36fd84da2e4aeec7db6a5ce43c",
                        "contact_id": "0624615e14fbbc02aab71620c76639d6",
                        "email_address": "Alexys_Aufderhar147@yahoo.com",
                        "unique_email_id": "82c2f4a8e8",
                        "email_type": "html",
                        "status": "subscribed",
                        "merge_fields": {
                            "FNAME": "",
                            "LNAME": "",
                            "ADDRESS": "",
                            "PHONE": ""
                        },
                        "stats": {
                            "avg_open_rate": 0,
                            "avg_click_rate": 0
                        },
                        "ip_signup": "",
                        "timestamp_signup": "",
                        "ip_opt": "170.244.255.167",
                        "timestamp_opt": "2024-12-23T16:21:58+00:00",
                        "member_rating": 2,
                        "last_changed": "2024-12-23T16:21:58+00:00",
                        "language": "",
                        "vip": false,
                        "email_client": "",
                        "location": {
                            "latitude": 0,
                            "longitude": 0,
                            "gmtoff": 0,
                            "dstoff": 0,
                            "country_code": "",
                            "timezone": ""
                        },
                        "tags_count": 0,
                        "tags": [],
                        "list_id": "b090e8dbda",
                        "_links": [
                            {
                                "rel": "self",
                                "href": "https://us14.api.mailchimp.com/3.0/lists/b090e8dbda/members/c526bf36fd84da2e4aeec7db6a5ce43c",
                                "method": "GET",
                                "targetSchema": "https://us14.api.mailchimp.com/schema/3.0/Definitions/Lists/Members/Response.json"
                            },
                            {
                                "rel": "parent",
                                "href": "https://us14.api.mailchimp.com/3.0/lists/b090e8dbda/members",
                                "method": "GET",
                                "targetSchema": "https://us14.api.mailchimp.com/schema/3.0/Definitions/Lists/Members/CollectionResponse.json",
                                "schema": "https://us14.api.mailchimp.com/schema/3.0/Paths/Lists/Members/Collection.json"
                            },
                            {
                                "rel": "update",
                                "href": "https://us14.api.mailchimp.com/3.0/lists/b090e8dbda/members/c526bf36fd84da2e4aeec7db6a5ce43c",
                                "method": "PATCH",
                                "targetSchema": "https://us14.api.mailchimp.com/schema/3.0/Definitions/Lists/Members/Response.json",
                                "schema": "https://us14.api.mailchimp.com/schema/3.0/Definitions/Lists/Members/PATCH.json"
                            },
                            {
                                "rel": "upsert",
                                "href": "https://us14.api.mailchimp.com/3.0/lists/b090e8dbda/members/c526bf36fd84da2e4aeec7db6a5ce43c",
                                "method": "PUT",
                                "targetSchema": "https://us14.api.mailchimp.com/schema/3.0/Definitions/Lists/Members/Response.json",
                                "schema": "https://us14.api.mailchimp.com/schema/3.0/Definitions/Lists/Members/PUT.json"
                            },
                            {
                                "rel": "delete",
                                "href": "https://us14.api.mailchimp.com/3.0/lists/b090e8dbda/members/c526bf36fd84da2e4aeec7db6a5ce43c",
                                "method": "DELETE"
                            },
                            {
                                "rel": "activity",
                                "href": "https://us14.api.mailchimp.com/3.0/lists/b090e8dbda/members/c526bf36fd84da2e4aeec7db6a5ce43c/activity",
                                "method": "GET",
                                "targetSchema": "https://us14.api.mailchimp.com/schema/3.0/Definitions/Lists/Members/Activity/Response.json"
                            },
                            {
                                "rel": "goals",
                                "href": "https://us14.api.mailchimp.com/3.0/lists/b090e8dbda/members/c526bf36fd84da2e4aeec7db6a5ce43c/goals",
                                "method": "GET",
                                "targetSchema": "https://us14.api.mailchimp.com/schema/3.0/Definitions/Lists/Members/Goals/Response.json"
                            },
                            {
                                "rel": "notes",
                                "href": "https://us14.api.mailchimp.com/3.0/lists/b090e8dbda/members/c526bf36fd84da2e4aeec7db6a5ce43c/notes",
                                "method": "GET",
                                "targetSchema": "https://us14.api.mailchimp.com/schema/3.0/Definitions/Lists/Members/Notes/CollectionResponse.json"
                            },
                            {
                                "rel": "events",
                                "href": "https://us14.api.mailchimp.com/3.0/lists/b090e8dbda/members/c526bf36fd84da2e4aeec7db6a5ce43c/events",
                                "method": "POST",
                                "targetSchema": "https://us14.api.mailchimp.com/schema/3.0/Definitions/Lists/Members/Events/POST.json"
                            },
                            {
                                "rel": "delete_permanent",
                                "href": "https://us14.api.mailchimp.com/3.0/lists/b090e8dbda/members/c526bf36fd84da2e4aeec7db6a5ce43c/actions/delete-permanent",
                                "method": "POST"
                            }
                        ]
                    },
                    {
                        "id": "82151ddfdeb0db56c27a7e8db088787b",
                        "contact_id": "c877f5df21433f4eab1051ea121bd7cb",
                        "email_address": "Jamil381@hotmail.com",
                        "unique_email_id": "79e61d1dd7",
                        "email_type": "html",
                        "status": "subscribed",
                        "merge_fields": {
                            "FNAME": "",
                            "LNAME": "",
                            "ADDRESS": "",
                            "PHONE": ""
                        },
                        "stats": {
                            "avg_open_rate": 0,
                            "avg_click_rate": 0
                        },
                        "ip_signup": "",
                        "timestamp_signup": "",
                        "ip_opt": "170.244.255.167",
                        "timestamp_opt": "2024-12-23T16:21:58+00:00",
                        "member_rating": 2,
                        "last_changed": "2024-12-23T16:21:58+00:00",
                        "language": "",
                        "vip": false,
                        "email_client": "",
                        "location": {
                            "latitude": 0,
                            "longitude": 0,
                            "gmtoff": 0,
                            "dstoff": 0,
                            "country_code": "",
                            "timezone": ""
                        },
                        "tags_count": 0,
                        "tags": [],
                        "list_id": "b090e8dbda",
                        "_links": [
                            {
                                "rel": "self",
                                "href": "https://us14.api.mailchimp.com/3.0/lists/b090e8dbda/members/82151ddfdeb0db56c27a7e8db088787b",
                                "method": "GET",
                                "targetSchema": "https://us14.api.mailchimp.com/schema/3.0/Definitions/Lists/Members/Response.json"
                            },
                            {
                                "rel": "parent",
                                "href": "https://us14.api.mailchimp.com/3.0/lists/b090e8dbda/members",
                                "method": "GET",
                                "targetSchema": "https://us14.api.mailchimp.com/schema/3.0/Definitions/Lists/Members/CollectionResponse.json",
                                "schema": "https://us14.api.mailchimp.com/schema/3.0/Paths/Lists/Members/Collection.json"
                            },
                            {
                                "rel": "update",
                                "href": "https://us14.api.mailchimp.com/3.0/lists/b090e8dbda/members/82151ddfdeb0db56c27a7e8db088787b",
                                "method": "PATCH",
                                "targetSchema": "https://us14.api.mailchimp.com/schema/3.0/Definitions/Lists/Members/Response.json",
                                "schema": "https://us14.api.mailchimp.com/schema/3.0/Definitions/Lists/Members/PATCH.json"
                            },
                            {
                                "rel": "upsert",
                                "href": "https://us14.api.mailchimp.com/3.0/lists/b090e8dbda/members/82151ddfdeb0db56c27a7e8db088787b",
                                "method": "PUT",
                                "targetSchema": "https://us14.api.mailchimp.com/schema/3.0/Definitions/Lists/Members/Response.json",
                                "schema": "https://us14.api.mailchimp.com/schema/3.0/Definitions/Lists/Members/PUT.json"
                            },
                            {
                                "rel": "delete",
                                "href": "https://us14.api.mailchimp.com/3.0/lists/b090e8dbda/members/82151ddfdeb0db56c27a7e8db088787b",
                                "method": "DELETE"
                            },
                            {
                                "rel": "activity",
                                "href": "https://us14.api.mailchimp.com/3.0/lists/b090e8dbda/members/82151ddfdeb0db56c27a7e8db088787b/activity",
                                "method": "GET",
                                "targetSchema": "https://us14.api.mailchimp.com/schema/3.0/Definitions/Lists/Members/Activity/Response.json"
                            },
                            {
                                "rel": "goals",
                                "href": "https://us14.api.mailchimp.com/3.0/lists/b090e8dbda/members/82151ddfdeb0db56c27a7e8db088787b/goals",
                                "method": "GET",
                                "targetSchema": "https://us14.api.mailchimp.com/schema/3.0/Definitions/Lists/Members/Goals/Response.json"
                            },
                            {
                                "rel": "notes",
                                "href": "https://us14.api.mailchimp.com/3.0/lists/b090e8dbda/members/82151ddfdeb0db56c27a7e8db088787b/notes",
                                "method": "GET",
                                "targetSchema": "https://us14.api.mailchimp.com/schema/3.0/Definitions/Lists/Members/Notes/CollectionResponse.json"
                            },
                            {
                                "rel": "events",
                                "href": "https://us14.api.mailchimp.com/3.0/lists/b090e8dbda/members/82151ddfdeb0db56c27a7e8db088787b/events",
                                "method": "POST",
                                "targetSchema": "https://us14.api.mailchimp.com/schema/3.0/Definitions/Lists/Members/Events/POST.json"
                            },
                            {
                                "rel": "delete_permanent",
                                "href": "https://us14.api.mailchimp.com/3.0/lists/b090e8dbda/members/82151ddfdeb0db56c27a7e8db088787b/actions/delete-permanent",
                                "method": "POST"
                            }
                        ]
                    },
                    {
                        "id": "d4b250354a3147c8b78aa08a50957211",
                        "contact_id": "2f79a28adbd96b392a36f01192d90653",
                        "email_address": "Trace.Johnston128@yahoo.com",
                        "unique_email_id": "fd759f0891",
                        "email_type": "html",
                        "status": "subscribed",
                        "merge_fields": {
                            "FNAME": "",
                            "LNAME": "",
                            "ADDRESS": "",
                            "PHONE": ""
                        },
                        "stats": {
                            "avg_open_rate": 0,
                            "avg_click_rate": 0
                        },
                        "ip_signup": "",
                        "timestamp_signup": "",
                        "ip_opt": "170.244.255.167",
                        "timestamp_opt": "2024-12-23T16:21:58+00:00",
                        "member_rating": 2,
                        "last_changed": "2024-12-23T16:21:58+00:00",
                        "language": "",
                        "vip": false,
                        "email_client": "",
                        "location": {
                            "latitude": 0,
                            "longitude": 0,
                            "gmtoff": 0,
                            "dstoff": 0,
                            "country_code": "",
                            "timezone": ""
                        },
                        "tags_count": 0,
                        "tags": [],
                        "list_id": "b090e8dbda",
                        "_links": [
                            {
                                "rel": "self",
                                "href": "https://us14.api.mailchimp.com/3.0/lists/b090e8dbda/members/d4b250354a3147c8b78aa08a50957211",
                                "method": "GET",
                                "targetSchema": "https://us14.api.mailchimp.com/schema/3.0/Definitions/Lists/Members/Response.json"
                            },
                            {
                                "rel": "parent",
                                "href": "https://us14.api.mailchimp.com/3.0/lists/b090e8dbda/members",
                                "method": "GET",
                                "targetSchema": "https://us14.api.mailchimp.com/schema/3.0/Definitions/Lists/Members/CollectionResponse.json",
                                "schema": "https://us14.api.mailchimp.com/schema/3.0/Paths/Lists/Members/Collection.json"
                            },
                            {
                                "rel": "update",
                                "href": "https://us14.api.mailchimp.com/3.0/lists/b090e8dbda/members/d4b250354a3147c8b78aa08a50957211",
                                "method": "PATCH",
                                "targetSchema": "https://us14.api.mailchimp.com/schema/3.0/Definitions/Lists/Members/Response.json",
                                "schema": "https://us14.api.mailchimp.com/schema/3.0/Definitions/Lists/Members/PATCH.json"
                            },
                            {
                                "rel": "upsert",
                                "href": "https://us14.api.mailchimp.com/3.0/lists/b090e8dbda/members/d4b250354a3147c8b78aa08a50957211",
                                "method": "PUT",
                                "targetSchema": "https://us14.api.mailchimp.com/schema/3.0/Definitions/Lists/Members/Response.json",
                                "schema": "https://us14.api.mailchimp.com/schema/3.0/Definitions/Lists/Members/PUT.json"
                            },
                            {
                                "rel": "delete",
                                "href": "https://us14.api.mailchimp.com/3.0/lists/b090e8dbda/members/d4b250354a3147c8b78aa08a50957211",
                                "method": "DELETE"
                            },
                            {
                                "rel": "activity",
                                "href": "https://us14.api.mailchimp.com/3.0/lists/b090e8dbda/members/d4b250354a3147c8b78aa08a50957211/activity",
                                "method": "GET",
                                "targetSchema": "https://us14.api.mailchimp.com/schema/3.0/Definitions/Lists/Members/Activity/Response.json"
                            },
                            {
                                "rel": "goals",
                                "href": "https://us14.api.mailchimp.com/3.0/lists/b090e8dbda/members/d4b250354a3147c8b78aa08a50957211/goals",
                                "method": "GET",
                                "targetSchema": "https://us14.api.mailchimp.com/schema/3.0/Definitions/Lists/Members/Goals/Response.json"
                            },
                            {
                                "rel": "notes",
                                "href": "https://us14.api.mailchimp.com/3.0/lists/b090e8dbda/members/d4b250354a3147c8b78aa08a50957211/notes",
                                "method": "GET",
                                "targetSchema": "https://us14.api.mailchimp.com/schema/3.0/Definitions/Lists/Members/Notes/CollectionResponse.json"
                            },
                            {
                                "rel": "events",
                                "href": "https://us14.api.mailchimp.com/3.0/lists/b090e8dbda/members/d4b250354a3147c8b78aa08a50957211/events",
                                "method": "POST",
                                "targetSchema": "https://us14.api.mailchimp.com/schema/3.0/Definitions/Lists/Members/Events/POST.json"
                            },
                            {
                                "rel": "delete_permanent",
                                "href": "https://us14.api.mailchimp.com/3.0/lists/b090e8dbda/members/d4b250354a3147c8b78aa08a50957211/actions/delete-permanent",
                                "method": "POST"
                            }
                        ]
                    },
                    {
                        "id": "e7c1aaefe8ac76f85b9aa1ae1fbdf896",
                        "contact_id": "0c400d96557f785c0810c9c80db7a244",
                        "email_address": "Felipe238@icloud.com",
                        "unique_email_id": "f7364efebd",
                        "email_type": "html",
                        "status": "subscribed",
                        "merge_fields": {
                            "FNAME": "",
                            "LNAME": "",
                            "ADDRESS": "",
                            "PHONE": ""
                        },
                        "stats": {
                            "avg_open_rate": 0,
                            "avg_click_rate": 0
                        },
                        "ip_signup": "",
                        "timestamp_signup": "",
                        "ip_opt": "170.244.255.167",
                        "timestamp_opt": "2024-12-23T16:21:58+00:00",
                        "member_rating": 2,
                        "last_changed": "2024-12-23T16:21:58+00:00",
                        "language": "",
                        "vip": false,
                        "email_client": "",
                        "location": {
                            "latitude": 0,
                            "longitude": 0,
                            "gmtoff": 0,
                            "dstoff": 0,
                            "country_code": "",
                            "timezone": ""
                        },
                        "tags_count": 0,
                        "tags": [],
                        "list_id": "b090e8dbda",
                        "_links": [
                            {
                                "rel": "self",
                                "href": "https://us14.api.mailchimp.com/3.0/lists/b090e8dbda/members/e7c1aaefe8ac76f85b9aa1ae1fbdf896",
                                "method": "GET",
                                "targetSchema": "https://us14.api.mailchimp.com/schema/3.0/Definitions/Lists/Members/Response.json"
                            },
                            {
                                "rel": "parent",
                                "href": "https://us14.api.mailchimp.com/3.0/lists/b090e8dbda/members",
                                "method": "GET",
                                "targetSchema": "https://us14.api.mailchimp.com/schema/3.0/Definitions/Lists/Members/CollectionResponse.json",
                                "schema": "https://us14.api.mailchimp.com/schema/3.0/Paths/Lists/Members/Collection.json"
                            },
                            {
                                "rel": "update",
                                "href": "https://us14.api.mailchimp.com/3.0/lists/b090e8dbda/members/e7c1aaefe8ac76f85b9aa1ae1fbdf896",
                                "method": "PATCH",
                                "targetSchema": "https://us14.api.mailchimp.com/schema/3.0/Definitions/Lists/Members/Response.json",
                                "schema": "https://us14.api.mailchimp.com/schema/3.0/Definitions/Lists/Members/PATCH.json"
                            },
                            {
                                "rel": "upsert",
                                "href": "https://us14.api.mailchimp.com/3.0/lists/b090e8dbda/members/e7c1aaefe8ac76f85b9aa1ae1fbdf896",
                                "method": "PUT",
                                "targetSchema": "https://us14.api.mailchimp.com/schema/3.0/Definitions/Lists/Members/Response.json",
                                "schema": "https://us14.api.mailchimp.com/schema/3.0/Definitions/Lists/Members/PUT.json"
                            },
                            {
                                "rel": "delete",
                                "href": "https://us14.api.mailchimp.com/3.0/lists/b090e8dbda/members/e7c1aaefe8ac76f85b9aa1ae1fbdf896",
                                "method": "DELETE"
                            },
                            {
                                "rel": "activity",
                                "href": "https://us14.api.mailchimp.com/3.0/lists/b090e8dbda/members/e7c1aaefe8ac76f85b9aa1ae1fbdf896/activity",
                                "method": "GET",
                                "targetSchema": "https://us14.api.mailchimp.com/schema/3.0/Definitions/Lists/Members/Activity/Response.json"
                            },
                            {
                                "rel": "goals",
                                "href": "https://us14.api.mailchimp.com/3.0/lists/b090e8dbda/members/e7c1aaefe8ac76f85b9aa1ae1fbdf896/goals",
                                "method": "GET",
                                "targetSchema": "https://us14.api.mailchimp.com/schema/3.0/Definitions/Lists/Members/Goals/Response.json"
                            },
                            {
                                "rel": "notes",
                                "href": "https://us14.api.mailchimp.com/3.0/lists/b090e8dbda/members/e7c1aaefe8ac76f85b9aa1ae1fbdf896/notes",
                                "method": "GET",
                                "targetSchema": "https://us14.api.mailchimp.com/schema/3.0/Definitions/Lists/Members/Notes/CollectionResponse.json"
                            },
                            {
                                "rel": "events",
                                "href": "https://us14.api.mailchimp.com/3.0/lists/b090e8dbda/members/e7c1aaefe8ac76f85b9aa1ae1fbdf896/events",
                                "method": "POST",
                                "targetSchema": "https://us14.api.mailchimp.com/schema/3.0/Definitions/Lists/Members/Events/POST.json"
                            },
                            {
                                "rel": "delete_permanent",
                                "href": "https://us14.api.mailchimp.com/3.0/lists/b090e8dbda/members/e7c1aaefe8ac76f85b9aa1ae1fbdf896/actions/delete-permanent",
                                "method": "POST"
                            }
                        ]
                    },
                    {
                        "id": "132ed4580f0fca2a3c130d050d158559",
                        "contact_id": "4e86e4b4466af0ea02a4c640266356d9",
                        "email_address": "Reginald_Bechtelar980@gmail.com",
                        "unique_email_id": "6dc82163bc",
                        "email_type": "html",
                        "status": "subscribed",
                        "merge_fields": {
                            "FNAME": "",
                            "LNAME": "",
                            "ADDRESS": "",
                            "PHONE": ""
                        },
                        "stats": {
                            "avg_open_rate": 0,
                            "avg_click_rate": 0
                        },
                        "ip_signup": "",
                        "timestamp_signup": "",
                        "ip_opt": "170.244.255.167",
                        "timestamp_opt": "2024-12-23T16:21:58+00:00",
                        "member_rating": 2,
                        "last_changed": "2024-12-23T16:21:59+00:00",
                        "language": "",
                        "vip": false,
                        "email_client": "",
                        "location": {
                            "latitude": 0,
                            "longitude": 0,
                            "gmtoff": 0,
                            "dstoff": 0,
                            "country_code": "",
                            "timezone": ""
                        },
                        "tags_count": 0,
                        "tags": [],
                        "list_id": "b090e8dbda",
                        "_links": [
                            {
                                "rel": "self",
                                "href": "https://us14.api.mailchimp.com/3.0/lists/b090e8dbda/members/132ed4580f0fca2a3c130d050d158559",
                                "method": "GET",
                                "targetSchema": "https://us14.api.mailchimp.com/schema/3.0/Definitions/Lists/Members/Response.json"
                            },
                            {
                                "rel": "parent",
                                "href": "https://us14.api.mailchimp.com/3.0/lists/b090e8dbda/members",
                                "method": "GET",
                                "targetSchema": "https://us14.api.mailchimp.com/schema/3.0/Definitions/Lists/Members/CollectionResponse.json",
                                "schema": "https://us14.api.mailchimp.com/schema/3.0/Paths/Lists/Members/Collection.json"
                            },
                            {
                                "rel": "update",
                                "href": "https://us14.api.mailchimp.com/3.0/lists/b090e8dbda/members/132ed4580f0fca2a3c130d050d158559",
                                "method": "PATCH",
                                "targetSchema": "https://us14.api.mailchimp.com/schema/3.0/Definitions/Lists/Members/Response.json",
                                "schema": "https://us14.api.mailchimp.com/schema/3.0/Definitions/Lists/Members/PATCH.json"
                            },
                            {
                                "rel": "upsert",
                                "href": "https://us14.api.mailchimp.com/3.0/lists/b090e8dbda/members/132ed4580f0fca2a3c130d050d158559",
                                "method": "PUT",
                                "targetSchema": "https://us14.api.mailchimp.com/schema/3.0/Definitions/Lists/Members/Response.json",
                                "schema": "https://us14.api.mailchimp.com/schema/3.0/Definitions/Lists/Members/PUT.json"
                            },
                            {
                                "rel": "delete",
                                "href": "https://us14.api.mailchimp.com/3.0/lists/b090e8dbda/members/132ed4580f0fca2a3c130d050d158559",
                                "method": "DELETE"
                            },
                            {
                                "rel": "activity",
                                "href": "https://us14.api.mailchimp.com/3.0/lists/b090e8dbda/members/132ed4580f0fca2a3c130d050d158559/activity",
                                "method": "GET",
                                "targetSchema": "https://us14.api.mailchimp.com/schema/3.0/Definitions/Lists/Members/Activity/Response.json"
                            },
                            {
                                "rel": "goals",
                                "href": "https://us14.api.mailchimp.com/3.0/lists/b090e8dbda/members/132ed4580f0fca2a3c130d050d158559/goals",
                                "method": "GET",
                                "targetSchema": "https://us14.api.mailchimp.com/schema/3.0/Definitions/Lists/Members/Goals/Response.json"
                            },
                            {
                                "rel": "notes",
                                "href": "https://us14.api.mailchimp.com/3.0/lists/b090e8dbda/members/132ed4580f0fca2a3c130d050d158559/notes",
                                "method": "GET",
                                "targetSchema": "https://us14.api.mailchimp.com/schema/3.0/Definitions/Lists/Members/Notes/CollectionResponse.json"
                            },
                            {
                                "rel": "events",
                                "href": "https://us14.api.mailchimp.com/3.0/lists/b090e8dbda/members/132ed4580f0fca2a3c130d050d158559/events",
                                "method": "POST",
                                "targetSchema": "https://us14.api.mailchimp.com/schema/3.0/Definitions/Lists/Members/Events/POST.json"
                            },
                            {
                                "rel": "delete_permanent",
                                "href": "https://us14.api.mailchimp.com/3.0/lists/b090e8dbda/members/132ed4580f0fca2a3c130d050d158559/actions/delete-permanent",
                                "method": "POST"
                            }
                        ]
                    },
                    {
                        "id": "e47f0c01ef6114bc7d0552c9a3e64fa7",
                        "contact_id": "7a30b06851ef5785f69b59009eec04f2",
                        "email_address": "Myrtis343@icloud.com",
                        "unique_email_id": "68ee6998ab",
                        "email_type": "html",
                        "status": "subscribed",
                        "merge_fields": {
                            "FNAME": "",
                            "LNAME": "",
                            "ADDRESS": "",
                            "PHONE": ""
                        },
                        "stats": {
                            "avg_open_rate": 0,
                            "avg_click_rate": 0
                        },
                        "ip_signup": "",
                        "timestamp_signup": "",
                        "ip_opt": "170.244.255.167",
                        "timestamp_opt": "2024-12-23T16:21:59+00:00",
                        "member_rating": 2,
                        "last_changed": "2024-12-23T16:21:59+00:00",
                        "language": "",
                        "vip": false,
                        "email_client": "",
                        "location": {
                            "latitude": 0,
                            "longitude": 0,
                            "gmtoff": 0,
                            "dstoff": 0,
                            "country_code": "",
                            "timezone": ""
                        },
                        "tags_count": 0,
                        "tags": [],
                        "list_id": "b090e8dbda",
                        "_links": [
                            {
                                "rel": "self",
                                "href": "https://us14.api.mailchimp.com/3.0/lists/b090e8dbda/members/e47f0c01ef6114bc7d0552c9a3e64fa7",
                                "method": "GET",
                                "targetSchema": "https://us14.api.mailchimp.com/schema/3.0/Definitions/Lists/Members/Response.json"
                            },
                            {
                                "rel": "parent",
                                "href": "https://us14.api.mailchimp.com/3.0/lists/b090e8dbda/members",
                                "method": "GET",
                                "targetSchema": "https://us14.api.mailchimp.com/schema/3.0/Definitions/Lists/Members/CollectionResponse.json",
                                "schema": "https://us14.api.mailchimp.com/schema/3.0/Paths/Lists/Members/Collection.json"
                            },
                            {
                                "rel": "update",
                                "href": "https://us14.api.mailchimp.com/3.0/lists/b090e8dbda/members/e47f0c01ef6114bc7d0552c9a3e64fa7",
                                "method": "PATCH",
                                "targetSchema": "https://us14.api.mailchimp.com/schema/3.0/Definitions/Lists/Members/Response.json",
                                "schema": "https://us14.api.mailchimp.com/schema/3.0/Definitions/Lists/Members/PATCH.json"
                            },
                            {
                                "rel": "upsert",
                                "href": "https://us14.api.mailchimp.com/3.0/lists/b090e8dbda/members/e47f0c01ef6114bc7d0552c9a3e64fa7",
                                "method": "PUT",
                                "targetSchema": "https://us14.api.mailchimp.com/schema/3.0/Definitions/Lists/Members/Response.json",
                                "schema": "https://us14.api.mailchimp.com/schema/3.0/Definitions/Lists/Members/PUT.json"
                            },
                            {
                                "rel": "delete",
                                "href": "https://us14.api.mailchimp.com/3.0/lists/b090e8dbda/members/e47f0c01ef6114bc7d0552c9a3e64fa7",
                                "method": "DELETE"
                            },
                            {
                                "rel": "activity",
                                "href": "https://us14.api.mailchimp.com/3.0/lists/b090e8dbda/members/e47f0c01ef6114bc7d0552c9a3e64fa7/activity",
                                "method": "GET",
                                "targetSchema": "https://us14.api.mailchimp.com/schema/3.0/Definitions/Lists/Members/Activity/Response.json"
                            },
                            {
                                "rel": "goals",
                                "href": "https://us14.api.mailchimp.com/3.0/lists/b090e8dbda/members/e47f0c01ef6114bc7d0552c9a3e64fa7/goals",
                                "method": "GET",
                                "targetSchema": "https://us14.api.mailchimp.com/schema/3.0/Definitions/Lists/Members/Goals/Response.json"
                            },
                            {
                                "rel": "notes",
                                "href": "https://us14.api.mailchimp.com/3.0/lists/b090e8dbda/members/e47f0c01ef6114bc7d0552c9a3e64fa7/notes",
                                "method": "GET",
                                "targetSchema": "https://us14.api.mailchimp.com/schema/3.0/Definitions/Lists/Members/Notes/CollectionResponse.json"
                            },
                            {
                                "rel": "events",
                                "href": "https://us14.api.mailchimp.com/3.0/lists/b090e8dbda/members/e47f0c01ef6114bc7d0552c9a3e64fa7/events",
                                "method": "POST",
                                "targetSchema": "https://us14.api.mailchimp.com/schema/3.0/Definitions/Lists/Members/Events/POST.json"
                            },
                            {
                                "rel": "delete_permanent",
                                "href": "https://us14.api.mailchimp.com/3.0/lists/b090e8dbda/members/e47f0c01ef6114bc7d0552c9a3e64fa7/actions/delete-permanent",
                                "method": "POST"
                            }
                        ]
                    },
                    {
                        "id": "b84d964442a9b7bdeda855bc918e520a",
                        "contact_id": "7bf4ecd433c140d86b53ea595823f7a1",
                        "email_address": "Rebeka_Thompson200@gmail.com",
                        "unique_email_id": "afa05c3958",
                        "email_type": "html",
                        "status": "subscribed",
                        "merge_fields": {
                            "FNAME": "",
                            "LNAME": "",
                            "ADDRESS": "",
                            "PHONE": ""
                        },
                        "stats": {
                            "avg_open_rate": 0,
                            "avg_click_rate": 0
                        },
                        "ip_signup": "",
                        "timestamp_signup": "",
                        "ip_opt": "170.244.255.167",
                        "timestamp_opt": "2024-12-23T16:21:59+00:00",
                        "member_rating": 2,
                        "last_changed": "2024-12-23T16:21:59+00:00",
                        "language": "",
                        "vip": false,
                        "email_client": "",
                        "location": {
                            "latitude": 0,
                            "longitude": 0,
                            "gmtoff": 0,
                            "dstoff": 0,
                            "country_code": "",
                            "timezone": ""
                        },
                        "tags_count": 0,
                        "tags": [],
                        "list_id": "b090e8dbda",
                        "_links": [
                            {
                                "rel": "self",
                                "href": "https://us14.api.mailchimp.com/3.0/lists/b090e8dbda/members/b84d964442a9b7bdeda855bc918e520a",
                                "method": "GET",
                                "targetSchema": "https://us14.api.mailchimp.com/schema/3.0/Definitions/Lists/Members/Response.json"
                            },
                            {
                                "rel": "parent",
                                "href": "https://us14.api.mailchimp.com/3.0/lists/b090e8dbda/members",
                                "method": "GET",
                                "targetSchema": "https://us14.api.mailchimp.com/schema/3.0/Definitions/Lists/Members/CollectionResponse.json",
                                "schema": "https://us14.api.mailchimp.com/schema/3.0/Paths/Lists/Members/Collection.json"
                            },
                            {
                                "rel": "update",
                                "href": "https://us14.api.mailchimp.com/3.0/lists/b090e8dbda/members/b84d964442a9b7bdeda855bc918e520a",
                                "method": "PATCH",
                                "targetSchema": "https://us14.api.mailchimp.com/schema/3.0/Definitions/Lists/Members/Response.json",
                                "schema": "https://us14.api.mailchimp.com/schema/3.0/Definitions/Lists/Members/PATCH.json"
                            },
                            {
                                "rel": "upsert",
                                "href": "https://us14.api.mailchimp.com/3.0/lists/b090e8dbda/members/b84d964442a9b7bdeda855bc918e520a",
                                "method": "PUT",
                                "targetSchema": "https://us14.api.mailchimp.com/schema/3.0/Definitions/Lists/Members/Response.json",
                                "schema": "https://us14.api.mailchimp.com/schema/3.0/Definitions/Lists/Members/PUT.json"
                            },
                            {
                                "rel": "delete",
                                "href": "https://us14.api.mailchimp.com/3.0/lists/b090e8dbda/members/b84d964442a9b7bdeda855bc918e520a",
                                "method": "DELETE"
                            },
                            {
                                "rel": "activity",
                                "href": "https://us14.api.mailchimp.com/3.0/lists/b090e8dbda/members/b84d964442a9b7bdeda855bc918e520a/activity",
                                "method": "GET",
                                "targetSchema": "https://us14.api.mailchimp.com/schema/3.0/Definitions/Lists/Members/Activity/Response.json"
                            },
                            {
                                "rel": "goals",
                                "href": "https://us14.api.mailchimp.com/3.0/lists/b090e8dbda/members/b84d964442a9b7bdeda855bc918e520a/goals",
                                "method": "GET",
                                "targetSchema": "https://us14.api.mailchimp.com/schema/3.0/Definitions/Lists/Members/Goals/Response.json"
                            },
                            {
                                "rel": "notes",
                                "href": "https://us14.api.mailchimp.com/3.0/lists/b090e8dbda/members/b84d964442a9b7bdeda855bc918e520a/notes",
                                "method": "GET",
                                "targetSchema": "https://us14.api.mailchimp.com/schema/3.0/Definitions/Lists/Members/Notes/CollectionResponse.json"
                            },
                            {
                                "rel": "events",
                                "href": "https://us14.api.mailchimp.com/3.0/lists/b090e8dbda/members/b84d964442a9b7bdeda855bc918e520a/events",
                                "method": "POST",
                                "targetSchema": "https://us14.api.mailchimp.com/schema/3.0/Definitions/Lists/Members/Events/POST.json"
                            },
                            {
                                "rel": "delete_permanent",
                                "href": "https://us14.api.mailchimp.com/3.0/lists/b090e8dbda/members/b84d964442a9b7bdeda855bc918e520a/actions/delete-permanent",
                                "method": "POST"
                            }
                        ]
                    },
                    {
                        "id": "120a309aa42ae1027ba9852904ba4b3a",
                        "contact_id": "57f298a0316d17fbfb89784c251ceda3",
                        "email_address": "Benedict_Kunze311@icloud.com",
                        "unique_email_id": "bf67eb0c62",
                        "email_type": "html",
                        "status": "subscribed",
                        "merge_fields": {
                            "FNAME": "",
                            "LNAME": "",
                            "ADDRESS": "",
                            "PHONE": ""
                        },
                        "stats": {
                            "avg_open_rate": 0,
                            "avg_click_rate": 0
                        },
                        "ip_signup": "",
                        "timestamp_signup": "",
                        "ip_opt": "170.244.255.167",
                        "timestamp_opt": "2024-12-23T16:21:59+00:00",
                        "member_rating": 2,
                        "last_changed": "2024-12-23T16:21:59+00:00",
                        "language": "",
                        "vip": false,
                        "email_client": "",
                        "location": {
                            "latitude": 0,
                            "longitude": 0,
                            "gmtoff": 0,
                            "dstoff": 0,
                            "country_code": "",
                            "timezone": ""
                        },
                        "tags_count": 0,
                        "tags": [],
                        "list_id": "b090e8dbda",
                        "_links": [
                            {
                                "rel": "self",
                                "href": "https://us14.api.mailchimp.com/3.0/lists/b090e8dbda/members/120a309aa42ae1027ba9852904ba4b3a",
                                "method": "GET",
                                "targetSchema": "https://us14.api.mailchimp.com/schema/3.0/Definitions/Lists/Members/Response.json"
                            },
                            {
                                "rel": "parent",
                                "href": "https://us14.api.mailchimp.com/3.0/lists/b090e8dbda/members",
                                "method": "GET",
                                "targetSchema": "https://us14.api.mailchimp.com/schema/3.0/Definitions/Lists/Members/CollectionResponse.json",
                                "schema": "https://us14.api.mailchimp.com/schema/3.0/Paths/Lists/Members/Collection.json"
                            },
                            {
                                "rel": "update",
                                "href": "https://us14.api.mailchimp.com/3.0/lists/b090e8dbda/members/120a309aa42ae1027ba9852904ba4b3a",
                                "method": "PATCH",
                                "targetSchema": "https://us14.api.mailchimp.com/schema/3.0/Definitions/Lists/Members/Response.json",
                                "schema": "https://us14.api.mailchimp.com/schema/3.0/Definitions/Lists/Members/PATCH.json"
                            },
                            {
                                "rel": "upsert",
                                "href": "https://us14.api.mailchimp.com/3.0/lists/b090e8dbda/members/120a309aa42ae1027ba9852904ba4b3a",
                                "method": "PUT",
                                "targetSchema": "https://us14.api.mailchimp.com/schema/3.0/Definitions/Lists/Members/Response.json",
                                "schema": "https://us14.api.mailchimp.com/schema/3.0/Definitions/Lists/Members/PUT.json"
                            },
                            {
                                "rel": "delete",
                                "href": "https://us14.api.mailchimp.com/3.0/lists/b090e8dbda/members/120a309aa42ae1027ba9852904ba4b3a",
                                "method": "DELETE"
                            },
                            {
                                "rel": "activity",
                                "href": "https://us14.api.mailchimp.com/3.0/lists/b090e8dbda/members/120a309aa42ae1027ba9852904ba4b3a/activity",
                                "method": "GET",
                                "targetSchema": "https://us14.api.mailchimp.com/schema/3.0/Definitions/Lists/Members/Activity/Response.json"
                            },
                            {
                                "rel": "goals",
                                "href": "https://us14.api.mailchimp.com/3.0/lists/b090e8dbda/members/120a309aa42ae1027ba9852904ba4b3a/goals",
                                "method": "GET",
                                "targetSchema": "https://us14.api.mailchimp.com/schema/3.0/Definitions/Lists/Members/Goals/Response.json"
                            },
                            {
                                "rel": "notes",
                                "href": "https://us14.api.mailchimp.com/3.0/lists/b090e8dbda/members/120a309aa42ae1027ba9852904ba4b3a/notes",
                                "method": "GET",
                                "targetSchema": "https://us14.api.mailchimp.com/schema/3.0/Definitions/Lists/Members/Notes/CollectionResponse.json"
                            },
                            {
                                "rel": "events",
                                "href": "https://us14.api.mailchimp.com/3.0/lists/b090e8dbda/members/120a309aa42ae1027ba9852904ba4b3a/events",
                                "method": "POST",
                                "targetSchema": "https://us14.api.mailchimp.com/schema/3.0/Definitions/Lists/Members/Events/POST.json"
                            },
                            {
                                "rel": "delete_permanent",
                                "href": "https://us14.api.mailchimp.com/3.0/lists/b090e8dbda/members/120a309aa42ae1027ba9852904ba4b3a/actions/delete-permanent",
                                "method": "POST"
                            }
                        ]
                    },
                    {
                        "id": "74c18c8e31ad69c13f8cdc58931d0046",
                        "contact_id": "ac66f96ea83eef77711e4cb7844a5882",
                        "email_address": "Jennie.Kessler436@hotmail.com",
                        "unique_email_id": "e4f3988cad",
                        "email_type": "html",
                        "status": "subscribed",
                        "merge_fields": {
                            "FNAME": "",
                            "LNAME": "",
                            "ADDRESS": "",
                            "PHONE": ""
                        },
                        "stats": {
                            "avg_open_rate": 0,
                            "avg_click_rate": 0
                        },
                        "ip_signup": "",
                        "timestamp_signup": "",
                        "ip_opt": "170.244.255.167",
                        "timestamp_opt": "2024-12-23T16:21:59+00:00",
                        "member_rating": 2,
                        "last_changed": "2024-12-23T16:21:59+00:00",
                        "language": "",
                        "vip": false,
                        "email_client": "",
                        "location": {
                            "latitude": 0,
                            "longitude": 0,
                            "gmtoff": 0,
                            "dstoff": 0,
                            "country_code": "",
                            "timezone": ""
                        },
                        "tags_count": 0,
                        "tags": [],
                        "list_id": "b090e8dbda",
                        "_links": [
                            {
                                "rel": "self",
                                "href": "https://us14.api.mailchimp.com/3.0/lists/b090e8dbda/members/74c18c8e31ad69c13f8cdc58931d0046",
                                "method": "GET",
                                "targetSchema": "https://us14.api.mailchimp.com/schema/3.0/Definitions/Lists/Members/Response.json"
                            },
                            {
                                "rel": "parent",
                                "href": "https://us14.api.mailchimp.com/3.0/lists/b090e8dbda/members",
                                "method": "GET",
                                "targetSchema": "https://us14.api.mailchimp.com/schema/3.0/Definitions/Lists/Members/CollectionResponse.json",
                                "schema": "https://us14.api.mailchimp.com/schema/3.0/Paths/Lists/Members/Collection.json"
                            },
                            {
                                "rel": "update",
                                "href": "https://us14.api.mailchimp.com/3.0/lists/b090e8dbda/members/74c18c8e31ad69c13f8cdc58931d0046",
                                "method": "PATCH",
                                "targetSchema": "https://us14.api.mailchimp.com/schema/3.0/Definitions/Lists/Members/Response.json",
                                "schema": "https://us14.api.mailchimp.com/schema/3.0/Definitions/Lists/Members/PATCH.json"
                            },
                            {
                                "rel": "upsert",
                                "href": "https://us14.api.mailchimp.com/3.0/lists/b090e8dbda/members/74c18c8e31ad69c13f8cdc58931d0046",
                                "method": "PUT",
                                "targetSchema": "https://us14.api.mailchimp.com/schema/3.0/Definitions/Lists/Members/Response.json",
                                "schema": "https://us14.api.mailchimp.com/schema/3.0/Definitions/Lists/Members/PUT.json"
                            },
                            {
                                "rel": "delete",
                                "href": "https://us14.api.mailchimp.com/3.0/lists/b090e8dbda/members/74c18c8e31ad69c13f8cdc58931d0046",
                                "method": "DELETE"
                            },
                            {
                                "rel": "activity",
                                "href": "https://us14.api.mailchimp.com/3.0/lists/b090e8dbda/members/74c18c8e31ad69c13f8cdc58931d0046/activity",
                                "method": "GET",
                                "targetSchema": "https://us14.api.mailchimp.com/schema/3.0/Definitions/Lists/Members/Activity/Response.json"
                            },
                            {
                                "rel": "goals",
                                "href": "https://us14.api.mailchimp.com/3.0/lists/b090e8dbda/members/74c18c8e31ad69c13f8cdc58931d0046/goals",
                                "method": "GET",
                                "targetSchema": "https://us14.api.mailchimp.com/schema/3.0/Definitions/Lists/Members/Goals/Response.json"
                            },
                            {
                                "rel": "notes",
                                "href": "https://us14.api.mailchimp.com/3.0/lists/b090e8dbda/members/74c18c8e31ad69c13f8cdc58931d0046/notes",
                                "method": "GET",
                                "targetSchema": "https://us14.api.mailchimp.com/schema/3.0/Definitions/Lists/Members/Notes/CollectionResponse.json"
                            },
                            {
                                "rel": "events",
                                "href": "https://us14.api.mailchimp.com/3.0/lists/b090e8dbda/members/74c18c8e31ad69c13f8cdc58931d0046/events",
                                "method": "POST",
                                "targetSchema": "https://us14.api.mailchimp.com/schema/3.0/Definitions/Lists/Members/Events/POST.json"
                            },
                            {
                                "rel": "delete_permanent",
                                "href": "https://us14.api.mailchimp.com/3.0/lists/b090e8dbda/members/74c18c8e31ad69c13f8cdc58931d0046/actions/delete-permanent",
                                "method": "POST"
                            }
                        ]
                    },
                    {
                        "id": "fb4936e8aa186d85f93eb6677fb1293c",
                        "contact_id": "41c4a7ebd7abc7830294617ffc468c51",
                        "email_address": "Terrance379@outlook.com",
                        "unique_email_id": "da48eefb3a",
                        "email_type": "html",
                        "status": "subscribed",
                        "merge_fields": {
                            "FNAME": "",
                            "LNAME": "",
                            "ADDRESS": "",
                            "PHONE": ""
                        },
                        "stats": {
                            "avg_open_rate": 0,
                            "avg_click_rate": 0
                        },
                        "ip_signup": "",
                        "timestamp_signup": "",
                        "ip_opt": "170.244.255.167",
                        "timestamp_opt": "2024-12-23T16:21:59+00:00",
                        "member_rating": 2,
                        "last_changed": "2024-12-23T16:21:59+00:00",
                        "language": "",
                        "vip": false,
                        "email_client": "",
                        "location": {
                            "latitude": 0,
                            "longitude": 0,
                            "gmtoff": 0,
                            "dstoff": 0,
                            "country_code": "",
                            "timezone": ""
                        },
                        "tags_count": 0,
                        "tags": [],
                        "list_id": "b090e8dbda",
                        "_links": [
                            {
                                "rel": "self",
                                "href": "https://us14.api.mailchimp.com/3.0/lists/b090e8dbda/members/fb4936e8aa186d85f93eb6677fb1293c",
                                "method": "GET",
                                "targetSchema": "https://us14.api.mailchimp.com/schema/3.0/Definitions/Lists/Members/Response.json"
                            },
                            {
                                "rel": "parent",
                                "href": "https://us14.api.mailchimp.com/3.0/lists/b090e8dbda/members",
                                "method": "GET",
                                "targetSchema": "https://us14.api.mailchimp.com/schema/3.0/Definitions/Lists/Members/CollectionResponse.json",
                                "schema": "https://us14.api.mailchimp.com/schema/3.0/Paths/Lists/Members/Collection.json"
                            },
                            {
                                "rel": "update",
                                "href": "https://us14.api.mailchimp.com/3.0/lists/b090e8dbda/members/fb4936e8aa186d85f93eb6677fb1293c",
                                "method": "PATCH",
                                "targetSchema": "https://us14.api.mailchimp.com/schema/3.0/Definitions/Lists/Members/Response.json",
                                "schema": "https://us14.api.mailchimp.com/schema/3.0/Definitions/Lists/Members/PATCH.json"
                            },
                            {
                                "rel": "upsert",
                                "href": "https://us14.api.mailchimp.com/3.0/lists/b090e8dbda/members/fb4936e8aa186d85f93eb6677fb1293c",
                                "method": "PUT",
                                "targetSchema": "https://us14.api.mailchimp.com/schema/3.0/Definitions/Lists/Members/Response.json",
                                "schema": "https://us14.api.mailchimp.com/schema/3.0/Definitions/Lists/Members/PUT.json"
                            },
                            {
                                "rel": "delete",
                                "href": "https://us14.api.mailchimp.com/3.0/lists/b090e8dbda/members/fb4936e8aa186d85f93eb6677fb1293c",
                                "method": "DELETE"
                            },
                            {
                                "rel": "activity",
                                "href": "https://us14.api.mailchimp.com/3.0/lists/b090e8dbda/members/fb4936e8aa186d85f93eb6677fb1293c/activity",
                                "method": "GET",
                                "targetSchema": "https://us14.api.mailchimp.com/schema/3.0/Definitions/Lists/Members/Activity/Response.json"
                            },
                            {
                                "rel": "goals",
                                "href": "https://us14.api.mailchimp.com/3.0/lists/b090e8dbda/members/fb4936e8aa186d85f93eb6677fb1293c/goals",
                                "method": "GET",
                                "targetSchema": "https://us14.api.mailchimp.com/schema/3.0/Definitions/Lists/Members/Goals/Response.json"
                            },
                            {
                                "rel": "notes",
                                "href": "https://us14.api.mailchimp.com/3.0/lists/b090e8dbda/members/fb4936e8aa186d85f93eb6677fb1293c/notes",
                                "method": "GET",
                                "targetSchema": "https://us14.api.mailchimp.com/schema/3.0/Definitions/Lists/Members/Notes/CollectionResponse.json"
                            },
                            {
                                "rel": "events",
                                "href": "https://us14.api.mailchimp.com/3.0/lists/b090e8dbda/members/fb4936e8aa186d85f93eb6677fb1293c/events",
                                "method": "POST",
                                "targetSchema": "https://us14.api.mailchimp.com/schema/3.0/Definitions/Lists/Members/Events/POST.json"
                            },
                            {
                                "rel": "delete_permanent",
                                "href": "https://us14.api.mailchimp.com/3.0/lists/b090e8dbda/members/fb4936e8aa186d85f93eb6677fb1293c/actions/delete-permanent",
                                "method": "POST"
                            }
                        ]
                    },
                    {
                        "id": "9f2740b21d9d7510d7ef0bab9544384e",
                        "contact_id": "cd9766df94dd030505edcc908dbfcf61",
                        "email_address": "Jackie571@icloud.com",
                        "unique_email_id": "d248f14851",
                        "email_type": "html",
                        "status": "subscribed",
                        "merge_fields": {
                            "FNAME": "",
                            "LNAME": "",
                            "ADDRESS": "",
                            "PHONE": ""
                        },
                        "stats": {
                            "avg_open_rate": 0,
                            "avg_click_rate": 0
                        },
                        "ip_signup": "",
                        "timestamp_signup": "",
                        "ip_opt": "170.244.255.167",
                        "timestamp_opt": "2024-12-23T16:21:59+00:00",
                        "member_rating": 2,
                        "last_changed": "2024-12-23T16:21:59+00:00",
                        "language": "",
                        "vip": false,
                        "email_client": "",
                        "location": {
                            "latitude": 0,
                            "longitude": 0,
                            "gmtoff": 0,
                            "dstoff": 0,
                            "country_code": "",
                            "timezone": ""
                        },
                        "tags_count": 0,
                        "tags": [],
                        "list_id": "b090e8dbda",
                        "_links": [
                            {
                                "rel": "self",
                                "href": "https://us14.api.mailchimp.com/3.0/lists/b090e8dbda/members/9f2740b21d9d7510d7ef0bab9544384e",
                                "method": "GET",
                                "targetSchema": "https://us14.api.mailchimp.com/schema/3.0/Definitions/Lists/Members/Response.json"
                            },
                            {
                                "rel": "parent",
                                "href": "https://us14.api.mailchimp.com/3.0/lists/b090e8dbda/members",
                                "method": "GET",
                                "targetSchema": "https://us14.api.mailchimp.com/schema/3.0/Definitions/Lists/Members/CollectionResponse.json",
                                "schema": "https://us14.api.mailchimp.com/schema/3.0/Paths/Lists/Members/Collection.json"
                            },
                            {
                                "rel": "update",
                                "href": "https://us14.api.mailchimp.com/3.0/lists/b090e8dbda/members/9f2740b21d9d7510d7ef0bab9544384e",
                                "method": "PATCH",
                                "targetSchema": "https://us14.api.mailchimp.com/schema/3.0/Definitions/Lists/Members/Response.json",
                                "schema": "https://us14.api.mailchimp.com/schema/3.0/Definitions/Lists/Members/PATCH.json"
                            },
                            {
                                "rel": "upsert",
                                "href": "https://us14.api.mailchimp.com/3.0/lists/b090e8dbda/members/9f2740b21d9d7510d7ef0bab9544384e",
                                "method": "PUT",
                                "targetSchema": "https://us14.api.mailchimp.com/schema/3.0/Definitions/Lists/Members/Response.json",
                                "schema": "https://us14.api.mailchimp.com/schema/3.0/Definitions/Lists/Members/PUT.json"
                            },
                            {
                                "rel": "delete",
                                "href": "https://us14.api.mailchimp.com/3.0/lists/b090e8dbda/members/9f2740b21d9d7510d7ef0bab9544384e",
                                "method": "DELETE"
                            },
                            {
                                "rel": "activity",
                                "href": "https://us14.api.mailchimp.com/3.0/lists/b090e8dbda/members/9f2740b21d9d7510d7ef0bab9544384e/activity",
                                "method": "GET",
                                "targetSchema": "https://us14.api.mailchimp.com/schema/3.0/Definitions/Lists/Members/Activity/Response.json"
                            },
                            {
                                "rel": "goals",
                                "href": "https://us14.api.mailchimp.com/3.0/lists/b090e8dbda/members/9f2740b21d9d7510d7ef0bab9544384e/goals",
                                "method": "GET",
                                "targetSchema": "https://us14.api.mailchimp.com/schema/3.0/Definitions/Lists/Members/Goals/Response.json"
                            },
                            {
                                "rel": "notes",
                                "href": "https://us14.api.mailchimp.com/3.0/lists/b090e8dbda/members/9f2740b21d9d7510d7ef0bab9544384e/notes",
                                "method": "GET",
                                "targetSchema": "https://us14.api.mailchimp.com/schema/3.0/Definitions/Lists/Members/Notes/CollectionResponse.json"
                            },
                            {
                                "rel": "events",
                                "href": "https://us14.api.mailchimp.com/3.0/lists/b090e8dbda/members/9f2740b21d9d7510d7ef0bab9544384e/events",
                                "method": "POST",
                                "targetSchema": "https://us14.api.mailchimp.com/schema/3.0/Definitions/Lists/Members/Events/POST.json"
                            },
                            {
                                "rel": "delete_permanent",
                                "href": "https://us14.api.mailchimp.com/3.0/lists/b090e8dbda/members/9f2740b21d9d7510d7ef0bab9544384e/actions/delete-permanent",
                                "method": "POST"
                            }
                        ]
                    },
                    {
                        "id": "c35e631196882cbf212c77115504c95f",
                        "contact_id": "b56685ca74e6f9a6c4fa5671f1907c2a",
                        "email_address": "Austin244@hotmail.com",
                        "unique_email_id": "74728da702",
                        "email_type": "html",
                        "status": "subscribed",
                        "merge_fields": {
                            "FNAME": "",
                            "LNAME": "",
                            "ADDRESS": "",
                            "PHONE": ""
                        },
                        "stats": {
                            "avg_open_rate": 0,
                            "avg_click_rate": 0
                        },
                        "ip_signup": "",
                        "timestamp_signup": "",
                        "ip_opt": "170.244.255.167",
                        "timestamp_opt": "2024-12-23T16:21:59+00:00",
                        "member_rating": 2,
                        "last_changed": "2024-12-23T16:21:59+00:00",
                        "language": "",
                        "vip": false,
                        "email_client": "",
                        "location": {
                            "latitude": 0,
                            "longitude": 0,
                            "gmtoff": 0,
                            "dstoff": 0,
                            "country_code": "",
                            "timezone": ""
                        },
                        "tags_count": 0,
                        "tags": [],
                        "list_id": "b090e8dbda",
                        "_links": [
                            {
                                "rel": "self",
                                "href": "https://us14.api.mailchimp.com/3.0/lists/b090e8dbda/members/c35e631196882cbf212c77115504c95f",
                                "method": "GET",
                                "targetSchema": "https://us14.api.mailchimp.com/schema/3.0/Definitions/Lists/Members/Response.json"
                            },
                            {
                                "rel": "parent",
                                "href": "https://us14.api.mailchimp.com/3.0/lists/b090e8dbda/members",
                                "method": "GET",
                                "targetSchema": "https://us14.api.mailchimp.com/schema/3.0/Definitions/Lists/Members/CollectionResponse.json",
                                "schema": "https://us14.api.mailchimp.com/schema/3.0/Paths/Lists/Members/Collection.json"
                            },
                            {
                                "rel": "update",
                                "href": "https://us14.api.mailchimp.com/3.0/lists/b090e8dbda/members/c35e631196882cbf212c77115504c95f",
                                "method": "PATCH",
                                "targetSchema": "https://us14.api.mailchimp.com/schema/3.0/Definitions/Lists/Members/Response.json",
                                "schema": "https://us14.api.mailchimp.com/schema/3.0/Definitions/Lists/Members/PATCH.json"
                            },
                            {
                                "rel": "upsert",
                                "href": "https://us14.api.mailchimp.com/3.0/lists/b090e8dbda/members/c35e631196882cbf212c77115504c95f",
                                "method": "PUT",
                                "targetSchema": "https://us14.api.mailchimp.com/schema/3.0/Definitions/Lists/Members/Response.json",
                                "schema": "https://us14.api.mailchimp.com/schema/3.0/Definitions/Lists/Members/PUT.json"
                            },
                            {
                                "rel": "delete",
                                "href": "https://us14.api.mailchimp.com/3.0/lists/b090e8dbda/members/c35e631196882cbf212c77115504c95f",
                                "method": "DELETE"
                            },
                            {
                                "rel": "activity",
                                "href": "https://us14.api.mailchimp.com/3.0/lists/b090e8dbda/members/c35e631196882cbf212c77115504c95f/activity",
                                "method": "GET",
                                "targetSchema": "https://us14.api.mailchimp.com/schema/3.0/Definitions/Lists/Members/Activity/Response.json"
                            },
                            {
                                "rel": "goals",
                                "href": "https://us14.api.mailchimp.com/3.0/lists/b090e8dbda/members/c35e631196882cbf212c77115504c95f/goals",
                                "method": "GET",
                                "targetSchema": "https://us14.api.mailchimp.com/schema/3.0/Definitions/Lists/Members/Goals/Response.json"
                            },
                            {
                                "rel": "notes",
                                "href": "https://us14.api.mailchimp.com/3.0/lists/b090e8dbda/members/c35e631196882cbf212c77115504c95f/notes",
                                "method": "GET",
                                "targetSchema": "https://us14.api.mailchimp.com/schema/3.0/Definitions/Lists/Members/Notes/CollectionResponse.json"
                            },
                            {
                                "rel": "events",
                                "href": "https://us14.api.mailchimp.com/3.0/lists/b090e8dbda/members/c35e631196882cbf212c77115504c95f/events",
                                "method": "POST",
                                "targetSchema": "https://us14.api.mailchimp.com/schema/3.0/Definitions/Lists/Members/Events/POST.json"
                            },
                            {
                                "rel": "delete_permanent",
                                "href": "https://us14.api.mailchimp.com/3.0/lists/b090e8dbda/members/c35e631196882cbf212c77115504c95f/actions/delete-permanent",
                                "method": "POST"
                            }
                        ]
                    },
                    {
                        "id": "d6ede34d04d30b4b52ddb6454644543a",
                        "contact_id": "a447a5eceb9b0ca9c45c268a462a0052",
                        "email_address": "Michael_Dach29@hotmail.com",
                        "unique_email_id": "8d3db97b42",
                        "email_type": "html",
                        "status": "subscribed",
                        "merge_fields": {
                            "FNAME": "",
                            "LNAME": "",
                            "ADDRESS": "",
                            "PHONE": ""
                        },
                        "stats": {
                            "avg_open_rate": 0,
                            "avg_click_rate": 0
                        },
                        "ip_signup": "",
                        "timestamp_signup": "",
                        "ip_opt": "170.244.255.167",
                        "timestamp_opt": "2024-12-23T16:21:59+00:00",
                        "member_rating": 2,
                        "last_changed": "2024-12-23T16:21:59+00:00",
                        "language": "",
                        "vip": false,
                        "email_client": "",
                        "location": {
                            "latitude": 0,
                            "longitude": 0,
                            "gmtoff": 0,
                            "dstoff": 0,
                            "country_code": "",
                            "timezone": ""
                        },
                        "tags_count": 0,
                        "tags": [],
                        "list_id": "b090e8dbda",
                        "_links": [
                            {
                                "rel": "self",
                                "href": "https://us14.api.mailchimp.com/3.0/lists/b090e8dbda/members/d6ede34d04d30b4b52ddb6454644543a",
                                "method": "GET",
                                "targetSchema": "https://us14.api.mailchimp.com/schema/3.0/Definitions/Lists/Members/Response.json"
                            },
                            {
                                "rel": "parent",
                                "href": "https://us14.api.mailchimp.com/3.0/lists/b090e8dbda/members",
                                "method": "GET",
                                "targetSchema": "https://us14.api.mailchimp.com/schema/3.0/Definitions/Lists/Members/CollectionResponse.json",
                                "schema": "https://us14.api.mailchimp.com/schema/3.0/Paths/Lists/Members/Collection.json"
                            },
                            {
                                "rel": "update",
                                "href": "https://us14.api.mailchimp.com/3.0/lists/b090e8dbda/members/d6ede34d04d30b4b52ddb6454644543a",
                                "method": "PATCH",
                                "targetSchema": "https://us14.api.mailchimp.com/schema/3.0/Definitions/Lists/Members/Response.json",
                                "schema": "https://us14.api.mailchimp.com/schema/3.0/Definitions/Lists/Members/PATCH.json"
                            },
                            {
                                "rel": "upsert",
                                "href": "https://us14.api.mailchimp.com/3.0/lists/b090e8dbda/members/d6ede34d04d30b4b52ddb6454644543a",
                                "method": "PUT",
                                "targetSchema": "https://us14.api.mailchimp.com/schema/3.0/Definitions/Lists/Members/Response.json",
                                "schema": "https://us14.api.mailchimp.com/schema/3.0/Definitions/Lists/Members/PUT.json"
                            },
                            {
                                "rel": "delete",
                                "href": "https://us14.api.mailchimp.com/3.0/lists/b090e8dbda/members/d6ede34d04d30b4b52ddb6454644543a",
                                "method": "DELETE"
                            },
                            {
                                "rel": "activity",
                                "href": "https://us14.api.mailchimp.com/3.0/lists/b090e8dbda/members/d6ede34d04d30b4b52ddb6454644543a/activity",
                                "method": "GET",
                                "targetSchema": "https://us14.api.mailchimp.com/schema/3.0/Definitions/Lists/Members/Activity/Response.json"
                            },
                            {
                                "rel": "goals",
                                "href": "https://us14.api.mailchimp.com/3.0/lists/b090e8dbda/members/d6ede34d04d30b4b52ddb6454644543a/goals",
                                "method": "GET",
                                "targetSchema": "https://us14.api.mailchimp.com/schema/3.0/Definitions/Lists/Members/Goals/Response.json"
                            },
                            {
                                "rel": "notes",
                                "href": "https://us14.api.mailchimp.com/3.0/lists/b090e8dbda/members/d6ede34d04d30b4b52ddb6454644543a/notes",
                                "method": "GET",
                                "targetSchema": "https://us14.api.mailchimp.com/schema/3.0/Definitions/Lists/Members/Notes/CollectionResponse.json"
                            },
                            {
                                "rel": "events",
                                "href": "https://us14.api.mailchimp.com/3.0/lists/b090e8dbda/members/d6ede34d04d30b4b52ddb6454644543a/events",
                                "method": "POST",
                                "targetSchema": "https://us14.api.mailchimp.com/schema/3.0/Definitions/Lists/Members/Events/POST.json"
                            },
                            {
                                "rel": "delete_permanent",
                                "href": "https://us14.api.mailchimp.com/3.0/lists/b090e8dbda/members/d6ede34d04d30b4b52ddb6454644543a/actions/delete-permanent",
                                "method": "POST"
                            }
                        ]
                    }
                ],
                "updated_members": [],
                "errors": [],
                "total_created": 24,
                "total_updated": 0,
                "error_count": 0,
                "_links": [
                    {
                        "rel": "self",
                        "href": "https://us14.api.mailchimp.com/3.0/lists/b090e8dbda",
                        "method": "GET",
                        "targetSchema": "https://us14.api.mailchimp.com/schema/3.0/Definitions/Lists/Response.json"
                    },
                    {
                        "rel": "parent",
                        "href": "https://us14.api.mailchimp.com/3.0/lists",
                        "method": "GET",
                        "targetSchema": "https://us14.api.mailchimp.com/schema/3.0/Definitions/Lists/CollectionResponse.json",
                        "schema": "https://us14.api.mailchimp.com/schema/3.0/Paths/Lists/Collection.json"
                    },
                    {
                        "rel": "update",
                        "href": "https://us14.api.mailchimp.com/3.0/lists/b090e8dbda",
                        "method": "PATCH",
                        "targetSchema": "https://us14.api.mailchimp.com/schema/3.0/Definitions/Lists/Response.json",
                        "schema": "https://us14.api.mailchimp.com/schema/3.0/Definitions/Lists/PATCH.json"
                    },
                    {
                        "rel": "batch-sub-unsub-members",
                        "href": "https://us14.api.mailchimp.com/3.0/lists/b090e8dbda",
                        "method": "POST",
                        "targetSchema": "https://us14.api.mailchimp.com/schema/3.0/Definitions/Lists/BatchPOST-Response.json",
                        "schema": "https://us14.api.mailchimp.com/schema/3.0/Definitions/Lists/BatchPOST.json"
                    },
                    {
                        "rel": "delete",
                        "href": "https://us14.api.mailchimp.com/3.0/lists/b090e8dbda",
                        "method": "DELETE"
                    },
                    {
                        "rel": "abuse-reports",
                        "href": "https://us14.api.mailchimp.com/3.0/lists/b090e8dbda/abuse-reports",
                        "method": "GET",
                        "targetSchema": "https://us14.api.mailchimp.com/schema/3.0/Definitions/Lists/Abuse/CollectionResponse.json",
                        "schema": "https://us14.api.mailchimp.com/schema/3.0/Paths/Lists/Abuse/Collection.json"
                    },
                    {
                        "rel": "activity",
                        "href": "https://us14.api.mailchimp.com/3.0/lists/b090e8dbda/activity",
                        "method": "GET",
                        "targetSchema": "https://us14.api.mailchimp.com/schema/3.0/Definitions/Lists/Activity/Response.json"
                    },
                    {
                        "rel": "clients",
                        "href": "https://us14.api.mailchimp.com/3.0/lists/b090e8dbda/clients",
                        "method": "GET",
                        "targetSchema": "https://us14.api.mailchimp.com/schema/3.0/Definitions/Lists/Clients/Response.json"
                    },
                    {
                        "rel": "growth-history",
                        "href": "https://us14.api.mailchimp.com/3.0/lists/b090e8dbda/growth-history",
                        "method": "GET",
                        "targetSchema": "https://us14.api.mailchimp.com/schema/3.0/Definitions/Lists/Growth/CollectionResponse.json",
                        "schema": "https://us14.api.mailchimp.com/schema/3.0/Paths/Lists/Growth/Collection.json"
                    },
                    {
                        "rel": "interest-categories",
                        "href": "https://us14.api.mailchimp.com/3.0/lists/b090e8dbda/interest-categories",
                        "method": "GET",
                        "targetSchema": "https://us14.api.mailchimp.com/schema/3.0/Definitions/Lists/InterestCategories/CollectionResponse.json",
                        "schema": "https://us14.api.mailchimp.com/schema/3.0/Paths/Lists/InterestCategories/Collection.json"
                    },
                    {
                        "rel": "members",
                        "href": "https://us14.api.mailchimp.com/3.0/lists/b090e8dbda/members",
                        "method": "GET",
                        "targetSchema": "https://us14.api.mailchimp.com/schema/3.0/Definitions/Lists/Members/CollectionResponse.json",
                        "schema": "https://us14.api.mailchimp.com/schema/3.0/Paths/Lists/Members/Collection.json"
                    },
                    {
                        "rel": "merge-fields",
                        "href": "https://us14.api.mailchimp.com/3.0/lists/b090e8dbda/merge-fields",
                        "method": "GET",
                        "targetSchema": "https://us14.api.mailchimp.com/schema/3.0/Definitions/Lists/MergeFields/CollectionResponse.json",
                        "schema": "https://us14.api.mailchimp.com/schema/3.0/Paths/Lists/MergeFields/Collection.json"
                    },
                    {
                        "rel": "segments",
                        "href": "https://us14.api.mailchimp.com/3.0/lists/b090e8dbda/segments",
                        "method": "GET",
                        "targetSchema": "https://us14.api.mailchimp.com/schema/3.0/Definitions/Lists/Segments/CollectionResponse.json",
                        "schema": "https://us14.api.mailchimp.com/schema/3.0/Paths/Lists/Segments/Collection.json"
                    },
                    {
                        "rel": "webhooks",
                        "href": "https://us14.api.mailchimp.com/3.0/lists/b090e8dbda/webhooks",
                        "method": "GET",
                        "targetSchema": "https://us14.api.mailchimp.com/schema/3.0/Definitions/Lists/Webhooks/CollectionResponse.json",
                        "schema": "https://us14.api.mailchimp.com/schema/3.0/Paths/Lists/Webhooks/Collection.json"
                    },
                    {
                        "rel": "signup-forms",
                        "href": "https://us14.api.mailchimp.com/3.0/lists/b090e8dbda/signup-forms",
                        "method": "GET",
                        "targetSchema": "https://us14.api.mailchimp.com/schema/3.0/Definitions/Lists/SignupForms/CollectionResponse.json",
                        "schema": "https://us14.api.mailchimp.com/schema/3.0/Paths/Lists/SignupForms/Collection.json"
                    },
                    {
                        "rel": "locations",
                        "href": "https://us14.api.mailchimp.com/3.0/lists/b090e8dbda/locations",
                        "method": "GET",
                        "targetSchema": "https://us14.api.mailchimp.com/schema/3.0/Definitions/Lists/Locations/CollectionResponse.json",
                        "schema": "https://us14.api.mailchimp.com/schema/3.0/Paths/Lists/Locations/Collection.json"
                    }
                ]
            }
            """;
    }

    #region Disposable Members

    public void Dispose()
    {
        _server.Stop();
        _server.Dispose();
    }
    #endregion
}
