using LearningJsonNet;
using Newtonsoft.Json;
using Xunit;

namespace LearningJsonNetTest
{
    public class MissingMemberHandlingFacts
    {
        [Fact]
        public void should_ignore_missing_members_given_setting_ignore()
        {
            const string jsonString = @"
                {
                  name: ""Tom"",
                }
            ";

            var student = JsonConvert.DeserializeObject<Student>(jsonString, new JsonSerializerSettings
            {
                MissingMemberHandling = MissingMemberHandling.Ignore
            });
            Assert.NotNull(student);
            Assert.Equal("Tom", student.Name);
            Assert.Equal(0, student.Id);
        }

        [Fact]
        public void should_throw_error_given_setting_error()
        {
            const string jsonString = @"{name:""Tom"", grade: 2}";
            
            Assert.Throws<JsonSerializationException>(() =>
            {
                JsonConvert.DeserializeObject<Student>(jsonString, new JsonSerializerSettings
                {
                    MissingMemberHandling = MissingMemberHandling.Error
                });
            });
        }
    }
}