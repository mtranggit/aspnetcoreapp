using Api.Database;
using GraphQL;

namespace Api.Graphql 
{
  [GraphQLMetadata("Mutation")]
  public class Mutation 
  {
    [GraphQLMetadata("addAuthor")]
    public Author Add(string name)
    {
      using(var db = new StoreContext()) {
        var author = new Author() { Name = name};
        db.Authors.Add(author);
        db.SaveChanges();
        return author;
      }
    }

    [GraphQLMetadata("addBook")]
    public Book Add(string name, int authorId, string genre, bool published)
    {
      using(var db = new StoreContext()) {
        var book = new Book() {
          Name = name,
          Published = published,
          Genre = genre,
          AuthorId = authorId
        };
        db.Books.Add(book);
        db.SaveChanges();
        return book;
      }
    }
  }
}