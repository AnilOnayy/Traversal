﻿using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repository;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.EntityFramework
{
    public class EfDestinationDal : GenericRepository<Destination>, IDestinationDal
    {
        private readonly Context _context;

        public EfDestinationDal(Context context)
        {
            _context = context;
        }

        public Destination GetDestinaitonWithGuide(int id)
        {
            return _context.Destinatons.Include(x => x.Guide).Where(x => x.DestinationId==id).FirstOrDefault();
        }

        public List<Destination> GetLast4DestinationsWithGuides()
        {
            return _context.
                Destinatons
                .Take(4)
                .Include(x => x.Guide)
                .OrderByDescending(x => x.DestinationId)
                .ToList();
        }
    }
}
