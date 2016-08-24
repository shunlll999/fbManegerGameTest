using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace StatelessGame.Controllers
{

    public class ValuesController : ApiController
    {
       
        // GET api/values 
        public IEnumerable<string> Get()
        {
            return new string[] { "player1", "player2" };
        }

        // GET api/values/message
        public object Get(string msg)
        {
            object dataSending = null;

            switch (msg.ToUpper())
            {
                case "BONUS":
                    dataSending = (object)GetBonus();
                    break;
                case "PHYSIO":
                    dataSending = (object)GetPhysio();
                    break;
                case "QUICK":
                    dataSending = (object)GetQuickTraning();
                    break;
                case "REPORTS":
                    dataSending = (object)GetReports();
                    break;
            }
            
            return dataSending;
        }

        // POST api/values 
        public void Post([FromBody]string value)
        {

        }

        // PUT api/values/5 
        public void Put(string msg, [FromBody]string value)
        {

        }

        // DELETE api/values/5 
        public void Delete(string msg)
        {
        }

        private BonusData GetBonus()
        {
            ResultData[] result = new ResultData[5];
            for( int i = 0; i < result.Length; i++)
            {
                result.SetValue(new ResultData()
                {

                    gameRoom = "GameRoom"+(i+1),
                    maxScore = 150* (i + 1),
                    request = "Request_Bonus"

                }, i);
            }
            Random rnd = new Random();
            int random = rnd.Next(100, 1000);
            BonusData bonus = new BonusData()
            {
                userid = random * 123,
                username = "Wachiii"+ random*654,
                bonusid = random * 456,
                bonuscalculate = 5,
                bonusEachRoom = result
            };

            return bonus;
        }

        private PhysioData[] GetPhysio()
        {

            PhysioData[] physios = new PhysioData[10];
            for( int i = 0; i < physios.Length; i++)
            {
                physios.SetValue(new PhysioData()
                {
                    place = "London"+i,
                    country = "England"+i,
                    code = "LDEN"+i
                }, i);
            }


            return physios;
        }

        private QuickTraning GetQuickTraning()
        {

            QuickTraning quick = new QuickTraning()
            {
                status = "ON",
                passed = true,
                message = "Congreatulation!"
            };

            return quick;
        }

        private Reports GetReports()
        {

            Reports report = new Reports()
            {
                bonus = GetBonus(),
                physio = GetPhysio(),
                quick = GetQuickTraning()
            };
            return report;
        }
        
    }

}
