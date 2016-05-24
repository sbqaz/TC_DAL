using TrafficControl.DAL.RestSharp.Types;

namespace TrafficControl.DAL.RestSharp
{
    /// <summary>
    /// Denne klasse har ansvar for at API kald der omhandler Position
    /// </summary>
    /// <remarks>nedarvet fra TCDATA<list type="Position"></list></remarks>
    public class TCDataPosition : TCData<Position>
    {
        /// <summary>
        /// Sætter Connection klassen til den rigtige api url
        /// </summary>
        public TCDataPosition()
        {
            LIB = new TCDataConnection {ApiDirectory = "api/position/"};
        }

        /// <summary>
        /// post
        /// </summary>
        /// <remarks>
        /// Der må ikke oprettes Position i database fra aplikationer, derfor returner den altid false
        /// </remarks>
        /// <param name="obj"></param>
        /// <returns>False</returns>
        public override bool Post(Position obj)
        {
            /*if (obj == null) return false;
            var response = LIB.TCAPIconnection(Method.POST, obj.Id, obj);
            return response.StatusCode == HttpStatusCode.OK;
            */
            return false;
        }
        /// <summary>
        /// post
        /// </summary>
        /// <remarks>
        /// Der må ikke ændres Position i database fra aplikationer, derfor returner den altid false
        /// </remarks>
        /// <param name="obj"></param>
        /// <returns>False</returns>
        public override bool Update(Position user)
        {
            /*
            if (user == null) return false;
            var response = LIB.TCAPIconnection(Method.PUT, user.Id, user);
            return response.StatusCode == HttpStatusCode.OK;
            */
            return false;
        }
    }
}