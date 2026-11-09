namespace SistemasBiblioteca.CapaEntidades
{
    public abstract class Persona
    {
        public int ID { get; set; }
        public string Nombre { get; set; }

        // Método polimorfismo
        public virtual string ObtenerResumen()
        {
            return $"ID: {ID} - Nombre: {Nombre}";
        }
    }
}