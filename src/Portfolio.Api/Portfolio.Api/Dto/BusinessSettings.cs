using System.Collections.Generic;

namespace Portfolio.Api.Dto;

public class BusinessSettings
{
    public IEnumerable<FeatureFlag> FeatureFlags { get; set; }
    public IEnumerable<string> AppConfig { get; set; }
}