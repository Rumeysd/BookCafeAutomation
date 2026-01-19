using System;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace BookCafeAutomation.Authors;

public class AuthorAppService : CrudAppService<
    Author,
    AuthorDto,
    Guid,
    PagedAndSortedResultRequestDto,
    CreateUpdateAuthorDto>, IAuthorAppService
{
    public AuthorAppService(IRepository<Author, Guid> repository)
        : base(repository)
    {
    }
}