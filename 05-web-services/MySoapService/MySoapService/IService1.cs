﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace MySoapService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IService1
    {
        [OperationContract]
        string GetServiceVersion();

        [OperationContract]
        [OperationBehavior(TransactionScopeRequired = true)]
        int DoubleNumber(int num);

        [OperationContract]
        [FaultContract(typeof(InvalidOperationException))]
        Question GetQuestion(int id);
    }
}
