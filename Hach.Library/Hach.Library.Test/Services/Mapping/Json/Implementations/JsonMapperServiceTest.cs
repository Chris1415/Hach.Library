using Hach.Library.Services.Mapping.Json.Implementations;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Hach.Library.Test.Services.Mapping.Json.Implementations
{
    [TestClass]
    public class JsonMapperServiceTest
    {
        /// <summary>
        /// Testing Helper Model
        /// </summary>
        public class TestModel
        {
            public string Key { get; set; }
        }

        [TestMethod]
        public void MapStringToClassSuccess()
        {
            JsonMapperService jsonMapperService = new JsonMapperService();
            const string inputString = "{\"Key\":\"TestKey\"}";

            TestModel model = jsonMapperService.MapStringToClass<TestModel>(inputString);

            Assert.IsTrue(model.Key.Equals("TestKey"));
        }
    }
}
