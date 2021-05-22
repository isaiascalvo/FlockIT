using System.Collections.Generic;

namespace ExamenTecnico.Models
{
    public class ProvAPIResponse
    {
        public int Cantidad { get; set; }
        public int Inicio { get; set; }
        public object Parametros { get; set; }
        public List<Provincia> Provincias { get; set; }
        public int Total { get; set; }
    }

    public class Provincia
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public ProvData Centroide { get; set; }
    }

    public class ProvData
    {
        public double Lon { get; set; }
        public double Lat { get; set; }
    }
}
