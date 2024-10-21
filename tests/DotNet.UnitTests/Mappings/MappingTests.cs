﻿using AutoMapper;
using DotNet.ApplicationCore.Mappings;

namespace DotNet.UnitTests.Mappings
{
    public class MappingTests
    {
        private readonly IConfigurationProvider _configuration;
        private readonly IMapper _mapper;

        public MappingTests()
        {
            _configuration = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<GeneralProfile>();
            });

            _mapper = _configuration.CreateMapper();
        }

        //[Fact]
        //public void ShouldBeValidConfiguration()
        //{
        //    _configuration.AssertConfigurationIsValid();
        //}

        //[Theory]
        //[InlineData(typeof(CreateProductRequest), typeof(Product))]
        //[InlineData(typeof(Product), typeof(ProductResponse))]
        //public void Map_SourceToDestination_ExistConfiguration(Type origin, Type destination)
        //{
        //    var instance = FormatterServices.GetUninitializedObject(origin);

        //    _mapper.Map(instance, origin, destination);
        //}
    }
}
