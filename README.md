# dotnet-training-project
This project is for .net core training


### AutoMapper
**Steps:**

1 Install packages
`AutoMapper` & `AutoMapper.Extensions.Microsoft.DependencyInjection`

2 Register in `program.cs` 
````
builder.Services.AddAutoMapper(typeof(Program).Assembly);
````

3 Create Model `SuperHero` and Dto `SuperHeroDto`

3 Create AutoMapper Profile
````
public class AutoMapperProfile: Profile
{
    public AutoMapperProfile()
    {
        CreateMap<SuperHero, SuperHeroDto>();
        CreateMap<SuperHeroDto, SuperHero>();
    }
}
````

4 Inject the mapper into controller and use it
````
 var data = _mapper.Map<SuperHero>(superHeroDto);
 var dto = _mapper.Map<SuperHeroDto>(superHero);
````

