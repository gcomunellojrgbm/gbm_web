namespace Grupo_Beira_Mar_Web_Application.DataModels
{
    public partial class EventoEstadoAcao
    {
        public int Id { get; set; }

        public string Decricao { get; set; }

        public int IdEventoEstado { get; set; }

        public string Cor { get; set; }

        public string CodigoEvento { get; set; }

        virtual public EventoEstado EventoEstado { get; set; }
        
    }
}