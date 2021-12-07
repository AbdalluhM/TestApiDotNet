using CarRentalApi.Data.ViewModel;
using CarRentalApi.Data.Models;

namespace CarRentalApi.Data.Services
{
    public class BookService
    {
        private AppDbContext _context;
        public BookService(AppDbContext context) { 
             _context = context;
        }
        public void AddBook(BookVM bookVM)
        {
            var _Book = new Book()
            {
                Title = bookVM.Title,
                CoverUrl=bookVM.CoverUrl,
                IsRead = bookVM.IsRead,
                DateAdded=DateTime.Now,
                Description = bookVM.Description,
                Author=bookVM.Author,
                Genre = bookVM.Genre,
                Rate = bookVM.Rate,   
            };
            _context.books.Add(_Book);
            _context.SaveChanges();
        }

        public List<Book> GetAll()=>_context.books.ToList();
        public Book GeById(int id)=>_context.books.FirstOrDefault(b=>b.Id==id);

        public Book update(int id , BookVM bookVM)
        {

            var book = _context.books.FirstOrDefault(b => b.Id == id);
            if (book!=null)
            {
                book.Title = bookVM.Title;
                book.CoverUrl = bookVM.CoverUrl;
                book.IsRead = bookVM.IsRead;
                book.DateAdded = DateTime.Now;
                book.Description = bookVM.Description;
                book.Author = bookVM.Author;
                book.Genre = bookVM.Genre;
                book.Rate = bookVM.Rate;
           
            _context.SaveChanges();
            
            }
            return book;
        }
        public void delete(int id)
        {
            var book = _context.books.FirstOrDefault(b=>b.Id==id);
            if (book != null)
            {
                _context.books.Remove(book);
                _context.SaveChanges();
            }
        }
    }
}
