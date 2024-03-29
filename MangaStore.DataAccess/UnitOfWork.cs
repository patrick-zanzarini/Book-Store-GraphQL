﻿using System.Runtime.InteropServices;
using MangaStore.DataAccess.Repositories;
using MangaStore.DataAccess.Repositories.Contracts;
using MangaStore.Database.DbContexts;

namespace MangaStore.DataAccess
{
    public sealed class UnitOfWork : IUnitOfWork
    {
        private readonly MangaStoreDbContext Context;

        public UnitOfWork(MangaStoreDbContext context)
        {
            Context = context;
            Books = new BookRepository(context);
            Genres = new GenreRepository(context);
        }


        public void Commit()
        {
            Context.SaveChanges();
        }

        public IBookRepository Books { get; private set; }
        public IGenreRepository Genres { get; private set; }

        public void Dispose()
        {
            Context?.Dispose();
        }
    }
}
