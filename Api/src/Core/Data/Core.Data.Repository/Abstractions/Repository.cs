﻿using Core.Data.EF.Context;

namespace Core.Data.Repository
{
    public abstract class Repository
    {
        public Repository(DatabaseContext context)
        {
            _context = context;
        }

        protected DatabaseContext _context { get; }
    }
}
