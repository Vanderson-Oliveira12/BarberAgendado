namespace BarberAgendado.Domain.Models
{
    public class Customer : Entity
    {
        public string Name { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
    }
}
