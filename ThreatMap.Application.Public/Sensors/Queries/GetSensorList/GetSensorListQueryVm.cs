﻿using ThreatMap.Application.Public.Institutions.Queries.GetInstitutionsList;
using ThreatMap.Application.Shared.Common.DTO;
using ThreatMap.Domain.Sensors.Enums;
using ThreatMap.Domain.ValueObjects;

namespace ThreatMap.Application.Public.Sensors.Queries.GetSensorList
{
    public class GetSensorListQueryVm
    {
        public List<SensorDto> Items { get; set; } = new List<SensorDto>();
        
        public class SensorDto
        {
            public long Id { get; set; }
            public string ExternalId { get; set; }
            public string Name { get; set; }
            public SensorCategoryE Category { get; set; }
            public string Description { get; set; }
            public LocationDto Location { get; set; }
            public AddressDto Address { get; set; }
        }
    }
}