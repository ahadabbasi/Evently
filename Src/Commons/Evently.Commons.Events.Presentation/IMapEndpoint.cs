using System;
using Microsoft.AspNetCore.Routing;

namespace Evently.Commons.Presentation;


public interface IMapEndpoint
{
    static void MapEndpoint(IEndpointRouteBuilder app) => throw new NotImplementedException();
}
