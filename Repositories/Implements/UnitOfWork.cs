﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Models.Contexts;
using Models.Entities;
using Repositories.Interfaces;

namespace Repositories.Implements
{
    public class UnitOfWork : IUnitOfWork
    {
        /// <summary>
        ///     The database context
        /// </summary>
        private readonly WebContext _context;

        /// <summary>
        ///     The repositories
        /// </summary>
        private readonly Dictionary<Type, object> _repositories = new Dictionary<Type, object>();

        /// <summary>
        ///     User repository
        /// </summary>
        private readonly IUserRepository _userRepository;

        /// <summary>
        ///     Initializes a new instance of the <see>
        ///         <cref>UnitOfWork{TContext}</cref>
        ///     </see>
        ///     class.
        /// </summary>
        /// <param name="context">The database context.</param>
        /// <param name="userRepository">The user repository.</param>
        public UnitOfWork(WebContext context, IUserRepository userRepository)
        {
            _context = context;
            _userRepository = userRepository;
        }

        /// <summary>
        ///     Gets generic repository
        /// </summary>
        /// <typeparam name="TEntity">The generic type</typeparam>
        /// <returns>The generic repository</returns>
        public IGenericRepository<TEntity> Repository<TEntity>()
            where TEntity : BaseEntity
        {
            if (_repositories.Keys.Contains(typeof(TEntity)))
                return _repositories[typeof(TEntity)] as IGenericRepository<TEntity>;

            IGenericRepository<TEntity> repo = new GenericRepository<TEntity>(_context);
            _repositories.Add(typeof(TEntity), repo);
            return repo;
        }

        public IUserRepository UserRepository()
        {
            return _userRepository;
        }

        /// <summary>
        ///     Commits the synchronous.
        /// </summary>
        /// <returns>
        ///     The commit result
        /// </returns>
        public int Commit()
        {
            return _context.SaveChanges();
        }

        /// <summary>
        ///     Commits the asynchronous.
        /// </summary>
        /// <returns>
        ///     The commit result
        /// </returns>
        public async Task<int> CommitAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}