using EntityService.Protos;
using EntityService.SubServices;
using Grpc.Core;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace EntityService.Services
{
    public class CommonsService : Commons.CommonsBase
    {
        private readonly ILogger<CommonsService> _logger;
        public CommonsService(ILogger<CommonsService> logger)
        {
            _logger = logger;
        }

        public override Task<Profile> ProfileCreate(ProfileCreateInfo request, ServerCallContext context)
        {
            return Task.FromResult(Mapper.ToAssign<ProfileCreateInfo, Profile>(request, Activator.CreateInstance<Profile>()));
        }
    }
}
