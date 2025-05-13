using AutoMapper;
using Presentation.Controllers;

namespace Presentation.Tests.Mapping;

public class AutoMapperMappingTests
{
    /// <summary>
    ///     Verifies that, according to all mapping atlas, there are corresponding field between any model A and B.
    /// </summary>
    [Fact]
    public void AutoMapper_AtlasMapping_FieldsMatch()
    {
        var config = new MapperConfiguration(cfg => { cfg.AddMaps(typeof(UserManagementApiController).Assembly); });
        config.AssertConfigurationIsValid();
    }
}