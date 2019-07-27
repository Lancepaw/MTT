//-----------------------------------------------------------------------
// <copyright file="ITestWCFService.cs" company="No Company">
//     Company copyright tag.
// </copyright>
//-----------------------------------------------------------------------

namespace TestWcfService
{
    using System.Collections.Generic;
    using System.ServiceModel;
    using System.ServiceModel.Web;
    
    /// <summary>
    /// Интерфейс с выборкой последних N чеков.
    /// </summary>
    [ServiceContract]
    public interface ITestWCFService
    {
        #region Insert Method;

        /// <summary>
        /// Метод, отвечающие за добавление чека в БД.
        /// </summary>
        /// <param name="cheques">Чеки для внесения в БД.</param>
        [OperationContract]
        void InsertCheques(Cheque cheques);
        #endregion
        
        #region Select Method

        /// <summary>
        /// Метод, выбирающий из БД последние N чеков.
        /// </summary>
        /// <param name="n">n</param>
        /// <returns>Последние N чеков</returns>
        [OperationContract]        
        [WebInvoke(Method = "GET", UriTemplate = "getN?n={n}")]
        List<ExportCheque> GetN(int n);
        #endregion
    }
}
