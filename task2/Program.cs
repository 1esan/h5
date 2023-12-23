// Создаем объекты классов Book, BookGenre и BookGenrePubl с разными параметрами
Book book = new Book("Пардус", "Евгений Гаглоев", 469.30);
BookGenre bookGenre = new BookGenre("Мастер и Маргарита", "Михаил Булгаков", 500, "Классика");
BookGenrePubl bookGenrePubl = new BookGenrePubl("НИ СЫ", "Джен Синсеро", 350.50, "Личностный рост", "ЭКСМО");

// Вызываем метод Print() для каждого объекта, чтобы вывести информацию о книге
book.Print();
Console.WriteLine();
bookGenre.Print();
Console.WriteLine();
bookGenrePubl.Print();
Console.WriteLine();

// Изменяем стоимость книги bookGenrePubl с помощью свойства set
bookGenrePubl.Price = 300;

// Вызываем метод Print() для объекта bookGenrePubl, чтобы увидеть изменение
bookGenrePubl.Print();
Console.WriteLine();
class Book
{
    private string title; 
    private string author; 
    private double price; 

    public Book(string title, string author, double price)
    {
        this.title = title;
        this.author = author;
        this.price = price;
    }

    public string Title
    {
        get { return title; }
        set { title = value; }
    }

    public string Author
    {
        get { return author; }
        set { author = value; }
    }

    public double Price
    {
        get { return price; }
        set { price = value; }
    }

    public virtual void Print()
    {
        Console.WriteLine("Название книги: {0}", title);
        Console.WriteLine("Автор книги: {0}", author);
        Console.WriteLine("Стоимость книги: {0}", price);
    }
}

class BookGenre : Book
{
    private string genre; 

    public BookGenre(string title, string author, double price, string genre) : base(title, author, price)
    {
        this.genre = genre;
    }

    public string Genre
    {
        get { return genre; }
        set { genre = value; }
    }

    public override void Print()
    {
        base.Print();
        Console.WriteLine("Жанр книги: {0}", genre);
    }
}

sealed class BookGenrePubl : BookGenre
{
    private string publisher; 

    public BookGenrePubl(string title, string author, double price, string genre, string publisher) : base(title, author, price, genre)
    {
        this.publisher = publisher;
    }

    public string Publisher
    {
        get { return publisher; }
        set { publisher = value; }
    }

    public override void Print()
    {
        base.Print();
        Console.WriteLine("Издатель книги: {0}", publisher);
    }
}