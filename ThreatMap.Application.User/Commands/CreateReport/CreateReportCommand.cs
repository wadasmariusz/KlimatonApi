﻿using MediatR;
using ThreatMap.Domain.Reports.Enums;

namespace ThreatMap.Application.User.Commands.CreateReport;

public class CreateReportCommand : IRequest<long>
{
    public string Title { get; set; }
    public string Description { get; set; }
    public ReportType Type { get; set; }
}