using System.Net;
using RestSharp;
using TrafficControl.DAL.RestSharp.Types;

namespace TrafficControl.DAL.RestSharp
{
    /// <summary>
    /// Denne klasse har ansvar for at API kald der omhandler Installation
    /// </summary>
    /// <remarks>nedarvet fra TCDATA<list type="Installation"></list></remarks>
    public class TCDataInstallation : TCData<Installation>
    {
        /// <summary>
        /// Sætter Connection klassen til den rigtige api 
        /// </summary>
        public TCDataInstallation()
        {
            LIB = new TCDataConnection {ApiDirectory = "api/Installation"};
        }

        /// <summary>
        /// post
        /// </summary>
        /// <remarks>
        /// Der må ikke oprettes Installation i database fra aplikationer, derfor returner den altid false
        /// </remarks>
        /// <param name="obj"></param>
        /// <returns>False</returns>
        public override bool Post(Installation obj)
        {
            return false;
        }
        /// <summary>
        /// post
        /// </summary>
        /// <remarks>
        /// Der må ikke ændres Installation i database fra aplikationer, derfor returner den altid false
        /// </remarks>
        /// <param name="obj"></param>
        /// <returns>False</returns>
        public override bool Update(Installation user)
        {
            return false;
        }
    }
}