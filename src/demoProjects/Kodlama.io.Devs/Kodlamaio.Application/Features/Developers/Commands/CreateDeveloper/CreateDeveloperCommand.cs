using Application.Services.Repositories;
using AutoMapper;
using Core.Security.Hashing;
using Core.Security.JWT;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using Application.Features.Developers.Dtos;
using Core.Security.Entities;

namespace Application.Features.Developers.Commands.CreateDeveloper
{
    public class CreateDeveloperCommand : IRequest<TokenDto>
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }


        public class CreateDeveloperCommandHandler : IRequestHandler<CreateDeveloperCommand, TokenDto>
        {
            private readonly IDeveloperRepository _developerRepository;
            private readonly IMapper _mapper;
            private readonly ITokenHelper _tokenHelper;

            public CreateDeveloperCommandHandler(IMapper mapper, ITokenHelper tokenHelper, IDeveloperRepository developerRepository)
         => (_mapper, _tokenHelper, _developerRepository) = (mapper, tokenHelper, developerRepository);
            public async Task<TokenDto> Handle(CreateDeveloperCommand request, CancellationToken cancellationToken)
            {
                byte[] passwordHash, passwordSalt;
                HashingHelper.CreatePasswordHash(request.Password, out passwordHash, out passwordSalt);

                Developer developer = _mapper.Map<Developer>(request);
                developer.PasswordHash = passwordHash;
                developer.PasswordSalt = passwordSalt;

                var createdDdeveloper = await _developerRepository.AddAsync(developer);
                
                 var token = _tokenHelper.CreateToken(developer, new List<OperationClaim>());
                return new() { Token = token.Token, Expiration = token.Expiration };


            }
        }
    }
}
