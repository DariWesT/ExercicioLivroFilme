var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

Livro Gaga = new Livro("Gaga", 400);
Filme titanic = new Filme("O vento levou...", 238);

app.MapGet("/", () => "O livro " + Gaga.Titulo + " têm " + Gaga.QntPaginas + " páginas.");
app.MapGet("/titulo", () => Gaga.Titulo);
app.MapGet("/ler{paginas}", (int paginas) => Gaga.setPaginasLidas(paginas));
app.MapGet("/progresso", () => Gaga.verificaprogresso() + "%");
app.MapGet("/filme", () => titanic.exibirDuracaoEmHoras());

app.Run();


class Livro
{
    //Atributos
    private string titulo;
    private int qntPaginas;
    private int paginasLidas = 0;

    //Construtor
    public Livro() { }

    //Graças ao polimorfimos pode se criar dois métodos com o mesmo nome, embora tenham que ter parametros de entrada diferente
    public Livro(string titulo, int qntPaginas)
    {
        this.Titulo = titulo;
        this.QntPaginas = qntPaginas;
    }

    //Métodos
    public double verificaprogresso()
    {
        return ((double)this.paginasLidas * 100.0) / (double)this.qntPaginas;
    }

    //Getters e Setters
    public string Titulo
    {
        get => titulo; set => titulo = value;
    }
    public int QntPaginas
    {
        get => qntPaginas; set => qntPaginas = value;
    }
    public int getPaginasLidas()
    {
        return this.paginasLidas;
    }
    public void setPaginasLidas(int value)
    {
        if (QntPaginas < this.paginasLidas + value)
        {
            Console.WriteLine("Excedeu as páginas do livro. ");
        }
        else
        {
            this.paginasLidas += value;
        }
    }
}


class Filme
{
    //Atributos
    private string titulo;
    private int duracaoEmMinutos;

    //Contrutores
    public Filme() { }
    public Filme(string titulo, int duracao)
    {
        this.titulo = titulo;
        this.duracaoEmMinutos = duracao;
    }
    public string exibirDuracaoEmHoras()
    {

        int minutos = this.duracaoEmMinutos;
        int horas = 0;
        while (minutos >= 60)
        {
            horas++;
            minutos -= 60;
        }
        return "O filme " + titulo + " tem uma duração de " + horas + " horas " + minutos + " minutos. Do inicio ao fim. ";

    }
    //Getters e Setters
    public string Titulo { get => titulo; set => titulo = value; }
    public int DuracaoEmMinutos { get => duracaoEmMinutos; set => duracaoEmMinutos = value; }
}