using MediatR;

namespace NerdStoreDDD.Catalogo.Domain.Events;

public class ProdutoEventHandler : INotificationHandler<ProdutoAbaixoEstoqueEvent>
{
    private readonly IProdutoRepository _produtoRepository;

    public ProdutoEventHandler(IProdutoRepository produtoRepository)
    {
        _produtoRepository = produtoRepository;
    }

    public async Task Handle(ProdutoAbaixoEstoqueEvent message, CancellationToken cancellationToken)
    {
        var produto = await _produtoRepository.ObterPorId(message.AggregateId);

        //Enviar um email para aquisicao de mais produtos
    }
}
