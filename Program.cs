using System;

namespace DIO.Series;

class Program
{

    static SerieRepository repository = new SerieRepository();

    private static void Main(string[] args)
    {

        string opcaoUsuario = ObterOpcaoUsuario();

        while (opcaoUsuario.ToUpper() != "X")
        {
            switch (opcaoUsuario)
            {
                case "1":
                    ListarSeries();
                    break;
                case "2":
                    InserirSeries();
                    break;
                case "3":
                    AtualizarSeries();
                    break;
                case "4":
                    ExcluirSerie();
                    break;
                case "5":
                    VisualizarSerie();
                    break;
                case "C":
                    Console.Clear();
                    break;

                    default:
                    Console.WriteLine("Descreva um numero Valido");
                 throw new ArgumentOutOfRangeException();

            }

            opcaoUsuario = ObterOpcaoUsuario();
        }

        Console.WriteLine("Obrigado por utilizar nossos serviços.");
	    Console.ReadLine();
    }

    private static void ListarSeries(){
        
        Console.WriteLine("Listar Séries");
        
        var lista = repository.Lista();

        if(lista.Count == 0){
            Console.WriteLine("Nenhuma Serie encontrada.");
            return;
        }

        foreach(var serie in lista){

            var excluido = serie.retornaExcluido();

            Console.WriteLine("#ID {0}: - {1} {2}", serie.retornaId(), serie.retornaTitulo(), (excluido ? "*Excluído*" : ""));
			
        }
    }

    private static void InserirSeries()
    {
       Console.WriteLine("Inserir nova Serie");

       foreach (var i in Enum.GetValues(typeof(Genero)))
       {
        Console.WriteLine("{0}-{1}",
                          i,
                          Enum.GetName(typeof(Genero), i));			
       }

       Console.WriteLine("Digite o Gênero entre as opções acima: ");
       int entradaGenero = int.Parse(Console.ReadLine());

       Console.WriteLine("Digite o titulo da Série: ");
       string entradaTitulo = Console.ReadLine();

       Console.WriteLine("Digite o ano de inicio da Série: ");
       int entradaAno = int.Parse(Console.ReadLine());

       Console.WriteLine("Digite a descrição da Série: ");
       string entradaDescricao = Console.ReadLine();

       Series novaSerie = new Series(id: repository.ProximoId(), genero: (Genero)entradaGenero, titulo: entradaTitulo, ano: entradaAno, descricao: entradaDescricao);

       repository.Insere(novaSerie);
    }

     private static void AtualizarSeries()
    {
        Console.WriteLine("Digite o id da Série: ");
        int indiceSerie = int.Parse(Console.ReadLine()!);

        foreach (int i in Enum.GetValues(typeof(Genero)))
        {
            Console.WriteLine($"#ID {0}: - {1}", i, Enum.GetName(typeof(Genero), i));
        }

        Console.WriteLine("Digite o Gênero entre as opções: ");
       int entradaGenero = int.Parse(Console.ReadLine());

       Console.WriteLine("Digite o titulo da Série: ");
       string entradaTitulo = Console.ReadLine();

       Console.WriteLine("Digite o ano de inicio da Série: ");
       int entradaAno = int.Parse(Console.ReadLine());

       Console.WriteLine("Digite a descrição da Série: ");
       string entradaDescricao = Console.ReadLine();

       Series atualizaSerie = new Series(id: indiceSerie, genero: (Genero)entradaGenero, titulo: entradaTitulo, ano: entradaAno, descricao: entradaDescricao);

       repository.Atualiza(indiceSerie, atualizaSerie);

    }

    private static void ExcluirSerie()
    {
        Console.Write("Digite o 'ID' da Série: ");
        int indiceSerie = int.Parse(Console.ReadLine()!);

        repository.Excluir(indiceSerie);
    }

    private static void VisualizarSerie()
    {
        Console.WriteLine("Digite o 'ID' da Série: ");
        int indiceSerie = int.Parse(Console.ReadLine());

        var serie = repository.RetornaPorId(indiceSerie);

        Console.WriteLine(serie);
    }


    static string ObterOpcaoUsuario()
    {

        Console.WriteLine();
        Console.WriteLine("DIO Series a seu dispor!!!");
        Console.WriteLine("Informe a opção desejada: ");

        Console.WriteLine("1, Listar Series");
        Console.WriteLine("2, Inserir nova Serie");
        Console.WriteLine("3, Atualizar Series");
        Console.WriteLine("4, Excluir Serie");
        Console.WriteLine("5, Visualizar Serie");
        Console.WriteLine("C, Limpar Tela");
        Console.WriteLine("X, Sair");
        Console.WriteLine();

        string opcaoUsuario = Console.ReadLine()!.ToUpper();
        Console.WriteLine();
        return opcaoUsuario;
    }
}

/////////////////////////////////////////////////////////////

// using System;

// namespace DIO.Series
// {
//     class Program
//     {
//         static SerieRepository repositorio = new SerieRepository();
//         static void Main(string[] args)
//         {
//             string opcaoUsuario = ObterOpcaoUsuario();

