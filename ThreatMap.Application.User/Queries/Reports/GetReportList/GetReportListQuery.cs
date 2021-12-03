﻿using MediatR;
using ThreatMap.Shared.Models;

namespace ThreatMap.Application.User.Queries.Reports.GetReportList;

// Tutaj przekazujemy parametry,
public class GetReportListQuery : PaginationRequest,IRequest<PaginatedList<GetReportListQueryVm>>
{
    public string SearchPhrase { get; set; }
}