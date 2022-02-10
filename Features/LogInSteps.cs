using Interprit_Exam.DTO.Login;
using Interprit_Exam.DTO.Register;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace Interprit_Exam.Features
{
    [Binding]
    public class LogInSteps:Base
    {
        public Register postData;
        public Login LoginResponse;
        public string response;
        public HttpResponseMessage responseMessage;
        public string url = "https://reqres.in/api";

        [Given(@"(.*) username and password")]
        public void GivenUsernameAndPassword(string value)
        {
            if(value.ToLower()=="valid")
            {
                postData = new Register { email = "eve.holt@reqres.in", password = "cityslicka" };
            }
            if (value.ToLower() == "invalid")
            {
                postData = new Register { email = "peter@klaven", password = null };
            }
            if (value.ToLower() == "unregistered")
            {
                postData = new Register { email = "eve.holt@reqres.in", password = "cityslicka" };
            }
            
        }
                
        [When(@"user sends POST request for (.*)")]
        public async Task<HttpResponseMessage> WhenUserSendsPOSTRequestForLogIn(string value)
        {
            if(value.ToLower()=="log in" || value.ToLower()=="login")
            { 
                responseMessage = await getPostResponse(url + "/login", postData); 
            }
            else if(value.ToLower() == "register")
            { 
                responseMessage = await getPostResponse(url + "/register", postData); 
            }

            return responseMessage;
        }
        
        [Then(@"log in response should be (.*)")]
        public void ThenLogInResponseShouldBeOK(string expResult)
        {
            validatePostResponse(responseMessage, expResult);
        }

        [Then(@"Token will be generated")]
        public void ThenTokenWillbeGenerated()
        {
            Login LoginResponse = JsonConvert.DeserializeObject<Login>(responseMessage.Content.ReadAsStringAsync().Result);
            Assert.IsNotNull(LoginResponse.Token);
        }

        [Then(@"response message should be (.*)")]
        public void ThenResponseMessageShouldBeMissingPassword(string message)
        {
            RegisterError errorregisterResponse = JsonConvert.DeserializeObject<RegisterError>(responseMessage.Content.ReadAsStringAsync().Result);
            Assert.AreEqual(errorregisterResponse.error, message);
        }

    }
}
