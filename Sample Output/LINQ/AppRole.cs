using System;
using System.Linq;
using System.Data;
using System.Data.Linq;
using System.Collections.Generic;

namespace CDH
{
	[Table(Name="dbo.AppRole")]
	class AppRole
	{
		[Column(Name="Id", DBType="int NOT NULL " , CanBeNull=false , IsPrimaryKey=true)]
		public int Id { get; set; }

		[Column(Name="Name", DBType="nvarchar(10)"  )]
		public string Name { get; set; }

		[Column(Name="Description", DBType="nvarchar(50)"  )]
		public string Description { get; set; }

	}
}
