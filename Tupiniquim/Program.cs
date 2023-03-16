namespace Tupiniquim
{
    internal class Program
    {

        public static void Main()
        {
            const int ROBOS = 2;
            int[] roboX = new int[ROBOS];
            int[] roboY = new int[ROBOS];
            char[] direcoes = "NLSO".ToCharArray();
            Console.Write("Digite o tamanho do grid: ");
            int gridTamanho = Convert.ToInt32(Console.ReadLine());

            int[] grid = { gridTamanho, gridTamanho };

            for (int i = 0; i < ROBOS; i++)
            {

                Console.Write("Digite o input inicial do " + (i + 1) + " robô: ");
                char[] comando = Console.ReadLine().ToCharArray();
                roboX[i] = Convert.ToInt32(comando[0] + "");
                roboY[i] = Convert.ToInt32(comando[2] + "");
                char direcao = comando[(comando.Length - 1)];
                Console.Write("Digite os comandos do " + (i + 1) + " robô: ");
                char[] movimentos = Console.ReadLine().ToCharArray();
                int indice = 0;
                for (int j = 0; j < direcoes.Length; j++)
                {
                    if (direcoes[j] == direcao)
                    {
                        indice = j;
                        break;
                    }
                }

                for (int j = 0; j < movimentos.Length; j++)
                {
                    if (movimentos[j] == 'E')
                    {
                        indice = MudarDirecao(-1, indice, direcoes);
                        direcao = direcoes[indice];
                    }

                    if (movimentos[j] == 'D')
                    {
                        indice = MudarDirecao(1, indice, direcoes);
                        direcao = direcoes[indice];
                    }

                    if (movimentos[j] == 'M')
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
                        if (roboX[i] > grid[i] || roboX[i] < 0 || roboY[i] > grid[1] || roboY[i] < 0)
                        {
                            roboX[i] = salvoX;
                            roboY[i] = salvoY;
                            Console.WriteLine("Comando inválido!");
                        }
                    }
                }
                Console.WriteLine(roboX[i] + " " + roboY[i] + " " + direcao);
                Console.ReadLine();
            }
        }

        public static int MudarDirecao(int n, int indice, char[] direcoes)
        {
            if (n + indice >= direcoes.Length)
            {
                return 0;
            }

            if (n + indice < 0)
            {
                return (direcoes.Length) - 1;
            }

            return (indice + n);
        }
    }
}