using System.Runtime.CompilerServices;

internal class Program
{
    public static List<Produto> ListaProdutos = new List<Produto>();
    public static List<Venda> ListaDeProdutosVendidos = new List<Venda>();
    public static Caixa Caixa = new Caixa();
    private static void Main(string[] args)
    {
        MenuInicial();
    }

    private static void MenuInicial()
    {
        int opcao;

        Console.WriteLine("==================================================");
        Console.WriteLine("Bem-Vindo ao Sistema de Gerenciamento de Produtos!");
        Console.WriteLine("==================================================");

        do
        {
            Console.WriteLine("O que deseja fazer? \n 1- Cadastro de Produtos \n 2- Exibir Lista \n 3- Modificação de Produto \n 4- Relatório de Produtos \n 5- Caixa \n 0- Sair");
            opcao = int.Parse(Console.ReadLine());

            switch ((MenuEnumeradores)opcao)
            {
                case MenuEnumeradores.CadastroDeProdutos:
                    CadastrarProdutos();
                    break;

                case MenuEnumeradores.ExibirLista:
                    ExibirLista();
                    break;

                case MenuEnumeradores.ModificacaoDeProdutos:
                    Modificacoes();
                    break;

                case MenuEnumeradores.RelatorioDeProdutos:
                    Relatorio();
                    break;

                case MenuEnumeradores.Caixa:
                    GerenciamentoCaixa();
                    break;

                case MenuEnumeradores.Sair:
                    Console.WriteLine("Obrigado e volte sempre!");
                    break;

                default:
                    Console.WriteLine("Opção inválida!");
                    break;
            }
        } while (opcao != 0);
    }

