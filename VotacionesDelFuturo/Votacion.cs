using System.Text;

namespace VotacionesDelFuturo
{
    internal class Votacion
    {
        private List<Candidato> Candidatos= new List<Candidato>();
        private int Votantes;

        public void InicializarVotacion(int noCandidatos, int noVotantes)
        {
            GenerarCandidatos(noCandidatos);
            Votantes = noVotantes;
        }

        private void GenerarCandidatos(int noCandidatos)
        {
            for (int i = 0; i < noCandidatos; i++)
            {
                Candidatos.Add(new Candidato() { Indice = i });
            }
        }

        public bool ValidarCandidato(int indiceCandidato)
        {
            return Candidatos.Where(x => x.Indice == indiceCandidato).Any();
        }

        public void EmitirVoto(int indiceCandidato)
        {
            var candidato = Candidatos.Find(x => x.Indice == indiceCandidato);
            candidato.Votos++;
        }

        public bool VotacionCompleta()
        {
            return Candidatos.Select(x => x.Votos).Sum() == Votantes;
        }

        public int getIndiceUltimoCandidato()
        {
            return Candidatos.Count() - 1;
        }

        public string MostrarResultados()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Resultados!");
            sb.AppendLine();
            foreach (var candidato in Candidatos.OrderByDescending(x => x.Votos).ToList())
            {
                sb.AppendLine($"Candidato: {candidato.Indice}, Total de Votos:  {candidato.Votos}");
            }

            return sb.ToString();
        }
    }
}
