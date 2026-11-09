namespace SistemasBiblioteca.CapaEntidades
{
    public class Autor : Persona
    {
        public string Apellido { get; set; }

        // Polimorfismo en acción
        public override string ObtenerResumen()
        {
            return $"Autor: {Nombre} {Apellido}";
        }
    }
}