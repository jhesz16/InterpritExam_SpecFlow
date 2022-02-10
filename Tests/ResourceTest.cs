using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Interprit_Exam
{
    [TestClass]
    public class ResourceTest:Base
    {

        [TestMethod]
        //Verify GET Resouce request
        public void TC1()
        {
            Assert.AreEqual(getResponse("get", "https://reqres.in/api/unknown"), "OK");
        }

        [TestMethod]
        //Verify GET Resouce response if Resouce found by page
        public void TC2()
        {
           Assert.AreEqual(getResponse("get", "https://reqres.in/api/unknown/2"),"OK");
        }

        [TestMethod]
        //Verify GET Resouce response if Resouce not found
        public void TC3()
        {
           Assert.AreEqual(getResponse("get", "https://reqres.in/api/unknown/23"), "NotFound");
        }
        
    }
}
