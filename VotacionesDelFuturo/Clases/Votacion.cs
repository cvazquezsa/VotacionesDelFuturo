namespace VotacionesDelFuturo
{
using System.Linq;
    internal class Votacion
    {
       List<Candidato> candidatos= new();
        public int totalVotantes { get; set; }
        public int totalCandidatos { get; set; }
        public Votacion()
        {
            CreateCandidatos();
            CreateVotantes();
            TakeVotos();
            ShowVotosDetalle();
            ShowGanador();
            
        }
       
        public bool ValidateIntPositive(string value,ref int variableToSave, int minValue=1, int maxValue= int.MaxValue){
            
            if(Int32.TryParse(value,out variableToSave) && variableToSave >= minValue &&  variableToSave <= maxValue)
                    return true;
            else
            {
                Console.Clear();
                if(maxValue==int.MaxValue)
                    Console.WriteLine($"Debe ingresar un numero corrrecto, numero entero mayor a {minValue-1}");
                else
                    Console.WriteLine($"Debe ingresar un numero corrrecto, numero entero entre {minValue} y  {maxValue}");
               return false;
            }
        }
        
        public void CreateCandidatos()
        {
            int total=0;
            do
                Console.WriteLine("Ingrese el numero de candidatos:");
            while(!ValidateIntPositive(Console.ReadLine(),ref total,2));

            totalCandidatos=total;

            for (int i = 1; i <= totalCandidatos; i++)
                candidatos.Add(new Candidato{Id=i});
           
        }

        public void CreateVotantes()
        {
            int total=0;
            do
                Console.WriteLine("Ingrese el numero de votantes:");
            while(!ValidateIntPositive(Console.ReadLine(),ref total,2));

            totalVotantes=total;
           
        }

        public void TakeVotos(){
            for(int v=0; v < totalVotantes; v++)
                SaveVoto(v);
        }
         public bool ValidateCandidato(int numberCandidato)
        {
            return candidatos.Exists(c => c.Id == numberCandidato);
        }

        public void SaveVoto(int IdVotante)
        {
            int votoCandidato=0;
            Console.Clear();
            do
                Console.WriteLine($"Votante  {IdVotante+1},Ingrese su voto:");
            while(!ValidateIntPositive(Console.ReadLine(),ref votoCandidato,1,totalCandidatos));

            candidatos.First(c => c.Id == votoCandidato).votos++;
        }
       
       public void ShowVotosDetalle()
        {
            Console.Clear();
            candidatos.OrderByDescending(c=> c.votos).ToList().ForEach(c=> Console.WriteLine($"El candidato {c.Id} tuvo: {c.votos} votos"));
        }

        public void ShowGanador()
        {
            int votosMax=candidatos.Max(c=>c.votos);
            if(candidatos.Count(c=> c.votos==votosMax) == 1)
                Console.WriteLine($"El candidato ganador es el: {candidatos.First(c=> c.votos== votosMax).Id}");
            else
                Console.WriteLine($"Existen candidatos con el mismo numero de votos maximos y no se puede dar un ganador");
            
        }
    }
    
}