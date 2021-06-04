using System;

namespace Cadastro_de_Series
{
    class Program
    {
        static SerieRepositorio repositorio = new SerieRepositorio();
        static void Main(string[] args)
        {
            string opcao = OpcaoUsuario();
            while(opcao != "X")
            {
                switch(opcao)
                {
                    case "1":
                        ListarSeries();
                        break;
                    case "2":
                        InserirSerie();
                        break;
                    case "3":
                        AtualizarSerie();
                        break;
                    case "4":
                        ExcluirSerie();
                        break;
                    case "5":
                        VisualizarSerie();
                        break;
                    default:
                        Console.WriteLine("Escolha uma opção válida");
                        break;
                }
                opcao = OpcaoUsuario();

            }
        }

        public static string OpcaoUsuario()
        {
            Console.WriteLine();
            Console.WriteLine("Cadastro de Séries");
            Console.WriteLine("Informe a opção Desejada");
            Console.WriteLine("1- Listar séries");
            Console.WriteLine("2- Inserir nova série");
            Console.WriteLine("3- Atualizar série");
            Console.WriteLine("4- Excluir série");
            Console.WriteLine("5- Visualizar série");
            Console.WriteLine("C- Limpar tela");
            Console.WriteLine("X- Sair");
            Console.WriteLine();
            string opcao = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcao;
        }
        public static void ListarSeries()
        {
            Console.WriteLine("Listar Series");
            var lista = repositorio.Lista();
            if (lista.Count == 0)
            {
                Console.WriteLine("Nenhuma série cadastrada");
                return;
            }
            foreach(var serie in lista)
            {
                var excluido = serie.retornaExcluido();
                if (!excluido)
                {
                    Console.WriteLine("#ID {0}: - {1}", serie.retornaId(), serie.retornaTitulo());
                }
            }
        }
        public static void InserirSerie()
        {
            Console.WriteLine("Inserir nova série");
            foreach(int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0} - {1}", i, Enum.GetName(typeof(Genero), i));
            }
            Console.WriteLine("Digite o Gênero entre as opções acima: ");
            int entradaGenero = int.Parse(Console.ReadLine());
            Console.WriteLine("Digite o Título da Série: ");
            string entradaTitulo = Console.ReadLine();
            Console.WriteLine("Digite o Ano de início da Série: ");
            int entradaAno = int.Parse(Console.ReadLine());
            Console.WriteLine("Digite a Descrição da Série: ");
            string entradaDescricao = Console.ReadLine();
            Serie serie = new Serie(id: repositorio.ProximoId(),
                                    genero: (Genero)entradaGenero,
                                    titulo: entradaTitulo,
                                    descricao: entradaDescricao,
                                    ano: entradaAno);
            repositorio.Insere(serie);
        }
        public static void AtualizarSerie()
        {
            Console.WriteLine("Atualizar Série");
            Console.WriteLine("Digite o ID da Série");
            int entradaId = int.Parse(Console.ReadLine());
            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0} - {1}", i, Enum.GetName(typeof(Genero), i));
            }
            Console.WriteLine("Digite o Gênero entre as opções acima: ");
            int entradaGenero = int.Parse(Console.ReadLine());
            Console.WriteLine("Digite o Título da Série: ");
            string entradaTitulo = Console.ReadLine();
            Console.WriteLine("Digite o Ano de início da Série: ");
            int entradaAno = int.Parse(Console.ReadLine());
            Console.WriteLine("Digite a Descrição da Série: ");
            string entradaDescricao = Console.ReadLine();
            Serie serie = new Serie(id: entradaId,
                                    genero: (Genero)entradaGenero,
                                    titulo: entradaTitulo,
                                    descricao: entradaDescricao,
                                    ano: entradaAno);
            repositorio.Atualiza(entradaId, serie);
        }
        public static void ExcluirSerie()
        {
            Console.WriteLine("Digite o ID da Série");
            int escolhaId = int.Parse(Console.ReadLine());
            repositorio.Exclui(escolhaId);
        }
        public static void VisualizarSerie()
        {
            Console.WriteLine("Digite o ID da Série");
            int escolhaId = int.Parse(Console.ReadLine());
            var serie = repositorio.RetornarPoId(escolhaId);
            Console.WriteLine(serie);
        }
    }
}
