using Data.Repositorio;
using Data.Repositorio.IRepositorio;
using Dominio.Bean;
using Dominio.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Controller {
    public class ControllerResultConsumeApiExternal :ControllerBase<ResultConsumeApiExternal, IRepositorioResultConsumeApiExternal, RepositorioResultConsumeApiExternal> {

        /// <summary>
        /// Persiste dados buscados na api externa e salva no banco de dados
        /// </summary>
        /// <param name="listData"></param>
        public void SaveData(IList<ResultConsumeApiExternal> listData) {
            BeginTrasaction();
            
            Delete(x => x.ID != new Guid());

            foreach (var data in listData) {
                Save(data);
            }

            SaveChanges();
            Commit();
        }

        /// <summary>
        /// Busca e calcula a media de casos confirmados e casos de mortes
        /// </summary>
        /// <param name="weeks">intervalo de semanas</param>
        /// <returns></returns>
        public List<AverageBean> GetAverages(int weeks) {
            int dayOfWeek = 7;
            DateTime from = DateTime.Now.Date.AddDays(-(weeks * dayOfWeek));
            DateTime to = DateTime.Now.Date;
            IList<ResultConsumeApiExternal> dataDataBase = Get(x => x.Date >= from && x.Date <= to).OrderByDescending(x => x.Date).ToList();
            List<AverageBean> result = new List<AverageBean>();

            AverageBean averageBean = null;

            ResultConsumeApiExternal resultConsumeApiExternalStart = null;
            ResultConsumeApiExternal resultConsumeApiExternalFinal = null;
            for (int i = 1; i <= dataDataBase.Count; i++) {

                if (i % dayOfWeek == 0 || i == dataDataBase.Count) {
                    resultConsumeApiExternalStart = dataDataBase[i - 1];
                    resultConsumeApiExternalFinal = dataDataBase[i - dayOfWeek];

                    averageBean = new AverageBean();
                    result.Add(averageBean);
                    averageBean.Week = $"Semana: {resultConsumeApiExternalFinal.Date.ToString("dd/MM/yyyy")} - {resultConsumeApiExternalStart.Date.ToString("dd/MM/yyyy")} ";
                    averageBean.AverageConfirmed = Convert.ToInt32((resultConsumeApiExternalFinal.Confirmed - resultConsumeApiExternalStart.Confirmed) / dayOfWeek);
                    averageBean.AverageDeaths = Convert.ToInt32((resultConsumeApiExternalFinal.Deaths - resultConsumeApiExternalStart.Deaths) / dayOfWeek);
                }
            }


            return result;
        }
    }
}

