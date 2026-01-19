using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace BookCafeAutomation.Books;

public class BookAppService : CrudAppService<
        Book,
        BookDto,
        Guid,
        PagedAndSortedResultRequestDto,
        CreateUpdateBookDto>,
    IBookAppService
{
    public BookAppService(IRepository<Book, Guid> repository)
        : base(repository)
    {
    }

    // 1. TEK KİTAP GETİRİRKEN (GET)
    public override async Task<BookDto> GetAsync(Guid id)
    {
        var queryable = await Repository.GetQueryableAsync();

        var query = queryable
            .Include(x => x.Author)
            .Include(x => x.Category)
            .Include(x => x.Images)
            .Where(x => x.Id == id);

        var book = await AsyncExecuter.FirstOrDefaultAsync(query);

        if (book == null)
        {
            throw new Volo.Abp.Domain.Entities.EntityNotFoundException(typeof(Book), id);
        }

        return ObjectMapper.Map<Book, BookDto>(book);
    }

    // 2. LİSTE GETİRİRKEN (GET LIST)
    public override async Task<PagedResultDto<BookDto>> GetListAsync(PagedAndSortedResultRequestDto input)
    {
        var queryable = await Repository.GetQueryableAsync();

        queryable = queryable
            .Include(x => x.Author)
            .Include(x => x.Category);

        queryable = queryable
            .OrderBy(input.Sorting ?? nameof(Book.Name))
            .Skip(input.SkipCount)
            .Take(input.MaxResultCount);

        var books = await AsyncExecuter.ToListAsync(queryable);
        var totalCount = await Repository.GetCountAsync();

        return new PagedResultDto<BookDto>(
            totalCount,
            ObjectMapper.Map<List<Book>, List<BookDto>>(books)
        );
    } 
    public async Task<BookDto> GetByQrCodeAsync(string qrCode)
    {
        var queryable = await Repository.GetQueryableAsync();

        var book = await queryable
            .Include(x => x.Author)
            .Include(x => x.Category)
            .Include(x => x.Images)
            .FirstOrDefaultAsync(x => x.QrCode == qrCode);

        if (book == null)
        {
            throw new Volo.Abp.UserFriendlyException($"'{qrCode}' barkodlu kitap bulunamadı!");
        }

        return ObjectMapper.Map<Book, BookDto>(book);
    }
}