    private static void CadastrarProdutos()
    {
        Console.WriteLine("Qual produto deseja cadastrar?");
        string nomeProduto = Console.ReadLine();

        if (ListaProdutos.Any(x => x.Nome == nomeProduto))
        {
            Console.WriteLine("Produto já cadastrado.");
        }
        else
        {
            Console.WriteLine("Produto cadastrado com sucesso!");

            Console.WriteLine("Qual o código do produto?");
            int codigoProduto = int.Parse(Console.ReadLine());

            Console.WriteLine("Qual o preço do produto?");
            decimal precoProduto = decimal.Parse(Console.ReadLine());

            Console.WriteLine("Qual a quantidade do produto?");
            int quantidadeProduto = int.Parse(Console.ReadLine());

            var produtoCompleto = new Produto(nomeProduto, codigoProduto, precoProduto, quantidadeProduto);

            ListaProdutos.Add(produtoCompleto);
        }
    }
    private static void ExibirLista()
    {
        if (ListaProdutos.Count() == 0)
        {
            Console.WriteLine("A lista está vazia.");
        }
        else
        {
            Console.WriteLine("Lista produtos:");
            foreach (var item in ListaProdutos)
            {
                Console.WriteLine($"Produto: {item.Nome} | Código: {item.Codigo} | Quantidade: {item.Quantidade} | Preço: {item.Preco}");
            }
        }
    }
    private static void Modificacoes()
    {
        Console.WriteLine("O que você deseja modificar? \n 1- Produto \n 2- Código \n 3- Preço \n 4- Quantidade \n 5- Remover Produto \n 6- Menu Inicial");
        int opcao = int.Parse(Console.ReadLine());

        switch ((ModicacoesEnumeradores)opcao)
        {
            case ModicacoesEnumeradores.Produtos:
                ModificarProduto();
                break;

            case ModicacoesEnumeradores.Codigos:
                ModificarCodigo();
                break;

            case ModicacoesEnumeradores.Precos:
                ModificarPreco();
                break;

            case ModicacoesEnumeradores.Quantidades:
                ModificarQuantidade();
                break;

            case ModicacoesEnumeradores.Remover:
                RemoverProduto();
                break;

            case ModicacoesEnumeradores.MenuInicial:
                MenuInicial();
                break;

            default:
                Console.WriteLine("Opção inválida.");
                break;
        }
    }
    private static void ModificarProduto()
    {
        Console.WriteLine("Qual produto deseja modificar?");
        string produtoModificar = Console.ReadLine();

        var modificandoProduto = ListaProdutos.FirstOrDefault(x => x.Nome == produtoModificar);

        if (modificandoProduto != null)
        {
            Console.WriteLine("Qual nome novo do produto?");
            string produto = Console.ReadLine();

            var novoProduto = ListaProdutos.FirstOrDefault(x => x.Nome == produto);

            if (novoProduto == null)
            {
                modificandoProduto.Nome = produto;
                Console.WriteLine("Produto modificado com sucesso!");
            }
            else
            {
                Console.WriteLine("Produto já existe no sistema.");
            }
        }
        else
        {
            Console.WriteLine("Produto não encontrado.");

        }
    }
    private static void ModificarCodigo()
    {
        Console.WriteLine("De qual produto deseja modificar o código?");
        string produto = Console.ReadLine();

        var modificandoProduto = ListaProdutos.FirstOrDefault(x => x.Nome == produto);

        if (modificandoProduto != null)
        {
            Console.WriteLine($"Código atual: {modificandoProduto.Codigo}");

            Console.WriteLine("Qual código novo do produto?");
            int codigo = int.Parse(Console.ReadLine());

            var novoCodigo = ListaProdutos.FirstOrDefault(x => x.Codigo == codigo);

            if (novoCodigo == null)
            {
                modificandoProduto.Codigo = codigo;
                Console.WriteLine("Código modificado com sucesso!");
            }
            else
            {
                Console.WriteLine("Código igual ao anterior.");

            }
        }
        else
        {
            Console.WriteLine("Código não encontrado.");
        }
    }
    private static void ModificarQuantidade()
    {
        Console.WriteLine("De qual produto deseja modificar a quantidade?");
        string produtoModificar = Console.ReadLine();

        var modificandoProduto = ListaProdutos.FirstOrDefault(x => x.Nome == produtoModificar);

        if (modificandoProduto != null)
        {
            Console.WriteLine($"Quantidade atual: {modificandoProduto.Quantidade}");

            Console.WriteLine("Qual a nova quantidade?");
            int quantidade = int.Parse(Console.ReadLine());

            var novaQuantidade = ListaProdutos.FirstOrDefault(x => x.Quantidade == quantidade);

            if (novaQuantidade == null)
            {
                modificandoProduto.Quantidade = quantidade;
                Console.WriteLine("Quantidade modificada com sucesso!");
            }
            else
            {
                Console.WriteLine("Quantidade igual a anterior.");
            }
        }
        else
        {
            Console.WriteLine("Produtos não encontrado.");

        }
    }
    private static void ModificarPreco()
    {
        Console.WriteLine("De qual produto deseja modificar o preço?");
        string produtoModificar = Console.ReadLine();

        var modificandoProduto = ListaProdutos.FirstOrDefault(x => x.Nome == produtoModificar);

        if (modificandoProduto != null)
        {
            Console.WriteLine($"Preço atual: {modificandoProduto.Preco}");

            Console.WriteLine("Qual preço novo do produto?");
            decimal preco = decimal.Parse(Console.ReadLine());

            var novoPreco = ListaProdutos.FirstOrDefault(x => x.Preco == preco);

            if (novoPreco == null)
            {
                modificandoProduto.Preco = preco;
                Console.WriteLine("Preço modificado com sucesso!");
            }
            else
            {
                Console.WriteLine("Preço igual ao anterior.");
            }
        }
        else
        {
            Console.WriteLine("Produto não encontrado.");

        }
    }
    private static void RemoverProduto()
    {
        Console.WriteLine("Qual produto deseja remover?");
        string produtoRemover = Console.ReadLine();

        var removendoProduto = ListaProdutos.FirstOrDefault(x => x.Nome == produtoRemover);

        if (removendoProduto != null)
        {
            ListaProdutos.Remove(removendoProduto);

            Console.WriteLine("Produto removido com sucesso!");
        }
        else
        {
            Console.WriteLine("Produto não encontrado.");

        }
    }

