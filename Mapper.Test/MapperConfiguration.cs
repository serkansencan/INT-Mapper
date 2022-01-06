using Mapper;

namespace Mapper.Test
{
    public class MapperConfiguration : AutoMapperProfile
    {
        public MapperConfiguration()
        {
            Test_To_TestViewModel();
        }

        private void Test_To_TestViewModel()
        {
            CreateMap<Test, TestViewModel>();

        }
    }
}
