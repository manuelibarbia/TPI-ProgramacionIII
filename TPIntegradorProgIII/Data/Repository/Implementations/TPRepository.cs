﻿using TPIntegradorProgIII.Data.Repository.Interfaces;
using TPIntegradorProgIII.DBContexts;

namespace TPIntegradorProgIII.Data.Repository
{
    public class TPRepository : ITPRepository
    {
        internal readonly TPContext _context;

        public TPRepository(TPContext context)
        {
            this._context = context;
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }
    }
}
