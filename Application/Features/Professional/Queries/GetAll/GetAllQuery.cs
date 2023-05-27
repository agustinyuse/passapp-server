using Application.Abstractions.Messaging;
using Application.Features.Professional.Queries.GetById;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Professional.Queries.GetAll;

public sealed record GetAllQuery(int Page, int PageSize) : IQuery<List<ProfessionalResponse>>;