    private static void GerenciamentoCaixa()
    {
        Console.WriteLine("O que você deseja fazer? \n 1- Venda de Produto \n 2- Estorno de Produto \n 3- Sangria \n 4- Total no Caixa \n 5- Menu Inicial");
        int opcao = int.Parse(Console.ReadLine());

        switch ((CaixaEnumeradores)opcao)
        {
            case CaixaEnumeradores.Venda:
                VendaProduto();
                break;

            case CaixaEnumeradores.Estorno:
                EstornoProduto();
                break;

            case CaixaEnumeradores.Sangria:
                SangriaCaixa();
                break;

            case CaixaEnumeradores.Total:
                ValorCaixa();
                break;

            case CaixaEnumeradores.MenuInicial:
                break;
        }
    }
    private static void VendaProduto()
    {
        Console.WriteLine("Qual produto deseja vender?");
        string produtoVender = Console.ReadLine();

        var vendendoProduto = ListaProdutos.FirstOrDefault(x => x.Nome == produtoVender);

        if (vendendoProduto != null)
        {
            Console.WriteLine("Qual a quantidade deseja vender?");
            int quantidade = int.Parse(Console.ReadLine());

            var produtoValido = ListaProdutos.FirstOrDefault(x => x.Quantidade >= quantidade);

            if (produtoValido != null)
            {
                Venda produtoVenda = new Venda(vendendoProduto, quantidade);
                
                produtoValido.DescontarQuantidade(quantidade);

                ListaDeProdutosVendidos.Add(produtoVenda);

                decimal valorPagar = quantidade * vendendoProduto.Preco;

                Console.WriteLine($"Data e Hora: {produtoVenda.DataHora}");

                Caixa.AdicionarDinheiro(valorPagar);

                Console.WriteLine($"Valor a ser pago: R$ {valorPagar}");
                Console.WriteLine($"Saldo caixa: R$ {Caixa.SaldoCaixa()}");
            }
            else
            {
                Console.WriteLine($"Estoque baixo. Quantidade disponível: {vendendoProduto.Quantidade}");
            }
        }
        else
        {
            Console.WriteLine("Produto não encontrado.");
        }
    }
    private static void EstornoProduto()
    {
        Console.WriteLine("Qual produto deseja estornar?");
        string produtoEstornar = Console.ReadLine();

        var estornandoProduto = ListaDeProdutosVendidos.FirstOrDefault(x => x.ProdutoVendido.Nome == produtoEstornar);

        if (estornandoProduto != null)
        {
            Console.WriteLine("Qual a quantidade deseja estornar?");
            int quantidade = int.Parse(Console.ReadLine());

            if (quantidade <= estornandoProduto.QuantidadeVendida)
            {
                decimal valorEstornar = quantidade * estornandoProduto.ProdutoVendido.Preco;

                estornandoProduto.ProdutoVendido.EstornoQuantidade(quantidade);

                Caixa.RemoverDinheiro(valorEstornar);

                Console.WriteLine($"Valor a ser devolvido ao cliente: R$ {valorEstornar}");
                Console.WriteLine($"Saldo caixa: R$ {Caixa.SaldoCaixa()}");
            }
            else
            {
                Console.WriteLine($"Informe a quantidade correta.");
            }
        }
        else
        {
            Console.WriteLine("Produto não encontrado.");
        }
    }
    private static void SangriaCaixa()
    {
        Console.WriteLine("Qual valor de retirada?");
        decimal valorRetirada = decimal.Parse(Console.ReadLine());

        if (valorRetirada > 0)
        {
            if (Caixa.SaldoCaixa() >= valorRetirada)
            {
                Caixa.RemoverDinheiro(valorRetirada);

                Console.WriteLine($"Valor retirado do caixa: R$ {valorRetirada}");
                Console.WriteLine($"Saldo caixa: R$ {Caixa.ValorCaixa}");
            }
            else
            {
                Console.WriteLine("Valor superior ao total do caixa.");
            }
        }
        else
        {
            Console.WriteLine("Informe um valor válido.");
        }
    }
    private static void ValorCaixa()
    {
        Console.WriteLine($"Saldo em caixa: R$ {Caixa.SaldoCaixa()}");
    }
    private static void Relatorio()
    {
        Console.WriteLine("Qual produto deseja saber o relatório?");
        string nomeProduto = Console.ReadLine();

        var mostrarProduto = ListaProdutos.FirstOrDefault(x => x.Nome == nomeProduto);

        if (mostrarProduto == null)
        {
            Console.WriteLine("Produto não encontrado.");
        }
        else
        {
            Console.WriteLine($"Produto: {mostrarProduto.Nome} | Código: {mostrarProduto.Codigo} | Quantidade: {mostrarProduto.Quantidade} | Preço: {mostrarProduto.Preco}");
        }
    }
}
