
using DocumentFormat.OpenXml.Wordprocessing;
using Grupo_Beira_Mar_Web_Application.Data;
using Grupo_Beira_Mar_Web_Application.Data.Migrations;
using Grupo_Beira_Mar_Web_Application.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Grupo_Beira_Mar_Web_Application.Controllers
{
    public class EventosFKSController : Controller
    {
        private readonly ApplicationDbContext _dbContext;

        public EventosFKSController(ApplicationDbContext context)
        {
            _dbContext = context;
        }

        [HttpGet]
        [Route("/eventos-fks/{id_evento_estado}/{descricao}")]
        public async Task<IActionResult> Index(int id_evento_estado, string descricao)
        {
            var viewModel = new EventosFKSViewModel();
            viewModel.IdEventoEstado = id_evento_estado;
            viewModel.Descricao = descricao;
            
            viewModel.Eventos = await ConsultarEventosAsync(id_evento_estado);

            return View(viewModel);
        }

        private async Task<List<EventosFKSItemViewModel>> ConsultarEventosAsync(int idEventoEstado)
        {
            StringBuilder sql = new StringBuilder();

            sql.Append(@$"
                Declare @id_evento_estado int = {idEventoEstado}

                Select
                    E.id_evento_estado as IdEventoEstado,
                    EEA.decricao as Descricao,
                    C.codigo as Codigo,
                    C.nome as Nome,
                    E.data_hora as DataHora
                From evento E
                Inner Join evento_estado_acao EEA
                    On EEA.cod_evento = E.evento
                Inner Join cliente C
                    On C.id_cliente = E.IdCliente
                Where E.id_receptora = 2
                    and E.id_evento_estado = @id_evento_estado
                    and Not Exists(
                        Select Top 1 1
                        From evento E2
                        Where E2.IdCliente = E.IdCliente
                            and E2.id_evento_estado = @id_evento_estado
                            and E2.data_hora > E.data_hora
                    )
                Order By EEA.cor desc, E.data_hora
            ");

            var query = _dbContext.Database.SqlQueryRaw<EventosFKSItemViewModel>(sql.ToString());
            return await query.ToListAsync();
        }
    }
}


