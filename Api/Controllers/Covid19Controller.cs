using Controller;
using Dominio.Bean;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;

namespace Api.Controllers {

    [Route("api/[controller]")]
    [ApiController]
    public class Covid19Controller :ControllerBase {

        /// <summary>
        /// Lista as medias de casos confirmados e casos de mortes
        /// </summary>
        /// <param name="weeks"></param>
        /// <returns></returns>
        [HttpGet("listAvarage/{weeks}")]
        [Authorize]
        public virtual ActionResult<IList<AverageBean>> ListAvarage(int weeks) {

            try {
                ControllerResultConsumeApiExternal controllerResultConsumeApiExternal = new ControllerResultConsumeApiExternal();
                return controllerResultConsumeApiExternal.GetAverages(weeks);

            } catch (Exception e) {
                return new ObjectResult(null) { StatusCode = (int)HttpStatusCode.InternalServerError, Value = e.Message };
            }
        }

        /// <summary>
        /// Persiste dados no banco de dados
        /// </summary>
        /// <returns></returns>
        [HttpGet("saveUpdateData")]
        [Authorize]
        public virtual ActionResult SaveUpdateData() {
            try {
                GetAllDataExternalAndSaveUpdateData(6);
                return Ok();

            } catch (Exception e) {
                return new ObjectResult(null) { StatusCode = (int)HttpStatusCode.InternalServerError, Value = "Falha ao salvar informações!" };
                //return new ObjectResult(null) { StatusCode = (int)HttpStatusCode.InternalServerError, Value = e.Message };
            }
        }


        /// <summary>
        /// Busca dados da api externa e salva os dados no banco de dados
        /// </summary>
        /// <param name="retroactMonth">quantidade de meses a buscar na api externa</param>
        private void GetAllDataExternalAndSaveUpdateData(int retroactMonth) {
            DateTime from = DateTime.Now.AddMonths(-retroactMonth);
            DateTime to = DateTime.Now;
            Consume.Consume consume = new Consume.Consume();
            var data = consume.GetAllDataByCountry(from, to, "Brazil");
            ControllerResultConsumeApiExternal controllerResultConsumeApiExternal = new ControllerResultConsumeApiExternal();
            controllerResultConsumeApiExternal.SaveData(data.ToList().ToList());
        }

    }
}
