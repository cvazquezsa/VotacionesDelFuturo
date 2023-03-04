namespace VotacionesDelFuturo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var votacion = new Votacion();
            
            int noCandidatos;
            int noVotantes;

            Console.WriteLine("Bienvenido a fraude electoral");
            Console.WriteLine("Ingrese el numero de candidatos:");



            while (!Int32.TryParse(Console.ReadLine(), out noCandidatos) || noCandidatos < 1)
            {
                Console.WriteLine("No mame ingrese un numero valido mayor que 1");
                Console.WriteLine("Ingrese el numero de candidatos:");
            }

            Console.WriteLine("Ingrese el numero de votantes:");
            while (!Int32.TryParse(Console.ReadLine(), out noVotantes) || noVotantes < 0)
            {
                Console.WriteLine("No mame ingrese un numero valido mayor que 0");
                Console.WriteLine("Ingrese el numero de votantes:");
            }

            votacion.InicializarVotacion(noCandidatos, noVotantes);

            Console.WriteLine("Que comiencen los juegos del hambre!!!!");

            while (!votacion.VotacionCompleta())
            {
                int indiceCandidato;
                Console.WriteLine($"Emita su voto indicando el indice del candidato entre 0 y {votacion.getIndiceUltimoCandidato()}");
                while (!Int32.TryParse(Console.ReadLine(), out indiceCandidato) || !votacion.ValidarCandidato(indiceCandidato))
                {
                    Console.WriteLine("Pongase chingon debe indicar un indice de candidato valido");
                    Console.WriteLine($"Emita su voto indicando el indice del candidato entre 0 y {votacion.getIndiceUltimoCandidato()}");
                }

                votacion.EmitirVoto(indiceCandidato);
            }

            string resultados = votacion.MostrarResultados();
            Console.WriteLine(resultados);
            Console.ReadLine();

        }
    }
}