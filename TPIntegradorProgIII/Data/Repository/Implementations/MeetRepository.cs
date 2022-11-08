using TPIntegradorProgIII.Data.Repository.Interfaces;
using TPIntegradorProgIII.Entities;
using TPIntegradorProgIII.Models;
using AutoMapper;

namespace TPIntegradorProgIII.Repository.Implementations
{
    public class MeetRepository : IMeetRepository
    {
        private readonly TPContext _context;
        private readonly IMapper _mapper;

        public MeetRepository(TPContext context, IMapper autoMapper)
        {
            _context = context;
            _mapper = autoMapper;
        }
        public List<Contact> GetAll()x
        {
            return _context.Contacts.ToList();
        }

        public void Create(CreateAndUpdateContact dto)
        {
            _context.Contacts.Add(_mapper.Map<Contact>(dto));
        }

        public void Update(CreateAndUpdateContact dto)
        {
            _context.Contacts.Update(_mapper.Map<Contact>(dto));
        }
        public void Delete(int id)
        {
            _context.Contacts.Remove(_context.Contacts.Single(c => c.Id == id));
        }
    }
}
