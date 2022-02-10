using Interprit_Exam.DTO.UserList;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using TechTalk.SpecFlow;

namespace Interprit_Exam.Features
{
    [Binding]
    public class UsersTestSteps:Base
    {
        public string URI = "https://reqres.in/";
        public string response;
        public string url;
        public object payLoad;
        [Given(@"(.*) exists")]
        public void GivenSingleUserExists(string val)
        {
            if (val.ToUpper() == "SINGLE USER")
            {
                url = URI + "api/users/2";
            }
            if (val.ToUpper() == "RESOURCE")
            {
                url = URI + "api/unknown";
            }
            if (val.ToUpper() == "RESOURCE PAGE")
            {
                url = URI + "api/unknown/2";
            }
        }

        [Given(@"(.*) does not exist")]
        public void GivenUserDoesNotExist(string val)
        {
            if (val.ToUpper() == "USER")
            {
                url = URI + "api/users/23";
            }
            if (val.ToUpper() == "RESOURCE")
            {
                url = URI + "api/unknown/23";
            }
            
        }

        [Given(@"user has a payload")]
        public void GivenUserHasAPayload()
        {
            payLoad = new CreateUser() { Name = "morpheus", Job = "leader" };
        }
        [Given(@"user has a payload for delete")]
        public void GivenUserHasAPayloadForDelete()
        {
            payLoad = new UpdateUser() { Name = "morpheus", Job = "zion resident" };
        }


        [When(@"user sends (.*) request")]
        public void WhenUserSendsRequest(string reqMethod)
        {
            switch(reqMethod.ToUpper())
            {
                case "POST":
                case "PUT":
                case "PATCH":
                    response = getResponse(reqMethod, URI + "api/users", payLoad);
                    break;

                case "GET":
                case "DELETE":
                    response = getResponse(reqMethod, url);
                    break;
                default:
                    throw new InvalidOperationException("Method not found.");
            }
        }

        [Then(@"response should be (.*)")]
        public void ThenResponseShouldBe(string expected)
        {
            Assert.AreEqual(expected, response);
        }
        

    }
}
