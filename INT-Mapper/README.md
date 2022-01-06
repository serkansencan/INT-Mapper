
INT-Mapper
============

[![CI](https://github.com/automapper/automapper/workflows/CI/badge.svg)](https://github.com/serkansencan/INT-Mapper)
[![NuGet](http://img.shields.io/nuget/vpre/AutoMapper.svg?label=NuGet)](https://www.nuget.org/packages/INT-Mapper/)


### What is Mapper?

INT-Mapper allows us to get rid of code that maps one object to another. With Int-Mapper we can perform mapping simply and quickly.


### How do I get started?

First, configure Int-Mapper to know what types you want to map, in the startup of your application:

```csharp
using Mapper.Extensions;

public void ConfigureServices(IServiceCollection services)
{
	services.AddAutoMapper();
}
```
Then add 'MapperConfiguration'
```csharp
using Mapper;

public class MapperConfiguration : AutoMapperProfile
{
	public MapperConfiguration()
	{
		Foo_To_FooDto();
		Bar_To_BarDto();
	}
	
	private void Foo_To_FooDto()
	{
		CreateMap<Foo, FooDto>();
	}
	private void Bar_To_BarDto()
	{
		CreateMap<Foo, FooDto>()
			.ForMember(dest => dest.FooDtoId, opt => opt.MapFrom(src => src.Id));
	}
}
```

Then in your application code, execute the mappings:

```csharp
var fooDto = foo.To<FooDto>();
var barDto = bar.To<BarDto>();
```


### Where can I get it?

First, [install NuGet](http://docs.nuget.org/docs/start-here/installing-nuget). Then, install [AutoMapper](https://www.nuget.org/packages/INT-Mapper/) from the package manager console:

```
PM> Install-Package INT-Mapper
```


### License, etc.

This project has adopted the code of conduct defined by the Contributor Covenant to clarify expected behavior in our community.
For more information see the [.NET Foundation Code of Conduct](https://dotnetfoundation.org/code-of-conduct).

AutoMapper is Copyright &copy; 2022 [Serkan Şencan](https://github.com/serkansencan) and other contributors under the [MIT license](LICENSE.txt).

