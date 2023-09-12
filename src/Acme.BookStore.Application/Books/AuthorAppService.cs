using Acme.BookStore.Authors;
using Acme.BookStore.Permissions;
using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.SettingManagement;
using Volo.Abp.Settings;

namespace Acme.BookStore.Books
{
   //[Authorize(BookStorePermissions.Authors.Default)]
    public class AuthorAppService : BookStoreAppService, IAuthorAppService, ITransientDependency
    {
        private readonly IAuthorRepository _authorRepository;
        private readonly AuthorManager _authorManager;
        private readonly IRepository<Book, Guid> _bookRepository;
        private readonly ISettingManager _settingManager;
        public AuthorAppService(
            IAuthorRepository authorRepository,
            AuthorManager authorManager,
              IRepository<Book, Guid> bookRepository, ISettingManager settingManager)
        {
            _authorRepository = authorRepository;
            _authorManager = authorManager;
            _bookRepository = bookRepository;
            _settingManager = settingManager; 
        }
        public void UpdateMaxBooksPerAuthor(int newLimit)
        {
            _settingManager.SetAsync("App.Author.MaxBooks", newLimit.ToString(),null,null);
          
        }
        public async Task<int> GetMaxBooksPerAuthor()
        {
          var   settingMaxBooksValue=
                await _settingManager.GetOrNullAsync("App.Author.MaxBooks", null, null);
            if (int.TryParse(settingMaxBooksValue, out int maxBooksPerAuthor))
            {
                return maxBooksPerAuthor;
            }
            return -1;
        }
        public async Task<AuthorDto> GetAsync(Guid id)
        {
            var author = await _authorRepository.GetAsync(id);
            return ObjectMapper.Map<Author, AuthorDto>(author);
        }
        public async Task<PagedResultDto<AuthorDto>> GetListAsync(GetAuthorListDto input)
        {
            if (input.Sorting.IsNullOrWhiteSpace())
            {
                input.Sorting = nameof(Author.Name);
            }

            var authors = await _authorRepository.GetListAsync(
                input.SkipCount,
                input.MaxResultCount,
                input.Sorting,
                input.Filter
            );

            var totalCount = input.Filter == null
                ? await _authorRepository.CountAsync()
                : await _authorRepository.CountAsync(
                    author => author.Name.Contains(input.Filter));

            return new PagedResultDto<AuthorDto>(
                totalCount,
                ObjectMapper.Map<List<Author>, List<AuthorDto>>(authors)
            );
        }
  //      [Authorize(BookStorePermissions.Authors.Create)]
        public async Task<AuthorDto> CreateAsync(CreateAuthorDto input)
        {
            var author = await _authorManager.CreateAsync(
                input.Name,
                input.BirthDate,
                input.ShortBio
            );

            await _authorRepository.InsertAsync(author);

            return ObjectMapper.Map<Author, AuthorDto>(author);
        }
        [Authorize(BookStorePermissions.Authors.Edit)]
        public async Task UpdateAsync(Guid id, UpdateAuthorDto input)
        {
            var author = await _authorRepository.GetAsync(id);

            if (author.Name != input.Name)
            {
                await _authorManager.ChangeNameAsync(author, input.Name);
            }

            author.BirthDate = input.BirthDate;
            author.ShortBio = input.ShortBio;

            await _authorRepository.UpdateAsync(author);
        }
        [Authorize(BookStorePermissions.Authors.Delete)]
        public async Task DeleteAsync(Guid id)
        {
            await _authorRepository.DeleteAsync(id);
       }
//        [Authorize(BookStorePermissions.Authors.Create)]
        public async Task<AuthorWithManyBooksDto> CreateAuthorWithBooksAsync(AuthorWithManyBooksDto input)
        {
        
            Author author = await _authorManager.CreateAsync(
                input.Name,
                input.BirthDate,
                input.ShortBio,
               input.Books.Select(bookInput => new Book
                {
                    Name = bookInput.Name,
                    Type = bookInput.Type,
                    PublishDate = bookInput.PublishDate,
                    Price = bookInput.Price
                }).ToList()
            );
           
            await _authorRepository.InsertAsync(author);
            return ObjectMapper.Map<Author, AuthorWithManyBooksDto>(author);
         

        }
    }
}
