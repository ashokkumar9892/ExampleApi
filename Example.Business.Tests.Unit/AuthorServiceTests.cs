using Example.Business.Services;
using Example.Business.Tests.Unit.Stubs;
using Example.Repository.Repositories;
using System;
using Xunit;

namespace Example.Business.Tests.Unit
{
    public class AuthorServiceTests
    {
        private IAuthorsRepository AuthorsRepository { get; set; }

        public AuthorServiceTests()
        {
            this.AuthorsRepository = new AuthorsRepositoryStub();
        }

        [Fact]
        public void AuthorExists_should_return_true_if_author_exists()
        {
            var authorSrvc = new AuthorsService(this.AuthorsRepository);
            var id = new Guid();

            Assert.True(authorSrvc.AuthorExists(id));
        }

        [Fact]
        public void GetAuthorById_should_return_an_author()
        {
            var authorSrvc = new AuthorsService(this.AuthorsRepository);
            var id = new Guid();

            Assert.NotNull(authorSrvc.GetAuthorById(id));
        }
    }
}