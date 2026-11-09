namespace SistemasBiblioteca.CapaEntidades
{
    public class Usuario : Persona
    {
        public string Documento { get; set; }
        public string Correo { get; set; }

        // Polimorfismo en acción
        public override string ObtenerResumen()
        {
            return $"Usuario: {Nombre} (Doc: {Documento}) - Contacto: {Correo}";
        }
    }
}