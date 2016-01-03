using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProductService.Models
{
    public class InMemoryContext
    {
        private static InMemoryContext instance = null;
        public static InMemoryContext Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new InMemoryContext();
                }
                return instance;
            }
        }

        public List<Team> Teams { get; set; }
        public List<Team> Members { get; set; }

        private InMemoryContext()
        {
            this.Reset();
            this.Initialize();
        }

        public void Reset()
        {
            this.Teams = new List<Team>();
        }
        public void Initialize()
        {
            var uberMembers = new List<Member> 
            {
                new Member{ Id=1, Name="Rakesh", Designation="PSE", WorkLevel="WL1"},
                new Member{ Id=2, Name="Amar", Designation="TE", WorkLevel="WL2"},
                new Member{ Id=3, Name="Mahesh", Designation="PSE", WorkLevel="WL1"},
                new Member{ Id=4, Name="Chaitra", Designation="SSE", WorkLevel="WL1"},
                new Member{ Id=5, Name="Ganesh", Designation="SSE", WorkLevel="WL1"}
            };
            var genesisMembers = new List<Member> 
            {
                new Member{ Id=6, Name="Arun", Designation="SSE", WorkLevel="WL1"},
                new Member{ Id=7, Name="Shyam", Designation="TE", WorkLevel="WL2"},
                new Member{ Id=8, Name="Satya", Designation="PSE", WorkLevel="WL1"}
            };
            this.Teams.AddRange(new List<Team> 
            {
                new Team{Id=1, Name="Uber", Members=uberMembers},
                new Team{Id=2, Name="Genesis", Members= genesisMembers}
            });

        }
    }
}