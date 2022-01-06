using System.Linq;
using Xunit;
using Mapper.Extensions;

namespace Mapper.Test
{
    public class UnitTest
    {
        [Fact]
        public void TestGetAllUsers()
        {

            var asd = new FakeContext<Test>
            {
                new Test
                {
                    Name = "Serkan"
                }
            };

            var item2 = asd.To<TestViewModel>();
           

        }

    }

    public class Test
    {
        public string Name { get; set; }
    }
    public class TestViewModel
    {
        public string Name { get; set; }
    }
}
