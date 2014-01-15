using System;
using System.Linq;
using System.Data;
using System.Data.Linq;
using System.Collections.Generic;

namespace CDH
{
	[Table(Name="dbo.User")]
	class User
	{
		[Column(Name="Id", DBType="int NOT NULL " , CanBeNull=false , IsPrimaryKey=true)]
		public int Id { get; set; }

		[Column(Name="LoginName", DBType="nvarchar(50)"  )]
		public string LoginName { get; set; }

		[Column(Name="DateAdded", DBType="datetime"  )]
		public DateTime DateAdded { get; set; }

		[Column(Name="LastUpdate", DBType="datetime"  )]
		public DateTime LastUpdate { get; set; }

		[Column(Name="NameOnSite", DBType="nvarchar(25)"  )]
		public string NameOnSite { get; set; }

	}
}
