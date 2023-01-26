using NerdStoreDDD.Core.DomainObjects;

namespace NerdStoreDDD.Catalogo.Domain;

public class Categoria : Entity
{
    protected Categoria() { }
    public Categoria(string nome, int codigo)
    {
        Nome = nome;
        Codigo = codigo;

        Validar();
    }

    public string Nome { get; private set; }
    public int Codigo { get; private set; }

    //EF Relation
    public ICollection<Produto> Produtos { get; set; }

    public void Validar()
    {
        Validacoes.ValidarSeVazio(Nome, "O campo Nome do produto não pode estar vazio");
        Validacoes.ValidarSeIgual(Codigo, 0, "O campo Descricao do produto não pode estar vazio");
    }
}
