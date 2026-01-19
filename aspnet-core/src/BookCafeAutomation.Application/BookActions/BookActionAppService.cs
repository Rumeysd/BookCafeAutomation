using System;
using System.Linq; 
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore; 
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace BookCafeAutomation.BookActions;

public class BookActionAppService : CrudAppService<
    BookAction,
    BookActionDto,
    Guid,
    PagedAndSortedResultRequestDto,
    CreateUpdateBookActionDto>, IBookActionAppService
{
    public BookActionAppService(IRepository<BookAction, Guid> repository)
        : base(repository)
    {
    }

 
    protected override async Task<IQueryable<BookAction>> CreateFilteredQueryAsync(PagedAndSortedResultRequestDto input)
    {
        var query = await base.CreateFilteredQueryAsync(input);

        return query
            .Include(x => x.Book)     
            .Include(x => x.Customer);
    }
}