// 			while (opcaoUsuario.ToUpper() != "X")
// 			{
// 				switch (opcaoUsuario)
// 				{
// 					case "1":
// 						ListarSeries();
// 						break;
// 					case "2":
// 						InserirSerie();
// 						break;
// 					case "3":
// 						AtualizarSerie();
// 						break;
// 					case "4":
// 						ExcluirSerie();
// 						break;
// 					case "5":
// 						VisualizarSerie();
// 						break;
// 					case "C":
// 						Console.Clear();
// 						break;

// 					default:
// 						throw new ArgumentOutOfRangeException();
// 				}

// 				opcaoUsuario = ObterOpcaoUsuario();
// 			}

// 			Console.WriteLine("Obrigado por utilizar nossos serviços.");
// 			Console.ReadLine();
//         }

//         private static void ExcluirSerie()
// 		{
// 			Console.Write("Digite o id da série: ");
// 			int indiceSerie = int.Parse(Console.ReadLine());

// 			repositorio.Excluir(indiceSerie);
// 		}

//         private static void VisualizarSerie()
// 		{
// 			Console.Write("Digite o id da série: ");
// 			int indiceSerie = int.Parse(Console.ReadLine());

// 			var serie = repositorio.RetornaPorId(indiceSerie);

// 			Console.WriteLine(serie);
// 		}

//         private static void AtualizarSerie()
// 		{
// 			Console.Write("Digite o id da série: ");
// 			int indiceSerie = int.Parse(Console.ReadLine());

// 			// https://docs.microsoft.com/pt-br/dotnet/api/system.enum.getvalues?view=netcore-3.1
// 			// https://docs.microsoft.com/pt-br/dotnet/api/system.enum.getname?view=netcore-3.1
// 			foreach (int i in Enum.GetValues(typeof(Genero)))
// 			{
// 				Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
// 			}
// 			Console.Write("Digite o gênero entre as opções acima: ");
// 			int entradaGenero = int.Parse(Console.ReadLine());

// 			Console.Write("Digite o Título da Série: ");
// 			string entradaTitulo = Console.ReadLine();

// 			Console.Write("Digite o Ano de Início da Série: ");
// 			int entradaAno = int.Parse(Console.ReadLine());

// 			Console.Write("Digite a Descrição da Série: ");
// 			string entradaDescricao = Console.ReadLine();

// 			Series atualizaSerie = new Series(id: indiceSerie,
// 										genero: (Genero)entradaGenero,
// 										titulo: entradaTitulo,
// 										ano: entradaAno,
// 										descricao: entradaDescricao);

// 			repositorio.Atualiza(indiceSerie, atualizaSerie);
// 		}
//         private static void ListarSeries()
// 		{
// 			Console.WriteLine("Listar séries");

// 			var lista = repositorio.Lista();

// 			if (lista.Count == 0)
// 			{
// 				Console.WriteLine("Nenhuma série cadastrada.");
// 				return;
// 			}

// 			foreach (var serie in lista)
// 			{
//                 var excluido = serie.retornaExcluido();
                
// 				Console.WriteLine("#ID {0}: - {1} {2}", serie.retornaId(), serie.retornaTitulo(), (excluido ? "*Excluído*" : ""));
// 			}
// 		}

//         private static void InserirSerie()
// 		{
// 			Console.WriteLine("Inserir nova série");

// 			// https://docs.microsoft.com/pt-br/dotnet/api/system.enum.getvalues?view=netcore-3.1
// 			// https://docs.microsoft.com/pt-br/dotnet/api/system.enum.getname?view=netcore-3.1
// 			foreach (int i in Enum.GetValues(typeof(Genero)))
// 			{
// 				Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
// 			}
// 			Console.Write("Digite o gênero entre as opções acima: ");
// 			int entradaGenero = int.Parse(Console.ReadLine());

// 			Console.Write("Digite o Título da Série: ");
// 			string entradaTitulo = Console.ReadLine();

// 			Console.Write("Digite o Ano de Início da Série: ");
// 			int entradaAno = int.Parse(Console.ReadLine());

// 			Console.Write("Digite a Descrição da Série: ");
// 			string entradaDescricao = Console.ReadLine();

// 			Series novaSerie = new Series(id: repositorio.ProximoId(),
// 										genero: (Genero)entradaGenero,
// 										titulo: entradaTitulo,
// 										ano: entradaAno,
// 										descricao: entradaDescricao);

// 			repositorio.Insere(novaSerie);
// 		}

//         private static string ObterOpcaoUsuario()
// 		{
// 			Console.WriteLine();
// 			Console.WriteLine("DIO Séries a seu dispor!!!");
// 			Console.WriteLine("Informe a opção desejada:");

// 			Console.WriteLine("1- Listar séries");
// 			Console.WriteLine("2- Inserir nova série");
// 			Console.WriteLine("3- Atualizar série");
// 			Console.WriteLine("4- Excluir série");
// 			Console.WriteLine("5- Visualizar série");
// 			Console.WriteLine("C- Limpar Tela");
// 			Console.WriteLine("X- Sair");
// 			Console.WriteLine();

// 			string opcaoUsuario = Console.ReadLine().ToUpper();
// 			Console.WriteLine();
// 			return opcaoUsuario;
// 		}
//     }
// }
