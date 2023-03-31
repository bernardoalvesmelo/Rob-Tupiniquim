namespace Tupiniquim
{
    internal class Program
    {
        const int ROBOS = 2;
        static int[] roboX = new int[ROBOS];
        static int[] roboY = new int[ROBOS];
        static int gridTamanho = 0;
        static int[] grid = new int[2];
        static char[] direcoes = "NLSO".ToCharArray();
        static char direcao = 'N';
        static int indice = 0;

        public static void Main()
        {
            gridTamanho = Convert.ToInt32(ReceberValor("Digite o tamanho do grid: "));
            grid[0] = gridTamanho;
            grid[1] = gridTamanho;
            for (int i = 0; i < ROBOS; i++)
            {
                ReceberPosicao(i);
                ExecutarMovimentos(i, ReceberMovimentos(i));
            }
        }

        static string ReceberValor(string mensagem)
        {
            Console.Write(mensagem);
            return Console.ReadLine();
        }

        static void ReceberPosicao(int i)
        {
            char[] comando = ReceberValor("Digite o input inicial do " + (i + 1) + " robô: ").ToCharArray();
            roboX[i] = Convert.ToInt32(comando[0] + "");
            roboY[i] = Convert.ToInt32(comando[2] + "");
            direcao = comando[(comando.Length - 1)];
        }

        static char[] ReceberMovimentos(int i)
        {
            char[] movimentos = ReceberValor("Digite os comandos do " + (i + 1) + " robô: ").ToCharArray();
            indice = Array.IndexOf(direcoes, direcao);
            return movimentos;
        }

        static void ExecutarMovimentos(int i, char[] movimentos)
        {
            for (int j = 0; j < movimentos.Length; j++)
            {
                if (movimentos[j] == 'E')
                {
                    MudarDirecao(-1);
                    direcao = direcoes[indice];
                }

                if (movimentos[j] == 'D')
                {
                    MudarDirecao(1);
                    direcao = direcoes[indice];
                }

                if (movimentos[j] == 'M')
                {
                    MovimentarRobo(i);
                }
            }

            Console.WriteLine(roboX[i] + " " + roboY[i] + " " + direcao);
            Console.ReadLine();
        }

        static void MudarDirecao(int n)
        {
            if (n + indice >= direcoes.Length)
            {
                indice = 0;
            }

            else if (n + indice < 0)
            {
                 indice = (direcoes.Length) - 1;
            }

            else indice += n;
        }

        static void MovimentarRobo(int i)
        {
            int salvoX = roboX[i];
            int salvoY = roboY[i];
            switch (direcao)
            {
                case 'N':
                    roboY[i]++;
                    break;
                case 'L':
                    roboX[i]++;
                    break;
                case 'S':
                    roboY[i]--;
                    break;
                case 'O':
                    roboX[i]--;
                    break;
            }

            if (roboX[i] > grid[0] || roboX[i] < 0 || roboY[i] > grid[1] || roboY[i] < 0)
            {
                roboX[i] = salvoX;
                roboY[i] = salvoY;
                Console.WriteLine("Comando inválido!");
            }
        }
    }
}