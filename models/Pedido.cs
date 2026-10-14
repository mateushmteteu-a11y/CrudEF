namespace CrudEF.Models;

public class Pedido
{
    public int Id { get; set; }
    public DateTime Data { get; set; }
    public decimal Valor { get; set; }
    public int ClienteId { get; set; }
    public Cliente Cliente { get; set; } = null;
}