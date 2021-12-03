﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc;
using ThreatMap.API.Areas.Public.Controllers;
using ThreatMap.Application.Public.Queries.Sensors.GetSensor;
using ThreatMap.Application.Public.Queries.Sensors.GetSensorDataList;
using ThreatMap.Application.Public.Queries.Sensors.GetSensorList;
using ThreatMap.Domain.Sensors.Enums;
using ThreatMap.Domain.ValueObjects;

namespace ThreatMap.API.Areas.Public.Controllers
{
    [Route("sensors")]
    public class SensorsController : BaseController
    {
        [HttpGet]
        public async Task<ActionResult> GetSensorList([FromQuery] GetSensorListQuery query)
        {
            //var response = await Mediator.Send(query);
            //return Ok(response);

            var loc1 = Location.Create(50.0306738, 21.9984216, null);
            var loc2 = Location.Create(50.0308557, 21.9981833, null);
            var loc3 = Location.Create(50.0310086, 21.9971134, null);
            var loc4 = Location.Create(50.0306118, 21.9984206, null);


            //MOCK
            var response = new List<GetSensorListQueryVm>();
            response.Add(new GetSensorListQueryVm { Category = SensorCategoryE.AirCondition, Description = "Sensor przy rzece", Location = loc1, Name = "Sensor 1000" });
            response.Add(new GetSensorListQueryVm { Category = SensorCategoryE.Water, Description = "Sensor przy rzece", Location = loc2, Name = "Sensor 2000" });
            response.Add(new GetSensorListQueryVm { Category = SensorCategoryE.Other, Description = "Sensor przy rzece", Location = loc3, Name = "Sensor 3000" });
            response.Add(new GetSensorListQueryVm { Category = SensorCategoryE.AirCondition, Description = "Sensor przy rzece", Location = loc4, Name = "Sensor 4000" });

            return Ok(response);
        }

        [HttpGet("{sensorId}/data")]
        public async Task<ActionResult> GetSensorDataList([FromQuery] GetSensorDataListQuery query, long sensorId)
        {
            //var response = Mediator.Send(query);
            //return Ok(response);

            //MOCK
            var response = new List<GetSensorDataListQueryVm>();
            response.Add(new GetSensorDataListQueryVm { Date = Convert.ToDateTime("2022-09-02 06:00:00"), Humidity = "25%", PM10 = "50%", PM25 = "50%", Sensor = null, Sensorid = 1, Temperature = "19" });
            response.Add(new GetSensorDataListQueryVm { Date = Convert.ToDateTime("2021-09-02 06:00:00"), Humidity = "25%", PM10 = "50%", PM25 = "50%", Sensor = null, Sensorid = 1, Temperature = "19" });
            response.Add(new GetSensorDataListQueryVm { Date = Convert.ToDateTime("2020-09-02 06:00:00"), Humidity = "25%", PM10 = "50%", PM25 = "50%", Sensor = null, Sensorid = 1, Temperature = "19" });
            response.Add(new GetSensorDataListQueryVm { Date = Convert.ToDateTime("2019-09-02 06:00:00"), Humidity = "25%", PM10 = "50%", PM25 = "50%", Sensor = null, Sensorid = 1, Temperature = "19" });

            return Ok(response);
        }

        [HttpGet("{sensorId}/data")]
        public async Task<ActionResult> GetSensor([FromQuery] GetSensorQuery query, long sensorId)
        {
            //var response = Mediator.Send(query);
            //return Ok(response);

            //MOCK
            var loc1 = Location.Create(50.0306738, 21.9984216, null);
            var response = new GetSensorQueryVm() { Category = SensorCategoryE.AirCondition, Description = "Sensor przy rzece", Location = loc1, Name = "Sensor 1000" };
            return Ok(response);
        }
    }
}
