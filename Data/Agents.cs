using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Malshinon.Data
{
    internal class Agent
    {

        public int id { get; set; }
        public string name { get; set; }
        public string? codeName {  get; set; }
        protected List<Reporter> Reporters { get; set; } = new ();

        public Agent(int id, string name)
        {
            this.id = id;
            this.name = name;
        }


        public Agent() { }


        


        public void AddReporter(Reporter reporter)
        {
            if (reporter != null && !Reporters.Any(r => r.CodeName == reporter.CodeName))
            {
                Reporters.Add(reporter);
            }
            else
            {
                throw new ArgumentException("Reporter is null or already exists.");
            }
        }


        public static Agent getAgent(int? agentId, string? name)
        {
            

            return new Agent();
        }




    }
}
