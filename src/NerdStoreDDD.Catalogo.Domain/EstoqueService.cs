using NerdStoreDDD.Catalogo.Domain.Events;
using NerdStoreDDD.Core.Bus;

namespace NerdStoreDDD.Catalogo.Domain;

public class EstoqueService : IEstoqueService
{
    private readonly IProdutoRepository _produtoRepository;
    private readonly IMediatrHandler _bus;

    public EstoqueService(IProdutoRepository produtoRepository,
                          IMediatrHandler bus)
    {
        _produtoRepository = produtoRepository;
        _bus = bus;
    }

    public async Task<bool> DebitarEstoque(Guid produtoId, int quantidade)
    {
        var produto = await _produtoRepository.ObterPorId(produtoId);

        if (produto == null)
            return false;

        if (!produto.PossuiEstoque(quantidade))
            return false;

        produto.DebitarEstoque(quantidade);

        //TODO: àra,etrozar a quantidade de estpqiei baixo
        if (produto.QuantidadeEstoque < 10)
        {
            //avisar, mandar email...
            await _bus.PublicarEvento(new ProdutoAbaixoEstoqueEvent(produto.Id, produto.QuantidadeEstoque));
        }

        _produtoRepository.Atualizar(produto);
        return await _produtoRepository.UnitOfWork.CommitAsync();
    }


    public async Task<bool> ReporEstoque(Guid produtoId, int quantidade)
    {
        var produto = await _produtoRepository.ObterPorId(produtoId);

        if (produto == null)
            return false;

        produto.ReporEstoque(quantidade);

        _produtoRepository.Atualizar(produto);
        return await _produtoRepository.UnitOfWork.CommitAsync();
    }
    public void Dispose()
    {
        _produtoRepository.Dispose();
    }
}