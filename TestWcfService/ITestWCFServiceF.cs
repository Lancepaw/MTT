//-----------------------------------------------------------------------
// <copyright file="ITestWCFServiceF.cs" company="No Company">
//     Company copyright tag.
// </copyright>
//-----------------------------------------------------------------------

namespace TestWcfService
{
    using System.Collections.Generic;
    using System.ServiceModel;
    using System.ServiceModel.Web;

    /// <summary>
    /// Интерфейс с выборкой первых N чеков.
    /// </summary>
    [ServiceContract]
    public interface ITestWCFServiceF
    {
        #region Insert Method;

        /// <summary>
        /// Метод, отвечающие за добавление чека в БД.
        /// </summary>
        /// <param name="cheques">Чеки для внесения в БД.</param>
        [OperationContract]
        void InsertCheques(Cheque cheques);

        #endregion
        
        #region SelectMethod2

        /// <summary>
        /// Метод, выбирающий из БД первые N чеков.
        /// </summary>
        /// <param name="n">n</param>
        /// <returns>Первые N чеков</returns>
        [OperationContract]        
        [WebInvoke(Method = "GET", UriTemplate = "getN?n={n}")]
        List<ExportCheque> GetNF(int n);
        #endregion   
    }
}
