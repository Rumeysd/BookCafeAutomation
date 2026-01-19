using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace BookCafeAutomation.Books;

public interface IBookAppService :
    ICrudAppService< // Standart CRUD operasyonlarını (Get, List, Create, Update, Delete) otomatik tanımlar
        BookDto, // Listelerken ne dönecek?
        Guid, // ID tipi nedir?
        Volo.Abp.Application.Dtos.PagedAndSortedResultRequestDto, // Listeleme isteği (Sayfalama/Sıralama)
        CreateUpdateBookDto> // Oluştururken/Güncellerken ne isteyecek?
{
    Task<BookDto> GetByQrCodeAsync(string qrCode);
}