using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace MathService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IMathService
    {

        [OperationContract]
        double Add(double a, double b);

        [OperationContract]
        double Divide(double a, double b);

        [OperationContract]
        double Multiply(double a, double b);

        [OperationContract]
        double Subtract(double a, double b);
    }


    
}
