using Application.Features.GitHubProfiles.Models;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Requests;
using Core.Persistence.Paging;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.GitHubProfiles.Queries
{
    public class GetListGitHubProfileQuery : IRequest<GitHubProfileListModel>
    {
        public PageRequest PageRequest { get; set; }

        public class GetListGitHubProfileQueryHandler : IRequestHandler<GetListGitHubProfileQuery, GitHubProfileListModel>
        {
            private readonly IMapper _mapper;
            private readonly IGitHubProfileRepository _gitHubProfileRepository;
            public GetListGitHubProfileQueryHandler(IMapper mapper, IGitHubProfileRepository gitHubProfileRepository)
                => (_mapper, _gitHubProfileRepository) = (mapper, gitHubProfileRepository);

            public async Task<GitHubProfileListModel> Handle(GetListGitHubProfileQuery request, CancellationToken cancellationToken)
            {
                IPaginate<GitHubProfile> profiles = await _gitHubProfileRepository
                    .GetListAsync(index: request.PageRequest.Page, size: request.PageRequest.PageSize);

                GitHubProfileListModel githubProfileListModel = _mapper.Map<GitHubProfileListModel>(profiles);

                return githubProfileListModel;
            }
        }
    }
}
