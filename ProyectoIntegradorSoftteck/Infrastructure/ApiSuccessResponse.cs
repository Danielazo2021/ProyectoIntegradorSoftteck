namespace AlkemyUmsa.Infrastructure
{
    /// <summary>
    /// Representa una respuesta HTTP exitosa que contiene un código de estado y datos.
    /// </summary>
    public class ApiSuccessResponse
    {
        public int Status { get; set; }
        public object? Data { get; set; }
    }
}
