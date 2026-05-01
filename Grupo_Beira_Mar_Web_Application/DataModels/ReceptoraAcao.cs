namespace Grupo_Beira_Mar_Web_Application.DataModels
{
    public partial class ReceptoraAcao
    {
        public int Id { get; set; }

        public int IdEventoEstadoAcao { get; set; }

        public int IdReceptora { get; set; }

        virtual public EventoEstadoAcao EventoEstadoAcao { get; set; }

        virtual public Receptora Receptora { get; set; }

        public bool GeraAtendimento { get; set; }

        public bool DisparaSom { get; set; }
    }
}